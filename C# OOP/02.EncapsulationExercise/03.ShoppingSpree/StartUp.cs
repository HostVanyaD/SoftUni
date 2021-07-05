using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] allPeopleData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();

            foreach (var person in allPeopleData)
            {
                string[] personInfo = person
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    people.Add(new Person(personInfo[0], decimal.Parse(personInfo[1])));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] allProductsData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();

            foreach (var product in allProductsData)
            {
                string[] productInfo = product
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    products.Add(new Product(productInfo[0], decimal.Parse(productInfo[1])));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] buyingInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person currentPerson = people.Find(p => p.Name == buyingInfo[0]);
                Product currentProduct = products.Find(p => p.Name == buyingInfo[1]);

                if (currentPerson.CanBuyProduct(currentProduct))
                {
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }
            }

            foreach (var person in people)
            {
                string output = person.Bag.Count > 0 ? String.Join(", ", person.Bag.Select(p => p.Name)) : "Nothing bought";

                Console.WriteLine($"{person.Name} - {output}");
            }
        }
    }
}
