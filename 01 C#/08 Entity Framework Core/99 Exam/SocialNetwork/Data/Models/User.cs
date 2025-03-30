using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public ICollection<Post> Posts { get; set; }
            = new HashSet<Post>();

        public ICollection<Message> Messages { get; set; }
            = new HashSet<Message>();

        public ICollection<UserConversation> UsersConversations { get; set; } 
            = new HashSet<UserConversation>();
    }
}
