using Microsoft.EntityFrameworkCore.Storage;
using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
            StringBuilder output = new StringBuilder();

            ImportHouseholdDto[]? houseDtos = XmlHelper.Deserialize<ImportHouseholdDto[]>(xmlString, "Households");

            if (houseDtos != null && houseDtos.Length > 0)
            {
                ICollection<Household> validHouseholds = new List<Household>();

                foreach (var houseDto in houseDtos)
                {
                    if (!IsValid(houseDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isAlreadyImportHousehold = context.Households
                        .Any(h => h.ContactPerson == houseDto.ContactPerson
                        || h.Email == houseDto.Email
                        || h.PhoneNumber == houseDto.Phone);

                    bool isToBeImported = validHouseholds
                        .Any(h => h.ContactPerson == houseDto.ContactPerson
                        || h.Email == houseDto.Email
                        || h.PhoneNumber == houseDto.Phone);

                    if (isAlreadyImportHousehold || isToBeImported)
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household household = new Household()
                    {
                        ContactPerson = houseDto.ContactPerson,
                        Email = houseDto.Email,
                        PhoneNumber = houseDto.Phone
                    };

                    validHouseholds.Add(household);

                    string successMessage = string.Format(SuccessfullyImportedHousehold, houseDto.ContactPerson);
                    output.AppendLine(successMessage);
                }

                context.Households.AddRange(validHouseholds);
               context.SaveChanges();
            }

            return output.ToString().Trim();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ImportExpenseDto[]? expenseDtos = JsonConvert.DeserializeObject<ImportExpenseDto[]>(jsonString);

            var validExpenses = new List<Expense>();

            if (expenseDtos != null && expenseDtos.Length > 0)
            {
                foreach (var expenseDto in expenseDtos)
                {
                    if (!IsValid(expenseDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool householdExists = context.Households
                        .Any(h => h.Id == expenseDto.HouseholdId);

                    bool expenseExists = context.Services
                        .Any(s => s.Id == expenseDto.ServiceId);

                    bool isDueDateValid = DateTime.TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, out DateTime dueDate);

                    bool isPaymentStatusValid = Enum.TryParse(expenseDto.PaymentStatus, out PaymentStatus paymentStatus);

                    if (!householdExists || !expenseExists || !isDueDateValid || !isPaymentStatusValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
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

                    output.AppendLine(string.Format(SuccessfullyImportedExpense, expenseDto.ExpenseName, expenseDto.Amount.ToString("f2")));
                }

                context.Expenses.AddRange(validExpenses);
                context.SaveChanges();
            }
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
