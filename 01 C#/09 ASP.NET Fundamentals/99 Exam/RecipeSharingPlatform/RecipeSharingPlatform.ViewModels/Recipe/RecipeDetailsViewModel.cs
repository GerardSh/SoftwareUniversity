namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class RecipeDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Instructions { get; set; } = null!;

        public string Category { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; } = null!;

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}
