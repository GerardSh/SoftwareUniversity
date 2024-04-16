int n = int.Parse(Console.ReadLine());

var usernames = new HashSet<string>();

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    usernames.Add(name);
}

Console.WriteLine(string.Join("\n", usernames));