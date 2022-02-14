namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Services;
    using SMS.ViewModels.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductsController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidator validator;

        public ProductsController(
            SMSDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var validationErrors = this.validator.ValidateProduct(model);

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price
            };

            this.data.Products.Add(product);

            this.data.SaveChanges();

            return Redirect("/Home/IndexLoggedIn");
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(ProductListingViewModel model)
        {
            var user = this.data
                .Users
                .FirstOrDefault(u => u.Id == this.User.Id);

            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = decimal.Parse(model.Price),
                CartId = user.CartId
            };

            this.data.Update(product);
            this.data.SaveChanges();

            return Redirect("/Carts/Details");
        }
    }
}
