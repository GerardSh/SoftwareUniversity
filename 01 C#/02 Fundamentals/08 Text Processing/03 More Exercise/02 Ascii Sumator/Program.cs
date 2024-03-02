char firstChar = char.Parse(Console.ReadLine());
char secondChar = char.Parse(Console.ReadLine());
string text = Console.ReadLine();

int maxChar = Math.Max(firstChar, secondChar);
int minChar = Math.Min(firstChar, secondChar);

int charSum = 0;

foreach (var c in text)
{
    if (c > minChar && c < maxChar)
    {
        charSum += c;
    }
}

Console.WriteLine(charSum);