namespace Restaurant
{
    public class Cake : Dessert
    {
        public const double DefaultGrams = 250;
        public const double DefaultCalories = 1000;
        public const decimal DefaultPrice = 5m;

        public Cake(string name)
            :base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {

        }
    }
}
