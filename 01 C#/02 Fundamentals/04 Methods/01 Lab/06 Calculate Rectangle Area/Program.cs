double p1 = int.Parse(Console.ReadLine());
double p2 = int.Parse(Console.ReadLine());

double area = RectangleArea(p1, p2);

Console.WriteLine(area);

static double RectangleArea(double p1, double p2)
{
    double area = p1 * p2;
    return area;
}