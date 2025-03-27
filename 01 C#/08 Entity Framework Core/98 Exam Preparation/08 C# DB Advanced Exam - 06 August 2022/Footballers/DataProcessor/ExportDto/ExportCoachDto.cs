using Footballers.Data.Models;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType(nameof(Coach))]
    public class ExportCoachDto
    {
        [XmlAttribute]
        public int FootballersCount { get; set; }

        public string CoachName { get; set; } = null!;

        [XmlArray("Footballers")]
        [XmlArrayItem("Footballer")]
        public List<ExportFootballerDto> Footballers { get; set; } = null!;
    }
}
