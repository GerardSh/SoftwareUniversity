using Horizons.Data;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Services.Core
{
    public class TerrainService(HorizonDbContext dbContext) : ITerrainService
    {
        public async Task<IEnumerable<DestinationAddTerrainDropdownModel>> GetTerrainsDropdownAsync()
        {
            IEnumerable<DestinationAddTerrainDropdownModel> terrainsAsDropdown = await dbContext
                .Terrains
                .AsNoTracking()
                .Select(t => new DestinationAddTerrainDropdownModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            return terrainsAsDropdown;
        }
    }
}
