using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    [XmlType("Property")]
    public class ExportPropertyDto
    {
        [XmlAttribute("postal-code")]
        public string PostalCode { get; set; } = null!;

        public string PropertyIdentifier { get; set; } = null!;

        public int Area { get; set; }

        public string DateOfAcquisition { get; set; } = null!;
    }
}
