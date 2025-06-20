using System.ComponentModel.DataAnnotations;
using static Horizons.Common.ValidationConstants;

namespace Horizons.Models
{
    public class TerrainViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
