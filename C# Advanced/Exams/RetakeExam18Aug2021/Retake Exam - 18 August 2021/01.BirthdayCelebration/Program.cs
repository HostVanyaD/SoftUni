namespace _01.BirthdayCelebration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] guestsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] platesInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> guestsCapacity = new Queue<int>(guestsInfo);
            Stack<int> platesGrams = new Stack<int>(platesInfo);

            int foodWasted = 0;

            while (true)
            {
                if (platesGrams.Count == 0 || guestsCapacity.Count == 0)
                {
                    break;
                }

                int currentGuest = guestsCapacity.Dequeue();
                int currentPlate = platesGrams.Pop();

                while (currentGuest > 0)
                {
                    if (currentGuest <= currentPlate)
                    {
                        foodWasted += currentPlate - currentGuest;
                        break;
                    }
                    else
                    {
                        currentGuest -= currentPlate;
                        currentPlate = platesGrams.Pop();
                    }
                }
            }

            if (guestsCapacity.Count == 0)
            {
                int count = platesGrams.Count;
                Console.Write("Plates:");
                for (int i = 0; i < count; i++)
                {
                    Console.Write($" {platesGrams.Pop()}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("Guests:");
                foreach (var guest in guestsCapacity)
                {
                    Console.Write($" {guest}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Wasted grams of food: {foodWasted}");
        }
    }
}
