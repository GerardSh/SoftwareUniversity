using Horizons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Horizons.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Destination> Destinations { get; set; } = null!;

        public virtual DbSet<Terrain> Terrains { get; set; } = null!;

        public virtual DbSet<UserDestination> UsersDestinations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Destination>()
                .HasOne(d => d.Terrain)
                .WithMany(t => t.Destinations)
                .HasForeignKey(d => d.TerrainId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Destination>()
                .HasQueryFilter(d => !d.IsDeleted);

            builder.Entity<UserDestination>()
                .HasKey(ud => new { ud.DestinationId, ud.UserId });

            builder.Entity<UserDestination>()
                .HasOne(ud => ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserDestination>()
                .HasOne(ud => ud.User)
                .WithMany()
                .HasForeignKey(ud => ud.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            var defaultUser = new IdentityUser
            {
                Id = "7699db7d-964f-4782-8209-d76562e0fece",
                UserName = "admin@horizons.com",
                NormalizedUserName = "ADMIN@HORIZONS.COM",
                Email = "admin@horizons.com",
                NormalizedEmail = "ADMIN@HORIZONS.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@horizons.com" },
                    "Admin123!")
            };
            builder.Entity<IdentityUser>().HasData(defaultUser);

            builder.Entity<Terrain>()
                .HasData(
                    new Terrain { Id = 1, Name = "Mountain" },
                    new Terrain { Id = 2, Name = "Beach" },
                    new Terrain { Id = 3, Name = "Forest" },
                    new Terrain { Id = 4, Name = "Plain" },
                    new Terrain { Id = 5, Name = "Urban" },
                    new Terrain { Id = 6, Name = "Village" },
                    new Terrain { Id = 7, Name = "Cave" },
                    new Terrain { Id = 8, Name = "Canyon" }
                );

            builder.Entity<Destination>().HasData(
        new Destination
        {
            Id = 1,
            Name = "Rila Monastery",
            Description = "A stunning historical landmark nestled in the Rila Mountains.",
            ImageUrl = "https://img.etimg.com/thumb/msid-112831459,width-640,height-480,imgsize-2180890,resizemode-4/rila-monastery-bulgaria.jpg",
            PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
            PublishedOn = DateTime.Now,
            TerrainId = 1,
            IsDeleted = false
        },
        new Destination
        {
            Id = 2,
            Name = "Durankulak Beach",
            Description = "The sand at Durankulak Beach showcases a pristine golden color, creating a beautiful contrast against the azure waters of the Black Sea.",
            ImageUrl = "https://travelplanner.ro/blog/wp-content/uploads/2023/01/durankulak-beach-1-850x550.jpg.webp",
            PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
            PublishedOn = DateTime.Now,
            TerrainId = 2,
            IsDeleted = false
        },
        new Destination
        {
            Id = 3,
            Name = "Devil's Throat Cave",
            Description = "A mysterious cave located in the Rhodope Mountains.",
            ImageUrl = "https://detskotobnr.binar.bg/wp-content/uploads/2017/11/Diavolsko_garlo_17.jpg",
            PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
            PublishedOn = DateTime.Now,
            TerrainId = 7,
            IsDeleted = false
        }
    );
        }
    }
}
