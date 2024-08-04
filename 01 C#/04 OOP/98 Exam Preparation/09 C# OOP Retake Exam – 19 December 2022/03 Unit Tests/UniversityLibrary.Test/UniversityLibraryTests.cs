namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class UniversityLibraryTests
    {
        TextBook book;
        UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            book = new TextBook("title", "author", "category");
            library = new UniversityLibrary();
        }

        [Test]
        public void ContructorsShouldCreateObjects()
        {
            Assert.NotNull(book);
            Assert.NotNull(library);

            Assert.That(book.Title, Is.EqualTo("title"));
            Assert.That(book.Author, Is.EqualTo("author"));
            Assert.That(book.Category, Is.EqualTo("category"));
            Assert.That(book.InventoryNumber, Is.EqualTo(0));
            Assert.That(book.Holder, Is.EqualTo(null));

            var sb = new StringBuilder();

            sb.AppendLine($"Book: title - 0");
            sb.AppendLine($"Category: category");
            sb.AppendLine($"Author: author");

            Assert.That(book.ToString(), Is.EqualTo(sb.ToString().Trim()));

            book.Holder = "holder";
            book.InventoryNumber = 1;

            Assert.That(book.Holder, Is.EqualTo("holder"));
            Assert.That(book.InventoryNumber, Is.EqualTo(1));
            Assert.That(library.Catalogue.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddTextBookToLibrarykMethodShouldReturnCorrectValues()
        {
            Assert.That(library.Catalogue.Count, Is.EqualTo(0));
            Assert.That(book.InventoryNumber, Is.EqualTo(0));

            string result = library.AddTextBookToLibrary(book);

            Assert.That(library.Catalogue.Count, Is.EqualTo(1));
            Assert.That(book.InventoryNumber, Is.EqualTo(1));

            var sb = new StringBuilder();

            sb.AppendLine($"Book: title - 1");
            sb.AppendLine($"Category: category");
            sb.AppendLine($"Author: author");

            Assert.That(result, Is.EqualTo(sb.ToString().Trim()));
        }

        [Test]
        public void LoanTextBookMethodShouldReturnCorrectValues()
        {
            var book2 = new TextBook("title2", "author2", "category2");
            book2.Holder = "student";

            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);

            string result = library.LoanTextBook(2, "student");

            Assert.That(result, Is.EqualTo("student still hasn't returned title2!"));

            Assert.That(book.Holder, Is.EqualTo(null));

            result = library.LoanTextBook(1, "student");

            Assert.That(book.Holder, Is.EqualTo("student"));
            Assert.That(result, Is.EqualTo("title loaned to student."));
        }

        [Test]
        public void ReturnTextBookMethodShouldReturnCorrectValues()
        {
            var book2 = new TextBook("title2", "author2", "category2");

            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);

            library.LoanTextBook(1, "student");

            Assert.That(book.Holder, Is.EqualTo("student"));

            string result = library.ReturnTextBook(1);

            Assert.That(book.Holder, Is.EqualTo(string.Empty));
            Assert.That(result, Is.EqualTo("title is returned to the library."));
        }
    }
}