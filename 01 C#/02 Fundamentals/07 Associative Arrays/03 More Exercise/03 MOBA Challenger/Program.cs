var skillsByPlayers = new Dictionary<string, Dictionary<string, int>>();

string input;

while ((input = Console.ReadLine()) != "Season end")
{

    if (input.Contains(" -> "))
    {
        string[] playerData = input
    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string player = playerData[0];
        string position = playerData[1];
        int skill = int.Parse(playerData[2]);

        if (!skillsByPlayers.ContainsKey(player))
        {
            skillsByPlayers.Add(player, new Dictionary<string, int>());
        }

        if (!skillsByPlayers[player].ContainsKey(position))
        {
            skillsByPlayers[player].Add(position, 0);
        }

        if (skill > skillsByPlayers[player][position])
        {
            skillsByPlayers[player][position] = skill;
        }

    }
    else
    {
        string[] playerData = input
    .Split(" vs ", StringSplitOptions.RemoveEmptyEntries);

        string playerOne = playerData[0];
        string playerTwo = playerData[1];

        if (!skillsByPlayers.ContainsKey(playerOne) || !skillsByPlayers.ContainsKey(playerTwo))
        {
            continue;
        }

        bool commonPosition = false;

        foreach (var position in skillsByPlayers[playerOne].Keys)
        {
            foreach (var secondPosition in skillsByPlayers[playerTwo].Keys)
            {
                if (position == secondPosition)
                {
                    commonPosition = true;
                }
            }
        }

        if (commonPosition)
        {
            int playerOneSkills = skillsByPlayers[playerOne].Values.Sum();
            int playerTwoSkills = skillsByPlayers[playerTwo].Values.Sum();

            if (playerOneSkills > playerTwoSkills)
            {
                skillsByPlayers.Remove(playerTwo);
            }

            if (playerOneSkills < playerTwoSkills)
            {
                skillsByPlayers.Remove(playerOne);
            }
        }
    }
}

foreach (var player in skillsByPlayers.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value))
{
    Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

    foreach (var positionAndSkill in player.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"- {positionAndSkill.Key} <::> {positionAndSkill.Value}");
    }
}