using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;


        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value; 
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag;
            }
        }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public bool CanBuyProduct(Product product)
        {
            if (money >= product.Cost)
            {
                money -= product.Cost;
                bag.Add(product);

                return true;
            }
            return false;
        }
    }
}
