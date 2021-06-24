namespace Parking
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} ({Year})";
        }
    }
}
