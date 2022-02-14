namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTrip
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Trip))]
        public string TripId { get; set; }

        public Trip Trip { get; set; }

    }
}
