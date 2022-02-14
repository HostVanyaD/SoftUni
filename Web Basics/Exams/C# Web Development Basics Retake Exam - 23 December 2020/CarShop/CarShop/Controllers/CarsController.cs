namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService users;
        private readonly ApplicationDbContext data;

        public CarsController(
            IValidator validator,
            IUserService users,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.users = users;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.data
                .Cars
                .AsQueryable();

            if (this.users.IsMechanic(this.User.Id))
            {
                carsQuery = carsQuery
                    .Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery
                    .Where(c => c.OwnerId == this.User.Id);
            }

            var allCars = carsQuery
                .Select(c => new CarViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Image = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    RemainingIssues = c.Issues.Count(i => !i.IsFixed),
                    FixedIssues = c.Issues.Count(i => i.IsFixed)
                })
                .ToList();

            return View(allCars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.users.IsMechanic(this.User.Id))
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarFormModel model)
        {
            var validationErrors = this.validator.ValidateCar(model);

            if (this.data.Cars.Any(c => c.PlateNumber == model.PlateNumber))
            {
                validationErrors.Add("There is a car registered with the same plate number.");
            }

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id
            };

            data.Cars.Add(car);

            data.SaveChanges();

            return Redirect("/Cars/All");
        }
    }
}
