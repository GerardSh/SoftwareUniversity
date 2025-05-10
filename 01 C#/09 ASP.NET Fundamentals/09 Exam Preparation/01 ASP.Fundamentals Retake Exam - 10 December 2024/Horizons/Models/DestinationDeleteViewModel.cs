namespace Horizons.Models
{
    public class DestinationDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string PublisherId { get; set; } = null!;

        public string Publisher { get; set; } = null!;
    }
}
