using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Add()
        {
            DestinationAddInputModel inputModel = new DestinationAddInputModel()
            {
                PublishedOn = DateTime.UtcNow.ToString(DestinationPublishedOnFormat),
                Terrains = await terrainService.GetTerrainsDropdownAsync()
            };

            return View(inputModel);
        }// 

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
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string? userId = GetUserId();

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
    }
}
