using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral
    {
        ICollection<IPrivate> Privates { get; }
    }
}
