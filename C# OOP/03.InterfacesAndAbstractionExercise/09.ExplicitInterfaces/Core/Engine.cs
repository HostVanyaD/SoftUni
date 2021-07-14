namespace _09.ExplicitInterfaces.Core
{
    using Contracts;
    using Models;
    using System;

    public class Engine
    {
        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson citizenAsIPerson = new Citizen(name, age, country);
                IResident citizenAsIResident = new Citizen(name, age, country);

                Console.WriteLine(citizenAsIPerson.GetName());
                Console.WriteLine(citizenAsIResident.GetName());
            }
        }
    }
}
