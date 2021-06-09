using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineLines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineLines; i++)
            {
                string[] engineData = ReadAnArrayFromTheConsole(); //"{model} {power} {displacement} {efficiency}"

                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                if (engineData.Length == 3)
                {
                    if (int.TryParse(engineData[2], out int displacement))
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, engineData[2]));
                    }
                }
                else if (engineData.Length == 4)
                {
                    int displacement = int.Parse(engineData[2]);
                    string efficiency = engineData[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            int carLines = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carLines; i++)
            {
                string[] carData = ReadAnArrayFromTheConsole(); //"{model} {engine} {weight} {color}

                string carModel = carData[0];
                Engine engineModel = engines.Find(e => e.Model == carData[1]);

                if (carData.Length == 3)
                {
                    if (int.TryParse(carData[2], out int weight))
                    {
                        cars.Add(new Car(carModel, engineModel, weight));
                    }
                    else
                    {
                        cars.Add(new Car(carModel, engineModel, carData[2]));
                    }
                }
                else if (carData.Length == 4)
                {
                    int weight = int.Parse(carData[2]);
                    string color = carData[3];
                    cars.Add(new Car(carModel, engineModel, weight, color));
                }
                else
                {
                    cars.Add(new Car(carModel, engineModel));
                }
            }

            cars
                .ForEach(c => Console.WriteLine(c));
        }

        private static string[] ReadAnArrayFromTheConsole()
        {
            return Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
