namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void DatabaseConstructorShouldCreateTheObjectSuccessfully()
        {
            Assert.That(database, Is.Not.Null, "Object is null.");
        }

        [Test]
        public void DatabaseConstructorShouldThrowArgumentExceptionIfMoreThan16ElementsAreGiven()
        {
            Person[] people = new Person[17];

            Assert.That(() => database = new Database(people), Throws.ArgumentException);
        }

        [Test]
        public void PersonConstructorShouldCreateTheObjectSuccessfully()
        {
            Person person = new Person(1L, "username");

            Assert.IsNotNull(person);
        }

        [Test]
        public void CountMethodShouldShowCorrectNumberOfEntries()
        {
            database.Add(new Person(1L, "username"));

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodShouldAddAnElementAtTheNextFreeCell()
        {
            database.Add(new Person(1L, "username"));

            Assert.That(database.Count, Is.EqualTo(1), "Add failed.");
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIf17thElementIsAdded()
        {
            Person[] people = GetPersonArray();
            database = new Database(people);

            Assert.That(() => database.Add(new Person(16L, "username16")), Throws.InvalidOperationException, "InvalidOperationException expected, but was not thrown.");
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfTwoUsersHaveTheSameUserName()
        {
            database.Add(new Person(1L, "username"));

            Assert.That(() => database.Add(new Person(2L, "username")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfTwoUsersHaveTheSameId()
        {
            database.Add(new Person(1L, "username"));

            Assert.That(() => database.Add(new Person(1L, "username2")), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethodShouldRemoveTheELementAtLastIndex()
        {
            database = new Database(GetPersonArray());

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(15), "Remove unsuccessful.");
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionIfNoElements()
        {
            database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException, "The collection is not empty.");
        }

        [Test]
        public void FindByUsernameMethodShouldThrowInvalidOperationExceptionIfNoUsernameWithSameCasingIsPresent()
        {
            database.Add(new Person(1L, "Username"));
            Assert.That(() => database.FindByUsername("username"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameMethodShouldFindTheUsernameWithTheCorrectCasing()
        {
            Person person = new Person(1L, "UserName");

            database.Add(person);

            Assert.That(person, Is.EqualTo(database.FindByUsername("UserName")));
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethodShouldThrowInvalidOperationExceptionIfParameterIsNull(string username)
        {
            Assert.That(() => database.FindByUsername(username), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameMethodShouldReturnThePersonWithTheSpecifiedName()
        {
            Person person = new Person(1L, "username");

            database.Add(person);
            database.Add(new Person(2L, "username2"));

            Assert.That(person, Is.EqualTo(database.FindByUsername("username")));
        }

        [Test]
        public void FindByIdMethodShouldReturnThePersonWithTheSpecifiedId()
        {
            Person person = new Person(1L, "username");

            database.Add(person);
            database.Add(new Person(2L, "username2"));

            Assert.That(person, Is.EqualTo(database.FindById(1)));
        }

        [Test]
        public void FindByIdMethodShouldThrowArgumentOutOfRangeExceptionIfIdIsNegativeNumber()
        {
            database.Add(new Person(1L, "username"));

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void FindByIdMethodShouldThrowInvalidOperationExceptionIfNoUserIsFound()
        {
            database.Add(new Person(1L, "username"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }

        public Person[] GetPersonArray()
        {
            Person[] people = new Person[16];

            for (long i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"username{i}");
                people[i] = person;
            }

            return people;
        }
    }
}