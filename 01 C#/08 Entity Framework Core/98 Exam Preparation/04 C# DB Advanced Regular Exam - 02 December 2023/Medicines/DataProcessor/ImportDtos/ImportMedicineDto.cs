using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDto
    {
        [XmlAttribute("category")]
        [Required]
        public string Category { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), "0.01", "1000")]
        public decimal Price { get; set; }

        [Required]
        public string ProductionDate { get; set; } = null!;

        [Required]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; } = null!;
    }
}