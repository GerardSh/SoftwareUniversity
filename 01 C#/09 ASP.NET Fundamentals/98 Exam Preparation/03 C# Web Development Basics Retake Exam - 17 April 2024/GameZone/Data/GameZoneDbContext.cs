using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<GamerGame> GamersGames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GamerGame>(options =>
            {
                base.OnModelCreating(builder);

                options
                .HasKey(gg => new { gg.GamerId, gg.GameId });

                options
                .HasOne(gg => gg.Game)
                .WithMany(g => g.GamersGames)
                .HasForeignKey(gg => gg.GameId)
                .OnDelete(DeleteBehavior.NoAction);

                options
                .HasOne(gg => gg.Gamer)
                .WithMany()
                .HasForeignKey(gg => gg.GamerId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder
                .Entity<Genre>()
                .HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Fighting" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Racing" },
                new Genre { Id = 6, Name = "Strategy" });
        }
    }
}
