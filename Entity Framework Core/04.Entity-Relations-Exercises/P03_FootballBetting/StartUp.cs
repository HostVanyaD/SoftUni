namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();
            context.Database.EnsureCreated();
        }
    }
}
