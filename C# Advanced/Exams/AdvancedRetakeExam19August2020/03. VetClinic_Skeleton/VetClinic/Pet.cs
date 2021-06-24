namespace VetClinic
{
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
