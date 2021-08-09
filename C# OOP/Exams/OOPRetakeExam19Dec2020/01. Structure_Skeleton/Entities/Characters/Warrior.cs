namespace WarCroft.Entities.Characters
{
    using System;

    using Constants;
    using Contracts;
    using Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double baseHeatlh = 100;
        private const double baseArmor = 50;
        private const double abilityPoints = 40;

        public Warrior(string name) 
            : base(name, baseHeatlh, baseArmor, abilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            this.EnsureAlive();

            if (character.IsAlive == true)
            {
                character.TakeDamage(this.AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
