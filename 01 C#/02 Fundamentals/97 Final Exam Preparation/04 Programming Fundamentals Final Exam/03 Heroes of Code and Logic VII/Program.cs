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




//2
class Hero
{
    public int HP { get; set; }
    public int MP { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

        for (int i = 0; i < n; i++)
        {
            string[] elements = Console.ReadLine().Split();

            string heroName = elements[0];
            int hP = int.Parse(elements[1]);
            int mP = int.Parse(elements[2]);

            if (hP > 100)
            {
                hP = 100;
            }

            if (mP > 200)
            {
                mP = 200;
            }

            heroes.Add(heroName, new Hero()
            {
                HP = hP,
                MP = mP
            });
        }

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] elements = input
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string command = elements[0];
            string heroName = elements[1];

            if (!heroes.ContainsKey(heroName))
            {
                continue;
            }

            if (command == "CastSpell")
            {
                int mpNeeded = int.Parse(elements[2]);
                string spellName = elements[3];

                if (heroes[heroName].MP >= mpNeeded)
                {
                    heroes[heroName].MP -= mpNeeded;
                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                }
                else
                {
                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                }
            }
            else if (command == "TakeDamage")
            {
                int damage = int.Parse(elements[2]);
                string attacker = elements[3];

                if (heroes[heroName].HP > damage)
                {
                    heroes[heroName].HP -= damage;

                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                }
                else
                {
                    Console.WriteLine($"{heroName} has been killed by {attacker}!");

                    heroes.Remove(heroName);
                }
            }
            else if (command == "Recharge")
            {
                int amountRecovered = int.Parse(elements[2]);

                if (amountRecovered + heroes[heroName].MP > 200)
                {
                    amountRecovered -= heroes[heroName].MP + amountRecovered - 200;
                }

                heroes[heroName].MP += amountRecovered;

                Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
            }
            else
            {
                int amountRecovered = int.Parse(elements[2]);

                if (amountRecovered + heroes[heroName].HP > 100)
                {
                    amountRecovered -= heroes[heroName].HP + amountRecovered - 100;
                }

                heroes[heroName].HP += amountRecovered;

                Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
            }
        }

        foreach (var hero in heroes)
        {
            Console.WriteLine($"{hero.Key}");
            Console.WriteLine($"  HP: {hero.Value.HP}");
            Console.WriteLine($"  MP: {hero.Value.MP}");
        }
    }
}