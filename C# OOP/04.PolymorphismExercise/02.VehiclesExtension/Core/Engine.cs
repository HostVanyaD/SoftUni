namespace _02.VehiclesExtension.Core
{
    using Models;
    using System;

    public class Engine
    {
        public void Run()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();

                string command = tokens[0];
                string vehicleType = tokens[1];
                double argument = double.Parse(tokens[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(argument);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(argument);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Drive(argument);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        ((Bus)bus).DriveEmpty(argument);
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
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Refuel(argument);
                        }
                    }
                }
                catch (Exception exception)
                        when (exception is InvalidOperationException || exception is ArgumentException)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Vehicle CreateVehicle()
        {
            string[] tokens = Console.ReadLine().Split();
            string vehicleType = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);
            double tankCapacity = double.Parse(tokens[3]);

            Vehicle vehicle = null;

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
