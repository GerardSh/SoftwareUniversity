using GameZone.Data;

namespace GameZone.Models
{
    public class GameViewModel
    {
        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime ReleasedOn { get; set; }

        public int GenreId { get; set; }

        public List<string> Genres { get; set; } 
            = new List<string>();
    }
}
