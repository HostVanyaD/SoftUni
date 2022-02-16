namespace Panda.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Receipt
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Column(TypeName = "money")]
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;


        [Required]
        [ForeignKey(nameof(Recipient))]
        public string RecipientId { get; set; }
        public User Recipient { get; set; }


        [Required]
        [ForeignKey(nameof(Package))]
        public string PackageId { get; set; }
        public Package Package { get; set; }
    }
}
