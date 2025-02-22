namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P02_FootballBetting.Data.Models;

    using static Common.ApplicationCommonConfiguration;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<PlayerStatistic> PlayersStatistics { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            // Just for the exercise
            // bool has default value of false, but if you wish to change it...
            modelBuilder
                .Entity<Player>()
                .Property(p => p.IsInjured)
                .HasDefaultValue(false);

            modelBuilder
                .Entity<Team>(t =>
                {
                    t.HasOne(t => t.PrimaryKitColor)
                     .WithMany(c => c.PrimaryKitTeams)
                     .HasForeignKey(t => t.PrimaryKitColorId)
                     .OnDelete(DeleteBehavior.Restrict);

                    t.HasOne(t => t.SecondaryKitColor)
                     .WithMany(c => c.SecondaryKitTeams)
                     .HasForeignKey(t => t.SecondaryKitColorId)
                     .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Game>(g =>
                {
                    g.HasOne(g => g.HomeTeam)
                     .WithMany(t => t.HomeGames)
                     .HasForeignKey(g => g.HomeTeamId)
                     .OnDelete(DeleteBehavior.Restrict);

                    g.HasOne(g => g.AwayTeam)
                     .WithMany(t => t.AwayGames)
                     .HasForeignKey(g => g.AwayTeamId)
                     .OnDelete(DeleteBehavior.Restrict);
                });


            modelBuilder
            .Entity<Player>()
            .HasOne(p => p.Town)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TownId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
