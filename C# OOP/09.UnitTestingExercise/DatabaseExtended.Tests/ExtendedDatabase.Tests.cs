using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int MaxCapacity = 16;
        private ExtendedDatabase.ExtendedDatabase extendedDb;

        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Constructor_ThrowsArgumentEx_WnehCapacityIsExceeded()
        {
            var users = new ExtendedDatabase.Person[MaxCapacity + 1];

            for (int i = 0; i < users.Length; i++)
            {
                users[i] = new ExtendedDatabase.Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            { extendedDb = new ExtendedDatabase.ExtendedDatabase(users); });
        }

        [Test]
        public void Add_IncreaseCount_WhenValidUserIsAdded()
        {
            AddUsersToExtendedDb(2);

            int expectedCount = 2;

            Assert.That(extendedDb.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_ThrowsInvalidOperationEx_WhenCapacityIsExceeded()
        {
            AddUsersToExtendedDb(MaxCapacity);

            Assert.Throws<InvalidOperationException>(() =>
            extendedDb.Add(new ExtendedDatabase.Person(16, "InvalidPerson")));
        }


        [Test]
        public void Add_ThrowsInvalidOperationEx_WhenUsernameAlreadyExists()
        {
            string username = "Billie";

            extendedDb.Add(new ExtendedDatabase.Person(1, username));

            Assert.Throws<InvalidOperationException>(() =>
            extendedDb.Add(new ExtendedDatabase.Person(2, username)));
        }

        [Test]
        public void Add_ThrowsInvalidOperationEx_WhenIdAlreadyExists()
        {
            long id = 1;

            extendedDb.Add(new ExtendedDatabase.Person(id, "Billie"));

            Assert.Throws<InvalidOperationException>(() =>
            extendedDb.Add(new ExtendedDatabase.Person(id, "BillieEilish")));
        }

        [Test]
        public void Remove_ThrowsInvalidOperationEx_WhenDatabaseISEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            extendedDb.Remove());
        }

        [Test]
        public void Remove_DecreaseCount()
        {
            AddUsersToExtendedDb(3);

            extendedDb.Remove();

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, extendedDb.Count);
        }

        [Test]
        public void FindByUsername_ThrowsInvalidOperationEx_WhenUsernameDoesNotExist()
        {
            string username = "Billie";

            Assert.Throws<InvalidOperationException>(() =>
            extendedDb.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsArgumentNullEx_WhenUsernameIsNotValid()
        {
            string username = null;

            Assert.Throws<ArgumentNullException>(() =>
            extendedDb.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ReturnsExpectedUser_WhenUsernameIsValid()
        {
            string expectedUsername = "Billie";
            extendedDb.Add(new ExtendedDatabase.Person(1, expectedUsername));
            var person = extendedDb.FindByUsername(expectedUsername);

            Assert.That(person.UserName, Is.EqualTo(expectedUsername));
        }

        [Test]
        public void FindByUsername_ShouldBeCaseSensitive()
        {
            string notExpectedResult = "billie";
            extendedDb.Add(new ExtendedDatabase.Person(1, "Billie"));
            string actualResult = extendedDb.FindByUsername("Billie").UserName;

            Assert.AreNotEqual(notExpectedResult, actualResult);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        public void FindById_ShouldThrowArgumentOutOfRangeEx_WhenIdIsNegative(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            extendedDb.FindById(id));
        }

        [Test]
        public void FindById_ShoudThrowInvalidOperationEx_WhenIdIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() =>
            extendedDb.FindById(1));
        }

        [Test]
        public void FindById_ReturnsUser_WhenIdIsValid()
        {
            long expectedId = 1;
            extendedDb.Add(new ExtendedDatabase.Person(expectedId, "Billie"));
            var person = extendedDb.FindById(expectedId);

            Assert.That(person.Id, Is.EqualTo(expectedId));
        }

        private void AddUsersToExtendedDb(int count)
        {
            for (int i = 0; i < count; i++)
            {
                extendedDb.Add(new ExtendedDatabase.Person(i, $"Username{i}"));
            }
        }
    }
}