namespace SMS.Services
{
    using SMS.ViewModels.Product;
    using SMS.ViewModels.User;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateProduct(CreateProductFormModel model);
    }
}
