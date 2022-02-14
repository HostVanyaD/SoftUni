namespace SMS.Controllers
{
    using System;
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Services;
    using SMS.ViewModels.User;

    public class UsersController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IPasswordHasher passwordHasher;
        private readonly IValidator validator;

        public UsersController(
            SMSDbContext data,
            IPasswordHasher passwordHasher,
            IValidator validator)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
            this.validator = validator;
        }

        public HttpResponse Login() => this.Login(new LoginUserFormModel { Username = "test123", Password = "test123" }); // FAKE LOGIN
        //View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username or password is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Home/IndexLoggedIn");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var validationErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                validationErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                validationErrors.Add($"User with '{model.Email}' e-mail address already exists.");
            }

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email,
                CartId = Guid.NewGuid().ToString()
            };

            var cart = new Cart()
            {
                Id = user.CartId,
                UserId = user.Id
            };

            this.data.Carts.Add(cart);
            this.data.Users.Add(user);

            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }
    }
}

