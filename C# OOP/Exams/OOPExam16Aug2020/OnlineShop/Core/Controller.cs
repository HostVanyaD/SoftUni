namespace OnlineShop.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models.Products.Components;
    using Models.Products.Computers;
    using Models.Products.Peripherals;
    using Common.Constants;
    using Common.Enums;

    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IPeripheral> peripherals;
        private readonly List<IComponent> components;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.peripherals = new List<IPeripheral>();
            this.components = new List<IComponent>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            IComputer computer = CreateComputer(computerType, id, manufacturer, model, price);

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            DoesComputerExist(computerId);

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);

            IComputer computer = computers.First(c => c.Id == computerId);

            computer.AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            DoesComputerExist(computerId);

            IComputer computer = computers.First(c => c.Id == computerId);          

            IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            DoesComputerExist(computerId);

            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            IPeripheral peripheral = CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);

            IComputer computer = computers.First(c => c.Id == computerId);

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            DoesComputerExist(computerId);

            IComputer computer = computers.First(c => c.Id == computerId);           

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string BuyComputer(int id)
        {
            DoesComputerExist(id);

            IComputer computer = computers.First(c => c.Id == id);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count == 0 || computers.All(c => c.Price > budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer bestComputer = computers.OrderByDescending(c => c.OverallPerformance).Where(c => c.Price <= budget).First();

            computers.Remove(bestComputer);

            return bestComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            DoesComputerExist(id);

            IComputer computer = computers.First(c => c.Id == id);

            return computer.ToString();
        }

        private void DoesComputerExist(int id)
        {
            if (this.computers.Any(x => x.Id == id) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private static IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            return computerType switch
            {
                nameof(ComputerType.DesktopComputer) => new DesktopComputer(id, manufacturer, model, price),
                nameof(ComputerType.Laptop) => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };
        }

        private static IComponent CreateComponent(int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            return componentType switch
            {
                nameof(ComponentType.CentralProcessingUnit) => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.Motherboard) => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                nameof(ComponentType.VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };
        }

        private static IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            return peripheralType switch
            {
                nameof(PeripheralType.Headset) => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(PeripheralType.Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(PeripheralType.Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(PeripheralType.Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };
        }
    }
}
