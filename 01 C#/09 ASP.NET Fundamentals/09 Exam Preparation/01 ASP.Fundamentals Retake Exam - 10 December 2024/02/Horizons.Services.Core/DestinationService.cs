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
                    IsFavorite = userId != null && d.UsersDestinations.Any(ud => ud.UserId == userId)
                })
                .ToListAsync();

            return allDestinations;
        }
    }
}
