namespace _01.Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; } //liters per km

        void Drive(double kilometers);
        void Refuel(double amountOfFuel);

    }
}
