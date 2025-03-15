namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    public class ExportUserStartDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<ExportUserProductDto> Users { get; set; }
            = new List<ExportUserProductDto>();
    }
}
