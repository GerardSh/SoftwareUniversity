double budget = double.Parse(Console.ReadLine());

string gameName = "";
double moneySpentTotal = 0;

while (budget != 0 && (gameName = Console.ReadLine()) != "Game Time")
{
    double gamePrice = 0;

    if (gameName == "OutFall 4")
    {
        gamePrice = 39.99;
    }
    else if (gameName == "CS: OG")
    {
        gamePrice = 15.99;
    }
    else if (gameName == "Zplinter Zell")
    {
        gamePrice = 19.99;
    }
    else if (gameName == "Honored 2")
    {
        gamePrice = 59.99;
    }
    else if (gameName == "RoverWatch")
    {
        gamePrice = 29.99;
    }
    else if (gameName == "RoverWatch Origins Edition")
    {
        gamePrice = 39.99;
    }
    else
    {
        Console.WriteLine("Not Found");
    }

    if (budget >= gamePrice && gamePrice != 0)
    {
        budget -= gamePrice;
        moneySpentTotal += gamePrice;

        Console.WriteLine($"Bought {gameName}");
    }
    else if (gamePrice > budget && budget != 0)
    {
        Console.WriteLine("Too Expensive");
    }

    if (budget == 0)
    {
        Console.WriteLine("Out of money!");
    }
}

if (gameName == "Game Time")
{
    Console.WriteLine($"Total spent: ${moneySpentTotal:f2}. Remaining: ${budget:f2}");
}