using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()                   //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumption);
                allCars.Add(newCar);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input                                 //"Drive {carModel} {amountOfKm}"
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Drive")
                {
                    string carModel = command[1];
                    double distance = double.Parse(command[2]);

                    var currentCar = allCars.Where(c => c.Model == carModel).FirstOrDefault();

                    currentCar.CarMoving(distance);
                }
            }

            allCars.ForEach(c => Console.WriteLine(c));
        }
    }
}
