namespace ConsoleApp1
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                Program.IsNameValid(value);
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                Program.IsMoneyValid(value);
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products { get => products; }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
