namespace TheRace
{
    public class Racer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Car Car { get; set; }

        public Racer(string name, int age, string country, Car car)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
            this.Car = car;
        }

        public override string ToString()
        {
            return $"Racer: {this.Name}, {this.Age} ({this.Country})";
        }
    }
}
