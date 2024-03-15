int n = int.Parse(Console.ReadLine());

Dictionary<string, string> composersByPieces = new Dictionary<string, string>();
Dictionary<string, string> keysByPieces = new Dictionary<string, string>();
List<string> orderOfPieces = new List<string>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split("|", StringSplitOptions.RemoveEmptyEntries);

    string piece = input[0];
    string composer = input[1];
    string key = input[2];

    if (!composersByPieces.ContainsKey(piece))
    {
        composersByPieces.Add(piece, "");
        keysByPieces.Add(piece, "");
        orderOfPieces.Add(piece);
    }

    composersByPieces[piece] = composer;
    keysByPieces[piece] = key;
}

string command;

while ((command = Console.ReadLine()) != "Stop")
{
    string[] commands = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

    string operation = commands[0];

    if (operation == "Add")
    {
        string piece = commands[1];
        string composer = commands[2];
        string key = commands[3];

        if (!keysByPieces.ContainsKey(piece))
        {
            keysByPieces.Add(piece, key);
            composersByPieces.Add(piece, composer);
            orderOfPieces.Add((piece));

            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
        }
        else
        {
            Console.WriteLine($"{piece} is already in the collection!");
        }
    }
    else if (operation == "Remove")
    {
        string piece = commands[1];

        if (keysByPieces.ContainsKey(piece))
        {
            keysByPieces.Remove(piece);
            composersByPieces.Remove(piece);
            orderOfPieces.Remove((piece));

            Console.WriteLine($"Successfully removed {piece}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }
    }
    else if (operation == "ChangeKey")
    {
        string piece = commands[1];
        string newKey = commands[2];

        if (keysByPieces.ContainsKey(piece))
        {
            keysByPieces[piece] = newKey;

            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }
    }
}

foreach (var piece in orderOfPieces)
{
    Console.WriteLine($"{piece} -> Composer: {composersByPieces[piece]}, Key: {keysByPieces[piece]}");
}