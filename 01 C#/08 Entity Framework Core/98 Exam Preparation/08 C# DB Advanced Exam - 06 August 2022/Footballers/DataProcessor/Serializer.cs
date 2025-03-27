namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .Where(c => c.Footballers.Count > 0)
                .ToArray()
                .Select(c => new ExportCoachDto()
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers.Select(f => new ExportFootballerDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .OrderBy(f => f.Name)
                    .ToList()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToList();

            var result = XmlHelper.Serialize(coaches, "Coaches");
            return result;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                        .Select(tf => tf.Footballer)
                        .Where(f => f.ContractStartDate >= date)
                        .OrderByDescending(f => f.ContractEndDate)
                        .ThenBy(f => f.Name)
                        .Select(t => new
                        {
                            FootballerName = t.Name,
                            ContractStartDate = t.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = t.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = t.BestSkillType.ToString(),
                            PositionType = t.PositionType.ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(t => t.Footballers.Count)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToList();

            var result = JsonConvert.SerializeObject(teams, Formatting.Indented);
            return result;
        }
    }
}
