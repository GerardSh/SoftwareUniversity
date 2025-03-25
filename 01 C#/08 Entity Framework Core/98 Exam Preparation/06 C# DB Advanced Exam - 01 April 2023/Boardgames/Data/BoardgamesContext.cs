namespace Boardgames.Data
{
    using Boardgames.Data.Models;
    using Microsoft.EntityFrameworkCore;
    
    public class BoardgamesContext : DbContext
    {
        public BoardgamesContext()
        { 
        }

        public BoardgamesContext(DbContextOptions options)
            : base(options) 
        {
        }

        public virtual DbSet<Boardgame> Boardgames { get; set; } = null!;

        public virtual DbSet<Creator> Creators { get; set; } = null!;

        public virtual DbSet<Seller> Sellers { get; set; } = null!;

        public virtual DbSet<BoardgameSeller> BoardgamesSellers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardgameSeller>().HasKey(bs => new { bs.SellerId, bs.BoardgameId });
        }
    }
}
