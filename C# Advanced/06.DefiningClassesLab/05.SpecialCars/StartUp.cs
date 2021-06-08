using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> allTires = new List<Tire[]>();
            List<Engine> allEngines = new List<Engine>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Queue<string> tiresInfo = new Queue<string>(inputData);

                var tires = new Tire[4]
                {
                new Tire (int.Parse(tiresInfo.Dequeue()), double.Parse(tiresInfo.Dequeue())),
                new Tire (int.Parse(tiresInfo.Dequeue()), double.Parse(tiresInfo.Dequeue())),
                new Tire (int.Parse(tiresInfo.Dequeue()), double.Parse(tiresInfo.Dequeue())),
                new Tire (int.Parse(tiresInfo.Dequeue()), double.Parse(tiresInfo.Dequeue()))
                };

                allTires.Add(tires);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var engine = new Engine(int.Parse(engineData[0]), double.Parse(engineData[1]));

                allEngines.Add(engine);
            }

            List<Car> allCars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] carData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allTires[tiresIndex]);

                allCars.Add(currentCar);
            }

            //drive 20 kilometers all the cars, which were manufactured during 2017 or after,
            //have horse power above 330 and the sum of their tire pressure is between 9 and 10

            List<Car> specialCars = allCars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();


            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
