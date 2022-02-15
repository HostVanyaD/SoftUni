namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services;
    using Git.ViewModels.Commits;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CommitsController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("F"),
                    Repository = c.Repository.Name
                })
                .ToList();

            return this.View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitFormModel commit)
        {
            if (!this.data.Repositories.Any(r => r.Id == commit.Id))
            {
                return NotFound();
            }

            var validationErrors = this.validator.ValidateCommit(commit);

            var newCommit = new Commit
            {
                Description = commit.Description,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = commit.Id,
                CreatorId = this.User.Id
            };

            this.data.Commits.Add(newCommit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data
                .Commits
                .Find(id);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            this.data.Commits.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
