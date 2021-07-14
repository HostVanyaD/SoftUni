using _08.CollectionHierarchy.Contracts;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList()
            :base()
        {
        }

        public int Used => this.List.Count;

       public override string Remove()
        {
            var itemToRemove = this.List[0];
            this.List.RemoveAt(0);

            return itemToRemove;
        }

    }
}
