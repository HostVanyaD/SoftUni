namespace CarShop.Services
{
    using CarShop.ViewModels.Cars;
    using CarShop.ViewModels.Issues;
    using CarShop.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null ||
                model.Username.Length < UsernameMinLength ||
                model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username is not valid. It must be betweetn {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Email == null)
            {
                errors.Add("Email address is required.");
            }

            if (model.Password == null ||
                model.Password.Length < PasswordMinLength ||
                model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Paswword is not valid. It must be betweetn {PasswordMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != null && model.Password.Any(x => x == ' '))
            {
                errors.Add("Paswword is not valid. It cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Provided password doesn't match confirm password.");
            }

            if (model.UserType != UserTypeClient && model.UserType != UserTypeMechanic)
            {
                errors.Add($"The user can be either a '{UserTypeClient}' or a '{UserTypeMechanic}'.");
            }

            return errors;
        }

        public ICollection<string> ValidateCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model == null ||
                model.Model.Length < CarModelMinLength ||
                model.Model.Length > DefaultMaxLength)
            {
                errors.Add($"Model is not valid. It must be between {CarModelMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Year < CarYearMinValue || model.Year > CarYearMaxValue)
            {
                errors.Add($"Year '{model.Year}' is not valid. It must be between {CarYearMinValue} and {CarYearMaxValue}.");
            }

            if (model.Image == null || 
                !Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add("Image URL is not valid.");
            }

            if (model.PlateNumber == null ||
                !Regex.IsMatch(model.PlateNumber, PlateNumberRegex))
            {
                errors.Add($"Plate number '{model.PlateNumber}' is not valid. It should be in 'XX0000XX' format.");
            }

            return errors;
        }

        public ICollection<string> ValidateIssue(AddIssueFormModel model)
        {
            var errors = new List<string>();

            if (model.CarId == null)
            {
                errors.Add("Car ID is required.");
            }

            if (model.Description == null ||
                model.Description.Length < DescriptionMinLenght)
            {
                errors.Add($"Description must be at least {DescriptionMinLenght} characters long.");
            }

            return errors;
        }
    }
}
