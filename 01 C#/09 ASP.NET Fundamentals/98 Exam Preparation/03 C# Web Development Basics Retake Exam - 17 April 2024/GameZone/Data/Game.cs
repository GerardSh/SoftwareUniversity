using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Common.ModelConstants.Game;

namespace GameZone.Data
{
    public class Game
    {
        [Key]
        [Comment("Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameMaxTitleLength)]
        [Comment("Game title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GameMaxDescriptionLength)]
        [Comment("Description")]
        public string Description { get; set; } = null!;

        [Comment("The Url of the image")]
        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        [Comment("Identifier of the game Publisher")]
        public string PublisherId { get; set; } = null!;

        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("Release date")]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        [Comment("Game Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;

        public List<GamerGame> GamersGames { get; set; }
            = new List<GamerGame>();

        [Comment("Shows wether game is deleted or not")]
        public bool IsDeleted { get; set; }
    }
}
