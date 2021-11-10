﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
            = new HashSet<Town>();
    }
}
