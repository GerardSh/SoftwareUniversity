string[] bannedWords = Console.ReadLine().Split(", ");
string text = Console.ReadLine();

foreach (string word in bannedWords)
{
    //string asterisks = string.Empty;

    //foreach (char c in word)
    //{
    //    asterisks += "*";
    //}

    //text = text.Replace(word, asterisks);

    text = text.Replace(word, new string('*', word.Length));
}

Console.WriteLine(text);