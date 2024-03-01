string figure = Console.ReadLine();

if (figure == "square")
{
    double sideLenght = double.Parse(Console.ReadLine());
    sideLenght = sideLenght * sideLenght;
    Console.WriteLine($"{sideLenght:F3}");
}
else if (figure == "rectangle")
{
    double sideA = double.Parse(Console.ReadLine());
    double sideB = double.Parse(Console.ReadLine());
    double multiply = sideA * sideB;
    Console.WriteLine($"{multiply:f3}");
}
else if (figure == "circle")
{
    double radius = double.Parse(Console.ReadLine());
    radius = radius * radius * Math.PI;
    Console.WriteLine($"{radius:f3}");
}
else if (figure == "triangle")
{
    double sideLenght = double.Parse(Console.ReadLine());
    double sideHeight = double.Parse(Console.ReadLine());
    double s = sideLenght * sideHeight / 2;
    Console.WriteLine($"{s:f3}");
}