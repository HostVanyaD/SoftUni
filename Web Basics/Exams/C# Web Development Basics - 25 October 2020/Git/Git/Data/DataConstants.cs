namespace Git.Data
{
    public static class DataConstants
    {
        public const int IdMaxLength = 36;

        // User
        public const int DefaultMaxLength = 20;
        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;
        public const string EmailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        // Repository
        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;
        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";

        // Commit
        public const int CommitDescriptionMinLength = 5;
    }
}
