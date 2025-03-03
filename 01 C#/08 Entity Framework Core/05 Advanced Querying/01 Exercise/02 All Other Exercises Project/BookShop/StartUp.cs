namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            bool isEnumValid = Enum
                .TryParse(command, true, out AgeRestriction ageRestriction);

            if (!isEnumValid)
            {
                Environment.Exit(0);
            }

            var titles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b =>  b.Title)
                .OrderBy(b=> b)
                .ToArray();

            return string.Join(Environment.NewLine, titles);
        }
    }
}
