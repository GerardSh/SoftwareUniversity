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
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = GetUserId();

                IEnumerable<DestinationIndexViewModel> allDestinations = await
                     destinationService.GetAllDestinationAsync(userId);

                return View(allDestinations);
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
                DestinationAddInputModel inputModel = new DestinationAddInputModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(DestinationPublishedOnFormat),
                    Terrains = await terrainService.GetTerrainsDropdownAsync()
                };

                return View(inputModel);
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
                model.Terrains = await terrainService.GetTerrainsDropdownAsync();

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string userId = GetUserId()!;

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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string userId = GetUserId()!;

                DestinationDetailsViewModel? destinationDetails = await destinationService
                    .GetDestinationDetailsAsync(id, userId);

                if (destinationDetails == null) return RedirectToAction(nameof(Index));

                return View(destinationDetails);
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
                model.Terrains = await terrainService.GetTerrainsDropdownAsync();

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string userId = GetUserId()!;

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
        public async Task<IActionResult> Favorites(int id)
        {
            try
            {
                string? userId = GetUserId();

                IEnumerable<DestinationIndexViewModel> allDestinations = await
                     destinationService.GetAllDestinationAsync(userId);

                return View(allDestinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = GetUserId()!;

                IEnumerable<FavoriteDestinationViewModel>? favDestinations = await destinationService
                    .GetUserFavoriteDestinationsAsync(userId);

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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
