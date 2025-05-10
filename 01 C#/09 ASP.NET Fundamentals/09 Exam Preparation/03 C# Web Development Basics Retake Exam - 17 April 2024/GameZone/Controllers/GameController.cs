using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Add()
        {
            var model = new GameViewModel();

            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel model)
        {
            model.Genres = await GetGenres();

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var isDateValid = DateTime.TryParseExact(model.ReleasedOn, GameReleasedOnDateFormat,
                CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date);

            if (!isDateValid)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format");
                return View(model);
            }

            Game game = new Game()
            {
                Description = model.Description,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                PublisherId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                ReleasedOn = date,
                Title = model.Title
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GameViewModel()
                {
                    Description = g.Description,
                    GenreId = g.GenreId,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Title = g.Title,
                })
                .FirstOrDefaultAsync();

            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel model, int id)
        {
            model.Genres = await GetGenres();

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var isDateValid = DateTime.TryParseExact(model.ReleasedOn, GameReleasedOnDateFormat,
                CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date);

            if (!isDateValid)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format");
                return View(model);
            }

            Game? entity = await GetGame(id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }

            string currentUserId = GetCurrentUserId();

            if (entity.PublisherId != currentUserId)
            {
                RedirectToAction(nameof(All));
            }

            entity.Description = model.Description;
            entity.GenreId = model.GenreId;
            entity.ImageUrl = model.ImageUrl;
            entity.ReleasedOn = date;
            entity.Title = model.Title;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string currentGamerId = GetCurrentUserId();

            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Where(g => g.GamersGames.Any(gg => gg.GamerId == currentGamerId))
                .Include(g => g.Publisher)
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Title = g.Title
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game? entity = await context.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }

            string currentGamerId = GetCurrentUserId();

            if (entity.GamersGames.Any(gg => gg.GamerId == currentGamerId))
            {
                return RedirectToAction(nameof(All));
            }

            entity.GamersGames.Add(new GamerGame()
            {
                GameId = id,
                GamerId = currentGamerId
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            Game? entity = await context.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }

            string currentGamerId = GetCurrentUserId();

            GamerGame? gamerGame = entity.GamersGames
                .FirstOrDefault(gg => gg.GamerId == currentGamerId);

            if (gamerGame != null)
            {
                entity.GamersGames.Remove(gamerGame);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Games
               .Where(g => g.Id == id)
               .Where(g => g.IsDeleted == false)
               .AsNoTracking()
               .Select(g => new GameDeleteViewModel()
               {
                   Id = g.Id,
                   Title = g.Title,
                   Publisher = g.Publisher.UserName
               })
               .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await context.Games
                          .Where(g => g.Id == id)
                          .Where(g => g.IsDeleted == false)
                          .FirstOrDefaultAsync();

            if (game != null)
            {
                game.IsDeleted = true;
                //context.Games.Remove(game);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<List<Genre>> GetGenres()
        {
            return await context.Genres
                .ToListAsync();
        }

        private async Task<Game> GetGame(int id)
        {
            return await context.Games.FindAsync(id);
        }
    }
}
