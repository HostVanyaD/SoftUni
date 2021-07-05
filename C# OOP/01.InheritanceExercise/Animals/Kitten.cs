using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public const string DefaultGender = "Female";

        public Kitten(string name, int age)
            :base(name, age, DefaultGender)
        {

        }

        public override string ProduceSound()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Meow");

            return result.ToString();
        }
    }
}
