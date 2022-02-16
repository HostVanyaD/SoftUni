namespace Panda.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Package
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Description { get; set; }

        public double Weight  { get; set; }

        public string ShippingAddress { get; set; }

        public string Status { get; set; } = PackageStatusPending;

        public DateTime EstimatedDeliveryDate  { get; set; }


        [Required]
        [ForeignKey(nameof(Recipient))]
        public string RecipientId  { get; set; }
        public User Recipient { get; set; }
    }
}
