namespace BattleCards.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserCard
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
