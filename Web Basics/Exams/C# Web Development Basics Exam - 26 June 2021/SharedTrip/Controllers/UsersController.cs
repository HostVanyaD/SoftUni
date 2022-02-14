namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
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
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel input)
        {
            var inputErrors = this.validator.ValidateUser(input);

            if (this.data.Users.Any(u => u.Username == input.Username))
            {
                inputErrors.Add($"User with '{input.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == input.Email))
            {
                inputErrors.Add($"User with '{input.Email}' email already exists.");
            }

            if (inputErrors.Any())
            {
                return Error(inputErrors);
            }

            var user = new User
            {
                Username = input.Username,
                Password = this.passwordHasher.HashPassword(input.Password),
                Email = input.Email
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }


        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel input)
        {
            var hashedPassword = this.passwordHasher.HashPassword(input.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == input.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username or password is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
