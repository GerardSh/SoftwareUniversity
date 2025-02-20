using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [MaxLength(80)]
        [Required]
        [Unicode]
        public string Name { get; set; } = null!;

        [Unicode]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int MyProperty { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = new List<StudentCourse>();

        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
