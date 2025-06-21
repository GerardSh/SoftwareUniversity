namespace BookVerse.ViewModels.Book
{
    public class BookIndexViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string? CoverImageUrl { get; set; }

        public int SavedCount { get; set; }

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}
