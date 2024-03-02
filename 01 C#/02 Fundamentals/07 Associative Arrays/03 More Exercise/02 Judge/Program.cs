string input;

var scoresByContest = new Dictionary<string, Dictionary<string, int>>();
var individualStandings = new Dictionary<string, Dictionary<string, int>>();


while ((input = Console.ReadLine()) != "no more time")
{
    string[] inputArr = input
        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string username = inputArr[0];
    string contest = inputArr[1];
    int points = int.Parse(inputArr[2]);

    if (!scoresByContest.ContainsKey(contest))
    {
        scoresByContest.Add(contest, new Dictionary<string, int>());
    }

    if (!scoresByContest[contest].ContainsKey(username))
    {
        scoresByContest[contest].Add(username, 0);
    }

    if (scoresByContest[contest][username] < points)
    {
        scoresByContest[contest][username] = points;
    }

    if (!individualStandings.ContainsKey(username))
    {
        individualStandings.Add(username, new Dictionary<string, int>());
    }

    if (!individualStandings[username].ContainsKey(contest))
    {
        individualStandings[username].Add(contest, 0);
    }

    if (points > individualStandings[username][contest])
    {
        individualStandings[username][contest] = points;
    }
}

foreach (var kvp in scoresByContest)
{
    int count = 1;

    Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");

    foreach (var score in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        Console.WriteLine($"{count++}. {score.Key} <::> {score.Value}");
    }
}

Console.WriteLine("Individual standings:");

int count2 = 1;

foreach (var kvp in individualStandings.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
{
    Console.WriteLine($"{count2++}. {kvp.Key} -> {kvp.Value.Values.Sum()}");
}