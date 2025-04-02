using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Import invoices in the system")]
    public class ImportInvoice
    {
        [Comment("Import invoice identifier")]
        public Guid Id { get; set; }

        [Comment("Invoice number for the import invoice")]
        public required string InvoiceNumber { get; set; }

        [Comment("Date of the import invoice")]
        public DateTime Date { get; set; }

        [Comment("Foreign key to the Client")]
        public virtual Guid ClientId { get; set; }

        public virtual required Client Client { get; set; }

        [Comment("Foreign key to the Warehouse")]
        public Guid WarehouseId { get; set; }

        public virtual required Warehouse Warehouse { get; set; }

        public virtual ICollection<ImportInvoiceDetail> ImportInvoicesDetails { get; set; }
            = new HashSet<ImportInvoiceDetail>();
    }
}
