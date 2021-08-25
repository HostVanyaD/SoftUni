namespace StreetRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Race
    {
        private List<Car> Participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Participants.All(c => c.LicensePlate != car.LicensePlate) &&
                Capacity > Participants.Count &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
            => Participants.Remove(Participants.FirstOrDefault(c => c.LicensePlate == licensePlate));

        public Car FindParticipant(string licensePlate)
            => Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar()
            => Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                report.AppendLine(car.ToString());
            }

            return report.ToString().TrimEnd();
        }

    }
}
