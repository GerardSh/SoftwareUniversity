using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatcherDto
    {
        [XmlAttribute]
        public int TrucksCount { get; set; }

        public string DespatcherName { get; set; } = null!;

        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public List<ExportTruckDto> Trucks { get; set; } = null!;
    }
}
