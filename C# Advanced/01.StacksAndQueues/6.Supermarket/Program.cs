using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    int n = people.Count;
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                    continue;
                }

                people.Enqueue(input);
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
