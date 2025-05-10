using Horizons.Data.Models;

namespace Horizons.Models
{
    public class HomeViewModel
    {
        public List<Destination> FeaturedDestinations { get; set; } = new List<Destination>();

        public List<Terrain> Terrains { get; set; } = new List<Terrain>();
    }
}
