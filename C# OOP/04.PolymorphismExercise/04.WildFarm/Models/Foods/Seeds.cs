namespace _04.WildFarm.Models.Foods
{
    public class Seeds : Food
    {
        public Seeds(int quantity) 
            : base(quantity)
        {
        }

        public override int Quantity { get; protected set; }
    }
}
