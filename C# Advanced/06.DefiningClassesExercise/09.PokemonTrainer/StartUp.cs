using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries); //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(t => t.Name == trainerName))
                {
                    var findTrainer = trainers.Find(t => t.Name == trainerName);
                    findTrainer.CollectionOfPokemons.Add(currentPokemon);
                }
                else
                {
                    var currentTrainer = new Trainer
                    {
                        Name = trainerName,
                        CollectionOfPokemons = new List<Pokemon> { currentPokemon }
                    };

                    trainers.Add(currentTrainer);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    int countOfPokemonsWithCurrentElement = GetCountWithGivenElement(input, trainer);
                    ModifyingTrainersCollection(trainer, countOfPokemonsWithCurrentElement);
                }
            }

            trainers
                .OrderByDescending(t => t.Badges)
                .ToList()
                .ForEach(t => Console.WriteLine($"{t.Name} {t.Badges} {t.CollectionOfPokemons.Count}"));
        }

        private static void ModifyingTrainersCollection(Trainer trainer, int countOfPokemonsWithCurrentElement)
        {
            if (countOfPokemonsWithCurrentElement >= 1)
            {
                trainer.Badges++;
            }
            else
            {
                for (int i = 0; i < trainer.CollectionOfPokemons.Count; i++)
                {
                    Pokemon pokemon = trainer.CollectionOfPokemons[i];
                    pokemon.Health -= 10;

                    if (pokemon.Health <= 0)
                    {
                        trainer.CollectionOfPokemons.Remove(pokemon);
                    }
                }
            }
        }

        private static int GetCountWithGivenElement(string input, Trainer trainer)
        {
            int count = 0;

            foreach (var pokemon in trainer.CollectionOfPokemons)
            {
                if (pokemon.Element == input)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
