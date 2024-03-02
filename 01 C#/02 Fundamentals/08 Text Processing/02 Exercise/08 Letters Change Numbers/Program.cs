using System.Text;

string[] strings = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

double sum = 0;

foreach (string s in strings)
{
    double number = GetNumber(s);
    int firstLetterPosition = GetLetterPostion(s[0]);
    double result = 0;

    if (char.IsUpper(s[0]))
    {
        result = number / firstLetterPosition;
    }
    else
    {
        result = number * firstLetterPosition;
    }

    int secondLetterPosition = GetLetterPostion(s[s.Length - 1]);

    if (char.IsUpper(s[s.Length - 1]))
    {
        result -= secondLetterPosition;
    }
    else
    {
        result += secondLetterPosition;
    }

    sum += result;
}

Console.WriteLine($"{sum:f2}");

int GetLetterPostion(char v)
{
    return char.ToUpper(v) - '@';
}

static double GetNumber(string s)
{
    var number = new StringBuilder();

    foreach (char c in s)
    {
        if (char.IsDigit(c))
        {
            number.Append(c);
        }
    }

    return double.Parse(number.ToString());
}