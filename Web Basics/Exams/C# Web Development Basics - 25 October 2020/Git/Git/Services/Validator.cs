namespace Git.Services
{
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;
    using Git.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
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
                user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username is not valid. It must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (user.Email == null)
            {
                errors.Add("Email is required.");
            }

            if (!Regex.IsMatch(user.Email, EmailRegex))
            {
                errors.Add("Email is not a valid e-mail address.");
            }

            if (user.Password == null)
            {
                errors.Add("Password is required.");
            }

            if (user.Password.Length < PasswordMinLength ||
                user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password is not valid. It must be between {PasswordMinLength} and {DefaultMaxLength} characters long.");
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

        public ICollection<string> ValidateRepoository(CreateRepositoryFormModel repository)
        {
            var errors = new List<string>();

            if (repository.Name == null)
            {
                errors.Add("Repsitory Name is required.");
            }

            if (repository.Name.Length < RepositoryNameMinLength ||
                repository.Name.Length > RepositoryNameMaxLength)
            {
                errors.Add($"Repsitory Name is not valid. It must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} characters long.");
            }

            if (repository.RepositoryType != RepositoryPublicType &&
                repository.RepositoryType != RepositoryPrivateType)
            {
                errors.Add($"Repository type can be either '{RepositoryPublicType}' or '{RepositoryPrivateType}'.");
            }

            return errors;
        }

        public ICollection<string> ValidateCommit(CreateCommitFormModel commit)
        {
            var errors = new List<string>();

            if (commit.Description == null)
            {
                errors.Add("Description is required.");
            }

            if (commit.Description.Length < CommitDescriptionMinLength)
            {
                errors.Add($"Description must be at least {CommitDescriptionMinLength} characters long.");
            }

            return errors;
        }
    }
}
