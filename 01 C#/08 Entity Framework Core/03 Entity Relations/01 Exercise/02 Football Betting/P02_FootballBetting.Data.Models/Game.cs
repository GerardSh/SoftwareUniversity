namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Game;

    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public short HomeTeamGoals { get; set; }

        public short AwayTeamGoals { get; set; }

        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DraweBetRate { get; set; }

        public DateTime? DateTime { get; set; }

        [MaxLength(GameResultMaxLength)]
        public string? Result { get; set; }
    }
}
