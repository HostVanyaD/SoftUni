namespace Git.Services
{
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;
    using Git.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel user);

        ICollection<string> ValidateRepoository(CreateRepositoryFormModel repository);

        ICollection<string> ValidateCommit(CreateCommitFormModel commit);
    }
}
