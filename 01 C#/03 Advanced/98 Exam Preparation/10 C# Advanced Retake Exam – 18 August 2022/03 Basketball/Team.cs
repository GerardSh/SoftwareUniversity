using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public List<Player> Players { get; private set; }

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            bool result = Players.Remove(Players.FirstOrDefault(x => x.Name == name));

            if (result)
            {
                OpenPositions++;
            }

            return result;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = Players.RemoveAll(x => x.Position == position);

            OpenPositions += count;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                player.Retired = true;
            }

            return player;
        }

        public List<Player> AwardPlayers(int games) => Players.Where(x => x.Games >= games).ToList();

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in Players.Where(x=>x.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
