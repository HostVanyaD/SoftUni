namespace Panda.Services
{
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterFormModel user);

        public ICollection<string> ValidatePackage(CreatePackageFormModel package);
    }
}
