using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class ImportHouseholdDto
    {
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        [XmlAttribute("phone")]
        public string Phone { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [XmlElement()]
        public string ContactPerson { get; set; } = null!;

        [MinLength(6)]
        [MaxLength(80)]
        [XmlElement]
        public string? Email { get; set; }
    }
}
