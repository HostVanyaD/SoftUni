using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            bool thereIsParty = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    thereIsParty = true;

                }

                if (thereIsParty)
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vip.Remove(input);
                    }
                    else
                    {
                        regular.Remove(input);
                    }
                }
                else
                {
                    if (Char.IsDigit(input[0]))
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }
                }
            }

            Console.WriteLine(vip.Count + regular.Count);
            if (vip.Count > 0) Console.WriteLine(string.Join("\n", vip));
            if (regular.Count > 0) Console.WriteLine(string.Join("\n", regular));
        }
    }
}
