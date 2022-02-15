namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Commit
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; init; }


        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public User Creator { get; set; }



        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
