using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [RegularExpression(@"^[A-Za-z0-9 .-]{3,40}$")]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; } = null!;

        public int Trophies { get; set; }

        public HashSet<int> Footballers { get; set; } = null!;
    }
}
