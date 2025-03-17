namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class ExportCustomerDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public string CarsBought { get; set; } = null!;

        [XmlAttribute("spent-money")]
        public string MoneySpent { get; set; } = null!;
    }
}