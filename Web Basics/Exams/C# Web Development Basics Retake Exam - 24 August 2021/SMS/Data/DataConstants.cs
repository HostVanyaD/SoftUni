namespace SMS.Data
{
    public static class DataConstants
    {
        // User
        public const int DefaultMaxLength = 20;
        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;
        public const string EmailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        // Product
        public const string SQLTypeName = "money";
        public const int ProductNameMinLentgh = 4;
        public const double PriceMinValue = 0.05;
        public const double PriceMaxValue = 1000;
    }
}
