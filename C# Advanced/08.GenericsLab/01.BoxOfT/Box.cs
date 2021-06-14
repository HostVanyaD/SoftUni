using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> items;
        public int Count 
        { 
            get
            {
                return items.Count;
            }
        }

        public Box()
        {
            this.items = new List<T>();
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public T Remove()
        {
            var lastItem = this.items.Last();
            this.items.RemoveAt(items.Count -1);

            return lastItem;
        }
    }
}
