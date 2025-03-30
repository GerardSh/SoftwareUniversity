using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; } = null!;

        public DateTime SentAt { get; set; }

        public MessageStatus Status { get; set; }

        [ForeignKey(nameof(Conversation))]
        public int ConversationId { get; set; }

        public Conversation Conversation { get; set; } = null!;

        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }

        public User Sender { get; set; } = null!;
    }
}
