using Artillery.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType(nameof(Manufacturer))]
    public class ImportManufacturerDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Founded { get; set; } = null!;
    }
}
