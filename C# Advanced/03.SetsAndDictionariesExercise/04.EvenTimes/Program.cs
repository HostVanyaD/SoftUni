using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int newNum = int.Parse(Console.ReadLine());

                if (numbersCount.ContainsKey(newNum))
                {
                    numbersCount[newNum]++;
                }
                else
                {
                    numbersCount.Add(newNum, 1);
                }
            }

            int result = numbersCount.Where(x => x.Value % 2 == 0).First().Key;

            Console.WriteLine(result);
        }
    }
}
