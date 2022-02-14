namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.ViewModels.Cart;
    using SMS.ViewModels.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CartsController : Controller
    {
        private readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
            => this.data = data;

        [Authorize]
        public HttpResponse Details()
        {
            var cart = this.data
                .Carts
                .Where(c => c.UserId == this.User.Id)
                .FirstOrDefault();

            var products = this.data
                .Products
                .Where(p => p.CartId == cart.Id)
                .Select(p => new DetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString("F2")
                })
                .ToList();

            return View(products);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var product = this.data
                .Products
                .FirstOrDefault(p => p.Id == productId);

            var productModel = new ProductListingViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString("F2"),
            };

            return View("/Products/Add", productModel);

        }

        [Authorize]
        public HttpResponse Buy()
        {
            var cart = this.data
                .Carts
                .Where(c => c.UserId == User.Id)
                .FirstOrDefault();

            var cartsProducts = this.data
                .Products
                .Where(p => p.CartId == cart.Id)
                .ToArray();

            foreach (var product in cartsProducts)
            {
                product.CartId = null;
            }

            this.data.Carts.Update(cart);
            this.data.SaveChanges();

            return Redirect("/Home/IndexLoggedIn");
        }

    }
}
