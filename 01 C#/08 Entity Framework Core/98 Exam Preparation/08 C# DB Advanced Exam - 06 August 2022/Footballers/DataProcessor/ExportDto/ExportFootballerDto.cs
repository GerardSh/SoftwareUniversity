using Footballers.Data.Models;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType(nameof(Footballer))]
    public class ExportFootballerDto
    {
        public string Name { get; set; } = null!;

        public string Position { get; set; } = null!;

    }
}
