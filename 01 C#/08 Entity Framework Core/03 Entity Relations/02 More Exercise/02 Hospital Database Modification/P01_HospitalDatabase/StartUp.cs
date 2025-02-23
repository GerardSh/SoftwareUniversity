using System;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    class StartUp
    {
        static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using HospitalContext dbContex = new HospitalContext();

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