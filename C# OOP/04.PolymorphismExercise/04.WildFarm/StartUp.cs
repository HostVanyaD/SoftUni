using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Animals.Birds;
using _04.WildFarm.Models.Animals.Mammals;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> allAnimals = new List<Animal>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalTokens = input.Split();

                Animal currentAnimal = CreateAnimal(animalTokens);
                allAnimals.Add(currentAnimal);

                string[] foodTokens = Console.ReadLine().Split();

                Food currentFood = CreateFood(foodTokens);

                Console.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in allAnimals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodTokens)
        {
            Food currentFood = null;
            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            if (type == nameof(Meat))
            {
                currentFood = new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                currentFood = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                currentFood = new Fruit(quantity);
            }
            else if (type == nameof(Seeds))
            {
                currentFood = new Seeds(quantity);
            }

            return currentFood;
        }

        private static Animal CreateAnimal(string[] animalTokens)
        {
            Animal currentAnimal = null;
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalTokens[3]);
                currentAnimal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalTokens[3]);
                currentAnimal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string region = animalTokens[3];
                currentAnimal = new Mouse(name, weight, region);
            }
            else if (type == nameof(Dog))
            {
                string region = animalTokens[3];
                currentAnimal = new Dog(name, weight, region);
            }
            else if (type == nameof(Cat))
            {
                string region = animalTokens[3];
                string breed = animalTokens[4];
                currentAnimal = new Cat(name, weight, region, breed);
            }
            else if (type == nameof(Tiger))
            {
                string region = animalTokens[3];
                string breed = animalTokens[4];
                currentAnimal = new Tiger(name, weight, region, breed);
            }

            return currentAnimal;
        }
    }
}
