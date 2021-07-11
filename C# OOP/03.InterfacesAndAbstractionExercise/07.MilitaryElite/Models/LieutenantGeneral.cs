using _07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString()
                + Environment.NewLine
                + "Privates:");

            foreach (var @private in this.Privates)
            {
                result.AppendLine($"  {@private}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
