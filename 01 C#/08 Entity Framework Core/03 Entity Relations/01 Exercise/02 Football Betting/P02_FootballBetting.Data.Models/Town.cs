namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Town;
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
