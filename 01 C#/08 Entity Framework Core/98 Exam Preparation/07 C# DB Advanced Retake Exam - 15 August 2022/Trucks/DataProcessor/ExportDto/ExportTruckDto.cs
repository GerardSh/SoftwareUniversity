using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportTruckDto
    {
        public string RegistrationNumber { get; set; } = null!;

        public string Make { get; set; } = null!;
    }
}
