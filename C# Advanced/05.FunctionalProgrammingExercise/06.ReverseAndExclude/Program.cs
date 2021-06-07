using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int d = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % d != 0;

            Func<int[], Predicate<int>, List<int>> reverseAndExclude = (array, predicate) =>
            {
                Array.Reverse(array);
                List<int> result = new List<int>();

                foreach (var number in array)
                {
                    if (predicate(number))
                    {
                        result.Add(number);
                    }
                }
                return result;
            };

            Console.WriteLine(string.Join(" ", reverseAndExclude(numbers, isDivisible)));
        }
    }
}
