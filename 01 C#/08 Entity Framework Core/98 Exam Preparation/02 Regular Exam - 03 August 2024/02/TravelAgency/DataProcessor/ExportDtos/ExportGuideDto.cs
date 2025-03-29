using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType(nameof(Guide))]
    public class ExportGuideDto
    {
        public string FullName { get; set; } = null!;

        [XmlArray("TourPackages")]
        [XmlArrayItem(nameof(TourPackage))]
        public List<ExportTourPackageDto> TourPackages { get; set; } = null!;
    }
}
