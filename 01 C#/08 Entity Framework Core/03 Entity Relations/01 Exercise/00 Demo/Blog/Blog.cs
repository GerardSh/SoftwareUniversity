using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo
{
    [Table("Blogs", Schema = "blg")]
    [Index(nameof(Name), IsUnique = true, Name = "ix_Blogs_Name_Unique")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("BlogName", TypeName = "NVARCHAR")]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public  DateTime LastUpdated { get; set; }
    }
}
