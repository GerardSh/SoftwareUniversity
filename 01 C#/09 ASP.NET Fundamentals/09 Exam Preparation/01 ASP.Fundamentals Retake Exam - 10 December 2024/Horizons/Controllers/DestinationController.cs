using Horizons.Models;
using Horizons.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Horizons.Controllers
{
    public class DestinationController : BaseController
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();
            var model = await _destinationService.GetIndexDestinationsAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            DestinationAddViewModel model = await _destinationService.GetDestinationAddViewModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _destinationService.GetDestinationAddViewModelAsync();
                return View(model);
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _destinationService.AddDestinationAsync(model, userId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            IEnumerable<DestinationFavoritesViewModel> model = await _destinationService.GetFavoritesDestinationsAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            await _destinationService.AddToFavoritesAsync(id, userId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }
            await _destinationService.RemoveFromFavoritesAsync(id, userId);
            return RedirectToAction("Favorites");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = GetUserId();
            DestinationDetailsViewModel model = await _destinationService.GetDestinationDetailsViewModelAsync(id, userId);

            if(model == null)
            {
                if(User?.Identity?.IsAuthenticated == false)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            DestinationEditViewModel? model = await _destinationService.GetDestinationViewModelForEditAsync(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            string? userId = GetUserId();

            if (model.PublisherId != userId)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DestinationEditViewModel model)
        {
            string? userId = GetUserId();
            if (model.PublisherId != userId)
            {
                return RedirectToAction("Index");
            }

            if(!ModelState.IsValid)
            {
                model.Terrains = await _destinationService.GetTerrainsAsync();
                return View(model);
            }

            bool success = await _destinationService.EditDestinationAsync(model);

            if (!success)
            {
                return View(model);
            }
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string? userId = GetUserId();

            DestinationDeleteViewModel? model = await _destinationService.GetDestinationDeleteViewModelAsync(id, userId);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DestinationDeleteViewModel model)
        {
            string? userId = GetUserId();
            if (model.PublisherId != userId)
            {
                return RedirectToAction("Index");
            }
            bool success = await _destinationService.DeleteDestinationAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
