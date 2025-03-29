using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        [Key]
        public int Id { get; set; }

        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(30)]
        public string Caliber { get; set; } = null!;

        public ICollection<Gun> Guns { get; set; }
            = new HashSet<Gun>();
    }
}
