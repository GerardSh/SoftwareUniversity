using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace ConsoleApp
{
    class Test
    {
        static void Main()
        {

            var quantityByResource = new Dictionary<string, int>();

            quantityByResource.Add("fragments", 0);
            quantityByResource.Add("shards", 0);
            quantityByResource.Add("motes", 0);
            bool isBought = false;

            while (!isBought)
            {
                string[] resources = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < resources.Length; i += 2)
                {
                    AddResources(quantityByResource, resources[i + 1], resources[i]);

                    if (BuyItem(quantityByResource, resources[i + 1]))
                    {
                        isBought = true;
                        break;
                    }
                }
            }

            var sortedDictionary = quantityByResource
                .Where(x => x.Key == "shards" || x.Key == "motes" || x.Key == "fragments")
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            var sortedDictionary2 = quantityByResource
                .Where(x => x.Key != "shards" && x.Key != "motes" && x.Key != "fragments")
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedDictionary2)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            static bool BuyItem(Dictionary<string, int> quantityByResource, string resource)
            {
                if (quantityByResource[resource] >= 250)
                {
                    string item = "";

                    if (resource == "shards")
                    {
                        item = "Shadowmourne";
                    }
                    else if (resource == "fragments")
                    {
                        item = "Valanyr";
                    }
                    else if (resource == "motes")
                    {
                        item = "Dragonwrath";
                    }
                    else
                    {
                        return false;
                    }

                    Console.WriteLine($"{item} obtained!");
                    quantityByResource[resource] -= 250;

                    return true;
                }

                return false;
            }

            static void AddResources(Dictionary<string, int> quantityByResource, string resource, string quantity)
            {
                if (!quantityByResource.ContainsKey(resource))
                {
                    quantityByResource.Add(resource, 0);
                }

                quantityByResource[resource] += int.Parse(quantity);
            }
        }
    }

}




//2
public static void Main()
{

    var quantityByResource = new Dictionary<string, int>();

    quantityByResource.Add("fragments", 0);
    quantityByResource.Add("shards", 0);
    quantityByResource.Add("motes", 0);

    bool itemBought = false;

    while (!itemBought)
    {
        string[] resources = Console.ReadLine()
            .ToLower()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < resources.Length; i += 2)
        {
            AddResources(quantityByResource, resources[i + 1], resources[i]);

            if (BuyItem(quantityByResource, resources[i + 1]))
            {
                itemBought = true;
                break;
            }
        }
    }

    var sortedDictionary = quantityByResource
        .Where(x => x.Key == "shards" || x.Key == "motes" || x.Key == "fragments")
        .OrderByDescending(x => x.Value)
        .ThenBy(x => x.Key)
        .ToDictionary(x => x.Key, x => x.Value);

    foreach (var kvp in sortedDictionary)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }

    var sortedDictionary2 = quantityByResource
        .Where(x => x.Key != "shards" && x.Key != "motes" && x.Key != "fragments")
        .OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

    foreach (var kvp in sortedDictionary2)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }


    static bool BuyItem(Dictionary<string, int> quantityByResource, string resource)
    {
        if (quantityByResource[resource] >= 250)
        {
            string item = "";

            if (resource == "shards")
            {
                item = "Shadowmourne";
            }
            else if (resource == "fragments")
            {
                item = "Valanyr";
            }
            else if (resource == "motes")
            {
                item = "Dragonwrath";
            }
            else
            {
                return false;
            }

            Console.WriteLine($"{item} obtained!");

            quantityByResource[resource] -= 250;

            return true;
        }
        return false;
    }
}


static void AddResources(Dictionary<string, int> quantityByResource, string resource, string quantity)
{
    if (!quantityByResource.ContainsKey(resource))
    {
        quantityByResource.Add(resource, 0);
    }

    quantityByResource[resource] += int.Parse(quantity);
}




//3
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Test
    {
        public static void Main()
        {

            var legendaryItems = new Dictionary<string, int>()
            {
                {"shards",0},
                {"fragments",0},
                {"motes",0}
            };
            var junkItems = new Dictionary<string, int>();

            bool itemBought = false;

            while (!itemBought)
            {
                string[] resources = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < resources.Length; i += 2)
                {
                    int quantity = int.Parse(resources[i]);
                    string material = resources[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material] >= 250)
                        {
                            if (material == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained!");

                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine($"Valanyr obtained!");
                            }
                            else
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            legendaryItems[material] -= 250;
                            itemBought = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems.Add(material, 0);
                        }

                        junkItems[material] += quantity;
                    }
                }
            }

            var sortedLegendaryItems = legendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedLegendaryItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            var sortedJunkItems = junkItems.OrderBy(x => x.Key);

            foreach (var item in sortedJunkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}