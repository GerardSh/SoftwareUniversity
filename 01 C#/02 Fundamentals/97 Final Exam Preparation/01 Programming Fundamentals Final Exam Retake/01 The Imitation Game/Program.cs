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




//2
using System.Text;

StringBuilder message = new StringBuilder(Console.ReadLine());

string input;

while ((input = Console.ReadLine()) != "Decode")
{
    string[] elements = input
        .Split("|", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "Move")
    {
        int lettersToMove = int.Parse(elements[1]);

        message.Append(message.ToString().Substring(0, lettersToMove));
        message.Remove(0, lettersToMove);
    }
    else if (command == "Insert")
    {
        int index = int.Parse(elements[1]);
        string value = elements[2];

        message.Insert(index, value);
    }
    else
    {
        string substring = elements[1];
        string replacment = elements[2];

        while (message.ToString().Contains(substring))
        {
            message.Replace(substring, replacment);
        }
    }
}

Console.WriteLine($"The decrypted message is: {message}");