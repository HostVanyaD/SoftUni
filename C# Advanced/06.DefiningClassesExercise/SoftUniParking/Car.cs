namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car(string make, string model, int horsePower, string regNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = regNumber;
        }

        public override string ToString()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nHorsePower: {this.HorsePower}\nRegistrationNumber: {this.RegistrationNumber}";
        }
    }
}
