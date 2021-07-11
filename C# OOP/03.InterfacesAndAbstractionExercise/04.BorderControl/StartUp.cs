using System;
using System.Collections.Generic;
using System.Linq;
using _04.BorderControl.Contracts;
using _04.BorderControl.Models;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> allPassing = new List<IIdentifiable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();

                if (info.Length == 3)
                {
                    Citizen currentCitizen = new Citizen(info[0], int.Parse(info[1]), info[2]);
                    allPassing.Add(currentCitizen);
                }
                else if (info.Length == 2)
                {
                    Robot currentRobot = new Robot(info[0], info[1]);
                    allPassing.Add(currentRobot);
                }
            }

            string fakeIdDigits = Console.ReadLine();
            
            allPassing
                .Where(p => p.Id.EndsWith(fakeIdDigits))
                .ToList()
                .ForEach(p => Console.WriteLine(p.Id));                
        }
    }
}
