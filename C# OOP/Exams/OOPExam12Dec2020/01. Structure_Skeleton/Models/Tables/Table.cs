namespace Bakery.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BakedFoods.Contracts;
    using Drinks.Contracts;
    using Contracts;
    using Utilities.Messages;
    using System.Linq;

    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)   // <= 0 ???
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(d => d.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder tableInfo = new StringBuilder();

            tableInfo.AppendLine($"Table: {this.TableNumber}")
             .AppendLine($"Type: {this.GetType().Name}")
             .AppendLine($"Capacity: {this.Capacity}")
             .AppendLine($"Price per Person: {this.PricePerPerson}");

            return tableInfo.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
