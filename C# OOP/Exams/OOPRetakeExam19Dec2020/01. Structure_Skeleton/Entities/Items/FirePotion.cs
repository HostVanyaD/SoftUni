namespace WarCroft.Entities.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarCroft.Entities.Characters.Contracts;

    public class FirePotion : Item
    {
        public const int DefaultWeight = 5;

        public FirePotion() 
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
