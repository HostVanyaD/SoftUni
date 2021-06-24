using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstData = ReadAnArrayFromTheConsole();
            int[] secondData = ReadAnArrayFromTheConsole();

            Queue<int> firstLootBox = new Queue<int>(firstData);
            Stack<int> secondLootBox = new Stack<int>(secondData);

            int sumOfClaimedItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int currentSum = firstLootBox.Peek() + secondLootBox.Peek();

                if (currentSum % 2 == 0)
                {
                    sumOfClaimedItems += currentSum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (firstLootBox.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondLootBox.Count <= 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumOfClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfClaimedItems}");
            }
        }

        private static int[] ReadAnArrayFromTheConsole()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
