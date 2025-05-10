using GameZone.Data;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ModelConstants.Game;

namespace GameZone.Models
{
    public class GameViewModel
    {
        [Required]
        [StringLength(GameMaxTitleLength, MinimumLength = GameMinTitleLength)]
        public string Title { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(GameMaxDescriptionLength, MinimumLength = GameMinDescriptionLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ReleasedOn { get; set; } = DateTime.Today.ToString(GameReleasedOnDateFormat);

        [Required]
        public int GenreId { get; set; }

        [Required]
        public List<Genre> Genres { get; set; } 
            = new List<Genre>();
    }
}
