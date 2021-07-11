using _06.FoodShortage.Contracts;

namespace _06.FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }

        public int Food { get; private set; } = 0;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
