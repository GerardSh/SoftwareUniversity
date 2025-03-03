namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            // Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));

            // Console.WriteLine(GetGoldenBooks(context));

            // Console.WriteLine(GetBooksByPrice(context));

            // Console.WriteLine(GetBooksNotReleasedIn(context, 1998));

            // Console.WriteLine(GetBooksByCategory(context, "horror mystery drama"));

            // Console.WriteLine(GetBooksReleasedBefore(context, "12-04-1992"));

            // Console.WriteLine(GetAuthorNamesEndingIn(context, "e"));

            // Console.WriteLine(GetBookTitlesContaining(context, "sK"));

            // Console.WriteLine(GetBooksByAuthor(context, "R"));

            // Console.WriteLine(CountBooks(context, 12));
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
                .OrderBy(b => b)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books
                .Where(b => b.EditionType == EditionType.Gold
                            && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            
            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue
                            && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] searchCategories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);


            var titles = context.Books
                 .Where(b => b.BookCategories
                            .Any(bc => searchCategories
                            .Contains(bc.Category.Name.ToLower())))
                 .OrderBy(b => b.Title)
                 .Select(b => b.Title)
                 .ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime inputDateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue
                       && b.ReleaseDate.Value.Date < inputDateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName != null && a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, titles);
        }
    }
}
