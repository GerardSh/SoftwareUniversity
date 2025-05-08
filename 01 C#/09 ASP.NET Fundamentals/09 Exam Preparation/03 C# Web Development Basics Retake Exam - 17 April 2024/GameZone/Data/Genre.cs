using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Data
{
    public class Genre
    {
        [Key]
        [Comment("Genre Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [Comment("Genre name")]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; }
            = new List<Game>();
    }
}