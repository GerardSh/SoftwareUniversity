string product = Console.ReadLine();
string city = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());

if (city == "Sofia")
{
    if (product == "coffee")
    {
        Console.WriteLine(quantity * 0.5);
    }
    else if (product == "water")
    {
        Console.WriteLine(quantity * 0.8);
    }
    else if (product == "beer")
    {
        Console.WriteLine($"{quantity * 1.2}");
    }
    else if (product == "sweets")
    {
        Console.WriteLine(quantity * 1.45);
    }
    else
    {
        Console.WriteLine(quantity * 1.6);
    }
}
else if (city == "Plovdiv")
{
    if (product == "coffee")
    {
        Console.WriteLine(quantity * 0.4);
    }
    else if (product == "water")
    {
        Console.WriteLine(quantity * 0.7);
    }
    else if (product == "beer")
    {
        Console.WriteLine(quantity * 1.15);
    }
    else if (product == "sweets")
    {
        Console.WriteLine(quantity * 1.3);
    }
    else
    {
        Console.WriteLine(quantity * 1.5);
    }
}
else
{
    if (product == "coffee")
    {
        Console.WriteLine(quantity * 0.45);
    }
    else if (product == "water")
    {
        Console.WriteLine(quantity * 0.7);
    }
    else if (product == "beer")
    {
        Console.WriteLine(quantity * 1.1);
    }
    else if (product == "sweets")
    {
        Console.WriteLine(quantity * 1.35);
    }
    else
    {
        Console.WriteLine(quantity * 1.55);
    }
}