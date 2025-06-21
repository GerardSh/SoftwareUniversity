using System.ComponentModel.DataAnnotations;

using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Category;

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class RecipeEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RecipeTitleMinLength)]
        [MaxLength(RecipeTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(CategoryRangeMin, CategoryRangeMax, ErrorMessage = "Invalid category selected.")]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(RecipeInstructionsMinLength)]
        [MaxLength(RecipeInstructionsMaxLength)]
        public string Instructions { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }

        [Required]
        public string CreatedOn { get; set; } = null!;

        public IEnumerable<RecipeCreateCategoryDropdownModel>? Categories { get; set; }
    }
}
