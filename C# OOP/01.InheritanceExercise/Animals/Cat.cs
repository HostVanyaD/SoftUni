using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            :base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Meow meow");

            return result.ToString();
        }
    }
}
