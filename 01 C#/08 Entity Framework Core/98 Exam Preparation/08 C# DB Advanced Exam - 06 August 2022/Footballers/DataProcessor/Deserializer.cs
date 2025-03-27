namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var output = new StringBuilder();

            var coachDtos = XmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

            if (coachDtos == null || coachDtos.Length == 0) return string.Empty;

            var validCoaches = new List<Coach>();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                foreach (var fbDto in coachDto.Footballers)
                {
                    bool isStartDateValid = DateTime
                        .TryParseExact(fbDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate);
                    bool isEndDateValid = DateTime
                        .TryParseExact(fbDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate);

                    if (!IsValid(fbDto) || !isStartDateValid || !isEndDateValid || startDate > endDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new Footballer()
                    {
                        Name= fbDto.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)fbDto.BestSkillType,
                        PositionType = (PositionType)fbDto.PositionType
                    };

                    coach.Footballers.Add(footballer);
                }

                output.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
                validCoaches.Add(coach);
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var output = new StringBuilder();

            var teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            if (teamDtos == null || teamDtos.Count() == 0) return string.Empty;

            var validTeams = new List<Team>();

            var footballersInDb = context.Footballers
                .Select(f => f.Id)
                .ToHashSet();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) || teamDto.Trophies == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies,
                };

                foreach (var footballerId in teamDto.Footballers)
                {
                    if (!footballersInDb.Contains(footballerId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var TeamFootballer = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerId,
                    };

                    team.TeamsFootballers.Add(TeamFootballer);
                }

                validTeams.Add(team);
                output.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
