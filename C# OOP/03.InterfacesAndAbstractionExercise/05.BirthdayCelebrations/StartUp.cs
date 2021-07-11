using System;
using System.Collections.Generic;
using System.Linq;
using _05.BirthdayCelebrations.Contracts;
using _05.BirthdayCelebrations.Models;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> allBirthdays = new List<IBirthable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();

                if (info[0] == "Citizen")
                { 
                    Citizen currentCitizen = new Citizen(info[1], int.Parse(info[2]), info[3], info[4]);
                    allBirthdays.Add(currentCitizen);
                }
                else if (info[0] == "Pet")
                { 
                    Pet currentPet = new Pet(info[1], info[2]);
                    allBirthdays.Add(currentPet);
                }
            }

            string yearOfBirth = Console.ReadLine();
            
            allBirthdays
                .Where(p => p.Birthdate.EndsWith(yearOfBirth))
                .ToList()
                .ForEach(p => Console.WriteLine(p.Birthdate));                
        }
    }
}
