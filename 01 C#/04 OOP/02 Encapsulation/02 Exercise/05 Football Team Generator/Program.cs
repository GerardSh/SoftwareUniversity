using System.Reflection;

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
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    string playerName = elements[2];
                    int endurance = int.Parse(elements[3]);
                    int sprint = int.Parse(elements[4]);
                    int dribble = int.Parse(elements[5]);
                    int passing = int.Parse(elements[6]);
                    int shooting = int.Parse(elements[7]);

                    if (!IsPlayerDataValid(playerName, endurance, sprint, dribble, passing, shooting))
                    {
                        continue;
                    }

                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                    teams[teamName].AddPlayer(player);
                }
                else if (command == "Remove")
                {
                    string playerName = elements[2];

                    try
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    teams[teamName].RemovePlayer(playerName);
                }
                else if (command == "Rating")
                {
                    try
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                }
            }
        }

        private static bool IsPlayerDataValid(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                if (endurance < 0 || endurance > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                if (endurance < 0 || endurance > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                if (endurance < 0 || endurance > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                if (endurance < 0 || endurance > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}