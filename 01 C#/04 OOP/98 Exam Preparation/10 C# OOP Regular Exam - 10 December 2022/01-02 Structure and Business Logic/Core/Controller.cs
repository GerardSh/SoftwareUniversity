using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booths.Models.Count, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size) != null)
            {
                return string.Format(string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName));
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            booth.Charge();
            booth.ChangeStatus();

            var sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.Append($"Booth {boothId} is now available!");

            return sb.ToString();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(x => !x.IsReserved && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInfo = order.Split("/");

            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int countOfOrderedPieces = int.Parse(orderInfo[2]);
            string size = null;

            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);



            if (itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Hibernation) && itemTypeName != nameof(Stolen) && itemTypeName != nameof(Gingerbread))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                size = orderInfo[3];
            }

            double price = 0;

            if (size != null)
            {
                if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }

                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                price = cocktail.Price;
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                price = delicacy.Price;
            }

            booth.UpdateCurrentBill(price * countOfOrderedPieces);

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
        }
    }
}