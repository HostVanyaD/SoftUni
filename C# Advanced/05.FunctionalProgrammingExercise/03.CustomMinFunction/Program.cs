using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNumber = (numbers) =>
            {
                int minNum = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minNum)
                    {
                        minNum = number;
                    }
                }
                return minNum;
            };

            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(smallestNumber(inputNumbers));
        }
    }
}
