using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                double tire1Pressure = double.Parse(carData[5]);
                int tire1Age = int.Parse(carData[6]);
                double tire2Pressure = double.Parse(carData[7]);
                int tire2Age = int.Parse(carData[8]);
                double tire3Pressure = double.Parse(carData[9]);
                int tire3Age = int.Parse(carData[10]);
                double tire4Pressure = double.Parse(carData[11]);
                int tire4Age = int.Parse(carData[12]);

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tires = new Tire[4]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire3Pressure, tire3Age)
                };

                Car currentCar = new Car(model, engine, cargo, tires);
                cars.Add(currentCar);
            }

            string criteria = Console.ReadLine();

            if (criteria == "fragile")
            {
                cars
                    .Where(c => c.Cargo.Type == "fragile")
                    .Where(c => c.Tires.Any(x => x.Pressure < 1))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
            }
            else if (criteria == "flamable")
            {
                cars
                    .Where(c => c.Cargo.Type == "flamable")
                    .Where(c => c.Engine.Power > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
