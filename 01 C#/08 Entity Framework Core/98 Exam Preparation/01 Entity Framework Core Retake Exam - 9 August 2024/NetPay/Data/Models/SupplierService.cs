using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models
{
    public class SupplierService
    {
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; } = null!;
    }
}
