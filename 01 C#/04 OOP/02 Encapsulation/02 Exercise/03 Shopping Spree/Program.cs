using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            string[] peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (string person in peopleInput)
                {
                    string[] peopleData = person.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = peopleData[0];
                    decimal money = decimal.Parse(peopleData[1]);

                    Person currentPerson = new Person(name, money);
                    people.Add(name, currentPerson);
                }

                foreach (string product in productInput)
                {
                    string[] productData = product.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = productData[0];
                    decimal money = decimal.Parse(productData[1]);

                    Product currentProduct = new Product(name, money);
                    products.Add(name, currentProduct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = elements[0];
                string productName = elements[1];

                people[personName].BuyProduct(products[productName]);
            }

            foreach (var kvp in people)
            {
                Console.Write($"{kvp.Key} - ");
                if (kvp.Value.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                    continue;
                }

                Console.WriteLine(string.Join(", ", kvp.Value.Products));
            }
        }

        public static void IsNameValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public static void IsMoneyValid(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}