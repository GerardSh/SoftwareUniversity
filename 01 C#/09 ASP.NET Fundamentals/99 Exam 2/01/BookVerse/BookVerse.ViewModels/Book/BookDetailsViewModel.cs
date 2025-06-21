namespace BookVerse.ViewModels.Book
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? CoverImageUrl { get; set; }

        public string Genre { get; set; } = null!;

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; } = null!;

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}
