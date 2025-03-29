using Artillery.Data.Models;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType(nameof(Artillery.Data.Models.Country))]
    public class ExportCountryDto
    {
        [XmlAttribute]
        public string Country { get; set; } = null!;

        [XmlAttribute]
        public string ArmySize { get; set; } = null!;
    }
}