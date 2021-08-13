namespace OnlineShop.Models.Products.Computers
{
    using Components;
    using Peripherals;
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Computer : Product, IComputer
    {

        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override decimal Price => GetPrice();

        public override double OverallPerformance => GetPerformance();

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Any() == false || 
                components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent componentToRemove = components.First(c => c.GetType().Name == componentType);
            components.Remove(componentToRemove);

            return componentToRemove;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Any() == false || 
                peripherals.All(c => c.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheralToRemove = peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        private double GetPerformance()
        {
            if (components.Count == 0)
            {
                return base.OverallPerformance;
            }

            return base.OverallPerformance 
                + components.Average(c => c.OverallPerformance);
        }

        private decimal GetPrice()
        {
                return base.Price +
                this.Peripherals.Sum(p => p.Price) +
                this.Components.Sum(c => c.Price);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($" Components ({components.Count}):");

            foreach (var component in components)
            {
                result.AppendLine($"  {component}");
            }

            result.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripherals.Average(p => p.OverallPerformance):F2}):");

            foreach (var peripheral in Peripherals)
            {
                result.AppendLine($"  {peripheral}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
