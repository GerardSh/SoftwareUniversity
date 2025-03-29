using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType(nameof(TourPackage))]
    public class ExportTourPackageDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Price { get; set; } = null!;
    }
}
