namespace WarCroft.Entities.Characters
{
    using System;

    using Contracts;
    using Inventory;
    using Constants;

    public class Priest : Character, IHealer
    {
        private const double baseHeatlh = 50;
        private const double baseArmor = 25;
        private const double abilityPoints = 40;

        public Priest(string name)
            : base(name, baseHeatlh, baseArmor, abilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();

            if (character.IsAlive)
            {
                character.Health += this.AbilityPoints;
                if (character.Health > character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
