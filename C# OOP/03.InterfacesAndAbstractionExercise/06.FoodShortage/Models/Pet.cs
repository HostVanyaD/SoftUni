using _06.FoodShortage.Contracts;

namespace _06.FoodShortage.Models
{
    public class Pet : IBirthable
    {
        public string Name { get; private set; }
        public string Birthdate { get; private set; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
