using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } = "Trail";
        public string Description { get; set; } = "n/a";

        public Player(string name, string _class)
        {
            Name = name;
            Class = _class;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Player {Name}: {Class}")
            .AppendLine($"Rank: {Rank}")
            .AppendLine($"Description: {Description}");

            return result.ToString().TrimEnd();
        }
    }
}
