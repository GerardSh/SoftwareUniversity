using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts
{
    public interface IDestinationService
    {
        public Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationAsync(string? userId);

        public Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? destinationId, string? userId);

    }
}
