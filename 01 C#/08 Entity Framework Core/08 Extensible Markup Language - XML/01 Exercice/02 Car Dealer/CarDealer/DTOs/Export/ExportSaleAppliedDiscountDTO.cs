namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
	public class ExportSaleAppliedDiscountDto
	{
		[XmlElement("car")]
		public ExportCarWithAttrDto Car { get; set; } = null!;

		[XmlElement("discount")]
		public string Discount { get; set; } = null!;

		[XmlElement("customer-name")]
		public string CustomerName { get; set; } = null!;

		[XmlElement("price")]
		public string Price { get; set; } = null!;

		[XmlElement("price-with-discount")]
		public string PriceWithDiscount { get; set; } = null!;
	}
}