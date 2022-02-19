namespace Andreys
{
    using Andreys.Data;
    using Andreys.Services;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<AndreysDbContext>()
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<AndreysDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
