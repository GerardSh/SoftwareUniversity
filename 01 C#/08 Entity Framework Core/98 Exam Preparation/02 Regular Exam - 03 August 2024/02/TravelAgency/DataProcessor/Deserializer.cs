using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var output = new StringBuilder();

            var customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, "Customers");

            if (customerDtos == null || customerDtos.Count() == 0) return string.Empty;

            var validCustomers = new List<Customer>();

            var customersInDb = context.Customers
                .Select(c=> new
                {
                    c.FullName,
                    c.Email,
                    c.PhoneNumber
                })
                .ToList();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (customersInDb.Any(c => c.FullName == customerDto.FullName
                || c.Email == customerDto.Email
                || c.PhoneNumber == customerDto.PhoneNumber)
                || validCustomers.Any(c => c.FullName == customerDto.FullName
                || c.Email == customerDto.Email
                || c.PhoneNumber == customerDto.PhoneNumber))
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    PhoneNumber = customerDto.PhoneNumber,
                    Email = customerDto.Email,              
                };

                validCustomers.Add(customer);
                output.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var output = new StringBuilder();

            var bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            if (bookingDtos == null || bookingDtos.Count() == 0) return string.Empty;

            var validBookings = new List<Booking>();

            foreach (var bookingDto in bookingDtos)
            {
                bool isDateValid = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!IsValid(bookingDto) || !isDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(t => t.PackageName == bookingDto.TourPackageName);

                if (customer == null || tourPackage == null) continue;

                var booking = new Booking()
                {
                    Customer = customer,
                    TourPackage = tourPackage,
                    BookingDate = date,
                };

                validBookings.Add(booking);
                output.AppendLine(string.Format(SuccessfullyImportedBooking,
                    booking.TourPackage.PackageName, booking.BookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(validBookings);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
