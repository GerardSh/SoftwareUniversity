namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}