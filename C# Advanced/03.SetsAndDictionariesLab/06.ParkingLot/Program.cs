using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            HashSet<string> parking = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                string car = command[1];

                if (direction == "IN")
                {
                    parking.Add(car);
                }
                else
                {
                    parking.Remove(car);
                }
            }

            if (parking.Count > 0)
            {
                Console.WriteLine(string.Join("\n", parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
