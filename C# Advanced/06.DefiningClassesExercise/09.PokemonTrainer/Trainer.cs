using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; } = 0;
        public List<Pokemon> CollectionOfPokemons { get; set; }
    }
}
