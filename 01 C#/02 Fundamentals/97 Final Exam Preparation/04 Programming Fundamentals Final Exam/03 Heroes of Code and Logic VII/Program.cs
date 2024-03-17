int n = int.Parse(Console.ReadLine());

Dictionary<string, int> hpByHero = new Dictionary<string, int>();
Dictionary<string, int> mpByHero = new Dictionary<string, int>();

AddHeroes(hpByHero, mpByHero, n);

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] commands = input
        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    string heroName = commands[1];

    if (command == "CastSpell")
    {
        int mpNeeded = int.Parse(commands[2]);
        string spellName = commands[3];

        if (mpByHero[heroName] >= mpNeeded)
        {
            mpByHero[heroName] -= mpNeeded;

            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {mpByHero[heroName]} MP!");
        }
        else
        {
            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
        }
    }
    else if (command == "TakeDamage")
    {
        int damage = int.Parse(commands[2]);
        string attacker = commands[3];

        hpByHero[heroName] -= damage;

        if (hpByHero[heroName] > 0)
        {
            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hpByHero[heroName]} HP left!");
        }
        else
        {
            Console.WriteLine($"{heroName} has been killed by {attacker}!");

            hpByHero.Remove(heroName);
            mpByHero.Remove(heroName);
        }
    }
    else if (command == "Recharge")
    {
        int mp = int.Parse(commands[2]);
        int amountRecovered = 0;

        if (mpByHero[heroName] + mp > 200)
        {
            amountRecovered = mp - (mpByHero[heroName] + mp - 200);
        }
        else
        {
            amountRecovered = mp;
        }

        mpByHero[heroName] += amountRecovered;

        Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
    }
    else if (command == "Heal")
    {
        int hp = int.Parse(commands[2]);
        int amountRecovered = 0;

        if (hpByHero[heroName] + hp > 100)
        {
            amountRecovered = hp - (hpByHero[heroName] + hp - 100);
        }
        else
        {
            amountRecovered = hp;
        }

        hpByHero[heroName] += amountRecovered;

        Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
    }
}

foreach (var kvp in hpByHero)
{
    string heroName = kvp.Key;
    int hp = kvp.Value;
    int mp = mpByHero[heroName];

    Console.WriteLine($"{heroName}");
    Console.WriteLine($"HP: {hp}");
    Console.WriteLine($"MP: {mp}");
}

static void AddHeroes(Dictionary<string, int> hpByHero, Dictionary<string, int> mpByHero, int n)
{
    for (int i = 0; i < n; i++)
    {
        string[] heroData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string name = heroData[0];
        int hp = int.Parse(heroData[1]);
        int mp = int.Parse(heroData[2]);

        if (hp > 100)
        {
            hp = 100;
        }
        if (mp > 200)
        {
            mp = 200;
        }

        if (!hpByHero.ContainsKey(name))
        {
            hpByHero[name] = hp;
            mpByHero[name] = mp;
        }
    }
}