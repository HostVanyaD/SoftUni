using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorp, ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, soldierCorp)
        {
            Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString() + "Missions:");

            foreach (var mission in this.Missions)
            {
                result.AppendLine($"  {mission}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
