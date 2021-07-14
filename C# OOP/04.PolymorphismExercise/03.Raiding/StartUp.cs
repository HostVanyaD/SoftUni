using System;
using System.Collections.Generic;
using System.Linq;
using _03.Raiding.Models;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfHeroes = int.Parse(Console.ReadLine());

            List<BaseHero> raid = new List<BaseHero>();

            while(raid.Count != numOfHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    if (nameof(Druid) == heroType)
                    {
                        raid.Add(new Druid(heroName));
                    }
                    else if (nameof(Paladin) == heroType)
                    {
                        raid.Add(new Paladin(heroName));
                    }
                    else if (nameof(Rogue) == heroType)
                    {
                        raid.Add(new Rogue(heroName));
                    }
                    else if (nameof(Warrior) == heroType)
                    {
                        raid.Add(new Warrior(heroName));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raid)
            {
                Console.WriteLine(hero.CastAbility());
            }

            Console.WriteLine(raid.Sum(h => h.Power) >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
