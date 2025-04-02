using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Details for export invoices")]
    public class ExportInvoiceDetail
    {
        [Comment("Export invoice detail identifier")]
        public Guid Id { get; set; }

        [Comment("Foreign key to the ExportInvoice")]
        public Guid ExportInvoiceId { get; set; }

        public virtual required ExportInvoice ExportInvoice { get; set; }

        [Comment("Foreign key to the ImportInvoiceDetail")]
        public Guid ImportInvoiceDetailId { get; set; }

        public virtual required ImportInvoiceDetail ImportInvoiceDetail { get; set; }

        [Comment("Quantity of the product in this export invoice detail")]
        public int Quantity { get; set; }

        [Comment("Unit price of the product in this export invoice detail")]
        public decimal? UnitPrice { get; set; }

    }
}
