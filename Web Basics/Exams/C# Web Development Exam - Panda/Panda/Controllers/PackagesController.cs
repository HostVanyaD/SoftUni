namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Data;
    using Panda.Data.Models;
    using Panda.Services;
    using Panda.ViewModels.Packages;
    using System.Collections.Generic;
    using System.Linq;
    using static Data.DataConstants;

    public class PackagesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public PackagesController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create() 
        { 
            var recipients = this.data
                .Users
                .Select(u => u.Username)
                .ToList();

            if (!recipients.Any())
            {
                return this.View(new List<string>());
            }

            return this.View(recipients);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreatePackageFormModel package)
        {
            var validationErrors = this.validator.ValidatePackage(package);

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var userId = this.data
                .Users
                .Where(u => u.Username == package.Recipient)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return BadRequest();
            }


            var newPackage = new Package
            {
                Description = package.Description,
                Weight = double.Parse(package.Weight),
                ShippingAddress = package.ShippingAddress,
                RecipientId = userId
            };

            this.data.Packages.Add(newPackage);
            this.data.SaveChanges();

            return Redirect("/Packages/Pending");
        }

        [Authorize]
        public HttpResponse Pending()
        {
            var packages = this.data
                .Packages
                .Where(p => p.Status == PackageStatusPending)
                .Select(p => new PendingPackageListingViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Weight = p.Weight.ToString("F2"),
                    ShippingAddress = p.ShippingAddress,
                    Recipient = p.Recipient.Username
                })
                .ToList();

            return this.View(packages);
        }

        [Authorize]
        public HttpResponse Deliver(string id)
        {
            var package = this.data
                .Packages
                .FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return BadRequest();
            }

            package.Status = PackageStatusDelivered;

            var receipt = new Receipt
            {
                PackageId = package.Id,
                RecipientId = package.RecipientId,
                Fee = (decimal)package.Weight * 2.67m
            };

            this.data.Receipts.Add(receipt);

            this.data.SaveChanges();

            return Redirect("/Receipts/Index");
        }

        [Authorize]
        public HttpResponse Delivered()
        {
            var packages = this.data
                .Packages
                .Where(p => p.Status == PackageStatusDelivered)
                .Select(p => new DeliveredPackageListingViewModel
                {
                    Description = p.Description,
                    Weight = p.Weight.ToString(),
                    ShippingAddress = p.ShippingAddress,
                    Recipient = p.Recipient.Username,
                    Status = p.Status
                })
                .ToList();

            return this.View(packages);
        }
    }
}
