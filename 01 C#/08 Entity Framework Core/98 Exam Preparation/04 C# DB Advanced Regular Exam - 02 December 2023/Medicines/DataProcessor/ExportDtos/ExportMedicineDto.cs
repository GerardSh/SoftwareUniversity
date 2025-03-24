using Medicines.Data.Models;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Medicine")]
    public class ExportMedicineDto
    {
        [XmlAttribute("Category")]
        public string Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string Producer { get; set; } = null!;

        public string BestBefore { get; set; } = null!;
    }
}
