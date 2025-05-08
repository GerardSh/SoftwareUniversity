using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data
{
    public class GamerGame
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public Game Game { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Gamer))]
        public string GamerId { get; set; } = null!;

        public IdentityUser Gamer { get; set; } = null!;
    }
}