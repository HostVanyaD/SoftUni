using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;

        public Druid(string name)
            :base(name, POWER)
        {
        }

        public override string Name { get; protected set; }
        public override int Power { get; protected set; } //moje da iska return POWER

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
