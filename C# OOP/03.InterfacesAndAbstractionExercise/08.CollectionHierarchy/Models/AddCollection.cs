using System;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : Collection
    {
        public AddCollection()
            :base()
        {
        }

        public override int Add(string item)
        {
            this.List.Add(item);

            return this.List.IndexOf(item);
        }
    }
}
