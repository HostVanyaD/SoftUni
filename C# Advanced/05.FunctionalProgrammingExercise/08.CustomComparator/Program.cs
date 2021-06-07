using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (x, y) =>
                (x % 2 == 0 && y % 2 != 0) ? -1 //първото остава първо
                : (x % 2 != 0 && y % 2 == 0) ? 1 //второто става първо
                : x.CompareTo(y);  //в противен случай ги сравнява

            Comparison<int> comparison = new Comparison<int>(sortFunc);

            Array.Sort(numbers, comparison);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
