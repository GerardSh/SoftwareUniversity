namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
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

            // Console.WriteLine(CountCopiesByAuthor(context));

            // Console.WriteLine(GetTotalProfitByCategory(context));

            // Console.WriteLine(GetMostRecentBooks(context));

            // IncreasePrices(context);

            // Console.WriteLine(RemoveBooks(context));
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

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"({b.Author.FirstName} {b.Author.LastName})"
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine($"{title.Title} {title.AuthorName}");
            }

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorCopies = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var author in authorCopies)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.BookCopies}");
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Sum = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Sum)
                .ThenBy(c => c.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Sum:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories

                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.
                            OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Take(3)
                            .Select(cb => new
                            {
                                cb.Book.Title,
                                cb.Book.ReleaseDate.Value.Year,
                            }).ToList()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                  .Where(b => b.ReleaseDate.HasValue
                           && b.ReleaseDate.Value.Year < 2010)
                  .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Length;
        }
    }
}
