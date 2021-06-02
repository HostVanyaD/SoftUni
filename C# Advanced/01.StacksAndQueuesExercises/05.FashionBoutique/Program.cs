using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(clothesInTheBox);

            int rackCounter = 1;
            int sumOfClothes = 0;

            while (box.Count > 0)
            {
                int currentClothes = box.Pop();

                if ((sumOfClothes + currentClothes) > rackCapacity)
                {
                    sumOfClothes = 0;
                    rackCounter += 1;
                }

                sumOfClothes += currentClothes;
            }

            Console.WriteLine(rackCounter);
        }
    }
}
