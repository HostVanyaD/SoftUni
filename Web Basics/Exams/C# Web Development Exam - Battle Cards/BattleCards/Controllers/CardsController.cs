namespace BattleCards.Controllers
{
    using BattleCards.Data;
    using BattleCards.Data.Models;
    using BattleCards.Services;
    using BattleCards.ViewModels.Cards;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CardsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public CardsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var cards = this.data
                .Cards
                .Select(c => new CardListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Keyword = c.Keyword,
                    Attack = c.Attack,
                    Health = c.Health,
                    Description = c.Description
                })
                .ToList();

            return this.View(cards);
        }

        [Authorize]
        public HttpResponse Add()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCardFormModel card)
        {
            var validationErrors = this.validator.ValidateCard(card);

            if (validationErrors.Any())
            {
                return Error(validationErrors);
            }

            var newCard = new Card
            {
                Name = card.Name,
                ImageUrl = card.Image,
                Keyword = card.Keyword,
                Attack = card.Attack,
                Health = card.Health,
                Description = card.Description
            };

            this.data.Cards.Add(newCard);

            this.data.SaveChanges();

            var userCard = new UserCard
            {
                CardId = newCard.Id,
                UserId = this.User.Id
            };

            this.data.UserCards.Add(userCard);

            this.data.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var collection = this.data
                .UserCards
                .Where(uc => uc.UserId == this.User.Id)
                .Select(uc => new CardListingViewModel
                {
                    Id = uc.Card.Id,
                    Name = uc.Card.Name,
                    Keyword = uc.Card.Keyword,
                    ImageUrl = uc.Card.ImageUrl,
                    Attack = uc.Card.Attack,
                    Health = uc.Card.Health,
                    Description = uc.Card.Description
                })
                .ToList();

            return this.View(collection);
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            if (this.data.UserCards.Any(uc => uc.UserId == this.User.Id &&
                                          uc.CardId == cardId))
            {
                return Error("You already have this card.");
            }

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = this.User.Id
            };

            this.data.UserCards.Add(userCard);

            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var card = this.data
                .UserCards
                .FirstOrDefault(uc => uc.UserId == this.User.Id && uc.CardId == cardId);

            if (card == null)
            {
                return Error("Card is not present in your collection.");
            }

            this.data.UserCards.Remove(card);

            this.data.SaveChanges();

            return this.Redirect("/Cards/Collection");
        }
    }
}
