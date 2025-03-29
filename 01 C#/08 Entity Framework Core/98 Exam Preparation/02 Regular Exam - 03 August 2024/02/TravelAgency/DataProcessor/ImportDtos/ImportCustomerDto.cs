using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType(nameof(Customer))]
    public class ImportCustomerDto
    {
        [XmlAttribute("phoneNumber")]
        [Required]
        [RegularExpression(@"^\+\d{12}$")]
        [MinLength(13)]
        [MaxLength(13)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        public string FullName { get; set; } = null!;

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
    }
}
