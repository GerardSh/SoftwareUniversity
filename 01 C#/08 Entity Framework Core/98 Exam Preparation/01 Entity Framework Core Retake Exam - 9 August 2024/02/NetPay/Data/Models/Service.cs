using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string ServiceName { get; set; } = null!;

        public ICollection<Expense> Expenses { get; set; }
            = new HashSet<Expense>();

        public ICollection<SupplierService> SuppliersServices { get; set; }
            = new HashSet<SupplierService>();
    }
}
