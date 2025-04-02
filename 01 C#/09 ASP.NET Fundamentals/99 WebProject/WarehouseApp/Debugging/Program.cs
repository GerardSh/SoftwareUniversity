using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;

namespace Debugging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the configuration
            var connectionString = "";

            // Set up DbContext with the connection string
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Instantiate the DbContext with the connection string
            var dbContext = new WarehouseDbContext(optionsBuilder.Options);

            // Ensure the database is created
            dbContext.Database.EnsureCreated();  // Create the database if it doesn't exist

            Console.WriteLine("Database created (if not already present).");
        }
    }
}
