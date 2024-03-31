using System.Reflection.Metadata.Ecma335;

class User
{
    public int SentMessage { get; set; }

    public int ReceivedMessage { get; set; }

    public int NumberID { get; set; }
}

class Program
{
    static void Main()
    {
        int capacity = int.Parse(Console.ReadLine());

        string input;

        int numberID = 0;

        var users = new Dictionary<string, User>();

        while ((input = Console.ReadLine()) != "Statistics")
        {
            string[] elements = input
                .Split("=", StringSplitOptions.RemoveEmptyEntries);

            string command = elements[0];

            if (command == "Add")
            {
                string username = elements[1];
                int sent = int.Parse(elements[2]);
                int received = int.Parse(elements[3]);

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new User()
                    {
                        SentMessage = sent,
                        ReceivedMessage = received,
                        NumberID = numberID++
                    });
                }
            }
            else if (command == "Message")
            {
                string sender = elements[1];
                string receiver = elements[2];

                if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                {
                    users[sender].SentMessage++;
                    users[receiver].ReceivedMessage++;
                }

                if (users[sender].SentMessage + users[sender].ReceivedMessage >= capacity)
                {
                    Console.WriteLine($"{sender} reached the capacity!");
                    users.Remove(sender);
                }

                if (users.ContainsKey(receiver))
                {
                    if (users[receiver].ReceivedMessage + users[receiver].SentMessage >= capacity)
                    {
                        Console.WriteLine($"{receiver} reached the capacity!");
                        users.Remove(receiver);
                    }
                }
            }
            else if (command == "Empty")
            {
                string username = elements[1];

                if (username == "All")
                {
                    users.Clear();
                }

                if (users.ContainsKey(username))
                {
                    users.Remove(username);
                }
            }
        }

        Console.WriteLine($"Users count: {users.Count}");

        foreach (var user in users.OrderBy(x => x.Value.NumberID))
        {
            Console.WriteLine($"{user.Key} - {user.Value.SentMessage + user.Value.ReceivedMessage}");
        }
    }
}
//10:11:32 31.03.2024