namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Data;
    using Panda.ViewModels.Users;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;

        public HomeController(ApplicationDbContext data)
            => this.data = data;

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.IndexLoggedIn();
            }

            return this.View();
        }
             

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var user = this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .Select(u => new UserIndexViewModel
                {
                    Username = u.Username
                })
                .FirstOrDefault();

            return this.View(user);
        }
    }
}
