using Artillery.Data.Models.Enums;
using Artillery.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunDto
    {
        public int ManufacturerId { get; set; }

        [Range(100, 1350000)]
        public int GunWeight { get; set; }

        [Range(2.0, 35.0)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(1, 100000)]
        public int Range { get; set; }

        [Required]
        public string GunType { get; set; } = null!;

        public int ShellId { get; set; }

        public HashSet<ImportCountryGunDto> Countries { get; set; } = null!;
    }
}
