var passwordsByContests = new Dictionary<string, string>();

string input;

while ((input = Console.ReadLine()) != "end of contests")
{
    string[] inputArr = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);
    string contest = inputArr[0];
    string password = inputArr[1];

    passwordsByContests.Add(contest, password);
}

var usersByContests = new SortedDictionary<string, Dictionary<string, int>>();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] inputArr = input
        .Split("=>", StringSplitOptions.RemoveEmptyEntries);
    string contest = inputArr[0];
    string password = inputArr[1];
    string username = inputArr[2];
    int points = int.Parse(inputArr[3]);

    if (passwordsByContests.ContainsKey(contest) && passwordsByContests[contest] == password)
    {
        if (!usersByContests.ContainsKey(username))
        {
            usersByContests.Add(username, new Dictionary<string, int>());
        }

        if (!usersByContests[username].ContainsKey(contest))
        {
            usersByContests[username].Add(contest, 0);
        }

        if (usersByContests[username][contest] < points)
        {
            usersByContests[username][contest] = points;
        }
    }
}

var scoreByUsers = new SortedDictionary<string, int>();

foreach (var user in usersByContests)
{
    int sum = 0;

    foreach (var score in user.Value)
    {
        sum += score.Value;
    }

    scoreByUsers.Add(user.Key, sum);
}

KeyValuePair<string, int> bestUser = scoreByUsers.OrderByDescending(x => x.Value).First();

Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value} points.");

Console.WriteLine("Ranking:");

foreach (var kvp in usersByContests)
{
    Console.WriteLine($"{kvp.Key}");

    var test = kvp.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

    foreach (var kvp2 in test)
    {
        Console.WriteLine($"#  {kvp2.Key} -> {kvp2.Value}");
    }
}




//2
var passwordsByContests = new Dictionary<string, string>();

string input;

while ((input = Console.ReadLine()) != "end of contests")
{
    string[] inputArr = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);
    string contest = inputArr[0];
    string password = inputArr[1];

    passwordsByContests.Add(contest, password);
}

var usersByContests = new SortedDictionary<string, Dictionary<string, int>>();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] inputArr = input
        .Split("=>", StringSplitOptions.RemoveEmptyEntries);
    string contest = inputArr[0];
    string password = inputArr[1];
    string username = inputArr[2];
    int points = int.Parse(inputArr[3]);

    if (passwordsByContests.ContainsKey(contest) && passwordsByContests[contest] == password)
    {
        if (!usersByContests.ContainsKey(username))
        {
            usersByContests.Add(username, new Dictionary<string, int>());
        }

        if (!usersByContests[username].ContainsKey(contest))
        {
            usersByContests[username].Add(contest, 0);
        }

        if (usersByContests[username][contest] < points)
        {
            usersByContests[username][contest] = points;
        }
    }
}

var bestCandidate = usersByContests.OrderByDescending(x => x.Value.Values.Sum()).First();

Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");

Console.WriteLine("Ranking:");

foreach (var kvp in usersByContests)
{
    Console.WriteLine($"{kvp.Key}");

    foreach (var innerDictionary in kvp.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {innerDictionary.Key} -> {innerDictionary.Value}");
    }
}