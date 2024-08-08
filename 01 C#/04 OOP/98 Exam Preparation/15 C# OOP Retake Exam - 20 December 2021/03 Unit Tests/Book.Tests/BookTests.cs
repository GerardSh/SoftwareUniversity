namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class BookTests
    {
        Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book("name", "author");
        }

        [Test]
        public void ConstructorShouldCreateObject()
        {
            Assert.IsNotNull(book);
            Assert.Throws<ArgumentException>(() => new Book(string.Empty, "author"));
            Assert.Throws<ArgumentException>(() => new Book(null, "author"));
            Assert.That(book.BookName, Is.EqualTo("name"));

            Assert.Throws<ArgumentException>(() => new Book("name", string.Empty));
            Assert.Throws<ArgumentException>(() => new Book("name", null));
            Assert.That(book.Author, Is.EqualTo("author"));

            Assert.That(book.FootnoteCount, Is.EqualTo(0));
        }

        [Test]
        public void AddFootnoteMethodShouldWorkCorrectly()
        {
            Assert.That(book.FootnoteCount, Is.EqualTo(0));

            book.AddFootnote(1, "text");

            Assert.That(book.FootnoteCount, Is.EqualTo(1));

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "text"));

            book.AddFootnote(2, "text");

            Assert.That(book.FootnoteCount, Is.EqualTo(2));
        }

        [Test]
        public void FindFootnoteMethodShouldWorkCorrectly()
        {
            book.AddFootnote(1, "text");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2));

            string result = book.FindFootnote(1);

            Assert.That(result, Is.EqualTo($"Footnote #1: text"));
        }

        [Test]
        public void AlterFootnoteMethodShouldWorkCorrectly()
        {
            book.AddFootnote(1, "text");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2, "new text"));

            book.AlterFootnote(1, "new text");

            string result = book.FindFootnote(1);

            Assert.That(result, Is.EqualTo($"Footnote #1: new text"));
        }
    }
}