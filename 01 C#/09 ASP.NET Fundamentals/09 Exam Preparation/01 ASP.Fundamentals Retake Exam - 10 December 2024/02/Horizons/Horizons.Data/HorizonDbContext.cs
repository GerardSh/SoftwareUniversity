namespace Horizons.Data
{
    using Horizons.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class HorizonDbContext : IdentityDbContext
    {
        public HorizonDbContext(DbContextOptions<HorizonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Destination> Destinations { get; set; } = null!;

        public virtual DbSet<Terrain> Terrains { get; set; } = null!;

        public virtual DbSet<UserDestination> UsersDestinations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
