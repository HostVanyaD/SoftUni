using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialGreenLight = int.Parse(Console.ReadLine());
            int initialFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input = string.Empty;
            bool thereIsCrash = false;
            string crashedCar = string.Empty;
            int crashIndex = -1;
            int carsPassed = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int greenLight = initialGreenLight;
                    int freeWindow = initialFreeWindow;

                    while (cars.Any() && greenLight > 0)
                    {
                        string currentCar = cars.Peek();
                        int carLenght = currentCar.Length;

                        if (carLenght <= greenLight)
                        {
                            greenLight -= carLenght;
                            carsPassed++;
                            cars.Dequeue();
                        }
                        else
                        {
                            carLenght -= greenLight;

                            if (carLenght <= freeWindow)
                            {
                                carsPassed++;
                                cars.Dequeue();
                            }
                            else
                            {
                                thereIsCrash = true;
                                crashedCar = currentCar;
                                crashIndex = greenLight + freeWindow;
                            }
                            break;
                        }
                    }

                    if (thereIsCrash)
                    {
                        break;
                    }
                }
            }

            if (!thereIsCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[crashIndex]}.");
            }
        }
    }
}
