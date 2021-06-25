using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }


        public Player(string name, string _class)
        {
            this.Name = name;
            this.Class = _class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public override string ToString()
        {
            return $"Player {this.Name}: {this.Class}{Environment.NewLine}" +
                   $"Rank: {this.Rank}{Environment.NewLine}" +
                   $"Description: {this.Description}";
        }
    }
}
