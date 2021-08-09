namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Models.Cars.Contracts;

    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Model == name);
        }
    }
}
