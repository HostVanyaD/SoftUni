﻿namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;

        public Car(int horsePower, double fuel)
            :base(horsePower, fuel)
        {

        }

        public override double FuelConsumption { get => defaultFuelConsumption; }
    }
}
