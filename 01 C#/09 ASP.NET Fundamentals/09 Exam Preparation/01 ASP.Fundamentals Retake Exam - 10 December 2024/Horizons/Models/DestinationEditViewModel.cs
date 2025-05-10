using Horizons.Common;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Horizons.Models
{
    public class DestinationEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.DestinationNameMaxLength, MinimumLength = ValidationConstants.DestinationNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.DestinationDescriptionMaxLength, MinimumLength = ValidationConstants.DestinationDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [RegexStringValidator(@"^\d{4}-\d{2}-\d{2}$")]
        public string PublishedOn { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.TerrainIdMinValue, ValidationConstants.TerrainIdMaxValue)]
        public int TerrainId { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;

        public virtual IEnumerable<TerrainViewModel>? Terrains { get; set; }
    }
}
