using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Horizons.Web.Controllers
{
    public class DestinationController(IDestinationService destinationService) : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();

           IEnumerable<DestinationIndexViewModel> allDestinations = await
                destinationService.GetAllDestinationAsync(userId);

            return View(allDestinations);
        }
    }
}
