namespace EasterRaces.Models.Cars.Entities
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private const int _MinModelLenght = 4;

        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.HorsePower = horsePower;
        }

        public string Model 
        {
            get => this.model; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < _MinModelLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, _MinModelLenght));
                }
                this.model = value;
            }
        }

        public int HorsePower 
        {
            get => this.horsePower;
            private set
            {
                if ((value >= this.minHorsePower && value <= this.maxHorsePower) == false)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
