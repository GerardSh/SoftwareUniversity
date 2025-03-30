using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Title { get; set; } = null!;

        public DateTime StartedAt { get; set; }

        public ICollection<Message> Messages { get; set; }
            = new HashSet<Message>();

        public ICollection<UserConversation> UsersConversations { get; set; }
            = new HashSet<UserConversation>();
    }
}
