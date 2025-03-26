namespace CinemaApp.Data.Utilities.Interfaces
{
    public interface IValidator
    {
        IReadOnlyCollection<string> ErrorMessages { get; }

        bool IsValid(object obj);
    }
}
