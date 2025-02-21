namespace P02_FootballBetting.Data.Models
{
    using P02_FootballBetting.Data.Models.Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public Predition Prediction { get; set; }

        public DateTime DateTime { get; set; }
    }
}
