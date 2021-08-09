namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            this.Models = new List<T>();
        }

        public ICollection<T> Models { get; }

        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)this.Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.Models.Remove(model);
        }
    }
}
