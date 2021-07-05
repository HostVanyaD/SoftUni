using System.Text;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            :base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Ribbit");

            return result.ToString();
        }
    }
}
