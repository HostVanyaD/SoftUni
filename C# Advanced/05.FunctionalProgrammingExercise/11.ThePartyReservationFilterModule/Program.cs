using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> guestsRemoved = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string criteria = tokens[1];
                string parameter = tokens[2];

                Predicate<string> filter = GetFilter(criteria, parameter);

                if (command == "Add filter")
                {
                    guestsRemoved.AddRange(guests.Where(g => filter(g)));
                    guests.RemoveAll(filter);
                }
                else if (command == "Remove filter")
                {
                    guests.AddRange(guestsRemoved.Where(g => filter(g)));
                    guestsRemoved.RemoveAll(filter);
                }
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        private static Predicate<string> GetFilter(string criteria, string parameter)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(parameter);
            }
            else if (criteria == "Ends with")
            {
                return x => x.EndsWith(parameter);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(parameter);
            }
            else if (criteria == "Contains")
            {
                return x => x.Contains(parameter);
            }
            else
            {
                return x => true;
            }
        }
    }
}
