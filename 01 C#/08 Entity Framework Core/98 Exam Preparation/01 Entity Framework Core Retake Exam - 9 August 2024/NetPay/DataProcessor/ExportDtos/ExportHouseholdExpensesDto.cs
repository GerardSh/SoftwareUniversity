using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType("Household")]
    public class ExportHouseholdExpensesDto
    {
        public string ContactPerson { get; set; } = null!;

        public string? Email { get; set; }

        public string PhoneNumber { get; set; } = null!;

        [XmlArray(nameof(Expenses))]
        [XmlArrayItem("Expense")]
        public ExportExpenseDto[] Expenses { get; set; } = null!;
    }
}
