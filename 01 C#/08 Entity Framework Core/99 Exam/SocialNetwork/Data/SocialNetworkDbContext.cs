using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkDbContext : DbContext
    {
        private const string ConnectionString = @"Server=.;Database=SocialNetwork;User Id=sa;Password=r3F4iJbYas&#aRj^bmjj;TrustServerCertificate=true;";

        public SocialNetworkDbContext()
        {

        }

        public SocialNetworkDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Conversation> Conversations { get; set; } = null!;

        public virtual DbSet<UserConversation> UsersConversations { get; set; } = null!;

        public virtual DbSet<Post> Posts { get; set; } = null!;

        public virtual DbSet<Friendship> Friendships { get; set; } = null!;

        public virtual DbSet<Message> Messages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserConversation>().HasKey(uc => new { uc.UserId, uc.ConversationId });

            modelBuilder.Entity<Friendship>()
       .HasKey(f => new { f.UserOneId, f.UserTwoId });

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.UserOne)
                .WithMany()
                .HasForeignKey(f => f.UserOneId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.UserTwo)
                .WithMany()
                .HasForeignKey(f => f.UserTwoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "john_doe", Email = "john@example.com", Password = "Pass123" },
                new User { Id = 2, Username = "jane_doe", Email = "jane@example.com", Password = "Secure456" },
                new User { Id = 3, Username = "alex_smith", Email = "alex_sm@mail.com", Password = "TestPass789" },
                new User { Id = 4, Username = "sara_miller", Email = "sara_m@mail.com", Password = "MillerPass99" },
                new User { Id = 5, Username = "michael_brown", Email = "michael_b@mail.com", Password = "BrownSecret88" },
                new User { Id = 6, Username = "emily_white", Email = "emily_w@mail.com", Password = "EmilyW12345" },
                new User { Id = 7, Username = "david_jackson", Email = "david_j@mail.com", Password = "JacksonD777" },
                new User { Id = 8, Username = "olivia_taylor", Email = "olivia_t@mail.com", Password = "TaylorOlivia12" },
                new User { Id = 9, Username = "william_clark", Email = "william_c@mail.com", Password = "ClarkWill99" }
                );

            modelBuilder.Entity<Conversation>().HasData(
                new Conversation { Id = 1, Title = "Project Discussion", StartedAt = new DateTime(2025, 02, 24, 14, 30, 00) },
                new Conversation { Id = 2, Title = "Weekend Plans", StartedAt = new DateTime(2025, 02, 22, 18, 00, 00) },
                new Conversation { Id = 3, Title = "Team Meeting", StartedAt = new DateTime(2025, 02, 23, 10, 15, 00) },
                new Conversation { Id = 4, Title = "Movie Night", StartedAt = new DateTime(2025, 01, 31, 16, 23, 00) },
                new Conversation { Id = 5, Title = "BackUp Group", StartedAt = new DateTime(2024, 08, 10, 20, 11, 00) },
                new Conversation { Id = 6, Title = "Study Group", StartedAt = new DateTime(2024, 08, 10, 14, 00, 00) }
                );

            modelBuilder.Entity<UserConversation>().HasData(
                new UserConversation { UserId = 1, ConversationId = 1 },
                new UserConversation { UserId = 2, ConversationId = 1 },
                new UserConversation { UserId = 3, ConversationId = 1 },
                new UserConversation { UserId = 7, ConversationId = 1 },
                new UserConversation { UserId = 9, ConversationId = 1 },

                new UserConversation { UserId = 2, ConversationId = 2 },
                new UserConversation { UserId = 6, ConversationId = 2 },
                new UserConversation { UserId = 8, ConversationId = 2 },

                new UserConversation { UserId = 1, ConversationId = 3 },
                new UserConversation { UserId = 2, ConversationId = 3 },
                new UserConversation { UserId = 3, ConversationId = 3 },
                new UserConversation { UserId = 4, ConversationId = 3 },
                new UserConversation { UserId = 5, ConversationId = 3 },
                new UserConversation { UserId = 6, ConversationId = 3 },
                new UserConversation { UserId = 7, ConversationId = 3 },
                new UserConversation { UserId = 8, ConversationId = 3 },
                new UserConversation { UserId = 9, ConversationId = 3 },

                new UserConversation { UserId = 1, ConversationId = 4 },
                new UserConversation { UserId = 2, ConversationId = 4 },

                new UserConversation { UserId = 4, ConversationId = 5 },
                new UserConversation { UserId = 5, ConversationId = 5 },
                new UserConversation { UserId = 9, ConversationId = 5 },

                new UserConversation { UserId = 2, ConversationId = 6 },
                new UserConversation { UserId = 4, ConversationId = 6 },
                new UserConversation { UserId = 6, ConversationId = 6 },
                new UserConversation { UserId = 8, ConversationId = 6 }
                );

            modelBuilder.Entity<Friendship>().HasData(
                new Friendship { UserOneId = 1, UserTwoId = 2 },
                new Friendship { UserOneId = 1, UserTwoId = 3 },
                new Friendship { UserOneId = 1, UserTwoId = 7 },
                new Friendship { UserOneId = 1, UserTwoId = 9 },
                new Friendship { UserOneId = 2, UserTwoId = 4 },
                new Friendship { UserOneId = 2, UserTwoId = 5 },
                new Friendship { UserOneId = 2, UserTwoId = 3 },
                new Friendship { UserOneId = 2, UserTwoId = 8 },
                new Friendship { UserOneId = 3, UserTwoId = 5 },
                new Friendship { UserOneId = 3, UserTwoId = 6 },
                new Friendship { UserOneId = 3, UserTwoId = 4 },
                new Friendship { UserOneId = 3, UserTwoId = 8 },
                new Friendship { UserOneId = 4, UserTwoId = 1 },
                new Friendship { UserOneId = 4, UserTwoId = 6 },
                new Friendship { UserOneId = 5, UserTwoId = 7 },
                new Friendship { UserOneId = 5, UserTwoId = 8 },
                new Friendship { UserOneId = 6, UserTwoId = 8 },
                new Friendship { UserOneId = 7, UserTwoId = 9 },
                new Friendship { UserOneId = 8, UserTwoId = 9 },
                new Friendship { UserOneId = 9, UserTwoId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
