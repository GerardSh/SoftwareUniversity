using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId);

        Task<bool> CreateRecipeAsync(string userId, RecipeCreateInputModel inputModel);

        Task<RecipeDetailsViewModel?> GetRecipeDetailsAsync(int? recipeId, string? userId);

        Task<RecipeEditInputModel> GetRecipeForEditingAsync(string userId, int? resipeId);

        Task<bool> PersistUpdatedRecipeAsync(string userId, RecipeEditInputModel inputModel);

        Task<string?> GetAuthorIdAsync(int recipeId);

        Task<RecipeDeleteInputModel?> GetRecipeForDeletingAsync(string userId, int? recipeId);

        Task<bool> SoftDeleteRecipeAsync(string userId, RecipeDeleteInputModel inputModel);

        Task<IEnumerable<FavoriteRecipeViewModel>?> GetUserFavoriteRecipesAsync(string userId);

        Task<bool> AddRecipeToUserFavoritesListAsync(string userId, int recipeId);

        Task<bool> RemoveRecipeFromUserFavoritesListAsync(string userId, int recipeId);
    }
}
