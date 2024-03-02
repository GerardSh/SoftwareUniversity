double x = double.Parse(Console.ReadLine());
double y = double.Parse(Console.ReadLine());
double x2 = double.Parse(Console.ReadLine());
double y2 = double.Parse(Console.ReadLine());
double x3 = double.Parse(Console.ReadLine());
double y3 = double.Parse(Console.ReadLine());
double x4 = double.Parse(Console.ReadLine());
double y4 = double.Parse(Console.ReadLine());

double distanceStraightLine1 = CalculateDistanceStraightLine(x, y, x2, y2);
double distanceStraightLine2 = CalculateDistanceStraightLine(x3, y3, x4, y4);

if (distanceStraightLine1 >= distanceStraightLine2)
{
    Console.WriteLine(PrintOrderOfPoints(x, y, x2, y2));
}
else
{
    Console.WriteLine(PrintOrderOfPoints(x3, y3, x4, y4));
}

static string PrintOrderOfPoints(double x, double y, double x2, double y2)
{
    double distance = CalculateDistance(x, y);
    double distance2 = CalculateDistance(x2, y2);

    if (distance <= distance2)
    {
        return $"({x}, {y})({x2}, {y2})";
    }
    else
    {
        return $"({x2}, {y2})({x}, {y})";
    }
}

static double CalculateDistanceStraightLine(double x, double y, double x2, double y2)
{
    return Math.Sqrt(Math.Pow(x2 - x, 2) + Math.Pow(y2 - y, 2));
}

static double CalculateDistance(double x, double y)
{
    return Math.Sqrt(x * x + y * y);
}