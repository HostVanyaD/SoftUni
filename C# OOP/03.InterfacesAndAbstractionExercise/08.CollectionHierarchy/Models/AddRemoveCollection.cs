using _08.CollectionHierarchy.Contracts;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IRemove
    {
        public AddRemoveCollection()
            :base()
        {
        }

        public override int Add(string item)
        {
            this.List.Insert(0, item);

            return 0;
        }

        public virtual string Remove()
        {
            var itemToRemove = this.List[this.List.Count - 1];
            this.List.Remove(itemToRemove);

            return itemToRemove;
        }
    }
}
