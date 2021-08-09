namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double _DefaultCubicCentimeters = 3000;
        private const int _DefaultMinHorsePower = 250;
        private const int _DefaultMaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, _DefaultCubicCentimeters, _DefaultMinHorsePower, _DefaultMaxHorsePower)
        {
        }
    }
}
