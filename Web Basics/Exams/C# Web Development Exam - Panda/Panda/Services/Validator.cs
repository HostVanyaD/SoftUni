namespace Panda.Services
{
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.Users;
    using System.Collections.Generic;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null)
            {
                errors.Add("Username is required.");
            }

            if (user.Username.Length < DefaultMinLength ||
                user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            if (user.Password == null)
            {
                errors.Add("Password is required.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and Confirm Password do not match.");
            }

            if (user.Email == null)
            {
                errors.Add("Email is required.");
            }

            if (user.Email.Length < DefaultMinLength ||
                user.Email.Length > DefaultMaxLength)
            {
                errors.Add($"Email is not valid. It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidatePackage(CreatePackageFormModel package)
        {
            var errors = new List<string>();

            if (package.Description == null)
            {
                errors.Add("Description is required.");
            }

            if (package.Description.Length < DefaultMinLength ||
                package.Description.Length > DefaultMaxLength)
            {
                errors.Add($"Description is not valid. It must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            return errors;
        }
    }
}
