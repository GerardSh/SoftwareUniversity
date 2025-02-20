using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        const string ConnectionString = "Server=.;Database=BlogDb;User Id=sa;Password=r3F4iJbYas&#aRj^bmjj;TrustServerCertificate=true;";

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Student> Courses { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsConcurrencyToken(false);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Sets the db in use
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
