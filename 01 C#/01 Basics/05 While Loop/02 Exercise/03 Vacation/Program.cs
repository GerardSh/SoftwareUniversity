double moneyNeeded = double.Parse(Console.ReadLine());
double moneyAvailable = double.Parse(Console.ReadLine());
int spentCounter = 0;
int daysCounter = 0;

while (moneyNeeded > moneyAvailable)
{
    string currentOperation = Console.ReadLine();
    double currentMoney = double.Parse(Console.ReadLine());
    daysCounter++;

    if (currentOperation == "save")
    {
        moneyAvailable += currentMoney;
        spentCounter = 0;
    }
    else
    {
        moneyAvailable -= currentMoney;
        spentCounter++;
        if (moneyAvailable < 0)
        {
            moneyAvailable = 0;
        }
    }
    if (spentCounter == 5)
    {
        Console.WriteLine($"You can't save the money.");
        Console.WriteLine(daysCounter);
        break;
    }
}
if (moneyAvailable >= moneyNeeded)
{
    Console.WriteLine($"You saved the money for {daysCounter} days.");
}