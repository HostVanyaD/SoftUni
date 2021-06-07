using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string criteria = tokens[1];
                string argument = tokens[2];

                Predicate<string> filter = GetPredicate(criteria, argument);

                if (command == "Remove")
                {
                    guests.RemoveAll(filter);
                }
                else if (command == "Double")
                {
                    List<string> filteredNames = guests
                        .Where(n => filter(n))
                        .ToList();

                    guests.InsertRange(0, filteredNames);
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string criteria, string argument)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(argument);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(argument);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(argument);
            }
            else
            {
                return x => true;
            }
        }
    }
}
