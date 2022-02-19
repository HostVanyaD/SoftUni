namespace Andreys.Services
{
    using Andreys.ViewModels.Products;
    using Andreys.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel user);

        ICollection<string> ValidateProduct(AddProductFormModel product);
    }
}
