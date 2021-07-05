namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const double DefaultMilliliters = 50;
        public const decimal DefaultPrice = 3.50m;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine)
            :base(name, DefaultPrice, DefaultMilliliters)
        {
            this.Caffeine = caffeine;
        }
    }
}
