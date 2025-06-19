using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationAsync(string? userId);

        Task<bool> AddDestinationAsync(string userId, DestinationAddInputModel inputModel);

        Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? destinationId, string? userId);

        Task<DestinationEditInputModel> GetDestinationForEditingAsync(string userId, int? id);

        Task<bool> PersistUpdatedDestinationAsync(string userId, DestinationEditInputModel inputModel);

        Task<DestinationDeleteInputModel?> GetDestinationForDeletingAsync(string userId, int? destId);

        Task<bool> SoftDeleteDestinationAsync(string userId, DestinationDeleteInputModel inputModel);

        Task<IEnumerable<FavoriteDestinationViewModel>?> GetUserFavoriteDestinationsAsync(string userId);

        Task<bool> AddDestinationToUserFavoritesListAsync(string userId, int destId);
    }
}
