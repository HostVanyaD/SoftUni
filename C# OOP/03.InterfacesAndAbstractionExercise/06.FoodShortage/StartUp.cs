using System;
using System.Collections.Generic;
using System.Linq;
using _06.FoodShortage.Contracts;
using _06.FoodShortage.Models;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> people = new List<IBuyer>();

            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string[] info = Console.ReadLine().Split();

                if (info.Length == 4)
                { 
                    Citizen currentCitizen = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
                    people.Add(currentCitizen);
                }
                else if (info.Length == 3)
                { 
                    Rebel currentRebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                    people.Add(currentRebel);
                }
            }

            string name = string.Empty;

            while ((name = Console.ReadLine()) != "End")
            {
                if (people.Any(p => p.Name == name))
                {
                    IBuyer current = people.First(p => p.Name == name);
                    current.BuyFood();
                }
            }

            Console.WriteLine(people.Sum(p => p.Food));              
        }
    }
}
