using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType("Expense")]
    public class ExportExpenseDto
    {
        public string ExpenseName { get; set; } = null!;

        public string Amount { get; set; } = null!;

        public string PaymentDate { get; set; } = null!;

        public string ServiceName { get; set; } = null!;
    }
}
