using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer testComputer;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            testComputer = new Computer("Manufacturer", "Model", 1000);
        }

        [Test]
        public void ComputersProp_ReturnsCollection()
        {
            Assert.IsNotNull(computerManager.Computers);
        }

        [Test]
        public void Ctor_CreatesInstanceOfTheCollection()
        {
            Assert.IsNotNull(computerManager);
        }

        [Test]
        public void CountProp_ReturnsTheCorrectResult()
        {
            computerManager.AddComputer(testComputer);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, computerManager.Count);
        }

        [Test]
        public void AddComputer_ThrowsArgumentNullEx_WhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ThrowsArgumentEx_WhenComputerAlreadyExists()
        {
            computerManager.AddComputer(testComputer);

            Assert.Throws<ArgumentException>(
                () => computerManager.AddComputer(testComputer));
        }

        [Test]
        public void RemoveComputer_ThrowsArgumentNullEx_WhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.RemoveComputer(null, "Model"));
        }


        [Test]
        public void RemoveComputer_ThrowsArgumentNullEx_WhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.RemoveComputer("Manifacturer", null));
        }

        [Test]
        public void RemoveComputer_ThrowsArgumentEx_WhenDataIsNotValid()
        {
            Assert.Throws<ArgumentException>(
                () => computerManager.RemoveComputer("InvalidManufacturer", "InvalidModel"));
        }

        [Test]
        public void RemoveComputer_RemovesTheValidComputerFromCollectionAndDecreasesCount()
        {
            computerManager.AddComputer(testComputer);
            computerManager.RemoveComputer("Manufacturer", "Model");

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, computerManager.Count);
        }

        [Test]
        public void RemoveComputer_ReturnsTheCorrectObject()
        {
            computerManager.AddComputer(testComputer);

            Assert.That(testComputer, 
                Is.SameAs(computerManager.RemoveComputer("Manufacturer", "Model")));
        }

        [Test]
        public void GetComputer_ThrowsArgumentNullEx_WhenManufacturerIsNull()
        {
            computerManager.AddComputer(testComputer);

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer(null, "Model"));
        }

        [Test]
        public void GetComputer_ThrowsArgumentNullEx_WhenModelIsNull()
        {
            computerManager.AddComputer(testComputer);

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer("Manufacturer", null));
        }

        [Test]
        public void GetComputer_ThrowsArgumentEx_WhenComputerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(
                () => computerManager.GetComputer("Manufacturer", "Model"));
        }

        [Test]
        public void GetComputer_ReturnsTheCorrectObject()
        {
            computerManager.AddComputer(testComputer);

            Assert.That(testComputer, Is.SameAs(computerManager.GetComputer("Manufacturer", "Model")));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowsArgumentNullEx_WhenManufacturerIsNull()
        {
            computerManager.AddComputer(testComputer);

            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsCollectionOfExistingComputersByManufacturer()
        {
            computerManager.AddComputer(new Computer("1", "1", 1500));
            computerManager.AddComputer(new Computer("2", "2", 1000));
            computerManager.AddComputer(new Computer("2", "3", 2000));

            var computers = computerManager
                .GetComputersByManufacturer("2")
                .ToList();

            Assert.That(computers.Count, Is.EqualTo(2));

            Assert.That(computers[0].Manufacturer, Is.EqualTo("2"));
            Assert.That(computers[1].Manufacturer, Is.EqualTo("2"));

            Assert.That(computers[0].Model, Is.EqualTo("2"));
            Assert.That(computers[1].Model, Is.EqualTo("3"));

            Assert.That(computers[0].Price, Is.EqualTo(1000));
            Assert.That(computers[1].Price, Is.EqualTo(2000));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsEmptyCollection()
        {
            computerManager.AddComputer(testComputer);
            computerManager.AddComputer(new Computer("1", "1", 1500));
            computerManager.AddComputer(new Computer("2", "2", 1000));

            var computers = computerManager
                .GetComputersByManufacturer("51")
                .ToList();

            Assert.IsEmpty(computers);
            Assert.That(computers.Count, Is.EqualTo(0));
        }
    }
}
