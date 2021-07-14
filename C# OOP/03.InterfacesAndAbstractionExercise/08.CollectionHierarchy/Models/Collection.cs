using _08.CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace _08.CollectionHierarchy.Models
{
    public abstract class Collection : ICollection
    {
        private List<string> list;

        protected Collection()
        {
            this.list = new List<string>();
        }

        protected List<string> List => list;

        public abstract int Add(string item);
    }
}
