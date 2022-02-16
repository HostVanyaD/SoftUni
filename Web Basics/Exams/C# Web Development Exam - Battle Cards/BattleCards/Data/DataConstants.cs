namespace BattleCards.Data
{
    public static class DataConstants
    {
        public const int IdMaxLength = 36;
        public const int DefaultMaxLength = 20;

        // User
        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;

        // Card
        public const int CardNameMinLength = 5;
        public const int CardNameMaxLength = 15;
        public const int CardDescriptionMaxLength = 200;
        public const int CardAttackAndHealthMinValue = 0;
    }
}
