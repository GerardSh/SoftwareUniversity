string input;

var passwordsByContest = new Dictionary<string, string>();

while ((input = Console.ReadLine()) != "end of contests")
{
    string[] elements = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);

    string contest = elements[0];
    string password = elements[1];

    if (!passwordsByContest.ContainsKey(contest))
    {
        passwordsByContest[contest] = password;
    }
}

var contestResultsByUsername = new Dictionary<string, Dictionary<string, int>>();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] elements = input
        .Split("=>", StringSplitOptions.RemoveEmptyEntries);

    string contest = elements[0];
    string password = elements[1];
    string username = elements[2];
    int points = int.Parse(elements[3]);

    if (!passwordsByContest.ContainsKey(contest) || passwordsByContest[contest] != password)
    {
        continue;
    }

    if (!contestResultsByUsername.ContainsKey(username))
    {
        contestResultsByUsername[username] = new Dictionary<string, int>();
    }

    if (!contestResultsByUsername[username].ContainsKey(contest))
    {
        contestResultsByUsername[username][contest] = 0;
    }

    if (contestResultsByUsername[username][contest] < points)
    {
        contestResultsByUsername[username][contest] = points;
    }
}

var bestUser = contestResultsByUsername.OrderByDescending(x => x.Value.Values.Sum()).First();

Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value.Values.Sum()} points.");
Console.WriteLine("Ranking:");

var sortedUsers = contestResultsByUsername.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

foreach (var user in sortedUsers)
{
    Console.WriteLine(user.Key);

    foreach (var contest in user.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}