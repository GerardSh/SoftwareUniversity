using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstDemo.Infrastructure.Data.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("TownID")]
        public int TownId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty("Town")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
