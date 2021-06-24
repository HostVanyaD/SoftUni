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
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return roster.Count;
            }
        }

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
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
            roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";            
        }

        public Player[] KickPlayersByClass(string theirClass)
        {
            Player[] kickedPlayers = roster.Where(p => p.Class == theirClass).ToArray();
            roster = roster.Where(p => p.Class != theirClass).ToList();

            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
