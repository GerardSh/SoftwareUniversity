string input;

var shops = new SortedDictionary<string, Dictionary<string, double>>();

while ((input = Console.ReadLine()) != "Revision")
{
    string[] elements = input
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string shop = elements[0];
    string product = elements[1];
    double price = double.Parse(elements[2]);

    if (!shops.ContainsKey(shop))
    {
        shops.Add(shop, new Dictionary<string, double>());
    }

    if (!shops[shop].ContainsKey(product))
    {
        shops[shop][product] = 0;
    }

    shops[shop][product] = price;
}

foreach (var shop in shops)
{
    Console.WriteLine($"{shop.Key}->");

    foreach (var product in shop.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value} ");
    }
}