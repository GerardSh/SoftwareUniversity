using System.Text;

using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Data.Utilities.Interfaces;
using static CinemaApp.Common.OutputMessages.ErrorMessages;

using Microsoft.Extensions.Logging;

namespace CinemaApp.Data.Seeding
{
    public abstract class BaseSeeder<T> : IBaseSeeder<T>
    {
        private readonly IValidator entityValidator;
        private readonly ILogger<T> logger;

        protected BaseSeeder(IValidator entityValidator, ILogger<T> logger)
        {
            this.FilePath = string.Empty;

            this.entityValidator = entityValidator;
            this.logger = logger;
        }

        public virtual string FilePath { get; }

        public IValidator EntityValidator
            => this.entityValidator;

        public ILogger<T> Logger
            => this.logger;

        public string BuildEntityValidatorWarningMessage(string entityName)
        {
            // Prepare log message with error messages from the validation
            StringBuilder logMessage = new StringBuilder();
            logMessage
            .AppendLine(string.Format(EntityImportError, entityName))
                .AppendLine(string.Join(Environment.NewLine, entityValidator.ErrorMessages));

            // Log the message
            return logMessage.ToString().TrimEnd();
        }
    }
}
