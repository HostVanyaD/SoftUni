namespace BattleCards.Controllers
{
    using BattleCards.Data;
    using BattleCards.Data.Models;
    using BattleCards.Services;
    using BattleCards.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => this.Login(new LoginUserFormModel { Username = "test123", Password = "test123" }); // FAKE LOGIN View();

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
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/Home/Index");
        }
    }
}
