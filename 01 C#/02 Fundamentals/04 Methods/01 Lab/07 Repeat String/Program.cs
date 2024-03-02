string input = Console.ReadLine();
int n = int.Parse(Console.ReadLine());

string result = StringRepeat(input, n);

Console.WriteLine(result);

static string StringRepeat(string originalString, int iterations)
{
    string repeatedString = "";

    for (int i = 0; i < iterations; i++)
    {
        repeatedString += originalString;
    }

    return repeatedString;
}