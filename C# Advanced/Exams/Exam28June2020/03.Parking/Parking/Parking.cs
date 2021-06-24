using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (Capacity > data.Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                var findCar = data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
                data.Remove(findCar);

                return true;
            }

            return false;
        }
        
        public Car GetLatestCar()
        {
            return data.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
