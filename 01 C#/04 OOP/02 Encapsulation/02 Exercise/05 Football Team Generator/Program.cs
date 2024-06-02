
namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main()
        {
            var teams = new Dictionary<string, Team>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = elements[0];
                string teamName = elements[1];

                if (command == "Team")
                {
                    teams.Add(teamName, new Team(teamName));
                }
                else if (command == "Add")
                {
                    try
                    {
                        ExistingTeam(teams, teamName);

                        string playerName = elements[2];
                        int endurance = int.Parse(elements[3]);
                        int sprint = int.Parse(elements[4]);
                        int dribble = int.Parse(elements[5]);
                        int passing = int.Parse(elements[6]);
                        int shooting = int.Parse(elements[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[teamName].AddPlayer(player);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "Remove")
                {
                    string playerName = elements[2];

                    try
                    {
                        ExistingTeam(teams, teamName);

                        teams[teamName].RemovePlayer(playerName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (command == "Rating")
                {
                    try
                    {
                        ExistingTeam(teams, teamName);

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private static void ExistingTeam(Dictionary<string, Team> teams, string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}