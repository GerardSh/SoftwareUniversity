namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;
    using System.Linq;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Count > 0)
                .ToArray()
                .Select(c => new ExportCreatorDto
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = c.FirstName + " " + c.LastName,
                    Boardgames = c.Boardgames
                        .OrderBy(b => b.Name)
                        .Select(b => new ExportBoardgameDto
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished,
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.Boardgames.Count)
                .ThenBy(c => c.CreatorName)
                .ToList();

            var result = XmlHelper.Serialize(creators, "Creators");
            return result;
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
               .Where(s => s.BoardgamesSellers.Any(pc => pc.Boardgame.YearPublished >= year && pc.Boardgame.Rating <= rating))
               .ToArray()
               .Select(s => new
               {
                   s.Name,
                   s.Website,
                   Boardgames = s.BoardgamesSellers
                       .Select(bs => bs.Boardgame)
                       .Where(b => b.YearPublished >= year && b.Rating <= rating)
                       .OrderByDescending(b => b.Rating)
                       .ThenBy(b => b.Name)
                       .Select(b => new
                       {
                           b.Name,
                           b.Rating,
                           b.Mechanics,
                           Category = b.CategoryType.ToString()
                       })
                       .ToList()
               })
               .OrderByDescending(p => p.Boardgames.Count())
               .ThenBy(p => p.Name)
               .Take(5)
               .ToList();

            string result = JsonConvert.SerializeObject(sellers, Formatting.Indented);
            return result;
        }
    }
}