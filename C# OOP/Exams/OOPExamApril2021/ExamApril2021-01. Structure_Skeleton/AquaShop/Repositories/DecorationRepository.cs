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
        }

        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        public void Add(IDecoration model)
            => decorations.Add(model);

        public IDecoration FindByType(string type)
            => Models.FirstOrDefault(m => m.GetType().Name == type);

        public bool Remove(IDecoration model)
            => decorations.Remove(model);
    }
}
