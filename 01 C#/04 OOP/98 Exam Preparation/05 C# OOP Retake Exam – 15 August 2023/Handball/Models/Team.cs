using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        List<IPlayer> players;

        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                name = value;
            }
        }

        public int PointsEarned { get; private set; }

        public double OverallRating => players.Any() ? Math.Round(players.Average(x => x.Rating), 2) : 0;

        public IReadOnlyCollection<IPlayer> Players => players;

        public void Draw()
        {
            PointsEarned += 1;

            foreach (var player in players)
            {
                if (player is Goalkeeper)
                {
                    player.IncreaseRating();

                    break;
                }
            }
        }

        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player) => players.Add(player);

        public void Win()
        {
            PointsEarned += 3;

            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.AppendLine("--Players: " + (players.Any() ? string.Join(", ", players.Select(x => x.Name)) : "none"));

            return sb.ToString().Trim();
        }
    }
}
