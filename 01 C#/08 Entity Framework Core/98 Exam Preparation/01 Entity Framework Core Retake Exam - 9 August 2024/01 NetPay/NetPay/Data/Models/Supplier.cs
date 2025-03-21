using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<SupplierService> SuppliersServices { get; set; }
            = new HashSet<SupplierService>();
    }
}
