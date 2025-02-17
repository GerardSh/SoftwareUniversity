using Microsoft.EntityFrameworkCore;

namespace BlogDemo
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasKey(b => b.BlogId);

            modelBuilder.Entity<Blog>()
                .ToTable("Blogs", "blg"); // Optionally creating a new schema named "blg"

            modelBuilder.Entity<Blog>()
                .Property(b => b.Name)
                .HasColumnName("BlogName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Blog>()
                 .Property(b => b.Description)
                 .HasColumnType("NVARCHAR")
                 .HasMaxLength(500);

            modelBuilder.Entity<Blog>()
                .Property(b => b.Created)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Blog>()
                .Property(b => b.LastUpdated)
                .ValueGeneratedOnUpdate();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BlogDb;User Id=sa;Password=r3F4iJbYas&#aRj^bmjj;TrustServerCertificate=true;");
            }
        }
    }
}