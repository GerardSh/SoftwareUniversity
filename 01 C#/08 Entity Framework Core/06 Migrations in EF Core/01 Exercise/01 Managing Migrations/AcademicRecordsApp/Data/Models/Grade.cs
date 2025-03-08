namespace AcademicRecordsApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Value { get; set; }

        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        [InverseProperty("Grades")]
        public virtual Exam Exam { get; set; } = null!;

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        [InverseProperty("Grades")]
        public virtual Student Student { get; set; } = null!;
    }
}
