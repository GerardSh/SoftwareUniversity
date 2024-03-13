using System.Text;
using System.Text.RegularExpressions;

int key = int.Parse(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "end")
{
    StringBuilder decryptedMessage = new StringBuilder();

    foreach (char c in input)
    {
        decryptedMessage.Append((char)(c - key));
    }

    Match match = Regex.Match(decryptedMessage.ToString(), @"@([A-Za-z]+)[^@\-:>!]*!([GN])!");
    string name = match.Groups[1].Value;
    string childBehaviour = match.Groups[2].Value;

    if (name != "" && (childBehaviour == "G"))
    {
        Console.WriteLine(name);
    }
}