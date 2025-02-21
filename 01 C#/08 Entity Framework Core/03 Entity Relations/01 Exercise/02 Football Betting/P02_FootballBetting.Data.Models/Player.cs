namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Player;

    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(PlayerNameMaxLength)]
        public string Name { get; set; } = null!;

        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }
    }
}
