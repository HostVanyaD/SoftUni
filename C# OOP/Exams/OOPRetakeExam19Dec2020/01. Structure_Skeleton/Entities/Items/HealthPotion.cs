namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

    public class HealthPotion : Item
    {
        public const int DefaultWeight = 5;

        public HealthPotion() 
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
