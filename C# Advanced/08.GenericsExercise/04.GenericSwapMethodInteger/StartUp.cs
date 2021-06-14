using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfElements = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < numOfElements; i++)
            {
                Box<int> current = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(current);
            }

            int[] swapCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            Swap(boxes, firstIndex, secondIndex);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        static void Swap<T>(IList<Box<T>> list, int firstIndex, int secondIndex)
        {
            Box<T> temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
