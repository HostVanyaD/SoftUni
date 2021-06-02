using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Queue<string> playersIn = new Queue<string>(kids);
            int counter = 1;

            while (playersIn.Count > 1)
            {
                string currentPLayer = playersIn.Dequeue();

                if (counter == n)
                {
                    Console.WriteLine($"Removed {currentPLayer}");
                    counter = 1;
                    continue;
                }

                playersIn.Enqueue(currentPLayer);
                counter++;
            }

            Console.WriteLine($"Last is {playersIn.Dequeue()}");
        }
    }
}
