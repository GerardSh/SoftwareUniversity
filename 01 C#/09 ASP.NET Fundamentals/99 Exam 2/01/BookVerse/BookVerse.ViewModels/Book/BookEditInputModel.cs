using System.ComponentModel.DataAnnotations;

using static BookVerse.GCommon.ValidationConstants.Book;
using static BookVerse.GCommon.ValidationConstants.Genre;

namespace BookVerse.ViewModels.Book
{
    public class BookEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Please select a genre.")]
        [Range(GenreRangeMin, GenreRangeMax, ErrorMessage = "Invalid genre selected.")]
        public int GenreId { get; set; }

        [Required]
        [MinLength(BookDescriptionMinLength)]
        [MaxLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Url]
        public string? CoverImageUrl { get; set; }

        [Required]
        public string PublishedOn { get; set; } = null!;

        public IEnumerable<BookCreateGenreDropdownModel>? Genres { get; set; }
    }
}
