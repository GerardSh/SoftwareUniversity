using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data
{
    public class GamerGame
    {
        [Required]
        [ForeignKey(nameof(Game))]
        [Comment("Identifier of the game")]
        public int GameId { get; set; }

        public Game Game { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Gamer))]
        [Comment("Identifier of the gamer")]
        public string GamerId { get; set; } = null!;

        public IdentityUser Gamer { get; set; } = null!;
    }
}