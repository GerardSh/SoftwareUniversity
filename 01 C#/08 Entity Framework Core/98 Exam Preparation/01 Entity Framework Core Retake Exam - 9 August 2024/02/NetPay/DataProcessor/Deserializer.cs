using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            var output = new StringBuilder();

            var householdDtos = XmlHelper.Deserialize<ImportHouseholdDto[]>(xmlString, "Households");

            if (householdDtos == null || householdDtos.Count() == 0) return string.Empty;

            var validHouseholds = new List<Household>();

            var houseHoldsInDb = context.Households
                .Select(h => new
                {
                    h.ContactPerson,
                    h.Email,
                    h.PhoneNumber
                })
                .ToList();

            foreach (var householdDto in householdDtos)
            {
                if (!IsValid(householdDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (validHouseholds.Any(h => h.ContactPerson == householdDto.ContactPerson
                || h.Email == householdDto.Email
                || h.PhoneNumber == householdDto.Phone)
                || houseHoldsInDb.Any(h => h.ContactPerson == householdDto.ContactPerson
                || h.Email == householdDto.Email
                || h.PhoneNumber == householdDto.Phone))
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var household = new Household()
                {
                    ContactPerson = householdDto.ContactPerson,
                    Email = householdDto.Email,
                    PhoneNumber = householdDto.Phone
                };

                validHouseholds.Add(household);
                output.AppendLine(string.Format(SuccessfullyImportedHousehold, household.ContactPerson));
            }

            context.Households.AddRange(validHouseholds);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            var output = new StringBuilder();

            var expenseDtos = JsonConvert.DeserializeObject<ImportExpenseDto[]>(jsonString);

            if (expenseDtos == null || expenseDtos.Count() == 0) return string.Empty;

            var validExpenses = new List<Expense>();

            var householdsInDb = context.Households
                .Select(h => h.Id)
                .ToHashSet();

            var servicesInDb = context.Services
                .Select(s => s.Id)
                .ToHashSet();

            foreach (var expenseDto in expenseDtos)
            {
                bool isDueDateValid = DateTime.TryParseExact(expenseDto.DueDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);
                bool isPaymentStatusValid = Enum.TryParse(expenseDto.PaymentStatus, out PaymentStatus paymentStatus)
                    && Enum.IsDefined(typeof(PaymentStatus), paymentStatus);

                if (!IsValid(expenseDto) || !isPaymentStatusValid || !isDueDateValid)
                {
                    output.AppendLine(ErrorMessage); continue;
                }

                if (!householdsInDb.Contains(expenseDto.HouseholdId) || !servicesInDb.Contains(expenseDto.ServiceId))
                {
                    output.AppendLine(ErrorMessage); continue;
                }

                var expense = new Expense()
                {
                    ExpenseName = expenseDto.ExpenseName,
                    Amount = expenseDto.Amount,
                    DueDate = dueDate,
                    PaymentStatus = paymentStatus,
                    HouseholdId = expenseDto.HouseholdId,
                    ServiceId = expenseDto.ServiceId,
                };

                validExpenses.Add(expense);
                output.AppendLine(string.Format(SuccessfullyImportedExpense,
                    expense.ExpenseName, expense.Amount.ToString("f2")));
            }

            context.Expenses.AddRange(validExpenses);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
