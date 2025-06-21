using System.ComponentModel.DataAnnotations;

using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class RecipeDeleteInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RecipeTitleMinLength)]
        [MaxLength(RecipeTitleMaxLength)]
        public string Title { get; set; } = null!;

        public string? Author { get; set; } = null!;

        [Required]
        public string AuthorId { get; set; } = null!;
    }
}
