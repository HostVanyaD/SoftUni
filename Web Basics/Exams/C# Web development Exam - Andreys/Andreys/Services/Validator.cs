namespace Andreys.Services
{
    using Andreys.Data.Enums;
    using Andreys.ViewModels.Products;
    using Andreys.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null)
            {
                errors.Add("Username is required.");
            }

            if (user.Username.Length < UsernameMinLength ||
                user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (user.Password == null)
            {
                errors.Add("Password is required.");
            }

            if (user.Password.Length < PasswordMinLength ||
                user.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password is not valid. It must be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"Password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and Confirm Password do not match.");
            }

            return errors;
        }

        public ICollection<string> ValidateProduct(AddProductFormModel product)
        {
            var errors = new List<string>();

            if (product.Name == null)
            {
                errors.Add("Name is required.");
            }

            if (product.Name.Length < ProductNameMinLength ||
                product.Name.Length > ProductNameMaxLength)
            {
                errors.Add($"Product name is not valid. It must be between {ProductNameMinLength} and {ProductNameMaxLength} characters long.");
            }

            if (product.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description must be maximum {DescriptionMaxLength} characters long");
            }

            if (product.Price <= 0)
            {
                errors.Add("Price is required and it must be more than 0.");
            }

            if (!Enum.IsDefined(typeof(Category), product.Category))
            {
                errors.Add("Category is not valid.");
            }

            if (!Enum.IsDefined(typeof(Gender), product.Gender))
            {
                errors.Add("Gender is not valid.");
            }

            return errors;
        }
    }
}
