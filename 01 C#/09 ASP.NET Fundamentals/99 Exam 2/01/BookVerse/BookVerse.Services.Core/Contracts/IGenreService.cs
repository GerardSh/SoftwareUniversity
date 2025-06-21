using BookVerse.ViewModels.Book;

namespace BookVerse.Services.Core.Contracts
{
    public interface IGenreService
    {
        public Task<IEnumerable<BookCreateGenreDropdownModel>> GetGenresDropdownAsync();
    }
}
