namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        int[] integersToInsert = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(integersToInsert);
        }

        [Test]
        public void DatabaseConstructorShouldCreateTheObjectSuccessfully()
        {
            Assert.That(database, Is.Not.Null, "Object is null");
        }

        [Test]
        public void CountShouldHave16Entries()
        {
            Assert.That(database.Count, Is.EqualTo(16));
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        public void AddShouldAddAnElementAtTheNextFreeCell(int[] integers)
        {
            database = new Database(integers);

            database.Add(5);

            Assert.That(database.Count, Is.EqualTo(integers.Length + 1), "Add failed.");
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionIf17thElementIsAdded()
        {
            Assert.That(() => database.Add(1), Throws.InvalidOperationException, "No collection was not full.");
        }

        [Test]
        public void RemoveShouldRemoveTheELementAtLastIndex()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(15), "Remove unsuccessful.");
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionIfNoElements()
        {
            database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException, "The collection is not empty.");
        }

        [Test]
        public void FetchShouldReturnTheElementsAsAnArray()
        {
            int[] dataBaseCopy = database.Fetch();

            CollectionAssert.AreEqual(integersToInsert, dataBaseCopy, "Fetch failed.");
        }
    }
}
