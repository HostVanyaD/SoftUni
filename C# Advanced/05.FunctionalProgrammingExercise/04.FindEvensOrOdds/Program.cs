using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            Func<int, int, List<int>> getNumbersInRange = (s, e) =>
            {
                List<int> numbers = new List<int>();

                for (int i = s; i <= e; i++)
                {
                    numbers.Add(i);
                }
                return numbers;
            };

            List<int> numbers = getNumbersInRange(start, end);

            string criteria = Console.ReadLine();

            Predicate<int> predicate = n => true;

            if (criteria == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (criteria == "even")
            {
                predicate = n => n % 2 == 0;
            }

            Console.WriteLine(string.Join(" ", Filter(numbers, predicate)));
        }

        private static List<int> Filter(List<int> numbers, Predicate<int> predicate)
        {
            List<int> result = new List<int>();

            foreach (var number in numbers)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }
}
