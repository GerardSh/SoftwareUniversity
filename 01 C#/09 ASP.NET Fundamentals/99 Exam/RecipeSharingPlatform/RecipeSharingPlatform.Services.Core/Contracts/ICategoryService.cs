using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<RecipeCreateCategoryDropdownModel>> GetCategoriesDropdownAsync();
    }
}
