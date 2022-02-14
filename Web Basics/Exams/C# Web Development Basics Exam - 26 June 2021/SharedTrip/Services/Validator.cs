namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null ||
                user.Username.Length < UsernameMinLength ||
                user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (user.Password == null ||
                user.Password.Length < PasswordMinLength ||
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
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(AddTripFormModel trip)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(trip.StartPoint))
            {
                errors.Add("Start point field is required!");
            }

            if (string.IsNullOrEmpty(trip.EndPoint))
            {
                errors.Add("End point field is required!");
            }

            if (trip.Seats < SeatsMinValue ||
                trip.Seats > SeatsMaxValue)
            {
                errors.Add($"Seats number should be between {SeatsMinValue} and {SeatsMaxValue}");
            }

            if (string.IsNullOrEmpty(trip.Description) ||
                trip.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description is required and it must be maximum {DescriptionMaxLength} characters long.");
            }

            if (!DateTime.TryParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                errors.Add("Departure time format is not valid. Please use 'dd.MM.yyyy HH:ss' format");
            }

            return errors;
        }
    }
}
