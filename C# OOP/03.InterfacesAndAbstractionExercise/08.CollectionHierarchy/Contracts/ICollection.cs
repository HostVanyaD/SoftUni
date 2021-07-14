using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Contracts
{
    public interface ICollection : ICollection
    {
        protected List<string> List { get; }
    }
}
