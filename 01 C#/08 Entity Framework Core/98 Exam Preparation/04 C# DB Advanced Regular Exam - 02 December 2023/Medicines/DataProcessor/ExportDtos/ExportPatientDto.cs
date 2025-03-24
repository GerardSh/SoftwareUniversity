using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class ExportPatientDto
    {
        [XmlAttribute("Gender")]
        public string Gender { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string AgeGroup { get; set; } = null!;

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public List<ExportMedicineDto> Medicines { get; set; } = null!;
    }
}
