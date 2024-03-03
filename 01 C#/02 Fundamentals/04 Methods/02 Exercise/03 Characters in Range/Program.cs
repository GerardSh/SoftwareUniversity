char a = char.Parse(Console.ReadLine());
char b = char.Parse(Console.ReadLine());

string result = CharsRange(a, b);

Console.WriteLine(result);

static string CharsRange(char a, char b)
{
    string result = "";


    if (a < b)
    {
        for (char c = (char)((int)a + 1); c < b; c++)
        {
            result += c + " ";
        }

    }
    else
    {
        for (char c = (char)((int)b + 1); c < a; c++)
        {
            result += c + " ";
        }
    }

    return result;
}




//2
char a = char.Parse(Console.ReadLine());
char b = char.Parse(Console.ReadLine());

string result = CharsRange(a, b);

Console.WriteLine(result);

static string CharsRange(char a, char b)
{
    string result = "";


    if (a < b)
    {
        for (char c = ++a; c < b; c++)
        {
            result += c + " ";
        }

    }
    else
    {
        for (char c = (char)(b + 1); c < a; c++)
        {
            result += c + " ";
        }
    }

    return result;
}