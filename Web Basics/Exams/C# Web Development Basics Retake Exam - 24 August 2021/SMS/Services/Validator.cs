namespace SMS.Services
{
    using SMS.ViewModels.Product;
    using SMS.ViewModels.User;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null)
            {
                errors.Add("Username is required.");
            }

            if (model.Username.Length < UsernameMinLength ||
                model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username is not valid. It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Email == null)
            {
                errors.Add("Email is required.");
            }

            if (!Regex.IsMatch(model.Email, EmailRegex))
            {
                errors.Add("Email is not a valid e-mail address.");
            }

            if (model.Password == null)
            {
                errors.Add("Password is required.");
            }

            if (model.Password.Length < PasswordMinLength ||
                model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password is not valid. It must be between {PasswordMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != null && model.Password.Any(x => x == ' '))
            {
                errors.Add($"Password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and Confirm Password do not match.");
            }

            return errors;
        }

        public ICollection<string> ValidateProduct(CreateProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null)
            {
                errors.Add("Product Name is required.");
            }

            if (model.Name.Length < ProductNameMinLentgh ||
                model.Name.Length > DefaultMaxLength)
            {
                errors.Add($"Product Name is not valid. It must be between {ProductNameMinLentgh} and {DefaultMaxLength} characters long.");
            }

            if (model.Price < (decimal)PriceMinValue ||
                model.Price > (decimal)PriceMaxValue)
            {
                errors.Add($"Price is not valid. It must be in range {PriceMinValue} - {PriceMaxValue}.");
            }

            return errors;
        }
    }
}
