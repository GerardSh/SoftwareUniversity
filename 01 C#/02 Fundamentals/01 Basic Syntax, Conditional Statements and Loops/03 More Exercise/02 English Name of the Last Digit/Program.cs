int n = int.Parse(Console.ReadLine());

int lastDigit = n % 10;
string inLetters = "";

if (lastDigit == 0)
{
    inLetters = "Zero";
}
else if (lastDigit == 1)
{
    inLetters = "One";
}
else if (lastDigit == 2)
{
    inLetters = "Two";
}
else if (lastDigit == 3)
{
    inLetters = "Three";
}
else if (lastDigit == 4)
{
    inLetters = "Four";
}
else if (lastDigit == 5)
{
    inLetters = "Five";
}
else if (lastDigit == 6)
{
    inLetters = "Six";
}
else if (lastDigit == 7)
{
    inLetters = "Seven";
}
else if (lastDigit == 8)
{
    inLetters = "Eight";
}
else if (lastDigit == 9)
{
    inLetters = "Nine";
}

Console.WriteLine(inLetters.ToLower());