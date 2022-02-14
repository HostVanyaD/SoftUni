namespace CarShop.Services
{
    using CarShop.ViewModels.Cars;
    using CarShop.ViewModels.Issues;
    using CarShop.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateCar(AddCarFormModel model);

        ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
