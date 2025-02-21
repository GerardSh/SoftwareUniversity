using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "char(10)")]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new List<StudentCourse>();

        public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
