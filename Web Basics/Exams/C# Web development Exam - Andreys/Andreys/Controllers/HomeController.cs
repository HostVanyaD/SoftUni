namespace Andreys.Controllers
{
    using Andreys.Data;
    using Andreys.ViewModels.Products;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly AndreysDbContext data;

        public HomeController(AndreysDbContext data)
            => this.data = data;

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Home(); ;
            }
            return this.View();
        }

        [Authorize]
        public HttpResponse Home()
        {
            var products = this.data
                .Products
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString("F2"),
                    ImageUrl = p.ImageUrl
                })
                .ToList();

            return this.View(products);
        }
    }
}
