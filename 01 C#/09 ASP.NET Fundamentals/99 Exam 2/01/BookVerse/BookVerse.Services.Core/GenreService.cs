using BookVerse.Data;
using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Services.Core
{
    public class GenreService(ApplicationDbContext dbContext) : IGenreService
    {
        public async Task<IEnumerable<BookCreateGenreDropdownModel>> GetGenresDropdownAsync()
        {
            var categoriesAsDropdown = await dbContext
                .Genres
                .AsNoTracking()
                .Select(t => new BookCreateGenreDropdownModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            return categoriesAsDropdown;
        }
    }
}
