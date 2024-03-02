int numberOfDragons = int.Parse(Console.ReadLine());

var dragonsByType = new Dictionary<string, Dictionary<string, List<int>>>();

AddDragons(dragonsByType);
PrintDragons(dragonsByType);

void PrintDragons(Dictionary<string, Dictionary<string, List<int>>> dragonsByType)
{
    foreach (var kvp in dragonsByType)
    {
        double damage = 0;
        double health = 0;
        double armor = 0;
        double count = kvp.Value.Count;

        foreach (var dragon in kvp.Value)
        {
            damage += dragon.Value[0];
            health += dragon.Value[1];
            armor += dragon.Value[2];
        }

        Console.WriteLine($"{kvp.Key}::({damage / count:f2}/{health / count:f2}/{armor / count:f2})");

        foreach (var dragon in kvp.Value.OrderBy(x => x.Key))
        {
            Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
        }
    }
}

void AddDragons(Dictionary<string, Dictionary<string, List<int>>> dragonsByType)
{
    for (int i = 0; i < numberOfDragons; i++)
    {
        string[] dragonData = Console.ReadLine()
         .Split();

        string type = dragonData[0];
        string name = dragonData[1];

        int damage;

        if (dragonData[2] == "null")
        {
            damage = 45;
        }
        else
        {
            damage = int.Parse(dragonData[2]);
        }

        int health;

        if (dragonData[3] == "null")
        {
            health = 250;
        }
        else
        {
            health = int.Parse(dragonData[3]);
        }

        int armor;

        if (dragonData[4] == "null")
        {
            armor = 10;
        }
        else
        {
            armor = int.Parse(dragonData[4]);
        }

        if (!dragonsByType.ContainsKey(type))
        {
            dragonsByType.Add(type, new Dictionary<string, List<int>>());
        }

        dragonsByType[type].Remove(name);
        dragonsByType[type].Add(name, new List<int> { damage, health, armor });
    }
}