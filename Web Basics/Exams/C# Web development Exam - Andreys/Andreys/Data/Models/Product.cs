namespace Andreys.Data.Models
{
    using Andreys.Data.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Gender Gender { get; set; }
    }
}
