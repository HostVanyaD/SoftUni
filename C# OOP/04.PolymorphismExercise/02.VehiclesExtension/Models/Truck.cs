using System;

namespace _02.VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + airConditionerConsumption, tankCapacity)
        {
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuelQuantity + amountOfFuel <= this.tankCapacity)
            {
                fuelQuantity += amountOfFuel * 0.95;
            }
            else
            {
                throw new InvalidOperationException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

        }
    }
}
