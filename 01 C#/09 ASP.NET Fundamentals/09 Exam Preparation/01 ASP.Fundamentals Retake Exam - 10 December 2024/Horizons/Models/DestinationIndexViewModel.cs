namespace Horizons.Models
{
    public class DestinationIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Terrain { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int FavoritesCount { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }
    }
}
