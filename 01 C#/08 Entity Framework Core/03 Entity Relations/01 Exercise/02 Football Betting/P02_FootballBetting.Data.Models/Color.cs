namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Color;

    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        [MaxLength(ColorNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
