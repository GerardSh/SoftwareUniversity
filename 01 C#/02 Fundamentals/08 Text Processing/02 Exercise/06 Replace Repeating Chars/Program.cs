using System.Text;

string input = Console.ReadLine();
StringBuilder textReplaced = new StringBuilder(input[0].ToString());

for (int i = 1; i < input.Length; i++)
{
    if (input[i] != input[i - 1])
    {
        textReplaced.Append(input[i]);
    }
}

Console.WriteLine(textReplaced);