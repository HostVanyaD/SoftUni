namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Repository
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; init; }

        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
