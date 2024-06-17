using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public int ButtonCapacity { get; set; }

        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public List<Drink> Drinks { get; set; }

        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > GetCount)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name) => Drinks.Remove(Drinks.FirstOrDefault(x => x.Name == name));

        public Drink GetLongest()
        {
            double longest = Drinks.Max(x => x.Volume);

            return Drinks.FirstOrDefault((x) => x.Volume == longest);
        }

        public Drink GetCheapest()
        {
            decimal cheapestPrice = Drinks.Min(x => x.Price);

            return Drinks.FirstOrDefault((x) => x.Price == cheapestPrice);
        }

        public string BuyDrink(string name) => Drinks.FirstOrDefault(x => x.Name == name).ToString();

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Drinks available:");

            foreach (var drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
