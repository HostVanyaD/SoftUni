using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int> getAsciiSum = n => n.Select(c => (int)c).Sum();

            Func<List<string>, Func<string, int>, int, string> getName = (names, getAsciiSum, num) =>
            names.FirstOrDefault(p => getAsciiSum(p) >= num);

            string name = getName(names, getAsciiSum, num);
            Console.WriteLine(name);
        }
    }
}
