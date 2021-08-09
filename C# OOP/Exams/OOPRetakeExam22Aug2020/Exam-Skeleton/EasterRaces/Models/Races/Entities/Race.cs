namespace EasterRaces.Models.Races.Entities
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Drivers.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
            this.Drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get; private set; }

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);

            this.Drivers = this.drivers;
        }
    }
}
