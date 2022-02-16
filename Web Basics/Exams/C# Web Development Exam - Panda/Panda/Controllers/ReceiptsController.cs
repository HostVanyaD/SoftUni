namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Data;
    using Panda.ViewModels.Receipts;
    using System.Linq;

    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext data;

        public ReceiptsController(ApplicationDbContext data)
            => this.data = data;

        [Authorize]
        public HttpResponse Index()
        {
            var receipts = this.data
                .Receipts
                .Where(r => r.RecipientId == this.User.Id)
                .Select(r => new ReceiptListingViewModel
                {
                    Id = r.Id,
                    Fee = $"${r.Fee.ToString("F2")}",
                    IssuedOn = r.IssuedOn.ToString("F"),
                    Recipient = r.Recipient.Username
                })
                .ToList();

            return this.View(receipts);
        }
    }
}
