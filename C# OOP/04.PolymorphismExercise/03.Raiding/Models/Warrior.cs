using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;

        public Warrior(string name) 
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
