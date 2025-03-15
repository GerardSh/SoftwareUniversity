namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportSoldProductDto
    {
        [XmlElement("count")]
        public int Count;

        [XmlArray("products")]
        public List<ExportProductDto> Products { get; set; }
            = new List<ExportProductDto>();
    }
}
