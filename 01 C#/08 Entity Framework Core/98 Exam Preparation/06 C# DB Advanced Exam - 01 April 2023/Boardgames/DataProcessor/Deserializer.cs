namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var output = new StringBuilder();

            var creatorDtos = XmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            if (creatorDtos == null || creatorDtos.Count() == 0) return string.Empty;

            var creatorsToBeAdded = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var bgDto in creatorDto.Boardgames)
                {
                    if (!IsValid(bgDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame()
                    {
                        Name = bgDto.Name,
                        Rating = bgDto.Rating,
                        YearPublished = bgDto.YearPublished,
                        CategoryType = (CategoryType)bgDto.CategoryType,
                        Mechanics = bgDto.Mechanics,
                    };

                    creator.Boardgames.Add(boardgame);
                }

                creatorsToBeAdded.Add(creator);
                output.AppendLine(string.Format(SuccessfullyImportedCreator,
                    creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creatorsToBeAdded);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var output = new StringBuilder();

            var sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            if (sellerDtos == null || sellerDtos.Count() == 0) return string.Empty;

            var validSellers = new List<Seller>();

            var existingBgIds = context.Boardgames
                .Select(b => b.Id)
                .ToHashSet();

            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (var bgDto in sellerDto.Boardgames)
                {
                    if (!existingBgIds.Contains(bgDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var BoardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = bgDto
                    };

                    seller.BoardgamesSellers.Add(BoardgameSeller);
                }

                output.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
                validSellers.Add(seller);
            }

            context.AddRange(validSellers);
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
