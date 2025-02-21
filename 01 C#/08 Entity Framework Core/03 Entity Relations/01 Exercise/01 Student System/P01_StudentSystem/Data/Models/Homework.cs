using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    [Table("Homeworks")]
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Unicode(false)]
        public string Content { get; set; } = null!;

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;
    }
}
