double budget = double.Parse(Console.ReadLine());
int stuff = int.Parse(Console.ReadLine());
double uniformStuffPrice = double.Parse(Console.ReadLine()) * stuff;

double decor = budget * 0.10;

if (stuff > 150)
{
    uniformStuffPrice *= 0.9;
}
if (uniformStuffPrice + decor > budget)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {uniformStuffPrice + decor - budget:f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {budget - (uniformStuffPrice + decor):f2} leva left.");
}