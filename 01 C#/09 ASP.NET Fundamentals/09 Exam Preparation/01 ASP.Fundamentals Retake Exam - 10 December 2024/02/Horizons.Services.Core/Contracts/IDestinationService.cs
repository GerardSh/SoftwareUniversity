using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts
{
    public interface IDestinationService
    {
        public Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationAsync(string? userId);
    }
}
