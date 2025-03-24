using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [XmlAttribute("non-stop")]
        [Required]
        public string NonStop { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$")]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public List<ImportMedicineDto> Medicines { get; set; } = null!;
    }
}
