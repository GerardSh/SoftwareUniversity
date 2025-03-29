using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using NetPay.Data.Models;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType(nameof(Household))]
    public class ExportHouseholdDto
    {
        public string ContactPerson { get; set; } = null!;

        public string? Email { get; set; }

        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Expenses")]
        [XmlArrayItem(nameof(Expense))]
        public List<ExportExpenseDto> Expenses { get; set; } = null!;
    }
}
