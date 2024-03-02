using System.Text;

string number = Console.ReadLine();
int multiplier = int.Parse(Console.ReadLine());
int inMind = 0;

if (multiplier == 0)
{
    Console.WriteLine(0);
    return;
}

StringBuilder multipliedNumbers = new StringBuilder();

for (int i = number.Length - 1; i >= 0; i--)
{
    // int result = int.Parse(number[i].ToString()) * multiplier + inMind;
    int result = (number[i] - '0') * multiplier + inMind;

    multipliedNumbers.Append(result % 10);
    inMind = result / 10;
}

if (inMind > 0)
{
    string inMindReversed = inMind.ToString();
    inMindReversed = string.Concat(inMindReversed.Reverse());
    multipliedNumbers.Append(inMindReversed);
}

string finalResult = string.Concat(multipliedNumbers.ToString().Reverse());
Console.WriteLine(finalResult);