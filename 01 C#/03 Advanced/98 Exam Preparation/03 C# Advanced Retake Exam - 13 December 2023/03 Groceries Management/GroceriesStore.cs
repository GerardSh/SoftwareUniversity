using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>(capacity);
        }

        public int Capacity { get; set; }

        public double Turnover { get; set; }

        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity && !Stall.Contains(product))
            {
                Stall.Add(product);
            }
        }

        public bool RemoveProduct(string name) => Stall.Remove(Stall.FirstOrDefault(x => x.Name == name));

        public string SellProduct(string name, double quantity)
        {
            Product product = Stall.FirstOrDefault(x => x.Name == name);

            if (product == null)
            {
                return "Product not found";
            }

            double price = Math.Round(product.Price * quantity, 2);
            Turnover += price;

            return $"{name} - {price:F2}$";
        }

        public string GetMostExpensive()
        {
            return Stall.OrderByDescending(x => x.Price).FirstOrDefault().ToString();
        }

        public string CashReport()
        {   
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Groceries Price List:");

            foreach (var item in Stall)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}