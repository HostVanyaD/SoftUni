using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
