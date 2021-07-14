namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public abstract string Name { get; protected set; }
        public abstract int Power { get; protected set; }
        public abstract string CastAbility();
    }
}
