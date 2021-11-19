namespace FastFood.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class FastFoodContextDesignTimeFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FastFoodContext>();

            //TODO: Configuration.GetConnectionString("Default")
            builder.UseSqlServer("Server=.;Database=FastFood;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new FastFoodContext(builder.Options);
        }
    }
}
