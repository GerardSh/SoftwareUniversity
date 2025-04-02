using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Export invoices in the system")]
    public class ExportInvoice
    {
        [Comment("Export invoice identifier")]
        public Guid Id { get; set; }

        [Comment("Export invoice number")]
        public required string InvoiceNumber { get; set; }

        [Comment("Date of the export invoice")]
        public DateTime Date { get; set; }

        [Comment("Foreign key to the Client")]
        public Guid ClientId { get; set; }

        public virtual required Client Client { get; set; }

        public ICollection<ExportInvoiceDetail> ExportInvoicesDetails { get; set; }
            = new HashSet<ExportInvoiceDetail>();
    }
}
