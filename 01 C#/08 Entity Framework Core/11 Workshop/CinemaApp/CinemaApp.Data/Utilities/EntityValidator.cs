using System.ComponentModel.DataAnnotations;

using CinemaApp.Data.Utilities.Interfaces;

namespace CinemaApp.Data.Utilities
{
    public class EntityValidator : IValidator
    {
        private ICollection<string> errorMessages;

        public EntityValidator()
        {
            this.errorMessages = new List<string>();
        }

        // Encapsulate the ErrorMessage collection as IReadOnlyCollection<T>
        public IReadOnlyCollection<string> ErrorMessages
            => this.errorMessages.ToList().AsReadOnly();

        public bool IsValid(object dto)
        {
            // Clean the Error Messages left from previous validation
            this.errorMessages = new List<string>();

            // Build ValidationContext and initialize collection for the Validation Results
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            // Validate the passed object
            bool isValid = Validator
                .TryValidateObject(dto, validationContext, validationResults, true);

            // Iterate through Validation Results
            foreach (var result in validationResults)
            {
                // Check if the current ValidationResult holds an ErrorMessage
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    // Add the ErrorMessage to the field, containing the current validation Error Messages
                    this.errorMessages.Add(result.ErrorMessage);
                }
            }

            // Return whether the validation was successful
            return isValid;
        }
    }
}
