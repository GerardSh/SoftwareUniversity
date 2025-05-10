using Horizons.Models;

namespace Horizons.Services.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationIndexViewModel>> GetIndexDestinationsAsync(string? userId);

        Task<DestinationAddViewModel> GetDestinationAddViewModelAsync();

        Task AddDestinationAsync(DestinationAddViewModel model, string userId);

        Task<IEnumerable<DestinationFavoritesViewModel>> GetFavoritesDestinationsAsync(string userId);

        Task AddToFavoritesAsync(int destinationId, string userId);

        Task RemoveFromFavoritesAsync(int destinationId, string userId);

        Task<DestinationDetailsViewModel> GetDestinationDetailsViewModelAsync(int destinationId, string? userId);

        Task<DestinationEditViewModel?> GetDestinationViewModelForEditAsync(int destinationId);

        Task<bool> EditDestinationAsync(DestinationEditViewModel model);

        Task<IEnumerable<TerrainViewModel>> GetTerrainsAsync();
        Task<DestinationDeleteViewModel?> GetDestinationDeleteViewModelAsync(int destinationId, string? userId);

        Task<bool> DeleteDestinationAsync(int destinationId);
    }
}
