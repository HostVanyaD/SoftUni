using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}
