using System;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
            Console.WriteLine($"Km driven -> {kilometers}");
        }
    }
}
