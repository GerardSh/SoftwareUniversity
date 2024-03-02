double x = double.Parse(Console.ReadLine());
double y = double.Parse(Console.ReadLine());
double x2 = double.Parse(Console.ReadLine());
double y2 = double.Parse(Console.ReadLine());

double distance1 = CalculateDistance(x, y);
double distance2 = CalculateDistance(x2, y2);

if (distance1 <= distance2)
{
    Console.WriteLine($"({x}, {y})");
}
else
{
    Console.WriteLine($"({x2}, {y2})");
}
static double CalculateDistance(double x, double y)
{
    return Math.Abs(x) + Math.Abs(y);
}