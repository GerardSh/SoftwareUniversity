Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

while (songs.Count > 0)
{
    string command = Console.ReadLine();

    if (command == "Play")
    {
        songs.Dequeue();
    }
    else if (command.Contains("Add"))
    {
        string song = command.Substring(4);

        if (!songs.Contains(song))
        {
            songs.Enqueue(song);
        }
        else
        {
            Console.WriteLine($"{song} is already contained!");
        }
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}

Console.WriteLine("No more songs!");