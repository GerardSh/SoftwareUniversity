using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Web.Controllers
{
    public class DestinationController(
        IDestinationService destinationService,
        ITerrainService terrainService)
        : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = GetUserId();

                var allDestinationsModel = await
                     destinationService.GetAllDestinationAsync(userId);

                return View(allDestinationsModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                string? userId = GetUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var model = new DestinationAddInputModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(DestinationPublishedOnFormat),
                    Terrains = await terrainService.GetTerrainsDropdownAsync()
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
        public async Task<IActionResult> Add(DestinationAddInputModel model)
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
                    model.Terrains = await terrainService.GetTerrainsDropdownAsync();

                    return View(model);
                }

                bool addResult = await destinationService.AddDestinationAsync(userId, model);

                if (!addResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while adding a destination!");
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

                DestinationDetailsViewModel? destinationDetailsModel = await destinationService
                    .GetDestinationDetailsAsync(id, userId);

                if (destinationDetailsModel == null)
                {
                    if (User?.Identity?.IsAuthenticated == false)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Index");
                }

                return View(destinationDetailsModel);
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

                DestinationEditInputModel editInputModel = await destinationService
                    .GetDestinationForEditingAsync(userId!, id);

                if (editInputModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                editInputModel.Terrains = await terrainService.GetTerrainsDropdownAsync();

                return View(editInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DestinationEditInputModel model)
        {
            try
            {
                string userId = GetUserId()!;
                if (model == null || model.PublisherId != userId)
                {
                    return RedirectToAction("Index");
                }

                if (!ModelState.IsValid)
                {
                    model.Terrains = await terrainService.GetTerrainsDropdownAsync();

                    return View(model);
                }

                bool editResult = await destinationService.PersistUpdatedDestinationAsync(userId, model);

                if (!editResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while updating the destination!");
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

                DestinationDeleteInputModel? deleteInputModel = await destinationService
                    .GetDestinationForDeletingAsync(userId!, id);

                if (deleteInputModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(deleteInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DestinationDeleteInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Please do not modify the page!");
                    return View(model);
                }

                string userId = GetUserId()!;

                bool deleteResult = await destinationService.SoftDeleteDestinationAsync(userId, model);

                if (!deleteResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occured while deleting the destination!");
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

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = GetUserId()!;

                IEnumerable<FavoriteDestinationViewModel>? favDestinations = await
                     destinationService.GetUserFavoriteDestinationsAsync(userId);

                if (favDestinations == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(favDestinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int? id)
        {
            try
            {
                string userId = GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                bool favAddResult = await destinationService
                    .AddDestinationToUserFavoritesListAsync(userId, id.Value);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            try
            {
                string userId = GetUserId()!;

                bool removeFavorite = await destinationService.RemoveDestinationFromUserFavoritesListAsync(userId, id);

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

