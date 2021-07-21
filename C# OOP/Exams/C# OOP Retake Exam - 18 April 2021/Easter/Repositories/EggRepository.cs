namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models { get; private set; } = new List<IEgg>();

        public void Add(IEgg model)
        {
            eggs.Add(model);
            Models = eggs;
        }

        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(e => e.Name == name);
        }

        public bool Remove(IEgg model)
        {
            if (eggs.Contains(model))
            {
                eggs.Remove(model);
                Models = eggs;

                return true;
            }

            return false;
        }
    }
}
