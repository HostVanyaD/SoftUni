namespace BattleCards.Services
{
    using BattleCards.ViewModels.Cards;
    using BattleCards.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Data.DataConstants;

    internal class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null)
            {
                errors.Add("Username is required.");
            }

            if (user.Username.Length < UsernameMinLength ||
                user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (user.Password == null)
            {
                errors.Add("Password is required.");
            }

            if (user.Password.Length < PasswordMinLength ||
                user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLength} and {DefaultMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and Confirm Password do not match.");
            }

            if (user.Email == null)
            {
                errors.Add("Email is required.");
            }

            return errors;
        }

        public ICollection<string> ValidateCard(AddCardFormModel card)
        {
            var errors = new List<string>();

            if (card.Name == null)
            {
                errors.Add("Username is required.");
            }

            if (card.Name.Length < CardNameMinLength ||
                card.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Username '{card.Name}' is not valid. It must be between {CardNameMinLength} and {CardNameMaxLength} characters long.");
            }

            if (card.Image == null)
            {
                errors.Add("ImageUrl is required.");
            }

            if (!Uri.IsWellFormedUriString(card.Image, UriKind.Absolute))
            {
                errors.Add("Image URL is not valid.");
            }

            if (card.Keyword == null)
            {
                errors.Add("Keyword is required.");
            }

            if (card.Attack < CardAttackAndHealthMinValue)
            {
                errors.Add("Card Attack must be positive.");
            }

            if (card.Health < CardAttackAndHealthMinValue)
            {
                errors.Add("Card Health must be positive.");
            }

            if (card.Description == null)
            {
                errors.Add("Description is required.");
            }

            if (card.Description.Length > CardDescriptionMaxLength)
            {
                errors.Add($"Description is not valid. It must be maximum {CardDescriptionMaxLength} characters long.");
            }

            return errors;
        }
    }
}
