Console.WriteLine(MultiplicationSign());

static string MultiplicationSign()
{
    int num1 = int.Parse(Console.ReadLine());
    int num2 = int.Parse(Console.ReadLine());
    int num3 = int.Parse(Console.ReadLine());

    if ((num1 < 0 && num2 < 0 && num3 > 0)
    || (num1 < 0 && num2 > 0 && num3 < 0)
    || (num1 > 0 && num2 < 0 && num3 < 0)
    || (num1 > 0 && num2 > 0 && num3 > 0))
    {
        return "positive";
    }
    else if (num1 == 0 || num2 == 0 || num3 == 0)
    {
        return "zero";
    }
    else
    {
        return "negative";
    }
}