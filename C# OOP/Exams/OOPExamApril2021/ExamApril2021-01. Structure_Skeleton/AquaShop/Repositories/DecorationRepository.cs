namespace AquaShop.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
            Models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models { get; private set; }

        public void Add(IDecoration model)
        {
            decorations.Add(model);

            Models = decorations;
        }

        public IDecoration FindByType(string type)
        {
            return Models.FirstOrDefault(m => m.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            if (Models.Contains(model))
            {
                decorations.Remove(model);

                Models = decorations;

                return true;
            }

            return false;
        }
    }
}
