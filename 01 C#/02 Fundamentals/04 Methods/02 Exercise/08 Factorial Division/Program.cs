double number1 = double.Parse(Console.ReadLine());
double number2 = double.Parse(Console.ReadLine());

double result = GetFactorial(number1) / GetFactorial(number2);

Console.WriteLine($"{result:f2}");

static double GetFactorial(double number)
{
    for (double i = number - 1; i > 0; i--)
    {
        number *= i;
    }

    return number;
}