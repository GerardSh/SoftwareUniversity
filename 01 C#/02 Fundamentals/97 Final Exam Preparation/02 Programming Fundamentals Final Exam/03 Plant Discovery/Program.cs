using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());

Dictionary<string, List<int>> rarityAndRatingsByPlants = new Dictionary<string, List<int>>();

for (int i = 0; i < n; i++)
{
    string[] plants = Regex.Split(Console.ReadLine(), @"<->");

    string plant = plants[0];
    int rarity = int.Parse(plants[1]);

    if (!rarityAndRatingsByPlants.ContainsKey(plant))
    {
        rarityAndRatingsByPlants[plant] = new List<int>() { 0 };
    }

    rarityAndRatingsByPlants[plant][0] = rarity;
}

string input;

while ((input = Console.ReadLine()) != "Exhibition")
{
    string[] commands = Regex.Split(input, @" - | ");
    string command = commands[0];
    string plant = commands[1];

    if (!rarityAndRatingsByPlants.ContainsKey(plant))
    {
        Console.WriteLine("error");
        continue;
    }

    if (command == "Rate:")
    {
        int rating = int.Parse(commands[2]);

        rarityAndRatingsByPlants[plant].Add(rating);
    }
    else if (command == "Update:")
    {
        int rarity = int.Parse(commands[2]);

        rarityAndRatingsByPlants[plant][0] = rarity;
    }
    else if (command == "Reset:")
    {
        int tempRarity = rarityAndRatingsByPlants[plant][0];

        rarityAndRatingsByPlants[plant].Clear();
        rarityAndRatingsByPlants[plant].Add(tempRarity);
    }
}

Console.WriteLine("Plants for the exhibition:");

foreach (var plant in rarityAndRatingsByPlants)
{
    string name = plant.Key;
    int rarity = plant.Value[0];
    plant.Value.RemoveAt(0);

    double averageRating = plant.Value.Count > 0 ? plant.Value.Average() : 0;

    Console.WriteLine($"- {name}; Rarity: {rarity}; Rating: {averageRating:f2}");
}