namespace _01.Vehicles.Models
{
    using Contracts;
    using System;

    public class Truck : IVehicle
    {
        private const double airConditionerConsumption = 1.6;

        private double fuelQuantity;
        private double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
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
            FuelQuantity += 0.95 * amountOfFuel;
        }

        public override string ToString()
        {
            return $"Truck: {Math.Round(FuelQuantity, 2):F2}";
        }
    }
}
