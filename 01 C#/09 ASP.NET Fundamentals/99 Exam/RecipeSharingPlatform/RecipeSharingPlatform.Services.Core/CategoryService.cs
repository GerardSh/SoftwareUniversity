using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class CategoryService(RecipeSharingDbContext dbContext) : ICategoryService
    {
        public async Task<IEnumerable<RecipeCreateCategoryDropdownModel>> GetCategoriesDropdownAsync()
        {
            var categoriesAsDropdown = await dbContext
                .Categories
                .AsNoTracking()
                .Select(t => new RecipeCreateCategoryDropdownModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            return categoriesAsDropdown;
        }
    }
}
