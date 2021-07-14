namespace _01.Vehicles.Core
{
    using Contracts;
    using Models;
    using System;

    public class Engine
    {
        public void Run()
        {
            IVehicle car = CreateVehicle();
            IVehicle truck = CreateVehicle();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();

                string command = tokens[0];
                string vehicleType = tokens[1];
                double argument = double.Parse(tokens[2]);

                if (command == "Drive")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(argument);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(argument);
                        }
                        Console.WriteLine($"{vehicleType} travelled {argument} km");
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    if (vehicleType == nameof(Car))
                    {
                        car.Refuel(argument);
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        truck.Refuel(argument);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static IVehicle CreateVehicle()
        {
            string[] tokens = Console.ReadLine().Split();
            string vehicleType = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);

            IVehicle vehicle = null;

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
