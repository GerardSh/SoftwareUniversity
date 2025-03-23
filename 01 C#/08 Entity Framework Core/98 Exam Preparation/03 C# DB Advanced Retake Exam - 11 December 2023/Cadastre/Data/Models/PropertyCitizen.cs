using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models
{
    public class PropertyCitizen
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        [Required]
        public virtual Property Property { get; set; } = null!;

        [ForeignKey(nameof(Citizen))]
        public int CitizenId { get; set; }

        [Required]
        public virtual Citizen Citizen { get; set; } = null!;
    }
}