int n = int.Parse(Console.ReadLine());

List<string> products = new List<string>(n);

for (int i = 0; i < n; i++)
{
    products.Add(Console.ReadLine());
}

products.Sort();

for (int i = 1; i <= products.Count; i++)
{
    Console.WriteLine($"{i}.{products[i - 1]}");
}