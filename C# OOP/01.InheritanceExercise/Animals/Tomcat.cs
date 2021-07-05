using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public const string DefaultGender = "Male";

        public Tomcat(string name, int age)
            :base(name, age, DefaultGender)
        {

        }

        public override string ProduceSound()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("MEOW");

            return result.ToString();
        }
    }
}
