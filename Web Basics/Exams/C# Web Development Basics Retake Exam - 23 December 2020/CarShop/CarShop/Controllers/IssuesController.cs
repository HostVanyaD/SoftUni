namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services;
    using CarShop.ViewModels.Issues;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class IssuesController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService users;
        private readonly ApplicationDbContext data;

        public IssuesController(
            IValidator validator,
            IUserService users,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.users = users;
            this.data = data;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!this.UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var carIssues = this.data
                .Cars
                .Where(i => i.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    CarId = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    IsUserMechanic = this.users.IsMechanic(this.User.Id),
                    Issues = c.Issues.Select(i => new IssueViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed,
                        IsFixedInformation = i.IsFixed ? "Yes" : "Not Yet"
                    })
                })
                .FirstOrDefault();

            if (carIssues == null)
            {
                return NotFound();
            }

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Add(string carId) => View(new AddIssueViewModel
        {
            CarId = carId
        });

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            if (!this.UserCanAccessCar(model.CarId))
            {
                return Unauthorized();
            }

            var modelErrors = this.validator.ValidateIssue(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId
            };

            data.Issues.Add(issue);

            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var userIsMechanic = this.users.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                return Unauthorized();
            }

            var issue = this.data.Issues.Find(issueId);

            issue.IsFixed = true;

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var issue = this.data.Issues.Find(issueId);

            this.data.Issues.Remove(issue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        private bool UserCanAccessCar(string carId)
        {
            var userIsMechanic = this.users.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                var userOwnsCar = this.users.OwnsCar(this.User.Id, carId);

                if (!userOwnsCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
