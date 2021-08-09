namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double _DefaultCubicCentimeters = 5000;
        private const int _DefaultMinHorsePower = 400;
        private const int _DefaultMaxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, _DefaultCubicCentimeters, _DefaultMinHorsePower, _DefaultMaxHorsePower)
        {
        }
    }
}
