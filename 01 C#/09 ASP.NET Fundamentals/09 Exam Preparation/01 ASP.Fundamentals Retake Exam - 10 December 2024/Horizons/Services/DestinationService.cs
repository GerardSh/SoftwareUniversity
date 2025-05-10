using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models;
using Horizons.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Horizons.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly ApplicationDbContext _context;

        public DestinationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DestinationIndexViewModel>> GetIndexDestinationsAsync(string? userId)
        {
            return await _context.Destinations
                .Include(d => d.Terrain)
                .Include(d => d.UsersDestinations)
                .Select(d => new DestinationIndexViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Terrain = d.Terrain.Name,
                    ImageUrl = d.ImageUrl,
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = userId != null && d.PublisherId == userId,
                    IsFavorite = userId != null && d.UsersDestinations
                    .Any(ud => ud.DestinationId == d.Id && ud.UserId == userId)
                })
                .ToListAsync();
        }

        public async Task<DestinationAddViewModel> GetDestinationAddViewModelAsync()
        {
            IEnumerable<TerrainViewModel> terrains = await _context.Terrains
                .Select(t => new TerrainViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            DestinationAddViewModel model = new DestinationAddViewModel
            {
                Terrains = terrains
            };

            return model;
        }

        public async Task AddDestinationAsync(DestinationAddViewModel model, string userId)
        {
            if (!DateTime.TryParseExact(model.PublishedOn, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var publishedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }

            Destination destination = new Destination
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublishedOn = publishedDate,
                TerrainId = model.TerrainId,
                PublisherId = userId
            };
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DestinationFavoritesViewModel>> GetFavoritesDestinationsAsync(string userId)
        {
            return await _context.UsersDestinations
                .Where(ud => ud.UserId == userId)
                .Include(ud => ud.Destination)
                .Select(ud => new DestinationFavoritesViewModel
                {
                    Id = ud.Destination.Id,
                    Name = ud.Destination.Name,
                    Terrain = ud.Destination.Terrain.Name,
                    ImageUrl = ud.Destination.ImageUrl
                })
                .ToListAsync();
        }

        public async Task AddToFavoritesAsync(int id, string userId)
        {
            if (await _context.UsersDestinations.AnyAsync(ud => ud.UserId == userId && ud.DestinationId == id))
            {
                return;
            }
            UserDestination userDestination = new UserDestination
            {
                UserId = userId,
                DestinationId = id
            };
            await _context.UsersDestinations.AddAsync(userDestination);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromFavoritesAsync(int id, string userId)
        {
            UserDestination userDestination = await _context.UsersDestinations
                .FirstOrDefaultAsync(ud => ud.UserId == userId && ud.DestinationId == id);
            if (userDestination == null)
            {
                return;
            }
            _context.UsersDestinations.Remove(userDestination);
            await _context.SaveChangesAsync();
        }

        public async Task<DestinationDetailsViewModel> GetDestinationDetailsViewModelAsync(int id, string? userId)
        {
            Destination destination = await _context.Destinations
                .Include(d => d.Terrain)
                .Include(d => d.Publisher)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (destination == null)
            {
                throw new InvalidOperationException("Destination not found");
            }
            DestinationDetailsViewModel model = new DestinationDetailsViewModel
            {
                Id = destination.Id,
                Name = destination.Name,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                PublisherId = destination.PublisherId,
                Publisher = destination.Publisher.UserName,
                PublishedOn = destination.PublishedOn,
                TerrainId = destination.TerrainId,
                Terrain = destination.Terrain.Name,
                IsPublisher = destination.PublisherId == userId,
                IsFavorite = userId != null && await _context.UsersDestinations.AnyAsync(ud => ud.UserId == userId && ud.DestinationId == id)
            };
            return model;
        }

        public async Task<DestinationEditViewModel?> GetDestinationViewModelForEditAsync(int id)
        {
            TerrainViewModel[] terrains = await _context.Terrains
                .Select(t => new TerrainViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();


            DestinationEditViewModel? destinationToEdit = await _context.Destinations
                .Where(d => d.Id == id)
                .Select(d => new DestinationEditViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    PublishedOn = d.PublishedOn.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    TerrainId = d.TerrainId,
                    Terrains = terrains,
                    PublisherId = d.PublisherId
                })
                .FirstOrDefaultAsync();

            return destinationToEdit;
        }

        public async Task<IEnumerable<TerrainViewModel>> GetTerrainsAsync()
        {
            return await _context.Terrains
                .Select(t => new TerrainViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }

        public async Task<bool> EditDestinationAsync(DestinationEditViewModel model)
        {
            if (!DateTime.TryParseExact(model.PublishedOn, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var publishedDate))
            {
                throw new InvalidOperationException("Invalid date format");
            }
            Destination? destination = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == model.Id);

            if (destination == null)
            {
                return false;
            }

            destination.Name = model.Name;
            destination.Description = model.Description;
            destination.ImageUrl = model.ImageUrl;
            destination.PublishedOn = publishedDate;
            destination.TerrainId = model.TerrainId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DestinationDeleteViewModel?> GetDestinationDeleteViewModelAsync(int destinationId, string? userId)
        {
            DestinationDeleteViewModel? destinationTodelete = await _context.Destinations
                .Where(d => d.Id == destinationId && d.PublisherId == userId)
                .Select(d => new DestinationDeleteViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    PublisherId = d.PublisherId,
                    Publisher = d.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            return destinationTodelete;
        }

        public async Task<bool> DeleteDestinationAsync(int id)
        {
            Destination? destination = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == id);
            if(destination == null)
            {
                return false;
            }
            destination.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
