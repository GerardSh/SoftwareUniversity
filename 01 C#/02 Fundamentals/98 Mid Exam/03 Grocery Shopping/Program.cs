List<string> shoppingList = Console.ReadLine()
    .Split("|", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "Shop!")
{
    string[] elements = input
        .Split("%", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];

    if (command == "Important")
    {
        string product = elements[1];

        if (shoppingList.Contains(product))
        {
            shoppingList.Remove(product);
            shoppingList.Insert(0, product);
        }
        else
        {
            shoppingList.Insert(0, product);
        }
    }
    else if (command == "Add")
    {
        string product = elements[1];

        if (!shoppingList.Contains(product))
        {
            shoppingList.Add(product);
        }
        else
        {
            Console.WriteLine("The product is already in the list.");
        }
    }
    else if (command == "Swap")
    {
        string productOne = elements[1];
        string productTwo = elements[2];

        if (!shoppingList.Contains(productOne))
        {
            Console.WriteLine($"Product {productOne} missing!");
        }
        else if (!shoppingList.Contains(productTwo))
        {
            Console.WriteLine($"Product {productTwo} missing!");
        }
        else
        {
            int indexOne = shoppingList.IndexOf(productOne);
            int indexTwo = shoppingList.IndexOf(productTwo);

            shoppingList[indexOne] = productTwo;
            shoppingList[indexTwo] = productOne;
        }
    }
    else if (command == "Remove")
    {
        string product = elements[1];

        int index = shoppingList.IndexOf(product);

        if (index < 0)
        {
            Console.WriteLine($"Product {product} isn't in the list.");
        }
        else
        {
            shoppingList.RemoveAt(index);
        }
    }
    else if (command == "Reversed")
    {
        shoppingList.Reverse();
    }
}

int number = 1;

foreach (string product in shoppingList)
{
    Console.WriteLine($"{number++}. {product}");
}
//09:46:13 04.04.2024