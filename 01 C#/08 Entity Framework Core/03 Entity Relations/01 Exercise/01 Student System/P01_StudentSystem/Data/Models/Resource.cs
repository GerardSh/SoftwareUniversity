using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Utilities;

namespace P01_StudentSystem.Data.Models
{
    [Table("Resources")]
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Unicode(false)]
        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;
    }
}