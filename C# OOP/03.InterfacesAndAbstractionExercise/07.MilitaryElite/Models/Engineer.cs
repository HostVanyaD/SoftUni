using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorp, ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, soldierCorp)
        {
            Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString() + "Repairs:");

            foreach (var repair in this.Repairs)
            {
                result.AppendLine($"  {repair}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
