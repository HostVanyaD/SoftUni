namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int _Capacity = 20;

        public Satchel() 
            : base(_Capacity)
        {
        }
    }
}
