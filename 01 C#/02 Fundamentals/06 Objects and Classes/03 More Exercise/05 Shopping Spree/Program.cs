namespace ConsoleApp
{
    class Person
    {
        public string Name { get; set; }

        public double Money { get; set; }

        public List<string> Bag { get; set; } = new List<string> { };

        public void BuyProduct(double productPrice, string product)
        {
            if (productPrice > Money)
            {
                Console.WriteLine($"{Name} can't afford {product}");
            }
            else
            {
                Money -= productPrice;
                Bag.Add(product);
                Console.WriteLine($"{Name} bought {product}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }

        public double Cost { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> peopleListed = new List<Person>();

            for (int i = 0; i < people.Length; i++)
            {
                string[] peopleData = people[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                peopleListed.Add(new Person { Name = peopleData[0], Money = double.Parse(peopleData[1]) });
            }

            List<Product> productsListed = new List<Product>();

            for (int i = 0; i < products.Length; i++)
            {
                string[] productData = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                productsListed.Add(new Product { Name = productData[0], Cost = double.Parse(productData[1]) });
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = commands[0];
                string product = commands[1];

                double productPrice = productsListed.FirstOrDefault(x => x.Name == product).Cost;
                ;
                peopleListed.FirstOrDefault(x => x.Name == name).BuyProduct(productPrice, product);
            }

            foreach (Person person in peopleListed)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
