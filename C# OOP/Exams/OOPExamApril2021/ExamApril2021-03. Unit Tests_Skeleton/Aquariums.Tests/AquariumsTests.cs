namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("MyAquarium", 2);
            aquarium.Add(new Fish("Gupi"));
        }

        [Test]
        [TestCase("", 10)]
        [TestCase(null, 10)]
        public void Ctor_ThrowArgumentNullException_WhenNameIsNotValid(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        [TestCase("ValidName", -10)]
        public void Ctor_ThrowArgumentException_WhenCapacityIsNegative(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void Ctor_CreatesCollection_WhenDataIsValid()
        {
            Assert.IsNotNull(aquarium.Count);
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenCapacityIsExceeded()
        {
            aquarium.Add(new Fish("Beta"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Nemo")));
        }

        [Test]
        public void Add_IncreaseCount_WhenNewFishIsAddedSuccessfully()
        {
            aquarium.Add(new Fish("Beta"));
            int expectedCount = 2;

            Assert.That(aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveFish_ThrowsInvalidOperationException_WhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("NonExistentName"));
        }

        [Test]
        public void RemoveFish_DecreaseCount_WhenFishNameExists()
        {
            int expectedCount = 0;
            aquarium.RemoveFish("Gupi");

            Assert.That(aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void SellFish_ThrowsInvalidOperationException_WhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("NonExistentName"));
        }

        [Test]
        public void SellFish_ReturnsFishCorrectly()
        {
            string fishName = "Beta";
            Fish betaFish = new Fish(fishName);

            aquarium.Add(betaFish);
            Fish soldFish = aquarium.SellFish(fishName);

            Assert.AreSame(betaFish, soldFish);
        }

        [Test]
        public void Report_ReturnsCorrectInfo()
        {
            string expected = $"Fish available at {aquarium.Name}: {"Gupi"}";

            Assert.That(aquarium.Report(), Is.EqualTo(expected));
        }
    }
}
