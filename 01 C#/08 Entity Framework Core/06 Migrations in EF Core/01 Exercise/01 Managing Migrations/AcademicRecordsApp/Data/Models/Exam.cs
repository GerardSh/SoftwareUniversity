namespace AcademicRecordsApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;

        [InverseProperty("Exam")]
        public virtual ICollection<Grade> Grades { get; set; }
            = new HashSet<Grade>();
    }
}