namespace WarCroft.Entities.Characters.Contracts
{
    using System;

    using Constants;
    using Inventory;
    using Items;

    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get; set; }

        public double BaseArmor { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            this.Armor -= hitPoints;
            if (this.Armor < 0)
            {
                hitPoints = Math.Abs(this.Armor);
                this.Armor = 0;
                this.Health -= hitPoints;
            }

            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }
    }
}