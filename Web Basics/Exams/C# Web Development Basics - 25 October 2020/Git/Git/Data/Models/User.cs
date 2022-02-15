namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User
    {
        [Key]
        [MaxLength(IdMaxLength)]
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

        public ICollection<Repository> Repositories { get; set; } = new HashSet<Repository>();

        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
