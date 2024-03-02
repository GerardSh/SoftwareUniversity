double number1 = int.Parse(Console.ReadLine());
string operation = Console.ReadLine();
double number2 = int.Parse(Console.ReadLine());

double result = MathOperations(number1, number2, operation);

Console.WriteLine(Math.Round(result, 2));

static double MathOperations(double n1, double n2, string operation)
{
    double result = 0;

    if (operation == "*")
    {
        result = n1 * n2;
    }
    else if (operation == "+")
    {
        result = n1 + n2;
    }
    else if (operation == "-")
    {
        result = n1 - n2;
    }
    else
    {
        result = n1 / n2;
    }

    return result;
}