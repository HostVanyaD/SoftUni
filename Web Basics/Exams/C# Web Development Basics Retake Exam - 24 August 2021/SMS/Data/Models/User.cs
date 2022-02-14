namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(EmailRegex)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CartId { get; set; }

        public Cart Cart { get; set; }

    }
}
