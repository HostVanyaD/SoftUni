namespace EasterRaces.Repositories.Entities
{
    using System.Linq;

    using Models.Drivers.Contracts;

    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Name == name);
        }
    }
}
