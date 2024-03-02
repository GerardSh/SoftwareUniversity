using System.Text;

string input = Console.ReadLine();
int power = 0;
var sb = new StringBuilder();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '>')
    {
        sb.Append(input[i]);
        power += input[i + 1] - '0';
    }
    else if (power > 0)
    {
        power--;
    }
    else
    {
        sb.Append(input[i]);
    }
}

Console.WriteLine(sb);