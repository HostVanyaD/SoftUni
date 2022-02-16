namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Data;
    using Panda.Data.Models;
    using Panda.Services;
    using Panda.ViewModels.Users;
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
        public HttpResponse Register(UserRegisterFormModel user)
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

            var newUser = new User
            {
                Username = user.Username,
                Password = this.passwordHasher.HashPassword(user.Password),
                Email = user.Email
            };

            this.data.Users.Add(newUser);
            this.data.SaveChanges();

            return Redirect("/Home/Index");
        }

        public HttpResponse Login()
            => this.View();

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel user)
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

            return Redirect("/Home/IndexLoggedIn");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
