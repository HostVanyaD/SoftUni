namespace CarShop.Data
{
    using System;

    public static class DataConstants
    {
        // User
        public const int DefaultMaxLength = 20;
        public const int UsernameMinLength = 4;
        public const int PasswordMinLength = 5;
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";

        // Car
        public const int CarModelMinLength = 5;
        public const string PlateNumberRegex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2100;

        // Issue
        public const int DescriptionMinLenght = 5;
    }
}
