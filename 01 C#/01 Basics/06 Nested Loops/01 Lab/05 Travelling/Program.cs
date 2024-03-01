string destination = Console.ReadLine();

while (destination != "End")
{

    double budget = double.Parse(Console.ReadLine());
    double currentMoney = 0;

    while (currentMoney < budget)
    {
        currentMoney += double.Parse(Console.ReadLine());

    }
    Console.WriteLine($"Going to {destination}!");
    destination = Console.ReadLine();
}