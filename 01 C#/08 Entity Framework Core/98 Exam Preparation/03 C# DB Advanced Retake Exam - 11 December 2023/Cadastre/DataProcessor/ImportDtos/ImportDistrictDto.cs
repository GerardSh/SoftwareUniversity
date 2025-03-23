using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [Required]
        [XmlAttribute("Region")]
        public string Region { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        [MinLength(8)]
        [MaxLength(8)]
        public string PostalCode { get; set; } = null!;

        [XmlArray("Properties")]
        [XmlArrayItem("Property")]
        public List<ImportPropertyDto> Properties { get; set; } = null!;
    }
}
