List<string> guestNames = Console.ReadLine()
    .Split()
    .ToList();

Predicate<string> predicate = name => true;

string input;

while ((input = Console.ReadLine()) != "Party!")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    string partToRemove = elements[2];

    if (elements[1].Contains("Start"))
    {
        predicate = name =>
        {
            string substring = name.Substring(0, partToRemove.Length);

            if (substring != partToRemove)
            {
                return false;
            }

            return true;
        };
    }
    else if (elements[1].Contains("End"))
    {
        predicate = name =>
        {
            string substring = name.Substring(name.Length - partToRemove.Length, partToRemove.Length);

            if (substring != partToRemove)
            {
                return false;
            }

            return true;
        };
    }
    else if (elements[1] == "Length")
    {
        int length = int.Parse(elements[2]);

        predicate = name =>
        {
            if (name.Length != length)
            {
                return false;
            }

            return true;
        };
    }

    if (command == "Remove")
    {
        guestNames = guestNames.Where(name => !predicate(name)).ToList();
    }
    else
    {
        for (int i = 0; i < guestNames.Count; i++)
        {
            if (predicate(guestNames[i]))
            {
                guestNames.Insert(i, guestNames[i++]);
            }
        }
    }
}

if (guestNames.Count > 0)
{
    Console.WriteLine(string.Join(", ", guestNames) + " are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}