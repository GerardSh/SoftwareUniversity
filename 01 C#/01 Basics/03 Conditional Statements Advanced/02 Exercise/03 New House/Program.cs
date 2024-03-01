string flowerType = Console.ReadLine();
int flowerCount = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());
double price = 0;

if (flowerType == "Roses")
{
    price = 5 * flowerCount;

    if (flowerCount > 80)
    {
        price *= 0.90;
    }
}
else if (flowerType == "Dahlias")
{
    price = 3.8 * flowerCount;

    if (flowerCount > 90)
    {
        price *= 0.85;
    }
}
else if (flowerType == "Tulips")
{
    price = 2.8 * flowerCount;

    if (flowerCount > 80)
    {
        price *= 0.85;
    }
}
else if (flowerType == "Narcissus")
{
    price = 3 * flowerCount;

    if (flowerCount < 120)
    {
        price *= 1.15;
    }
}
else if (flowerType == "Gladiolus")
{
    price = 2.5 * flowerCount;

    if (flowerCount < 80)
    {
        price *= 1.20;
    }
}

if (budget >= price)
{
    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {budget - price:f2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
}
