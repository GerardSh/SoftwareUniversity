
namespace FootballTeamGenerator
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name { get; set; }

        List<Player> players;

        public double Rating
        {
            get
            {
                double sum = 0;

                if (players.Count > 0)
                {
                    sum = players.Average(player => player.Skill);
                }

                return Math.Round(sum);
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(player);
        }
    }
}
