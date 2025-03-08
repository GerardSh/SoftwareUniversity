namespace AcademicRecordsApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [InverseProperty("Student")]
        public virtual ICollection<Grade> Grades { get; set; }
            = new HashSet<Grade>();

        public virtual ICollection<StudentCourse> Courses { get; set; }
            = new HashSet<StudentCourse>();
    }
}