string textToRemove = Console.ReadLine();
string text = Console.ReadLine();

while (text.Contains(textToRemove))
{
    int index = text.IndexOf(textToRemove);
    int length = textToRemove.Length;

    text = text.Remove(index, length);
}

Console.WriteLine(text);