using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static GameZone.Common.ModelConstants.Game;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Include(g => g.Publisher)
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Title = g.Title,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new GameViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new GameViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            return View(new List<GameInfoViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            return View(new List<GameInfoViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            return View(new List<GameInfoViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(new List<GameInfoViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(new List<GameInfoViewModel>());
        }
    }
}
