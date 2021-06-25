using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public string Name { get; set; }
        public int Capacity { get; private set; }
        public int Count { get => roster.Count; }

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }
        
        public bool RemovePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                roster.Remove(roster.First(p => p.Name == name));
                return true;
            }
            return false;
        }
        
        public void PromotePlayer(string name)
        {
            var playerToPromote = roster.Find(p => p.Name == name);

            if (playerToPromote != null && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var playerToPromote = roster.Find(p => p.Name == name);

            if (playerToPromote != null && playerToPromote.Rank != "Trial")
            {
                playerToPromote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string _class)
        {
            Player[] kickedPlayers = roster.Where(p => p.Class == _class).ToArray();
            roster.RemoveAll(p => p.Class == _class);

            return kickedPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
