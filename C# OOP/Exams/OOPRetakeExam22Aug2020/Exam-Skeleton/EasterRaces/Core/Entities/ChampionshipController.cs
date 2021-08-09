namespace EasterRaces.Core.Entities
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Utilities.Messages;
    using Repositories.Entities;
    using Models.Drivers.Contracts;
    using Models.Drivers.Entities;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Races.Contracts;
    using Models.Races.Entities;

    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);

            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = type switch
            {
                "Muscle" => new MuscleCar(model, horsePower),
                "Sports" => new SportsCar(model, horsePower),
                _ => null
            };

            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.drivers.GetByName(driverName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (this.cars.GetByName(carModel) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            ICar car = this.cars.GetByName(carModel);

            IDriver driver = this.drivers.GetByName(driverName);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.races.GetByName(raceName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (this.drivers.GetByName(driverName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IRace race = this.races.GetByName(raceName);

            IDriver driver = this.drivers.GetByName(driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (this.races.GetByName(raceName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = this.races.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> finalists = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();
            this.races.Remove(race);

            StringBuilder result = new StringBuilder()
                .AppendLine($"Driver {finalists[0].Name} wins {raceName} race.")
                .AppendLine($"Driver {finalists[1].Name} is second in {raceName} race.")
                .AppendLine($"Driver {finalists[2].Name} is third in {raceName} race.");

            return result.ToString().TrimEnd();

        }
    }
}
