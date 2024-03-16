string input;

Dictionary<string, int[]> cityData = new Dictionary<string, int[]>();

while ((input = Console.ReadLine()) != "Sail")
{
    string[] data = input
        .Split("||", StringSplitOptions.RemoveEmptyEntries);

    string town = data[0];
    int people = int.Parse(data[1]);
    int gold = int.Parse(data[2]);

    if (!cityData.ContainsKey(town))
    {
        cityData.Add(town, new int[] { people, gold });
    }
    else
    {
        cityData[town][0] += people;
        cityData[town][1] += gold;
    }
}

while ((input = Console.ReadLine()) != "End")
{
    string[] events = input
        .Split("=>", StringSplitOptions.RemoveEmptyEntries);

    string command = events[0];

    if (command == "Plunder")
    {
        string town = events[1];
        int people = int.Parse(events[2]);
        int gold = int.Parse(events[3]);

        cityData[town][0] -= people;
        cityData[town][1] -= gold;

        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

        if (cityData[town][0] == 0 || cityData[town][1] == 0)
        {
            Console.WriteLine($"{town} has been wiped off the map!");
            cityData.Remove(town);
        }
    }
    else if (command == "Prosper")
    {
        string town = events[1];
        int gold = int.Parse(events[2]);

        if (gold < 0)
        {
            Console.WriteLine("Gold added cannot be a negative number!");
            continue;
        }

        cityData[town][1] += gold;
        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cityData[town][1]} gold.");
    }
}

if (cityData.Count > 0)
{
    Console.WriteLine($"Ahoy, Captain! There are {cityData.Count} wealthy settlements to go to:");

    foreach (var city in cityData)
    {
        Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
    }
}
else
{
    Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
}