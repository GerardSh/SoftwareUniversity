namespace Horizons.Web.Controllers
{
    using System.Diagnostics;

    using ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class HomeController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction(nameof(Index), "Destination");
                }

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
