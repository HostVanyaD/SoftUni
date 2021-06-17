using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
        readonly List<Racer> racers = new List<Racer>();

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return racers.Count;
            }
        }

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public void Add(Racer racer)
        {
            if (racers.Count < Capacity)
            {
                racers.Add(racer);
            }
        }


        public bool Remove(string name)
        {
            foreach (var racer in racers)
            {
                if (racer.Name == name)
                {
                    racers.Remove(racer);
                    return true;
                }
            }
            return false;
        }

       
        public Racer GetOldestRacer()
        {
            int maxAge = 0;
            Racer oldest = null;

            foreach (var racer in racers)
            {
                if (racer.Age > maxAge)
                {
                    maxAge = racer.Age;
                    oldest = racer;
                }
            }
            return oldest;
        }


        public Racer GetRacer(string name)
        {
            foreach (var racer in racers)
            {
                if (racer.Name == name)
                {
                    return racer;
                }
            }
            return null;
        }

        public Racer GetFastestRacer()
        {
            int highestSpeed = 0;
            Racer best = null;

            foreach (var racer in racers)
            {
                if (racer.Car.Speed > highestSpeed)
                {
                    highestSpeed = racer.Car.Speed;
                    best = racer;
                }
            }
            return best;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in racers)
            {
                result.AppendLine(racer.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
