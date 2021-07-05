using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            :base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Woof!");

            return result.ToString();
        }
    }
}
