using System.ComponentModel.DataAnnotations;

using static BookVerse.GCommon.ValidationConstants.Book;
using static BookVerse.GCommon.ValidationConstants.Genre;

namespace BookVerse.ViewModels.Book
{
    public class BookCreateInputModel
    {
        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Genre is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid genre.")]
        public int GenreId { get; set; }

        [Required]
        [MinLength(BookDescriptionMinLength)]
        [MaxLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? CoverImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string PublishedOn { get; set; } = null!;

        public IEnumerable<BookCreateGenreDropdownModel>? Genres { get; set; }
    }
}
