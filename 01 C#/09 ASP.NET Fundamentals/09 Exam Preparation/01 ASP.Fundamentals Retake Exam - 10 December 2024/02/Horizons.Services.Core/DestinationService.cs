using Horizons.Data;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Services.Core
{
    public class DestinationService(
        HorizonDbContext dbContext, 
        UserManager<IdentityUser> userManager) : IDestinationService
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

        public async Task<bool> AddDestinationAsync(string userId, DestinationAddInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Terrain? terrainRef = await dbContext
                .Terrains
                .FindAsync(inputModel.TerrainId);

            bool isPublishedDateValid = DateTime
                .TryParseExact(inputModel.PublishedOn, DestinationPublishedOnFormat, CultureInfo.InvariantCulture, 
                               DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null && terrainRef != null &&isPublishedDateValid)
            {
                Destination destination = new Destination()
                {
                    Name = inputModel.Name,
                    Description= inputModel.Description,
                    ImageUrl= inputModel.ImageUrl,
                    PublishedOn = publishedOnDate,
                    PublisherId = userId,
                    TerrainId = inputModel.TerrainId
                };

                await dbContext.Destinations.AddAsync(destination);
                await dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<DestinationEditInputModel> GetDestinationForEditingAsync(string userId, int? destId)
        {
            DestinationEditInputModel? editModel = null;

            if (destId != null)
            {
                Destination? editDestination = await dbContext
                    .Destinations
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (editDestination != null &&
                   editDestination.PublisherId.ToLower() == userId.ToLower())
                {
                    editModel = new DestinationEditInputModel()
                    {
                        Id = editDestination.Id,
                        Name = editDestination.Name,
                        Description = editDestination.Description,
                        ImageUrl = editDestination.ImageUrl,
                        PublishedOn = editDestination.PublishedOn.ToString(DestinationPublishedOnFormat),
                        PublisherId = editDestination.PublisherId,
                        TerrainId = editDestination.TerrainId
                    };
                }
            }

            return editModel;
        }

        public async Task<bool> PersistUpdatedDestinationAsync(string userId, DestinationEditInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await userManager
                .FindByIdAsync(userId);

            Destination? updatedDestination = await dbContext
                .Destinations
                .FindAsync(inputModel.Id);

            Terrain? terrainRef = await dbContext
                .Terrains
                .FindAsync(inputModel.TerrainId);

            bool isPublishedDateValid = DateTime
                .TryParseExact(inputModel.PublishedOn, DestinationPublishedOnFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null
                && terrainRef != null
                && isPublishedDateValid
                && updatedDestination != null
                && updatedDestination.PublisherId == userId)
            {
                updatedDestination.Name = inputModel.Name;
                updatedDestination.Description = inputModel.Description;
                updatedDestination.ImageUrl = inputModel.ImageUrl;
                updatedDestination.PublishedOn = publishedOnDate;
                updatedDestination.TerrainId = inputModel.TerrainId;

               await  dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<DestinationDeleteInputModel?> GetDestinationForDeletingAsync(string userId, int? destId)
        {
            DestinationDeleteInputModel? deleteModel = null;

            if (destId != null)
            {
                Destination? deleteDestination = await dbContext
                    .Destinations
                    .Include(d => d.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (deleteDestination != null &&
                   deleteDestination.PublisherId.ToLower() == userId.ToLower())
                {
                    deleteModel = new DestinationDeleteInputModel()
                    {
                        Id = deleteDestination.Id,
                        Name = deleteDestination.Name,
                        Publisher = deleteDestination.Publisher.UserName!,
                        PublisherId = deleteDestination.PublisherId,
                    };
                }
            }

            return deleteModel;
        }

        Task<DestinationDeleteInputModel?> IDestinationService.GetDestinationForDeletingAsync(string userId, int? destId)
        {
            throw new NotImplementedException();
        }
    }
}
