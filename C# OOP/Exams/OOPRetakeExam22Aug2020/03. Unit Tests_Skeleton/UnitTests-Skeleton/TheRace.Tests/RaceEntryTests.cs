using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver testDriver;


        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            testDriver = new UnitDriver("TestDriver", new UnitCar("Model", 200, 50.0));
        }

        [Test]
        public void Ctor_CreatesInstanceOfCollection()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void CounterProp_ReturnsTheCorrectResult()
        {
            raceEntry = new RaceEntry();
            raceEntry.AddDriver(testDriver);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, raceEntry.Counter);
        }

        [Test]
        public void AddDriver_ThrowsInvalidOperationEx_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsInvalidOperationEx_WhenDriverAlreadyExist()
        {            
            raceEntry.AddDriver(testDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(testDriver));
        }

        [Test]
        public void AddDriver_AddsNewDriverToCollection()
        {
            raceEntry.AddDriver(testDriver);

            Assert.IsTrue(raceEntry.Counter == 1);
        }

        [Test]
        public void AddDriver_ReturnsTheCorrectResult()
        {
            string expected = "Driver TestDriver added in race.";

            Assert.AreEqual(expected, raceEntry.AddDriver(testDriver));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsInvalidOperationEx_WhenParticipantsAreLessThanMinimum()
        {
            raceEntry.AddDriver(testDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsTheCorrectResult()
        {
            UnitDriver testDriverTwo = new UnitDriver("TestDriver2", new UnitCar("Model", 200, 50.0));
            raceEntry.AddDriver(testDriver);
            raceEntry.AddDriver(testDriverTwo);

            double expectedAverage = (testDriver.Car.HorsePower + testDriverTwo.Car.HorsePower) / 2;

            Assert.AreEqual(expectedAverage, raceEntry.CalculateAverageHorsePower());

        }
    }
}