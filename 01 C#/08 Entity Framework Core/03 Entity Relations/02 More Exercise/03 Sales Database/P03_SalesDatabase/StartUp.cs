using P03_SalesDatabase.Data;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using SalesContext dbContex = new SalesContext();

                dbContex.Database.EnsureDeleted();
                dbContex.Database.EnsureCreated();

                Console.WriteLine("Db Creation was successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Db Creation failed! - {e.Message}");
            }
        }
    }
}