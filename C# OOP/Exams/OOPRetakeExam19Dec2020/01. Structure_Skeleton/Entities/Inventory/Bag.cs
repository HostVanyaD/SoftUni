namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Constants;
    using Items;

    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity) // >= ????
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
