Console.Write("Length: ");
double lenght = double.Parse(Console.ReadLine());
Console.Write("Width: ");
double width = double.Parse(Console.ReadLine());
Console.Write("Height: ");
double height = double.Parse(Console.ReadLine());

double area = lenght * width;
double volume = 1.0 / 3 * area * height;

Console.Write($"Pyramid Volume: {volume:f2}");