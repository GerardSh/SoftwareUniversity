using System.ComponentModel.DataAnnotations;
using static Horizons.Common.ValidationConstants;

namespace Horizons.Data.Models
{
    public class Terrain
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TerrainNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Destination> Destinations { get; set; }
            = new HashSet<Destination>();
    }
}