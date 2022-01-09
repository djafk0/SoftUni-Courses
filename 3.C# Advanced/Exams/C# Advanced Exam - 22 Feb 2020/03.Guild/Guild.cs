using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public int Count => roster.Count();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (Capacity >= Count + 1)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] curr = roster.Where(x => x.Class == @class).ToArray();
            roster.RemoveAll(x => x.Class == @class);
            return curr;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
