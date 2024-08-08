using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var items = new List<string>();
        var stores = new Dictionary<string, List<string>>();
        var importantItems = new List<string>();

        string input;

        while ((input = Console.ReadLine()) != "Go Shopping")
        {
            string[] elements = input.Split("->");

            string command = elements[0];

            string store = elements[1];

            if (command == "Add")
            {
                string[] currentItems = elements[2].Split(",");

                foreach (string item in currentItems)
                {
                    if (items.Contains(item))
                    {
                        continue;
                    }

                    items.Add(item);

                    if (!stores.ContainsKey(store))
                    {
                        stores.Add(store, new List<string>());
                    }

                    stores[store].Add(item);
                }
            }
            else if (command == "Important")
            {
                string importantItem = elements[2];

                if (items.Contains(importantItem))
                {
                    continue;
                }

                if (!stores.ContainsKey(store))
                {
                    stores.Add(store, new List<string>());
                }

                stores[store].Insert(0, importantItem);
                importantItems.Add(importantItem);
            }
            else if (command == "Remove")
            {
                if (!stores.ContainsKey(store))
                {
                    continue;
                }

                bool containsImportantItem = false;

                foreach (string item in stores[store])
                {
                    if (importantItems.Contains(item))
                    {
                        containsImportantItem = true;
                    }
                }

                if (!containsImportantItem)
                {
                    foreach (string item in stores[store])
                    {
                        items.Remove(item);
                    }

                    stores.Remove(store);
                }
            }
        }

        foreach (var kvp in stores)
        {
            Console.WriteLine($"{kvp.Key}:");

            foreach (var item in kvp.Value)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}

//Created on: 08 / 08 / 2024 10:26:22