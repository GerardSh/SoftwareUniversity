using Footballers.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType(nameof(Coach))]
    public class ImportCoachDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        [XmlArrayItem(nameof(Footballer))]
        public List<ImportFootballerDto> Footballers { get; set; } = null!;
    }
}
