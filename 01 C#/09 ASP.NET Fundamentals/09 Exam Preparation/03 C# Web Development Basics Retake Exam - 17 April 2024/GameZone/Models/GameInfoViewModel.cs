namespace GameZone.Models
{
    public class GameInfoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Genre { get; set; } = null!;

        public string ReleasedOn { get; set; } = null!;

        public string Publisher { get; set; } = null!;
    }
}
