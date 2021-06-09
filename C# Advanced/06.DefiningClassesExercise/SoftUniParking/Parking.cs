using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public int Count => cars.Count();

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string regNumber)
        {
            if (cars.Any(c => c.RegistrationNumber == regNumber))
            {
                var car = cars.Find(c => c.RegistrationNumber == regNumber);
                cars.Remove(car);
                return $"Successfully removed {regNumber}";                
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string regNumber)
        {
            return cars.Find(c => c.RegistrationNumber == regNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                if (cars.Any(c => c.RegistrationNumber == registrationNumbers[i]))
                {
                    var currentCar = cars.Find(c => c.RegistrationNumber == registrationNumbers[i]);
                    cars.Remove(currentCar);
                }
            }
        }
    }
}
