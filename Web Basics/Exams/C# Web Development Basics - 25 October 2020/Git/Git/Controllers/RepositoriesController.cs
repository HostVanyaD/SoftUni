namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services;
    using Git.ViewModels.Repositories;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;
    using static Data.DataConstants;

    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var repopsitoriesQuery = this.data
                .Repositories
                .AsQueryable();

            if (this.User.IsAuthenticated)
            {
                repopsitoriesQuery = repopsitoriesQuery
                    .Where(r => r.IsPublic || r.OwnerId == this.User.Id);
            }
            else
            {
                repopsitoriesQuery = repopsitoriesQuery
                    .Where(r => r.IsPublic);
            }

            var repositories = repopsitoriesQuery
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new RepositoryListingView
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
                    Commits = r.Commits.Count()
                })
                .ToList();

            return this.View(repositories);
        }

        [Authorize]
        public HttpResponse Create()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryFormModel repository)
        {
            var validationErrors = this.validator.ValidateRepoository(repository);

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var newRepository = new Repository
            {
                Name = repository.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = repository.RepositoryType == RepositoryPublicType,
                OwnerId = this.User.Id
            };

            this.data.Repositories.Add(newRepository);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
