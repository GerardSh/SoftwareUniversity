string projectionType = Console.ReadLine();
int r = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());
int totalPlaces = c * r;
double price = 0;
switch (projectionType)
{
    case "Premiere": price = 12; break;
    case "Normal": price = 7.5; break;
    case "Discount": price = 5; break;
}

double profit = price * totalPlaces;
Console.WriteLine($"{profit:f2}");
Console.WriteLine("leva");