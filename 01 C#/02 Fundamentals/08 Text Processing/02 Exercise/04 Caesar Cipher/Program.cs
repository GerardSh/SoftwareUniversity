using System.Text;

string input = Console.ReadLine();
StringBuilder encryptedText = new StringBuilder();

foreach (char c in input)
{
    encryptedText.Append((char)(c + 3));
}

Console.WriteLine(encryptedText);