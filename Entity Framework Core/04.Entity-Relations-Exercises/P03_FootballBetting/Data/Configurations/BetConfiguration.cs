namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet
                .HasKey(b => b.BetId);

            bet
                .Property(b => b.Amount)
                .IsRequired(true);

            bet
                .Property(b => b.Prediction)
                .IsRequired(true);

            bet
                .Property(b => b.DateTime)
                .IsRequired(true);

            bet
                .HasOne(b => b.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            bet
                .HasOne(b => b.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
