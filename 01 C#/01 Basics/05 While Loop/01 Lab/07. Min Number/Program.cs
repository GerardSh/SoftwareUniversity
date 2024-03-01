string command = Console.ReadLine();
int minNum = int.MaxValue;

while (command != "Stop")
{
    int currentNumber = int.Parse(command);

    if (currentNumber < minNum)
    {
        minNum = currentNumber;
    }
    command = Console.ReadLine();
}

Console.WriteLine(minNum);