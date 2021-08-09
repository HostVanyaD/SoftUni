namespace Bakery.Core
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Contracts;
    using Utilities.Messages;
    using Utilities.Enums;
    using Models.Tables.Contracts;
    using Models.BakedFoods.Contracts;
    using Models.Drinks.Contracts;
    using Models.Drinks;
    using Models.BakedFoods;
    using Models.Tables;

    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                nameof(DrinkType.Tea) => new Tea(name, portion, brand),
                nameof(DrinkType.Water) => new Water(name, portion, brand),
                _ => null
            };

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = type switch
            {
                nameof(BakedFoodType.Bread) => new Bread(name, price),
                nameof(BakedFoodType.Cake) => new Cake(name, price),
                _ => null
            };

            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                nameof(TableType.InsideTable) => new InsideTable(tableNumber, capacity),
                nameof(TableType.OutsideTable) => new OutsideTable(tableNumber, capacity),
                _ => null
            };

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder info = new StringBuilder();

            foreach (var table in freeTables)
            {
                info.AppendLine(table.GetFreeTableInfo());
            }

            return info.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.First(x => x.TableNumber == tableNumber);

            decimal bill = table.GetBill();

            totalIncome += bill;

            table.Clear();

            StringBuilder sb = new StringBuilder()
                .AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table is null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == d.Brand);

            if (drink is null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName + " " + drinkBrand);
            }

            table.OrderDrink(drink);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table is null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (food is null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable reserveTable = tables.Where(t => t.IsReserved == false).Where(t => t.Capacity >= numberOfPeople).FirstOrDefault();

            if (reserveTable is null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            reserveTable.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, reserveTable.TableNumber, numberOfPeople);
        }
    }
}
