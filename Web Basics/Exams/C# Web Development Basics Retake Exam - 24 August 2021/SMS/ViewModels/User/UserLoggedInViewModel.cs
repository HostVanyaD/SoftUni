namespace SMS.ViewModels.User
{
    using SMS.ViewModels.Product;
    using System.Collections.Generic;

    public class UserLoggedInViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public ICollection<ProductListingViewModel> Products { get; set; } = new HashSet<ProductListingViewModel>();
    }
}
