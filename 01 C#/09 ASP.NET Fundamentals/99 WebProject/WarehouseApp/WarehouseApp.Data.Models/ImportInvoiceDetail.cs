using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Details of the import invoice")]
    public class ImportInvoiceDetail
    {
        [Comment("Import invoice detail identifier")]
        public Guid Id { get; set; }

        [Comment("Foreign key to the ImportInvoice")]
        public Guid ImportInvoiceId { get; set; }

        public virtual required ImportInvoice ImportInvoice { get; set; }

        [Comment("Foreign key to the Product")]
        public Guid ProductId { get; set; }

        public virtual required Product Product { get; set; }

        [Comment("Quantity of the product in this import invoice detail")]
        public int Quantity { get; set; }

        [Comment("Unit price of the product in this import invoice detail, optional")]
        public decimal? UnitPrice { get; set; }

        public virtual ICollection<ExportInvoiceDetail> ExportInvoicesPerProduct { get; set; }
            = new HashSet<ExportInvoiceDetail>();
    }
}
