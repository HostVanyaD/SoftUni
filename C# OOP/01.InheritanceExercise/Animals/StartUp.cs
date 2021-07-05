using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }

                Type classType = Type.GetType($"Animals.{command}");
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);
                string gender = commandArgs[2];

                try
                {
                    Animal animal = (Animal)Activator
                    .CreateInstance(classType, new object[] { name, age, gender });
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
