double number = double.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());

Console.WriteLine(MathPower(number, power));

static double MathPower(double number, int power)
{
    double result = number;

    if (power == 0)
    {
        result = 1;
    }
    else
    {
        for (int i = 1; i < power; i++)
        {
            result *= number;
        }
    }

    return result;
}