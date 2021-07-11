using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumerations;
using System;

namespace _07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorp) 
            : base(id, firstName, lastName, salary)
        {
            Corp = soldierCorp;
        }

        public SoldierCorpEnum Corp { get; }

        public override string ToString()
        {
            return base.ToString()
                  + Environment.NewLine
                  + $"Corps: {Corp}"
                  + Environment.NewLine;
        }
    }
}
