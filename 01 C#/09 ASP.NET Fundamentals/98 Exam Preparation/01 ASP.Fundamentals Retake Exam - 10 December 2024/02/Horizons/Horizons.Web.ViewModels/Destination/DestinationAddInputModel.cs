using System.ComponentModel.DataAnnotations;

using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Web.ViewModels.Destination
{
    public class DestinationAddInputModel
    {
        [Required]
        [MinLength(DestinationNameMinLength)]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int TerrainId { get; set; }

        public IEnumerable<DestinationAddTerrainDropdownModel>? Terrains { get; set; }

        [Required]
        [MinLength(DestinationDescriptionMinLength)]
        [MaxLength(DestinationDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }

        [Required]
        [Display(Name = DestinationPublishedOn)]
        public string PublishedOn { get; set; } = null!;
    }
}
