using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class UserConversation
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Conversation))]
        public int ConversationId { get; set; }

        public Conversation Conversation { get; set; } = null!;
    }
}
