using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using System.Globalization;

using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class RecipeService(RecipeSharingDbContext dbContext,
           UserManager<IdentityUser> userManager) : IRecipeService
    {
        public async Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId)
        {
            var allRecipes = await dbContext
                .Recipes
                .AsNoTracking()
                .Select(r => new RecipeIndexViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    Category = r.Category.Name,
                    SavedCount = r.UsersRecipes.Count,
                    IsAuthor = userId != null && r.AuthorId == userId,
                    IsSaved = userId != null && r.UsersRecipes
                    .Any(ud => ud.UserId.ToLower() == userId.ToLower())
                })
                .ToListAsync();

            return allRecipes;
        }

        public async Task<bool> CreateRecipeAsync(string userId, RecipeCreateInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Category? categoryRef = await dbContext
                .Categories
                .FindAsync(inputModel.CategoryId);

            bool isCreatedOnDateValid = DateTime
                .TryParseExact(inputModel.CreatedOn, RecipeCreatedOnFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime createdOnDate);

            if (user != null && categoryRef != null && isCreatedOnDateValid)
            {
                Recipe recipe = new Recipe()
                {
                    Title = inputModel.Title,
                    Instructions = inputModel.Instructions,
                    ImageUrl = inputModel.ImageUrl,
                    CreatedOn = createdOnDate,
                    AuthorId = userId,
                    CategoryId = inputModel.CategoryId
                };

                await dbContext.Recipes.AddAsync(recipe);
                await dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<RecipeDetailsViewModel?> GetRecipeDetailsAsync(int? recipeId, string? userId)
        {
            RecipeDetailsViewModel? detailsModel = null;
            Recipe? recipeModel = null;

            if (recipeId.HasValue)
            {
                recipeModel = await dbContext
                    .Recipes
                    .Include(d => d.Category)
                    .Include(d => d.Author)
                    .Include(d => d.UsersRecipes)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == recipeId.Value);
            }

            if (recipeModel != null)
            {
                detailsModel = new RecipeDetailsViewModel()
                {
                    Id = recipeModel.Id,
                    Title = recipeModel.Title,
                    ImageUrl = recipeModel.ImageUrl,
                    Category = recipeModel.Category.Name,
                    Instructions = recipeModel.Instructions,
                    CreatedOn = recipeModel.CreatedOn,
                    Author = recipeModel.Author.UserName!,
                    IsAuthor = userId != null && recipeModel.AuthorId.ToLower() == userId.ToLower(),
                    IsSaved = userId != null && recipeModel.UsersRecipes.Any(ur => ur.UserId == userId)
                };
            }

            return detailsModel;
        }

        public async Task<RecipeEditInputModel> GetRecipeForEditingAsync(string userId, int? recipeId)
        {
            RecipeEditInputModel? editModel = null;

            if (recipeId != null)
            {
                Recipe? editRecipe = await dbContext
                    .Recipes
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == recipeId);

                if (editRecipe != null &&
                   editRecipe.AuthorId.ToLower() == userId.ToLower())
                {
                    editModel = new RecipeEditInputModel()
                    {
                        Id = editRecipe.Id,
                        Title = editRecipe.Title,
                        Instructions = editRecipe.Instructions,
                        ImageUrl = editRecipe.ImageUrl,
                        CreatedOn = editRecipe.CreatedOn.ToString(RecipeCreatedOnFormat),
                        CategoryId = editRecipe.CategoryId
                    };
                }
            }

            return editModel;
        }

        public async Task<bool> PersistUpdatedRecipeAsync(string userId, RecipeEditInputModel inputModel)
        {
            bool opResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Recipe? recipeModel = await dbContext
                .Recipes
                .FindAsync(inputModel.Id);

            Category? categoryRef = await dbContext
                .Categories
                .FindAsync(inputModel.CategoryId);

            bool isCreatedOnDateValid = DateTime
                .TryParseExact(inputModel.CreatedOn, RecipeCreatedOnFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime createdDate);

            if (user != null
                && categoryRef != null
                && isCreatedOnDateValid
                && recipeModel != null
                && recipeModel.AuthorId.ToLower() == userId.ToLower())
            {
                recipeModel.Title = inputModel.Title;
                recipeModel.Instructions = inputModel.Instructions;
                recipeModel.ImageUrl = inputModel.ImageUrl;
                recipeModel.CreatedOn = createdDate;
                recipeModel.CategoryId = inputModel.CategoryId;

                await dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }

        public async Task<string?> GetAuthorIdAsync(int recipeId)
        {
            return await dbContext.Recipes
           .Where(r => r.Id == recipeId)
           .Select(r => r.AuthorId)
           .FirstOrDefaultAsync();
        }

        public async Task<RecipeDeleteInputModel?> GetRecipeForDeletingAsync(string userId, int? recipeId)
        {
            RecipeDeleteInputModel? deleteModel = null;

            if (recipeId != null)
            {
                Recipe? recipeModel = await dbContext
                    .Recipes
                    .Include(r => r.Author)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == recipeId);

                if (recipeModel != null &&
                   recipeModel.AuthorId.ToLower() == userId.ToLower())
                {
                    deleteModel = new RecipeDeleteInputModel()
                    {
                        Id = recipeModel.Id,
                        Title = recipeModel.Title,
                        Author = recipeModel.Author.UserName!,
                        AuthorId = recipeModel.AuthorId,
                    };
                }
            }

            return deleteModel;
        }

        public async Task<bool> SoftDeleteRecipeAsync(string userId, RecipeDeleteInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Recipe? deleteRecipe = await dbContext
                .Recipes
                .FindAsync(inputModel.Id);

            if (user != null
                && deleteRecipe != null
                && deleteRecipe.AuthorId.ToLower() == userId.ToLower())
            {
                deleteRecipe.IsDeleted = true;

                await dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<IEnumerable<FavoriteRecipeViewModel>?> GetUserFavoriteRecipesAsync(string userId)
        {
            IEnumerable<FavoriteRecipeViewModel>? favRecipes = null;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            if (user != null)
            {
                favRecipes = await dbContext
                    .UsersRecipes
                    .Include(ur => ur.Recipe)
                    .ThenInclude(d => d.Category)
                    .Where(ur => ur.UserId.ToLower() == userId.ToLower())
                    .Select(ur => new FavoriteRecipeViewModel()
                    {
                        Id = ur.RecipeId,
                        Title = ur.Recipe.Title,
                        ImageUrl = ur.Recipe.ImageUrl,
                        Category = ur.Recipe.Category.Name
                    })
                    .ToArrayAsync();
            }

            return favRecipes;
        }

        public async Task<bool> AddRecipeToUserFavoritesListAsync(string userId, int recipeId)
        {
            bool opResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Recipe? favRecipe = await dbContext
                .Recipes
                .FindAsync(recipeId);

            if (user != null
                && favRecipe != null
                && favRecipe.AuthorId.ToLower() != userId.ToLower())
            {
                UserRecipe? userFavRecipe = await dbContext
                    .UsersRecipes
                    .SingleOrDefaultAsync(ur => ur.UserId.ToLower() == userId.ToLower() &&
                                                ur.RecipeId == recipeId);

                if (userFavRecipe == null)
                {
                    userFavRecipe = new UserRecipe()
                    {
                        UserId = userId,
                        RecipeId = recipeId
                    };

                    await dbContext.UsersRecipes.AddAsync(userFavRecipe);
                    await dbContext.SaveChangesAsync();

                    opResult = true;
                }
            }

            return opResult;
        }

        public async Task<bool> RemoveRecipeFromUserFavoritesListAsync(string userId, int destId)
        {
            bool opResult = false;

            var UserRecipe = await dbContext.UsersRecipes
                 .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RecipeId == destId);

            if (UserRecipe != null)
            {
                dbContext.UsersRecipes.Remove(UserRecipe);
                await dbContext.SaveChangesAsync();

                opResult = true;
            }

            return opResult;
        }
    }
}
