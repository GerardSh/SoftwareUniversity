using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Horizons.Common.ValidationConstants;
namespace Horizons.Data.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DestinationDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;

        public virtual IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public int TerrainId { get; set; }

        [Required]
        public virtual Terrain Terrain { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public  ICollection<UserDestination> UsersDestinations { get; set; }
            = new HashSet<UserDestination>();
    }
}
