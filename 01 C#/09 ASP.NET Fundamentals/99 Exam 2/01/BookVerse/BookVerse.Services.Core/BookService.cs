using BookVerse.Data;
using BookVerse.DataModels;
using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.Services.Core
{
    public class BookService(ApplicationDbContext dbContext,
           UserManager<IdentityUser> userManager) : IBookService
    {
        public async Task<IEnumerable<BookIndexViewModel>> GetAllBooksAsync(string? userId)
        {
            var allBooks = await dbContext
                .Books
                .AsNoTracking()
                .Select(b => new BookIndexViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    CoverImageUrl = b.CoverImageUrl,
                    Genre = b.Genre.Name,
                    SavedCount = b.UsersBooks.Count,
                    IsAuthor = userId != null && b.PublisherId == userId,
                    IsSaved = userId != null && b.UsersBooks
                    .Any(ub => ub.UserId.ToLower() == userId.ToLower())
                })
                .ToListAsync();

            return allBooks;
        }

        public async Task<bool> CreateBookAsync(string userId, BookCreateInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Genre? genreRef = await dbContext
                .Genres
                .FindAsync(inputModel.GenreId);

            bool isPublishedOnDateValid = DateTime
                .TryParseExact(inputModel.PublishedOn, BookPublishedOnFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null && genreRef != null && isPublishedOnDateValid)
            {
                Book book = new Book()
                {
                    Title = inputModel.Title,
                    Description = inputModel.Description,
                    CoverImageUrl = inputModel.CoverImageUrl,
                    PublishedOn = publishedOnDate,
                    PublisherId = userId,
                    GenreId = inputModel.GenreId
                };

                await dbContext.Books.AddAsync(book);
                await dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<BookDetailsViewModel?> GetBookDetailsAsync(int? bookId, string? userId)
        {
            BookDetailsViewModel? detailsModel = null;
            Book? bookModel = null;

            if (bookId.HasValue)
            {
                bookModel = await dbContext
                    .Books
                    .Include(d => d.Genre)
                    .Include(d => d.Publisher)
                    .Include(d => d.UsersBooks)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == bookId.Value);
            }

            if (bookModel != null)
            {
                detailsModel = new BookDetailsViewModel()
                {
                    Id = bookModel.Id,
                    Title = bookModel.Title,
                    Description = bookModel.Description,
                    CoverImageUrl = bookModel.CoverImageUrl,
                    Genre = bookModel.Genre.Name,
                    PublishedOn = bookModel.PublishedOn,
                    Publisher = bookModel.Publisher.UserName!,
                    IsAuthor = userId != null && bookModel.PublisherId.ToLower() == userId.ToLower(),
                    IsSaved = userId != null && bookModel.UsersBooks.Any(ub => ub.UserId == userId)
                };
            }

            return detailsModel;
        }

        public async Task<BookEditInputModel> GetBookForEditingAsync(string userId, int? bookId)
        {
            BookEditInputModel? editModel = null;

            if (bookId != null)
            {
                Book? editBook = await dbContext
                    .Books
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == bookId);

                if (editBook != null &&
                   editBook.PublisherId.ToLower() == userId.ToLower())
                {
                    editModel = new BookEditInputModel()
                    {
                        Id = editBook.Id,
                        Title = editBook.Title,
                        Description = editBook.Description,
                        CoverImageUrl = editBook.CoverImageUrl,
                        PublishedOn = editBook.PublishedOn.ToString(BookPublishedOnFormat),
                        GenreId = editBook.GenreId
                    };
                }
            }

            return editModel;
        }

        public async Task<bool> PersistUpdatedBookAsync(string userId, BookEditInputModel inputModel)
        {
            bool opResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Book? bookModel = await dbContext
                .Books
                .FindAsync(inputModel.Id);

            Genre? genreRef = await dbContext
                .Genres
                .FindAsync(inputModel.GenreId);

            bool isPublishedOnDateValid = DateTime
                .TryParseExact(inputModel.PublishedOn, BookPublishedOnFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime publishedDate);

            if (user != null
                && genreRef != null
                && isPublishedOnDateValid
                && bookModel != null
                && bookModel.PublisherId.ToLower() == userId.ToLower())
            {
                bookModel.Title = inputModel.Title;
                bookModel.Description = inputModel.Description;
                bookModel.CoverImageUrl = inputModel.CoverImageUrl;
                bookModel.PublishedOn = publishedDate;
                bookModel.GenreId = inputModel.GenreId;

                await dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }

        public async Task<string?> GetPublisherIdAsync(int bookId)
        {
            return await dbContext.Books
           .Where(book => book.Id == bookId)
           .Select(book => book.PublisherId)
           .FirstOrDefaultAsync();
        }

        public async Task<BookDeleteViewModel?> GetBookForDeletingAsync(string userId, int? bookId)
        {
            BookDeleteViewModel? deleteModel = null;

            if (bookId != null)
            {
                Book? bookModel = await dbContext
                    .Books
                    .Include(b => b.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(b => b.Id == bookId);

                if (bookModel != null &&
                   bookModel.PublisherId.ToLower() == userId.ToLower())
                {
                    deleteModel = new BookDeleteViewModel()
                    {
                        Id = bookModel.Id,
                        Title = bookModel.Title,
                        Publisher = bookModel.Publisher.UserName!,
                    };
                }
            }

            return deleteModel;
        }

        public async Task<bool> SoftDeleteBookAsync(string userId, BookDeleteViewModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Book? deleteBook = await dbContext
                .Books
                .FindAsync(inputModel.Id);

            var bookAuthorId = await GetPublisherIdAsync(inputModel.Id);

            if (user != null
                && bookAuthorId != null
                && deleteBook != null
                && bookAuthorId.ToLower() == userId.ToLower())
            {
                deleteBook.IsDeleted = true;

                await dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<IEnumerable<FavoriteBookViewModel>?> GetUserFavoriteBooksAsync(string userId)
        {
            IEnumerable<FavoriteBookViewModel>? favBooks = null;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            if (user != null)
            {
                favBooks = await dbContext
                    .UsersBooks
                    .Include(ub => ub.Book)
                    .ThenInclude(b => b.Genre)
                    .Where(ub => ub.UserId.ToLower() == userId.ToLower())
                    .Select(ub => new FavoriteBookViewModel()
                    {
                        Id = ub.BookId,
                        Title = ub.Book.Title,
                        CoverImageUrl = ub.Book.CoverImageUrl,
                        Genre = ub.Book.Genre.Name
                    })
                    .ToArrayAsync();
            }

            return favBooks;
        }

        public async Task<bool> AddBookToUserFavoritesListAsync(string userId, int bookId)
        {
            bool opResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Book? favBook = await dbContext
                .Books
                .FindAsync(bookId);

            if (user != null
                && favBook != null
                && favBook.PublisherId.ToLower() != userId.ToLower())
            {
                UserBook? userFavBook = await dbContext
                    .UsersBooks
                    .SingleOrDefaultAsync(ub => ub.UserId.ToLower() == userId.ToLower() &&
                                                ub.BookId == bookId);

                if (userFavBook == null)
                {
                    userFavBook = new UserBook()
                    {
                        UserId = userId,
                        BookId = bookId
                    };

                    await dbContext.UsersBooks.AddAsync(userFavBook);
                    await dbContext.SaveChangesAsync();

                    opResult = true;
                }
            }

            return opResult;
        }

        public async Task<bool> RemoveBookFromUserFavoritesListAsync(string userId, int bookId)
        {
            bool opResult = false;

            var userBook = await dbContext.UsersBooks
                 .FirstOrDefaultAsync(ub => ub.UserId == userId && ub.BookId == bookId);

            if (userBook != null)
            {
                dbContext.UsersBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }
    }
}
