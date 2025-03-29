using NetPay.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType(nameof(Household))]
    public class ImportHouseholdDto
    {
        [XmlAttribute("phone")]
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        public string Phone { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string ContactPerson { get; set; } = null!;

        [MinLength(6)]
        [MaxLength(80)]

        public string? Email { get; set; }
    }
}
