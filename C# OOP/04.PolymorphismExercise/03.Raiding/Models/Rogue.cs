using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;

        public Rogue(string name) 
            : base(name, POWER)
        {
        }

        public override string Name { get; protected set; }
        public override int Power { get; protected set; }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
