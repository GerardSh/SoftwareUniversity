using Cadastre.Data.Enumerations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "Char(8)")]
        public string PostalCode { get; set; } = null!;

        public virtual Region Region { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
            = new HashSet<Property>();
    }
}
