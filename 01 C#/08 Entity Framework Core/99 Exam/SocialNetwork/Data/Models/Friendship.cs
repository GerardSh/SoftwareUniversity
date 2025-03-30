using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class Friendship
    {
        [ForeignKey(nameof(UserOne))]
        public int UserOneId { get; set; }

        public User UserOne { get; set; } = null!;

        [ForeignKey(nameof(UserTwo))]
        public int UserTwoId { get; set; }

        public User UserTwo { get; set; } = null!;
    }
}
