var guestListVIP = new HashSet<string>();
var guestList = new HashSet<string>();

string input;

while ((input = Console.ReadLine()) != "PARTY")
{
    if (input.Length != 8)
    {
        continue;
    }

    string guestNumber = input;

    if (char.IsDigit(input[0]))
    {
        guestListVIP.Add(guestNumber);
    }
    else
    {
        guestList.Add(guestNumber);
    }
}

while ((input = Console.ReadLine()) != "END")
{
    string guestNumber = input;

    if (char.IsDigit(input[0]))
    {
        guestListVIP.Remove(guestNumber);
    }
    else
    {
        guestList.Remove(guestNumber);
    }
}

Console.WriteLine($"{guestList.Count + guestListVIP.Count}");

if (guestListVIP.Count > 0)
{
    Console.WriteLine(string.Join("\n", guestListVIP));
}

if (guestList.Count > 0)
{
    Console.WriteLine(string.Join("\n", guestList));
}