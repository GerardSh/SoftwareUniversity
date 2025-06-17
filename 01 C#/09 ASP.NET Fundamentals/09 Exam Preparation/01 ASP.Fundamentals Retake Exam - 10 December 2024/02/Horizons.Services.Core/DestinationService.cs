using Horizons.Data;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Services.Core
{
    public class DestinationService(HorizonDbContext dbContext) : IDestinationService
    {
        public async Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationAsync(string? userId)
        {
            var allDestinations = await dbContext
                .Destinations
                .AsNoTracking()
                .Select(d => new DestinationIndexViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Terrain = d.Terrain.Name,
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = userId != null && d.PublisherId == userId,
                    IsFavorite = userId != null && d.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower())
                })
                .ToListAsync();

            return allDestinations;
        }

        public async Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? id, string? userId)
        {
            DestinationDetailsViewModel? detailsVm = null;
            Destination? destinationModel = null;

            if (id.HasValue)
            {
                destinationModel = await dbContext
                    .Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.Publisher)
                    .Include(d => d.UsersDestinations)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == id.Value);
            }

            if (destinationModel != null)
            {
                detailsVm = new DestinationDetailsViewModel()
                {
                    Id = destinationModel.Id,
                    Name = destinationModel.Name,
                    ImageUrl = destinationModel.ImageUrl,
                    Terrain = destinationModel.Terrain.Name,
                    Description = destinationModel.Description,
                    PublishedOn = destinationModel.PublishedOn,
                    Publisher = destinationModel.Publisher.UserName!,
                    IsPublisher = userId != null && destinationModel.PublisherId.ToLower() == userId.ToLower(),
                    IsFavorite = userId != null && destinationModel.UsersDestinations.Any(f => f.UserId == userId)
                };
            }

            return detailsVm;
        }
    }
}
