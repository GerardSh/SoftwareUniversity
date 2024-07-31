using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        IRepository<IPlayer> players;
        IRepository<ITeam> teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            var sortedTeams = teams.Models.OrderByDescending(x => x.PointsEarned).ThenByDescending(x=>x.OverallRating).ThenBy(x => x.Name);

            var sb = new StringBuilder();

            sb.AppendLine("***League Standings***");

            foreach (var team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);

            if (player == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            ITeam team = teams.GetModel(teamName);

            if (team == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                return Result(firstTeam, secondTeam);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                return Result(secondTeam, firstTeam);
            }

            firstTeam.Draw();
            secondTeam.Draw();

            return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);

            static string Result(ITeam winningTeam, ITeam loosingTeam)
            {
                winningTeam.Win();
                loosingTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, winningTeam.Name, loosingTeam.Name);
            }
        }
        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = null;

            if (typeName == nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == nameof(ForwardWing))
            {
                player = new ForwardWing(name);
            }
            else if (typeName == nameof(CenterBack))
            {
                player = new CenterBack(name);
            }
            else
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            var anotherPlayer = players.GetModel(name);

            if (anotherPlayer != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository), anotherPlayer.GetType().Name);
            }

            players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            ITeam team = new Team(name);

            teams.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
        }

        public string PlayerStatistics(string teamName)
        {
            var team = teams.GetModel(teamName);

            var sortedPlayers = team.Players.OrderByDescending(x => x.Rating).ThenBy(x => x.Name);

            var sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            foreach (var player in sortedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
