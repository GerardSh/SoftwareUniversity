namespace ConsoleApp
{
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        //public override string ToString()
        //{
        //    return $"{FirstName} {LastName}: {Grade:f2}";
        //}
    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>(n);

            for (int i = 0; i < n; i++)
            {
                string[] newTeamData = Console.ReadLine()
                    .Split("-");

                bool existingTeamOrCreator = false;

                foreach (Team t in teams)
                {
                    if (t.TeamName == newTeamData[1])
                    {
                        Console.WriteLine($"Team {newTeamData[1]} was already created!");
                        existingTeamOrCreator = true;
                        break;
                    }

                    if (t.Creator == newTeamData[0])
                    {
                        Console.WriteLine($"{newTeamData[0]} cannot create another team!");
                        existingTeamOrCreator = true;
                        break;
                    }
                }

                if (existingTeamOrCreator)
                {
                    continue;
                }

                Team team = new Team()
                {
                    Creator = newTeamData[0],
                    TeamName = newTeamData[1],
                    Members = new List<string>()
                };

                Console.WriteLine($"Team {team.TeamName} has been created by {team.Creator}!");
                teams.Add(team);
            }

            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] newTeamMembers = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string name = newTeamMembers[0];
                string teamToJoin = newTeamMembers[1];

                bool existingTeam = false;
                Team team = new Team();


                foreach (Team t in teams)
                {
                    if (t.TeamName == teamToJoin)
                    {
                        existingTeam = true;
                        team = t;
                        break;
                    }
                }

                if (!existingTeam)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }

                bool memberOfAnotherTeam = false;

                foreach (Team t in teams)
                {
                    if (t.Members.Contains(name) || t.Creator == name)
                    {
                        Console.WriteLine($"Member {name} cannot join team {teamToJoin}!");
                        memberOfAnotherTeam = true;
                        break;
                    }
                }

                if (memberOfAnotherTeam)
                {
                    continue;
                }

                if (existingTeam)
                {
                    team.Members.Add(name);
                }
            }

            teams = teams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.TeamName).ToList();

            foreach (Team t in teams)
            {
                if (t.Members.Count > 0)
                {
                    Console.WriteLine($"{t.TeamName}");
                    Console.WriteLine($"- {t.Creator}");

                    t.Members.Sort();

                    foreach (string member in t.Members)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team t in teams)
            {
                if (t.Members.Count == 0)
                {

                    Console.WriteLine(t.TeamName);
                }
            }
        }
    }
}