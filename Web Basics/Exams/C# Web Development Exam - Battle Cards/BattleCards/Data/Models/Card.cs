namespace BattleCards.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Card
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public int Id { get; init; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        [Required]
        [MaxLength(CardDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserCard> UsersCards { get; set; } = new HashSet<UserCard>();
    }
}
