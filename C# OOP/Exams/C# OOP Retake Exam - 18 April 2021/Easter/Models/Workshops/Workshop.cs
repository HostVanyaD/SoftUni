namespace Easter.Models.Workshops
{
    using Contracts;
    using Bunnies.Contracts;
    using Eggs.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (egg.IsDone() == false)
            {
                if (bunny.Energy == 0 || bunny.Dyes.All(d => d.IsFinished()))
                {
                    break;
                }

                egg.GetColored();
                bunny.Work();
            }
        }
    }
}
