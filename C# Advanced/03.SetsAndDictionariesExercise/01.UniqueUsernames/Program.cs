using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string newName = Console.ReadLine();
                names.Add(newName);
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
