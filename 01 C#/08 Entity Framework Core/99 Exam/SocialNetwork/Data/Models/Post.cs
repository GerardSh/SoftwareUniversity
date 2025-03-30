using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        public User Creator { get; set; } = null!;
    }
}
