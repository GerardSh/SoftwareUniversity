using Artillery.Data.Models;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType(nameof(Gun))]
    public class ExportGunDto
    {
        [XmlAttribute]
        public string Manufacturer { get; set; } = null!;

        [XmlAttribute]
        public string GunType { get; set; } = null!;

        [XmlAttribute]
        public string GunWeight { get; set; } = null!;

        [XmlAttribute]
        public string BarrelLength { get; set; } = null!;

        [XmlAttribute]
        public string Range { get; set; } = null!;

        [XmlArray("Countries")]
        [XmlArrayItem(nameof(Country))]
        public List<ExportCountryDto> Countries { get; set; } = null!;
    }
}
