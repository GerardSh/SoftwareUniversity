using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuideDto
    {
        public string FullName { get; set; } = null!;

        [XmlArray("TourPackages")]
        [XmlArrayItem("TourPackage")]
        public List<ExportTourPackageDto> TourPackages { get; set; } = null!;
    }
}
