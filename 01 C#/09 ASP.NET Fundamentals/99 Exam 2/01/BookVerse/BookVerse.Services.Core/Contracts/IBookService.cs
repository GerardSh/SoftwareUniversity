using BookVerse.ViewModels.Book;

namespace BookVerse.Services.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookIndexViewModel>> GetAllBooksAsync(string? userId);

        Task<bool> CreateBookAsync(string userId, BookCreateInputModel inputModel);

        Task<BookDetailsViewModel?> GetBookDetailsAsync(int? bookId, string? userId);

        Task<BookEditInputModel> GetBookForEditingAsync(string userId, int? bookId);

        Task<bool> PersistUpdatedBookAsync(string userId, BookEditInputModel inputModel);

        Task<string?> GetPublisherIdAsync(int bookId);

        Task<BookDeleteViewModel?> GetBookForDeletingAsync(string userId, int? bookId);

        Task<bool> SoftDeleteBookAsync(string userId, BookDeleteViewModel inputModel);

        Task<IEnumerable<FavoriteBookViewModel>?> GetUserFavoriteBooksAsync(string userId);

        Task<bool> AddBookToUserFavoritesListAsync(string userId, int bookId);

        Task<bool> RemoveBookFromUserFavoritesListAsync(string userId, int bookId);
    }
}
