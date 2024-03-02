int n = int.Parse(Console.ReadLine());

Dictionary<string, string> plateNumberByUserName = new Dictionary<string, string>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = input[0];
    string username = input[1];

    switch (command)
    {
        case "register":
            {

                string licensePlate = input[2];

                if (plateNumberByUserName.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {plateNumberByUserName[username]}");
                }
                else
                {
                    plateNumberByUserName.Add(username, licensePlate);
                    Console.WriteLine($"{username} registered {licensePlate} successfully");
                }
            }
            break;
        default:
            {
                if (plateNumberByUserName.ContainsKey(username))
                {
                    plateNumberByUserName.Remove(username);
                    Console.WriteLine($"{username} unregistered successfully");
                }
                else
                {
                    Console.WriteLine($"ERROR: user {username} not found");
                }
            }
            break;
    }
}

foreach (var kvp in plateNumberByUserName)
{
    Console.WriteLine($"{kvp.Key} => {kvp.Value}");
}