class Product
{
    public double price { get; set; }
    public int quantity { get; set; }
}

class MyClass
{

    static void Main()
    {

        var products = new Dictionary<string, Product>();


        string input;

        while ((input = Console.ReadLine()) != "buy")
        {
            string[] productData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = productData[0];
            double price = double.Parse(productData[1]);
            int quantity = int.Parse(productData[2]);

            if (!products.ContainsKey(name))
            {
                products.Add(name, new Product());
            }

            products[name].price = price;
            products[name].quantity += quantity;
        }

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Key} -> {product.Value.quantity * product.Value.price:f2}");
        }
    }
}




//2
var priceAndQuantityByProducts = new Dictionary<string, Dictionary<decimal, int>>();

string input;

while ((input = Console.ReadLine()) != "buy")
{
    string[] productData = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = productData[0];
    decimal price = decimal.Parse(productData[1]);
    int quantity = int.Parse(productData[2]);

    if (!priceAndQuantityByProducts.ContainsKey(name))
    {
        priceAndQuantityByProducts.Add(name, new Dictionary<decimal, int>());
    }

    if (priceAndQuantityByProducts[name].Count == 0)
    {
        priceAndQuantityByProducts[name].Add(price, quantity);
        continue;
    }

    var currentKvp = priceAndQuantityByProducts[name].First();
    int currentQuantity = priceAndQuantityByProducts[name].Values.Sum() + quantity;

    priceAndQuantityByProducts[name].Remove(currentKvp.Key);
    priceAndQuantityByProducts[name].Add(price, currentQuantity);
}

foreach (var kvp in priceAndQuantityByProducts)
{
    foreach (var kvp2 in kvp.Value)
    {
        Console.WriteLine($"{kvp.Key} -> {kvp2.Key * kvp2.Value}");
    }
}