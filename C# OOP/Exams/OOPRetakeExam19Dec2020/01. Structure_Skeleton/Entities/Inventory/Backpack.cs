namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int _Capacity = 100;

        public Backpack() 
            : base(_Capacity)
        {
        }
    }
}
