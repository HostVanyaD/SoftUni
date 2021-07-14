namespace _04.WildFarm.Models.Foods
{
    public class Fruit : Food
    {
        public Fruit(int quantity) 
            : base(quantity)
        {
        }

        public override int Quantity { get; protected set; }
    }
}
