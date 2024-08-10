using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using FootballManager.Utilities.Messages;
using System.Text;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        IRepository<ITeam> championship;

        public Controller()
        {
            championship = new TeamRepository();
        }

        public string ChampionshipRankings()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***Ranking Table***");

            int counter = 1;

            foreach (var team in championship.Models.OrderByDescending(x => x.ChampionshipPoints).ThenByDescending(x => x.PresentCondition))
            {
                sb.AppendLine($"{counter++}. {team.ToString()}/{team.TeamManager.ToString()}");
            }

            return sb.ToString().Trim();
        }

        public string JoinChampionship(string teamName)
        {
            if (championship.Models.Count == 10)
            {
                return string.Format(OutputMessages.ChampionshipFull);
            }

            if (championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);
            }

            championship.Add(new Team(teamName));

            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            ITeam teamOne = championship.Get(teamOneName);
            ITeam teamTwo = championship.Get(teamTwoName);

            if (teamOne == null || teamTwo == null)
            {
                return string.Format(OutputMessages.OneOfTheTeamDoesNotExist);
            }

            if (teamOne.PresentCondition == teamTwo.PresentCondition)
            {
                teamOne.GainPoints(1);
                teamTwo.GainPoints(1);

                return string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
            }

            ITeam teamWon = null;
            ITeam teamLost = null;

            if (teamOne.PresentCondition > teamTwo.PresentCondition)
            {
                teamWon = teamOne;
                teamLost = teamTwo;
            }
            else
            {
                teamWon = teamTwo;
                teamLost = teamOne;
            }

            teamWon.GainPoints(3);

            if (teamWon.TeamManager != null)
            {
                teamWon.TeamManager.RankingUpdate(5);
            }

            if (teamLost.TeamManager != null)
            {
                teamLost.TeamManager.RankingUpdate(-5);
            }

            return string.Format(OutputMessages.TeamWinsMatch, teamWon.Name, teamLost.Name);
        }


        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            ITeam droppingTeam = championship.Get(droppingTeamName);

            if (droppingTeam == null)
            {
                return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);
            }

            if (championship.Exists(promotingTeamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);
            }

            ITeam promotingTeam = new Team(promotingTeamName);

            bool createManager = true;

            if (championship.Models.Any(x => x.TeamManager?.Name == managerName))
            {
                createManager = false;
            }

            IManager manager = null;

            if (managerTypeName == nameof(AmateurManager))
            {
                manager = new AmateurManager(managerName);
            }
            else if (managerTypeName == nameof(SeniorManager))
            {
                manager = new SeniorManager(managerName);
            }
            else if (managerTypeName == nameof(ProfessionalManager))
            {
                manager = new ProfessionalManager(managerName);
            }
            else
            {
                createManager = false;
            }

            if (createManager)
            {
                promotingTeam.SignWith(manager);
            }

            foreach (var team in championship.Models)
            {
                team.ResetPoints();
            }

            championship.Remove(droppingTeamName);
            championship.Add(promotingTeam);

            return string.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!championship.Exists(teamName))
            {
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            }

            IManager manager = null;

            if (managerTypeName == nameof(AmateurManager))
            {
                manager = new AmateurManager(managerName);
            }
            else if (managerTypeName == nameof(SeniorManager))
            {
                manager = new SeniorManager(managerName);
            }
            else if (managerTypeName == nameof(ProfessionalManager))
            {
                manager = new ProfessionalManager(managerName);
            }
            else
            {
                return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            }

            ITeam team = championship.Get(teamName);

            if (team.TeamManager != null)
            {
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
            }

            if (championship.Models.Any(x => x.TeamManager?.Name == managerName))
            {
                return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
            }


            team.SignWith(manager);

            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
        }
    }
}