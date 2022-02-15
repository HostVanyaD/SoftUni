namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services;
    using Git.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;
        private readonly IValidator validator;

        public UsersController(
            ApplicationDbContext data,
            IPasswordHasher passwordHasher,
            IValidator validator)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
            this.validator = validator;
        }

        public HttpResponse Register()
            => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel user)
        {
            var validationErrors = this.validator.ValidateUser(user);

            if (this.data.Users.Any(u => u.Username == user.Username))
            {
                validationErrors.Add($"User with '{user.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == user.Email))
            {
                validationErrors.Add($"User with '{user.Email}' e-mail already exists.");
            }

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var regUser = new User
            {
                Username = user.Username,
                Password = this.passwordHasher.HashPassword(user.Password),
                Email = user.Email
            };

            this.data.Users.Add(regUser);

            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
            => this.View(); // this.Login(new LoginUserFormModel { Username = "test123", Password = "test123" }); // FAKE LOGIN - can be used if you already registered with that username and password

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel user)
        {
            var hashedPassword = this.passwordHasher.HashPassword(user.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == user.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username or password is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
