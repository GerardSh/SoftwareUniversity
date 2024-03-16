string input = Console.ReadLine();

string encryptedMessage = input;

while ((input = Console.ReadLine()) != "Decode")
{
    string[] commands = input
        .Split("|", StringSplitOptions.RemoveEmptyEntries);

    string command = commands[0];

    if (command == "Move")
    {
        int moves = int.Parse(commands[1]);

        for (int i = 0; i < moves; i++)
        {
            encryptedMessage = encryptedMessage + encryptedMessage[0];
            encryptedMessage = encryptedMessage.Remove(0, 1);
        }
    }
    else if (command == "Insert")
    {
        int index = int.Parse(commands[1]);
        string value = commands[2];

        encryptedMessage = encryptedMessage.Insert(index, value);

    }
    else if (command == "ChangeAll")
    {
        string valueToReplace = commands[1];
        string replacmentValue = commands[2];

        encryptedMessage = encryptedMessage.Replace(valueToReplace, replacmentValue);
    }
}

Console.WriteLine($"The decrypted message is: {encryptedMessage}");