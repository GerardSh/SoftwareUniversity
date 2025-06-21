using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Services.Core;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Web.Controllers
{
    public class RecipeController(IRecipeService recipeService,
        ICategoryService categoryService)
        : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = GetUserId();

                var allRecipesModel = await
                     recipeService.GetAllRecipesAsync(userId);

                return View(allRecipesModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                string? userId = GetUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var model = new RecipeCreateInputModel()
                {
                    CreatedOn = DateTime.UtcNow.ToString(RecipeCreatedOnFormat),
                    Categories = await categoryService.GetCategoriesDropdownAsync()
                };

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateInputModel model)
        {
            try
            {
                string userId = GetUserId()!;

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                if (!ModelState.IsValid)
                {
                    model.Categories = await categoryService.GetCategoriesDropdownAsync();

                    return View(model);
                }

                bool addResult = await recipeService.CreateRecipeAsync(userId, model);

                if (!addResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while creating a recipe!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string? userId = GetUserId();

                RecipeDetailsViewModel? recipeDetailsModel = await recipeService
                    .GetRecipeDetailsAsync(id, userId);

                if (recipeDetailsModel == null)
                {
                    if (User?.Identity?.IsAuthenticated == false)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Index");
                }

                return View(recipeDetailsModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string userId = GetUserId()!;

               RecipeEditInputModel editInputModel = await recipeService
                    .GetRecipeForEditingAsync(userId!, id);

                if (editInputModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                editInputModel.Categories = await categoryService.GetCategoriesDropdownAsync();

                return View(editInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Categories = await categoryService.GetCategoriesDropdownAsync();

                    return View(model);
                }

                string userId = GetUserId()!;
                string? authorId = await recipeService.GetAuthorIdAsync(model.Id);

                if (string.IsNullOrEmpty(authorId) || authorId.ToLower() != userId.ToLower())
                {
                    return RedirectToAction("Index");
                }

                bool editResult = await recipeService.PersistUpdatedRecipeAsync(userId, model);

                if (!editResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while updating the recipe!");
                    return View(model);
                }

                return RedirectToAction(nameof(Details), new { model.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string userId = GetUserId()!;

                RecipeDeleteInputModel? deleteModel = await recipeService
                    .GetRecipeForDeletingAsync(userId!, id);

                if (deleteModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(deleteModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(RecipeDeleteInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Please do not modify the page!");
                    return View("Delete", model);
                }

                string userId = GetUserId()!;

                bool deleteResult = await recipeService.SoftDeleteRecipeAsync(userId, model);

                if (!deleteResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while deleting the recipe!");
                    return View("Delete", model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = GetUserId()!;

                IEnumerable<FavoriteRecipeViewModel>? favRecipes = await
                     recipeService.GetUserFavoriteRecipesAsync(userId);

                return View(favRecipes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(int? id)
        {
            try
            {
                string userId = GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                bool favAddResult = await recipeService
                    .AddRecipeToUserFavoritesListAsync(userId, id.Value);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                string userId = GetUserId()!;

                bool removeFavorite = await recipeService.RemoveRecipeFromUserFavoritesListAsync(userId, id);

                if (!removeFavorite)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
