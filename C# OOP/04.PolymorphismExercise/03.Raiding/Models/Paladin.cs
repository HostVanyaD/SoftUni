using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int POWER = 100;

        public Paladin(string name) 
            : base(name, POWER)
        {
        }

        public override string Name { get; protected set; }
        public override int Power { get; protected set; }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
