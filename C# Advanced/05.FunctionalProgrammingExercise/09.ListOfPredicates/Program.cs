using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> filter = (number, allDividers) =>
            {
                bool isDivisible = true;

                for (int i = 0; i < allDividers.Length; i++)
                {
                    if (number % allDividers[i] != 0)
                    {
                        isDivisible = false;
                        break;
                    }
                }
                return isDivisible;
            };

            int[] resultNumbers = Enumerable.Range(1, range)
                .Where(n => filter(n, dividers))
                .ToArray();

            Console.WriteLine(string.Join(" ", resultNumbers));
        }
    }
}
