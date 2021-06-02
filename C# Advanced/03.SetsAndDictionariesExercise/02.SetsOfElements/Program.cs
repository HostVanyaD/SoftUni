using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = sizes[0];
            int m = sizes[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                firstSet.Add(newNum);
            }
            for (int i = 0; i < m; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                if (firstSet.Contains(newNum))
                {
                    secondSet.Add(newNum);
                }
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
