namespace EasterRaces.Models.Drivers.Entities
{
    using System;

    using Contracts;
    using Cars.Contracts;
    using Utilities.Messages;

    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5) //IsNullOrWhiteSpace???
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                CanParticipate = false;
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }
    }
}
