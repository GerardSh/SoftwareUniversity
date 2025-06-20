using Horizons.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Horizons.Common.ValidationConstants;

namespace Horizons.Models
{
    public class DestinationIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Terrain { get; set; } = null!;

        public int FavoritesCount { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }
    }
}
