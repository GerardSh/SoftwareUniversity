var dwarfsByColor = new Dictionary<string, Dictionary<string, int>>();
var dwarfsByScore = new Dictionary<string, int>();

string input;

while ((input = Console.ReadLine()) != "Once upon a time")
{
    string[] dwarfData = input
        .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

    string name = dwarfData[0];
    string color = dwarfData[1];
    int physics = int.Parse(dwarfData[2]);

    if (!dwarfsByColor.ContainsKey(color))
    {
        dwarfsByColor.Add(color, new Dictionary<string, int>());
    }

    if (!dwarfsByColor[color].ContainsKey(name))
    {
        dwarfsByColor[color][name] = 0;
    }

    if (dwarfsByColor[color][name] < physics)
    {
        dwarfsByColor[color][name] = physics;
    }
}

foreach (var kvp in dwarfsByColor)
{
    foreach (var kvp2 in kvp.Value)
    {
        dwarfsByScore.Add($"({kvp.Key}) {kvp2.Key}", kvp2.Value);
    }
}

foreach (var drawf in dwarfsByScore.OrderByDescending(kvp => kvp.Value).ThenByDescending(c => dwarfsByScore.Where(kvp => kvp.Key.Split(")")[0] == c.Key.Split(")")[0]).Count()))
{
    Console.WriteLine($"{drawf.Key} <-> {drawf.Value}");
}








//2
namespace ConsoleApp
{
    class Dwarf
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int Physics { get; set; }
    }

    class Entry
    {
        public static void Main()
        {

            var dwarfs = new List<Dwarf>();

            var colorByDwarfs = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputArr = input
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArr[0];
                string color = inputArr[1];
                int physics = int.Parse(inputArr[2]);

                if (!colorByDwarfs.ContainsKey(color))
                {
                    colorByDwarfs.Add(color, new List<string>());
                }

                if (colorByDwarfs[color].Contains(name))
                {
                    Dwarf dwarf = dwarfs.FirstOrDefault(x => x.Name == name && x.Color == color);

                    if (dwarf.Physics < physics)
                    {
                        dwarf.Physics = physics;
                    }
                }
                else
                {
                    colorByDwarfs[color].Add(name);
                    dwarfs.Add(new Dwarf()
                    {
                        Name = name,
                        Color = color,
                        Physics = physics
                    });
                }
            }

            dwarfs = dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => colorByDwarfs[x.Color].Count).ToList();

            foreach (Dwarf dwarf in dwarfs)
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}









//3
namespace ConsoleApp
{
    class Dwarf
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int Physics { get; set; }

        public int ColorCount { get; set; }
    }

    class Entry
    {
        public static void Main()
        {

            var dwarfs = new List<Dwarf>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputArr = input
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArr[0];
                string color = inputArr[1];
                int physics = int.Parse(inputArr[2]);

                Dwarf dwarf = dwarfs.FirstOrDefault(dwarf => dwarf.Name == name && dwarf.Color == color);

                if (dwarf != null)
                {
                    if (dwarf.Physics < physics)
                    {
                        dwarf.Physics = physics;
                    }
                }
                else
                {
                    dwarfs.Add(new Dwarf()
                    {
                        Color = color,
                        Name = name,
                        Physics = physics
                    });
                }
            }

            Dictionary<string, int> colorCount = new Dictionary<string, int>();

            foreach (var dwarf1 in dwarfs)
            {
                if (!colorCount.ContainsKey(dwarf1.Color))
                {
                    colorCount.Add(dwarf1.Color, 0);
                }

                colorCount[dwarf1.Color]++;
            }

            dwarfs = dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => colorCount[x.Color]).ToList();

            // Second Variant
            //foreach (var dwarf1 in dwarfs)
            //{
            //    foreach (var dwarf2 in dwarfs)
            //    {
            //        if (dwarf1.Color == dwarf2.Color)
            //        {
            //            dwarf1.ColorCount++;
            //        }
            //    }
            //}

            //dwarfs = dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => x.ColorCount).ToList();

            foreach (Dwarf dwarf in dwarfs)
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}






//4
// {   {1, new Dictionary<string, Dictionary<string, int>>() { {"Peter", new Dictionary<string, int>() { {"Red", 5} } } }} ,
//    {2, new Dictionary<string, Dictionary<string, int>>() { {"George", new Dictionary<string, int>() { {"Blue", 5 } } } }} ,
//    {3, new Dictionary<string, Dictionary<string, int>>() { {"Peter", new Dictionary<string, int>() { {"Blue", 9} } } }},
//    {4, new Dictionary<string, Dictionary<string, int>>() { {"Philip", new Dictionary<string, int>() { {"Blue", 9 } } }
//} } };
string input;
var dwarfsByNumber = new Dictionary<int, Dictionary<string, Dictionary<string, int>>>();
int number = 1;

while ((input = Console.ReadLine()) != "Once upon a time")
{
    string[] inputArr = input
        .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
    string name = inputArr[0];
    string color = inputArr[1];
    int physics = int.Parse(inputArr[2]);

    bool isFound = false;

    foreach (var outerDictionary in dwarfsByNumber)
    {
        if (isFound)
        {
            break;
        }
        foreach (var middleDictionary in outerDictionary.Value)
        {
            foreach (var innerDictionary in middleDictionary.Value)
            {
                if (middleDictionary.Key == name && innerDictionary.Key == color)
                {
                    if (innerDictionary.Value < physics)
                    {
                        dwarfsByNumber[outerDictionary.Key][name][color] = physics;
                    }

                    isFound = true;
                }
            }
        }
    }

    if (isFound)
    {
        continue;
    }

    dwarfsByNumber.Add(number, new Dictionary<string, Dictionary<string, int>>());

    dwarfsByNumber[number].Add(name, new Dictionary<string, int>());

    dwarfsByNumber[number++][name].Add(color, physics);
}

var dwarfsByColor = new Dictionary<int, Dictionary<int, int>>();

foreach (var outerDictionary in dwarfsByNumber)
{
    foreach (var middleDictionary in outerDictionary.Value)
    {
        foreach (var innerDictionary in middleDictionary.Value)
        {
            int count = 0;

            foreach (var outerDictionarySecond in dwarfsByNumber.Values)
            {
                foreach (var middleDictionarySecond in outerDictionarySecond.Values)
                {
                    foreach (var innerDictionarySecond in middleDictionarySecond)
                    {
                        if (innerDictionary.Key == innerDictionarySecond.Key)
                        {
                            count++;
                        }
                    }
                }
            }

            dwarfsByColor.Add(outerDictionary.Key, new Dictionary<int, int>());
            dwarfsByColor[outerDictionary.Key].Add(count, innerDictionary.Value);
        }
    }
}

dwarfsByNumber = dwarfsByNumber
    .OrderByDescending(x => dwarfsByColor[x.Key].Values.Sum())
    .ThenByDescending(x => dwarfsByColor[x.Key].Keys.Sum())
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var outerDictionary in dwarfsByNumber)
{
    foreach (var middleDictionary in outerDictionary.Value)
    {
        foreach (var innerDictionary in middleDictionary.Value)
        {
            Console.WriteLine($"({innerDictionary.Key}) {middleDictionary.Key} <-> {innerDictionary.Value}");
        }
    }
}







//5
var dwarfs = new Dictionary<KeyValuePair<string, string>, int>();
string input;

while ((input = Console.ReadLine()) != "Once upon a time")
{
    string[] inputArray = input
        .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
    string name = inputArray[0];
    string color = inputArray[1];
    int physics = int.Parse(inputArray[2]);

    if (!dwarfs.ContainsKey(new KeyValuePair<string, string>(name, color)))
    {
        dwarfs.Add(new KeyValuePair<string, string>(name, color), 0);
    }

    if (physics > dwarfs[new KeyValuePair<string, String>(name, color)])
    {
        dwarfs[new KeyValuePair<string, string>(name, color)] = physics;
    }
}

dwarfs = dwarfs
    .OrderByDescending(x => x.Value)
    .ThenByDescending(outer => dwarfs.Where(x => x.Key.Value == outer.Key.Value).Count())
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var kvp in dwarfs)
{
    Console.WriteLine($"({kvp.Key.Value}) {kvp.Key.Key} <-> {kvp.Value}");
}