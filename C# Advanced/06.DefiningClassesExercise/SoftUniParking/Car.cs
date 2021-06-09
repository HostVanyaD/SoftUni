using System.Text;

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
            StringBuilder carInfo = new StringBuilder();

            carInfo.AppendLine($"Make: {Make}");
            carInfo.AppendLine($"Model: {Model}");
            carInfo.AppendLine($"HorsePower: {HorsePower}");
            carInfo.AppendLine($"RegistrationNumber: {RegistrationNumber}");

            return carInfo.ToString().TrimEnd();
        }
    }
}
