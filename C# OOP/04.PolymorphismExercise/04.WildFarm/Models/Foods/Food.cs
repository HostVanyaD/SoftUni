namespace _04.WildFarm.Models.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public abstract int Quantity { get; protected set; }
    }
}
