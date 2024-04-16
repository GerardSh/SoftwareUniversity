string input;

var followingByVlogger = new Dictionary<string, HashSet<string>>();
var followersByVlogger = new Dictionary<string, SortedSet<string>>();

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (elements.Contains("joined"))
    {
        string vlogger = elements[0];

        if (!followingByVlogger.ContainsKey(vlogger))
        {
            followingByVlogger[vlogger] = new HashSet<string>();
            followersByVlogger[vlogger] = new SortedSet<string>();
        }
    }
    else
    {
        string vloggerOne = elements[0];
        string vloggerTwo = elements[2];

        if (vloggerOne == vloggerTwo
            || !followingByVlogger.ContainsKey(vloggerOne)
            || !followingByVlogger.ContainsKey(vloggerTwo))
        {
            continue;
        }

        followingByVlogger[vloggerOne].Add(vloggerTwo);
        followersByVlogger[vloggerTwo].Add(vloggerOne);
    }
}

var sortedFollowersList = followersByVlogger
    .OrderByDescending(x => x.Value.Count)
    .ThenBy(x => followingByVlogger[x.Key].Count)
    .ToDictionary(x => x.Key, x => x.Value);

Console.WriteLine($"The V-Logger has a total of {followersByVlogger.Count} vloggers in its logs.");

int count = 1;

foreach (var kvp in sortedFollowersList)
{
    Console.WriteLine($"{count}. {kvp.Key} : {followersByVlogger[kvp.Key].Count} followers, {followingByVlogger[kvp.Key].Count} following");

    if (count++ == 1 && followersByVlogger[kvp.Key].Count > 0)
    {
        foreach (var follower in followersByVlogger[kvp.Key])
        {
            Console.WriteLine($"*  {follower}");
        }
    }
}