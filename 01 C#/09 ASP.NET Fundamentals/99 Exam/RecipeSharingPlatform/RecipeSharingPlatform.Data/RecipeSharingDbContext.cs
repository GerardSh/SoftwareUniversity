using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data.Models;
using System.Reflection;

namespace RecipeSharingPlatform.Data
{
    public class RecipeSharingDbContext : IdentityDbContext
    {
        public RecipeSharingDbContext(DbContextOptions<RecipeSharingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; } = null!;

        public virtual DbSet<Category> Categories { get; set; } = null!;

        public virtual DbSet<UserRecipe> UsersRecipes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
