using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "CHAR(14)")]
        public string PhoneNumber { get; set; } = null!;

        public bool IsNonStop { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
            = new HashSet<Medicine>();
    }
}
