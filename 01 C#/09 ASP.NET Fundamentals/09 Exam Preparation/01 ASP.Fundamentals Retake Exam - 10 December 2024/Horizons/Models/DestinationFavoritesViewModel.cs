namespace Horizons.Models
{
    public class DestinationFavoritesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Terrain { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
