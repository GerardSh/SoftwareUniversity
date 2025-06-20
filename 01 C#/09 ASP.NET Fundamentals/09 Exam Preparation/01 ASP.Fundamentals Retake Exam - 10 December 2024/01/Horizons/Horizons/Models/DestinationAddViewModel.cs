using Horizons.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using static Horizons.Common.ValidationConstants;

namespace Horizons.Models
{
    public class DestinationAddViewModel
    {
        [Required]
        [MinLength(DestinationNameMinLength)]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DestinationDescriptionMinLength)]
        [MaxLength(DestinationDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$", ErrorMessage = $"Date must be in {DestinationDateTimeFormat}.")]
        public string PublishedOn { get; set; } = null!;

        [Required]
        [Range(TerrainIdMinValue, TerrainIdMaxValue)]
        public int TerrainId { get; set; }

        public ICollection<TerrainViewModel>? Terrains { get; set; }
    }
}
