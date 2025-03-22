using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

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

            if (customerDtos != null && customerDtos.Length > 0)
            {
                var customersInDb = context.Customers;
                var customersToBeAdded = new List<Customer>();

                foreach (var customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (customersInDb.Any(c => c.FullName == customerDto.FullName || c.PhoneNumber == customerDto.PhoneNumber || c.Email == customerDto.Email) ||
                        customersToBeAdded.Any(c => c.FullName == customerDto.FullName || c.PhoneNumber == customerDto.PhoneNumber || c.Email == customerDto.Email))
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    var customer = new Customer()
                    {
                        FullName = customerDto.FullName,
                        Email = customerDto.Email,
                        PhoneNumber = customerDto.PhoneNumber,
                    };

                    customersToBeAdded.Add(customer);

                    output.AppendLine(string.Format(SuccessfullyImportedCustomer, customerDto.FullName));
                }

                context.Customers.AddRange(customersToBeAdded);
                context.SaveChanges();
            }

            return output.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ImportBookingDto[]? bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            var validBookings = new List<Booking>();

            if (bookingDtos != null && bookingDtos.Length > 0)
            {
                var customers = context.Customers
                    .Select(c => new
                    {
                        c.FullName,
                        c.Id
                    });

                var tourPackages = context.TourPackages
                    .Select(c => new
                    {
                        c.PackageName,
                        c.Id
                    });

                foreach (var bookingDto in bookingDtos)
                {
                    bool isDateValid = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out DateTime validDate);

                    if (!IsValid(bookingDto) || !isDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var customer = customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                    var tourPackage = tourPackages.FirstOrDefault(t => t.PackageName == bookingDto.TourPackageName);

                    if (customer == null || tourPackage == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var booking = new Booking()
                    {
                        BookingDate = validDate,
                        CustomerId = customer.Id,
                        TourPackageId = tourPackage.Id
                    };

                    validBookings.Add(booking);
                    output.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, validDate.ToString("yyyy-MM-dd")));
                }

                context.Bookings.AddRange(validBookings);
                context.SaveChanges();
            }

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
