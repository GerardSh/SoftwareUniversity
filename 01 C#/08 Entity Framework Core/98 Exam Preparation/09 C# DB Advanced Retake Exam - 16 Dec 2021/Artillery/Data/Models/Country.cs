using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string CountryName { get; set; } = null!;

        public int ArmySize { get; set; }

        public ICollection<CountryGun> CountriesGuns { get; set; }
            = new HashSet<CountryGun>();
    }
}
