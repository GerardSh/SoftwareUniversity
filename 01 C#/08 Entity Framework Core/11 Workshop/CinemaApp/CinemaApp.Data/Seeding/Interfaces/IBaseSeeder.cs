using CinemaApp.Data.Utilities.Interfaces;

using Microsoft.Extensions.Logging;

namespace CinemaApp.Data.Seeding.Interfaces
{
    public interface IBaseSeeder<T>
    {
        public string FilePath { get; }

        public IValidator EntityValidator { get; }

        public ILogger<T> Logger { get; }

        public string BuildEntityValidatorWarningMessage(string entityName);
    }
}
