namespace _01.Vehicles.Models
{
    using System;
    using Contracts;
    
    public class Car : IVehicle
    {
        private const double airConditionerConsumption = 0.9;

        private double fuelQuantity;
        private double fuelConsumption;

        public Car(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption 
        {
            get => fuelConsumption; 
            private set
            {
                fuelConsumption = value + airConditionerConsumption;
            }
        }

        public void Drive(double kilometers)
        {
            var fuelRequired = kilometers * FuelConsumption;

            if (fuelRequired > FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelRequired;
        }

        public void Refuel(double amountOfFuel)
        {
            FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"Car: {Math.Round(FuelQuantity, 2):F2}";
        }
    }
}
