string command = "";
double sum = 0;
command = Console.ReadLine();
while (command != "NoMoreMoney")
{
    double currentMoney = double.Parse(command);
    if (currentMoney < 0)
    {
        Console.WriteLine("Invalid operation!");
        break;
    }

    sum += currentMoney;
    Console.WriteLine($"Increase: {currentMoney:f2}");
    command = Console.ReadLine();
}
Console.WriteLine($"Total: {sum:f2}");