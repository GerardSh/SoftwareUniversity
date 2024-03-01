int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int fishers = int.Parse(Console.ReadLine());
double price = 0;

if (season == "Spring")
{
    price = 3000;
}
else if (season == "Summer" || season == "Autumn")
{
    price = 4200;
}
else if (season == "Winter")
{
    price = 2600;
}
if (fishers <= 6)
{
    price *= 0.9;
}
else if (fishers <= 11)
{
    price *= 0.85;
}
else if (fishers > 11)
{
    price *= 0.75;
}

if (fishers % 2 == 0 && season != "Autumn")
{
    price *= 0.95;
}
if (budget - price >= 0)
{
    Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
}