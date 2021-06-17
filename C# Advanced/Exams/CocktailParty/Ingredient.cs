using System;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }
        
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Ingredient: {Name}");
            result.AppendLine($"Quantity: {Quantity}");
            result.AppendLine($"Alcohol: {Alcohol}");

            return result.ToString().TrimEnd();
        }
    }
}
