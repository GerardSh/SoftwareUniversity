using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Data.Models
{
    [Comment("Warehouses in the system")]
    public class Warehouse
    {
        [Comment("Warehouse identifier")]
        public Guid Id { get; set; }

        [Comment("Warehouse address")]
        public required string Address { get; set; }

        [Comment("Warehouse size in square meters (m²)")]
        public double? Size { get; set; }

        [Comment("Shows the date of when the warehouse record was created")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Comment("Shows if warehouse is deleted")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<ImportInvoice> ImportInvoices { get; set; }
             = new HashSet<ImportInvoice>();
    }
}
