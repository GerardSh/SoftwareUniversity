using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Globalization;
using static Horizons.Common.ValidationConstants;

namespace Horizons.Controllers
{
    public class DestinationController : BaseController
    {
        ApplicationDbContext context;

        public DestinationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();

            var model = await context.Destinations
                .Select(d => new DestinationIndexViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Terrain = d.Terrain.Name,
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = userId != null && d.PublisherId == userId,
                    IsFavorite = userId != null && d.UsersDestinations
                    .Any(ud => ud.UserId == userId)
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new DestinationAddViewModel();

            model.Terrains = await context.Terrains
                .Select(t => new TerrainViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Terrains = await context.Terrains
                    .Select(t => new TerrainViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();

                return View(model);
            }

            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            if (!DateTime.TryParseExact(model.PublishedOn, DestinationDateTimeFormat,
                null, System.Globalization.DateTimeStyles.None, out var publishedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            Destination destination = new Destination()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublishedOn = publishedDate,
                TerrainId = model.TerrainId,
                PublisherId = userId
            };

            await context.Destinations.AddAsync(destination);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = await context.UsersDestinations
                .Where(ud => ud.UserId == userId)
                .Select(ud => new DestinationFavoritesViewModel()
                {
                    Id = ud.Destination.Id,
                    Name = ud.Destination.Name,
                    ImageUrl = ud.Destination.ImageUrl,
                    Terrain = ud.Destination.Terrain.Name,
                })
                .ToListAsync();

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

            if (await context.UsersDestinations.AnyAsync(ud => ud.UserId == userId && ud.DestinationId == id))
            {
                return RedirectToAction("Index");
            }

            var userDestination = new UserDestination()
            {
                UserId = userId,
                DestinationId = id
            };

            await context.UsersDestinations.AddAsync(userDestination);
            await context.SaveChangesAsync();

            var referer = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var userDestination = await context.UsersDestinations
                 .FirstOrDefaultAsync(ud => ud.UserId == userId && ud.DestinationId == id);

            if (userDestination == null)
            {
                return RedirectToAction("Index");
            }

            context.UsersDestinations.Remove(userDestination);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Favorites));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = GetUserId();

            var model = await context.Destinations
                .Where(d => d.Id == id)
                .Select(d => new DestinationDetailsViewModel()
                {
                    Name = d.Name,
                    Description = d.Description,
                    Id = d.Id,
                    ImageUrl = d.ImageUrl,
                    IsFavorite = d.UsersDestinations.Any(ud => ud.UserId == userId),
                    IsPublisher = d.Publisher.Id == userId,
                    PublishedOn = d.PublishedOn,
                    Terrain = d.Terrain.Name,
                    Publisher = d.Publisher.UserName!
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                if (User?.Identity?.IsAuthenticated == false)
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
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var terrains = await context.Terrains
                 .Select(t => new TerrainViewModel()
                 {
                     Id = t.Id,
                     Name = t.Name
                 })
                 .ToListAsync();

            var model = await context.Destinations
                .Where(d => d.Id == id)
                .Select(d => new DestinationEditViewModel()
                {
                    Id = d.Id,
                    ImageUrl = d.ImageUrl,
                    Description = d.Description,
                    Name = d.Name,
                    PublishedOn = d.PublishedOn.ToString(DestinationDateTimeFormat),
                    PublisherId = d.PublisherId,
                    TerrainId = d.TerrainId,
                    Terrains = terrains
                })
                .FirstOrDefaultAsync();

            if (model == null || model.PublisherId != userId)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DestinationEditViewModel model)
        {
            string? userId = GetUserId();
            if (model == null || model.PublisherId != userId)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                model.Terrains = await context.Terrains
                    .Select(t => new TerrainViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();

                return View(model);
            }

            if (!DateTime.TryParseExact(model.PublishedOn, DestinationDateTimeFormat,
                null, System.Globalization.DateTimeStyles.None, out var publishedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            Destination? destination = await context.Destinations.FindAsync(model.Id);

            if (destination == null)
            {
                return View(model);
            }

            destination.Name = model.Name;
            destination.Description = model.Description;
            destination.ImageUrl = model.ImageUrl;
            destination.PublishedOn = publishedDate;
            destination.TerrainId = model.TerrainId;
            destination.PublisherId = userId;

            await context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = await context.Destinations
                .Where(d => d.Id == id)
                .Select(d => new DestinationDeleteViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Publisher = d.Publisher.UserName,
                    PublisherId = d.PublisherId
                })
                .FirstOrDefaultAsync();

            if (model == null || model.PublisherId != userId)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DestinationDeleteViewModel model)
        {
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var destination = await context.Destinations
                .FindAsync(model.Id);

            if (destination == null || userId != destination.PublisherId)
            {
                return RedirectToAction("Index");
            }

            destination.IsDeleted = true;

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
