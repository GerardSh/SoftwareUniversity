using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressDto
    {
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string StreetName { get; set; } = null!;

        [Required]
        public string StreetNumber { get; set; } = null!;

        [Required]
        public string PostCode { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string City { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Country { get; set; } = null!;
    }
}