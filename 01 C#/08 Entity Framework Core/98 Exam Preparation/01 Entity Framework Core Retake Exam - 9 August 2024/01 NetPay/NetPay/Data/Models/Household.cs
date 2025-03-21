using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContactPerson { get; set; } = null!;

        [MaxLength(80)]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "Char(15)")]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Expense> Expenses { get; set; }
            = new HashSet<Expense>();
    }
}
