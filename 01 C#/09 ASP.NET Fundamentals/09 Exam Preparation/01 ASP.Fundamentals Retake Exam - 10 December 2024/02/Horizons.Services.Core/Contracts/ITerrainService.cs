using Horizons.Web.ViewModels.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Services.Core.Contracts
{
    public interface ITerrainService
    {
        public Task<IEnumerable<DestinationAddTerrainDropdownModel>> GetTerrainsDropdownAsync();
    }
}
