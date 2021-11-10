namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> color)
        {
            color
                .HasKey(c => c.ColorId);

            color
                .Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(true);
        }
    }
}
