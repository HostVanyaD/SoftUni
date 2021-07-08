using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double modifier = 2;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;

            switch (flourType.ToLower())
            {
                case "white": modifier *= 1.5; break;
                case "wholegrain": modifier *= 1.0; break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy": modifier *= 0.9; break;
                case "chewy": modifier *= 1.1; break;
                case "homemade": modifier *= 1.0; break;
            }
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                Validator.ThrowIfValueISNotInSet(new HashSet<string> { "white", "wholegrain" },
                    value.ToLower(),
                    "Invalid type of dough.");

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                Validator.ThrowIfValueISNotInSet(new HashSet<string> { "crispy", "chewy", "homemade" },
                    value.ToLower(),
                    "Invalid type of dough.");

                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowExceptionIfNumberIsOutOfRange(MinWeight, MaxWeight, value,
                    $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                weight = value;
            }
        }

        public double CalculateCalories()
        {
            return weight * modifier;
        }

        //public double CalculateCalories()
        //{
        //    var flourModifier = GetFlourModifier(FlourType);
        //    var bakingTechniqueModifier = GetBakingModifier(BakingTechnique);

        //    return (2 * Weight) * flourModifier * bakingTechniqueModifier;
        //}

        //private double GetBakingModifier(string bakingTechnique) => bakingTechnique.ToLower() switch
        //{
        //    "crispy" => 0.9,
        //    "chewy" => 1.1,
        //    "homemade" => 1.0,
        //    _ => throw new NotImplementedException()
        //};

        //private double GetFlourModifier(string flourType)
        //{
        //    if (flourType.ToLower() == "white")
        //    {
        //        return 1.5;
        //    }
        //    return 1.0;
        //}
    }
}
