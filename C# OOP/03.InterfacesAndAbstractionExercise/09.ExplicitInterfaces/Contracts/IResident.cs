namespace _09.ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }

        public string GetName();
    }
}
