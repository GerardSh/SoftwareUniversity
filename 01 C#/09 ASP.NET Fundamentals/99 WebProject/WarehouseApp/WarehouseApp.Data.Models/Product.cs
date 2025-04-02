using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Products available in the warehouse")]
    public class Product
    {
        [Comment("Product identifier")]
        public Guid Id { get; set; }

        [Comment("Name of the product")]
        public required string ProductName { get; set; }

        [Comment("Description of the product, optional")]
        public string? Description { get; set; }

        public virtual ICollection<ImportInvoiceDetail> ImportInvoicesDetails { get; set; }
            = new HashSet<ImportInvoiceDetail>();
    }
}
