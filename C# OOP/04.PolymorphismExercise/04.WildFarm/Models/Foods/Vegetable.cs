namespace _04.WildFarm.Models.Foods
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity) 
            : base(quantity)
        {
        }

        public override int Quantity { get; protected set; }
    }
}
