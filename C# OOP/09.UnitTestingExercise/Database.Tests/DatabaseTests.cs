using NUnit.Framework;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database databaseToFill;
        private Database.Database fullDatabase;
        private int[] dataCapacity = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 ,16 };

        [SetUp]
        public void Setup()
        {
            databaseToFill = new Database.Database();
            fullDatabase = new Database.Database(dataCapacity);
        }

        [Test]
        public void ConstructorSetsDatabaseProperly()
        {
            Assert.That(fullDatabase.Count, Is.EqualTo(dataCapacity.Length), "The Constructor is not working correctly");
        }

        [Test]
        public void AddMethod_ShouldIncreaseCount()
        {
            int countOfElements = 3;
            for (int i = 0; i < countOfElements; i++)
            {
                databaseToFill.Add(i);
            }

            Assert.That(databaseToFill.Count, Is.EqualTo(countOfElements));
        }

        [Test]
        public void AddMethod_ShouldThrowInvalidOperationEx_WhenCapacityIsExceeded()
        {
            int element = 1;

            Assert.That(() =>
            { fullDatabase.Add(element); },
            Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!")
            );
        }

        [Test]
        public void RemoveMethod_ShouldDecreaseCount()
        {
            int expectedCount = fullDatabase.Count - 1;
            fullDatabase.Remove();

            Assert.That(fullDatabase.Count, Is.EqualTo(expectedCount), "Remove method doesn't work properly");
        }

        [Test]
        public void RemoveMethod_ShouldThrowInvalidOperationEx_WhenDatabaseIsEmpty()
        {
            Assert.That(() =>
            { databaseToFill.Remove(); },
            Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!")
            );
        }

        [Test]
        public void RemoveMethod_ShouldRemoveTheLastElemntFromTheArray()
        {
            int expectedRemovedElement = dataCapacity[dataCapacity.Length - 1]; //16
            fullDatabase.Remove();
            int[] copy = fullDatabase.Fetch();

            Assert.IsFalse(copy.Contains(expectedRemovedElement), "Remove method doesn't remove the last element");
        }

        [Test]
        public void FetchMethod_ShouldReturnACopyOfTheInitialArray_NotARefference()
        {
            int[] copy = databaseToFill.Fetch();

            databaseToFill.Add(1);

            Assert.AreNotSame(copy, databaseToFill.Fetch(), "FetchMethod doesn't return a copy");
        }
    }
}