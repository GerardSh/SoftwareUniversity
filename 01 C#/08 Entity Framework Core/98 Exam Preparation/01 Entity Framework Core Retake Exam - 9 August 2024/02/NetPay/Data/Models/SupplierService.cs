using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models
{
    public class SupplierService
    {
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; } = null!;

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;
    }
}
