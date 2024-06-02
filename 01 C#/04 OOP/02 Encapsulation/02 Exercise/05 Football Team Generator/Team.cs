using System.Numerics;

namespace FootballTeamGenerator
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
            Rating = 0;
        }

        public string Name { get; set; }

        List<Player> players;

        public double Rating { get; set; }

        public void AddPlayer(Player player)
        {
            players.Add(player);
            CalculateRating();
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);

            try
            {
                if (player == null)
                {
                    throw new Exception($"Player {playerName} is not in {Name} team.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            players.Remove(player);

            CalculateRating();
        }

        void CalculateRating()
        {
            double sum = 0;

            if (players.Count > 0)
            {
                sum = players.Average(player => (player.Endurance + player.Dribbel + player.Passing + player.Spring + player.Shooting) / 5.0);
            }

            Rating = Math.Round(sum);
        }
    }
}
