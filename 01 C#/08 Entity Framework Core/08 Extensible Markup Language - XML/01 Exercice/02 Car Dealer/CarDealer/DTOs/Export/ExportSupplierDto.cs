using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("supplier")]
    public class ExportSupplierDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; } = null!;

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public string PartsCount { get; set; } = null!;
    }
}
