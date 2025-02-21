namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        // const string ConnectionString = "Server=.;Database=StudentSystemDb;User Id=sa;Password=r3F4iJbYas&#aRj^bmjj;TrustServerCertificate=true;";

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Sets the db in use
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}
    }
}