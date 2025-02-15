using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstDemo.Infrastructure.Data.Models
{
    public partial class Address
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string AddressText { get; set; } = null!;
        [Column("TownID")]
        public int? TownId { get; set; }

        [ForeignKey("TownId")]
        [InverseProperty("Addresses")]
        public virtual Town? Town { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
