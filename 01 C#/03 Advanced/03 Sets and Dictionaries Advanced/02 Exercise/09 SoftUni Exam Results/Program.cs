string input;

var languagesByStudent = new Dictionary<string, Dictionary<string, int>>();
var languages = new Dictionary<string, int>();

while ((input = Console.ReadLine()) != "exam finished")
{
    string[] elements = input
        .Split("-", StringSplitOptions.RemoveEmptyEntries);

    string user = elements[0];

    if (elements[1] == "banned")
    {
        if (languagesByStudent.ContainsKey(user))
        {
            languagesByStudent.Remove(user);
        }

        continue;
    }

    string language = elements[1];
    int scores = int.Parse(elements[2]);

    if (!languagesByStudent.ContainsKey(user))
    {
        languagesByStudent[user] = new Dictionary<string, int>();
    }

    if (!languages.ContainsKey(language))
    {
        languages[language] = 0;
    }

    languages[language]++;

    if (!languagesByStudent[user].ContainsKey(language))
    {
        languagesByStudent[user][language] = 0;
    }

    if (languagesByStudent[user][language] < scores)
    {
        languagesByStudent[user][language] = scores;
    }
}

Console.WriteLine("Results:");

foreach (var kvp in languagesByStudent.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
{
    Console.WriteLine($"{kvp.Key} | {kvp.Value.Values.Sum()}");
}

Console.WriteLine("Submissions:");

foreach (var kvp in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}