using BookShop.Data;

namespace BookShop
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using BookShopContext context = new BookShopContext();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Db Creation was successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Db Creation failed! - {e.Message}");
            }
        }
    }
}
