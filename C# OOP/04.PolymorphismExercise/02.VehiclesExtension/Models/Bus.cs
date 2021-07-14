using System;

namespace _02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double airConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + airConditionerConsumption, tankCapacity)
        {
        }

        public void DriveEmpty(double kilometers)
        {
            this.fuelConsumption -= airConditionerConsumption;

            base.Drive(kilometers);
        }
    }
}
