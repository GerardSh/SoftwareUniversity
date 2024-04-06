Dictionary<string, int> foods = new Dictionary<string, int>();
int soldFoods = 0;

string input;

while ((input = Console.ReadLine()) != "Complete")
{
    string[] elements = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];
    int quantity = int.Parse(elements[1]);
    string food = elements[2];

    if (command == "Receive")
    {
        if (quantity <= 0)
        {
            continue;
        }

        if (!foods.ContainsKey(food))
        {
            foods.Add(food, 0);
        }

        foods[food] += quantity;
    }
    else if (command == "Sell")
    {
        if (!foods.ContainsKey(food))
        {
            Console.WriteLine($"You do not have any {food}.");
            continue;
        }
        else if (foods[food] < quantity)
        {
            Console.WriteLine($"There aren't enough {food}. You sold the last {foods[food]} of them.");
            soldFoods += foods[food];
            foods[food] = 0;
        }
        else
        {
            foods[food] -= quantity;
            soldFoods += quantity;
            Console.WriteLine($"You sold {quantity} {food}.");
        }

        if (foods[food] == 0)
        {
            foods.Remove(food);
        }
    }
}

foreach (var food in foods)
{
    Console.WriteLine($"{food.Key}: {food.Value}");
}

Console.WriteLine($"All sold: {soldFoods} goods");