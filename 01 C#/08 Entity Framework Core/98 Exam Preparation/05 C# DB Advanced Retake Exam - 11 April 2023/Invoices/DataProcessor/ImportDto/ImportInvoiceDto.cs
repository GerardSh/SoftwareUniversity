using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoiceDto
    {
        [Required]
        [Range(1000000000, 1500000000)]
        public int Number { get; set; }

        [Required]
        public string IssueDate { get; set; } = null!;

        [Required]
        public string DueDate { get; set; } = null!;

        public decimal Amount { get; set; }

        [Required]
        public string CurrencyType { get; set; } = null!;

        public int ClientId { get; set; }
    }
}
