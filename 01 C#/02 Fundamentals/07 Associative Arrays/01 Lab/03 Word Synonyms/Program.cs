Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string word = Console.ReadLine();
    string synonim = Console.ReadLine();

    if (dictionary.ContainsKey(word))
    {
        dictionary[word].Add(synonim);
    }
    else
    {
        dictionary.Add(word, new List<string>()
        {
            synonim
        });
    }
}

foreach (var word in dictionary)
{
    Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
}