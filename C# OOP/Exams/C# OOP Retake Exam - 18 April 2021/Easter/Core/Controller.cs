namespace Easter.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Repositories;
    using Models.Dyes;
    using Models.Dyes.Contracts;
    using Models.Eggs.Contracts;
    using Models.Eggs;
    using Models.Workshops.Contracts;
    using Models.Workshops;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IEgg currentEgg = eggs.FindByName(eggName);

            IWorkshop workshop = new Workshop();

            List<IBunny> filteredBunnies = bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (filteredBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (filteredBunnies.Count > 0)
            {
                IBunny currentBunny = filteredBunnies.First();

                while (true)
                {
                    if (currentBunny.Energy == 0 || currentBunny.Dyes.All(x => x.IsFinished()))
                    {
                        filteredBunnies.Remove(currentBunny);
                        break;
                    }

                    workshop.Color(currentEgg, currentBunny);

                    if (currentEgg.IsDone())
                    {
                        break;
                    }
                }

                if (currentEgg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(currentEgg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{eggs.Models.Count(e => e.IsDone())} eggs are done!");
            result.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");
                result.AppendLine($"Dyes: {bunny.Dyes.Count(d => d.IsFinished() == false)} not finished");
            }

            return result.ToString().TrimEnd();
        }
    }
}
