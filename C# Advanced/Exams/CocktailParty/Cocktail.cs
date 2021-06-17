using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {        
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }        
        public int MaxAlcohol { get; set; }
        public int Capacity { get; set; }
        public int CurrentAlcoholLevel { get; set; } = 0;
        
        public Cocktail(string name, int maxAlcohol, int capacity)
        {
            this.Name = name;            
            this.MaxAlcohol = maxAlcohol;
            this.Capacity = capacity;
            this.Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Contains(ingredient) && 
                CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcohol &&
                Ingredients.Count < Capacity)
            {
                Ingredients.Add(ingredient);
                CurrentAlcoholLevel += ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                Ingredient ingredientToRemove = Ingredients.First(x => x.Name == name);
                CurrentAlcoholLevel -= ingredientToRemove.Alcohol;
                Ingredients.Remove(ingredientToRemove);

                return true;
            }

            return false;
        }

        public Ingredient FindIngridient(string name)
        {            
            return Ingredients.FirstOrDefault(x => x.Name == name);            
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var ingredient in Ingredients)
            {
                result.AppendLine(ingredient.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
