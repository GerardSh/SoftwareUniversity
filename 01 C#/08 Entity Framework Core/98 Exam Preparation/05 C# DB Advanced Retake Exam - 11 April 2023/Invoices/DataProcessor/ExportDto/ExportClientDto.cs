using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientDto
    {
        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        public string ClientName { get; set; } = null!;

        public string VatNumber { get; set; } = null!;

        [XmlArray("Invoices")]
        [XmlArrayItem("Invoice")]
        public List<ExportInvoiceDto> Invoices { get; set; } = null!;
    }
}
