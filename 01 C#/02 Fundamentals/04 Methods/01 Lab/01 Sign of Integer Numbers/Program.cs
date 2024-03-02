int number = int.Parse(Console.ReadLine());

Console.WriteLine(CheckSign(number));

static string CheckSign(int n)
{
    string value = "";

    if (n == 0)
    {
        value = $"The number {n} is zero.";
    }
    else
    {
        value = $"The number {n} is {(n > 0 ? "positive" : "negative")}.";
    }

    return value;
}