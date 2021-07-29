using NUnit.Framework;
using System;
using CarManager;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private readonly string make = "Range Rover";
        private readonly string model = "Evoque";
        private readonly double fuelConsumption = 5;
        private readonly double fuelCapacity = 50;

        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        [TestCase("", "Model", 5, 50)]
        [TestCase(null, "Model", 5, 50)]
        [TestCase("Make", "", 5, 50)]
        [TestCase("Make", null, 5, 50)]
        [TestCase("Make", "Model", 0, 50)]
        [TestCase("Make", "Model", -5, 50)]
        [TestCase("Make", "Model", 5, 0)]
        [TestCase("Make", "Model", 5, -50)]
        public void Ctor_ThrowsAgrumentException_WhenInvalidDataIsProvided
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        
        [Test]
        public void PropMake_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(car.Make, Is.EqualTo(make));
        }

        [Test]
        public void PropModel_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(car.Model, Is.EqualTo(model));
        }

        [Test]
        public void PropFuelConsumption_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
        }

        [Test]
        public void PropFuelCapacity_IsSetCorrectly_WhenAgumentIsValid()
        {
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_ThrowsArgumentException_WhenFuelAmountIsZeroOrNegative(double fuelAmount)
        {
            Assert.That(() => this.car.Refuel(fuelAmount),
                Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void Refuel_AddsFuelIntoTheTank_WhenAmountIsValid(double fuelToRefuel)
        {
            double expectedFuelAmount = car.FuelAmount + fuelToRefuel;
            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        [TestCase(150)]
        public void Refuel_SetsAmountToCapacity_WhenCapacityIsExceeded(double fuelToRefuel)
        {
            double expectedResult = car.FuelCapacity;
            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(1000)]
        [TestCase(3000)]
        public void Drive_ThrowsInvalidOperationException_WhenFuelAmountIsNotEnoughToDriveGivenDistance(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(10)]
        [TestCase(5)]
        public void Drive_DecreaseFuelAmount_WhenInvoked(double distance)
        {
            car.Refuel(fuelCapacity);
            double expectedAmountAfterDrive = car.FuelAmount - ((distance / 100) * car.FuelConsumption);
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(expectedAmountAfterDrive));
        }
    }
}