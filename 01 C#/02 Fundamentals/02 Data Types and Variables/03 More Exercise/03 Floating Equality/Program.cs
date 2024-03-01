const double eps = 0.01;

double number1 = double.Parse(Console.ReadLine());
double number2 = double.Parse(Console.ReadLine());
double result = 0;

if (number1 > number2)
{
    result = number1 - number2;
}
else
{
    result = number2 - number1;
}

Console.WriteLine(result < eps);