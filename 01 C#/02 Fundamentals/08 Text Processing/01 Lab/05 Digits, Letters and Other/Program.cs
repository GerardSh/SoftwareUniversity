using System.Text;

string input = Console.ReadLine();

var numbers = new StringBuilder();
var letters = new StringBuilder();
var symbols = new StringBuilder();

foreach (char c in input)
{
    if (c >= '0' && c <= '9')
    {
        numbers.Append(c);
    }
    else if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
    {
        letters.Append(c);
    }
    else
    {
        symbols.Append(c);
    }
}

Console.WriteLine(numbers);
Console.WriteLine(letters);
Console.WriteLine(symbols);