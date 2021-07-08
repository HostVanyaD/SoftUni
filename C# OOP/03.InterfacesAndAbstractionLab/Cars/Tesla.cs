using System;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public Tesla(string model, string color, int batteries)
        {
            Model = model;
            Color = color;
            Battery = batteries;
        }

        public string Start()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{Color} {this.GetType().Name} {Model} with {Battery} Batteries");
            result.AppendLine($"{this.Start()}");
            result.AppendLine($"{this.Stop()}");

            return result.ToString().TrimEnd();
        }
    }
}
