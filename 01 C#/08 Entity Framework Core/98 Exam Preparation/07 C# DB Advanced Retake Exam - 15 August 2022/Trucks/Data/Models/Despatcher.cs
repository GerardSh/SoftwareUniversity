using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public string Position { get; set; } = null!;

        public virtual ICollection<Truck> Trucks { get; set; }
            = new HashSet<Truck>();
    }
}
