using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Cadastre.Data.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string PropertyIdentifier { get; set; } = null!;

        public int Area { get; set; }

        [MaxLength(500)]
        public string? Details { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = null!;

        public DateTime DateOfAcquisition { get; set; }

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        [Required]
        public virtual District District { get; set; } = null!;

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
            = new HashSet<PropertyCitizen>();
    }
}
