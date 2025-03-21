using NetPay.Data;
using NetPay.Data.Models;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using System.ComponentModel.DataAnnotations;
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

                    if (isAlreadyImportHousehold)
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
               // context.SaveChanges();
            }

            return output.ToString().Trim();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            throw new NotImplementedException();
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
