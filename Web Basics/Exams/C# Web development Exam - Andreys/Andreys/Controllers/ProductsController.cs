namespace Andreys.Controllers
{
    using Andreys.Data;
    using Andreys.Data.Enums;
    using Andreys.Data.Models;
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly AndreysDbContext data;
        private readonly IValidator validator;

        public ProductsController(
            AndreysDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddProductFormModel model)
        {
            var validationErrors = this.validator.ValidateProduct(model);

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender),
                Price = model.Price
            };

            this.data.Products.Add(product);

            this.data.SaveChanges();

            return Redirect("/Home/Home");
        }

        [Authorize]
        public HttpResponse Details(int id)
        {
            var productDetails = this.data
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price.ToString("F2"),
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.ToString(),
                    Gender = p.Gender.ToString()
                })
                .FirstOrDefault();

            return this.View(productDetails);
        }

        [Authorize]
        public HttpResponse Delete(int id)
        {
            var product = this.data
                .Products
                .Find(id);

            this.data.Products.Remove(product);
            this.data.SaveChanges();

            return Redirect("/Home/Home");
        }
    }
}
