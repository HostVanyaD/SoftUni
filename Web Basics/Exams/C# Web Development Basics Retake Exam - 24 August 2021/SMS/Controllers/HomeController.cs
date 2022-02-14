namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Services;
    using SMS.ViewModels.Product;
    using SMS.ViewModels.User;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidator validator;

        public HomeController(
            SMSDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.IndexLoggedIn();
            }

            return this.View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var user = this.data
                .Users
                .FirstOrDefault(u => u.Id == this.User.Id);

            var products = this.data
                .Products
                .ToList();

            var loggedInUserView = new UserLoggedInViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Products = products
                    .Select(p => new ProductListingViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price.ToString("F2")
                    })
                    .ToList()
            };

            return View(loggedInUserView);
        }
    }
}