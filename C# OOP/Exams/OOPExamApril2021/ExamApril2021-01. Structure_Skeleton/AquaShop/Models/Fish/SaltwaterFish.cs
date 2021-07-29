namespace AquaShop.Models.Fish
{
    using Aquariums.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SaltwaterFish : Fish
    {
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = 5;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
