using P02_FootballBetting.Data;

namespace P02_FootballBetting
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using FootballBettingContext dbContex = new FootballBettingContext();

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
