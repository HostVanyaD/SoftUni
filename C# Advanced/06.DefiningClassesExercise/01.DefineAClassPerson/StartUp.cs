using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstPerson = new Person("Pesho", 20);

            var secondPerson = new Person
            {
                Name = "Gosho",
                Age = 18
            };

            var thirdPerson = new Person();
            thirdPerson.Name = "Stamat";
            thirdPerson.Age = 43;
        }
    }
}
