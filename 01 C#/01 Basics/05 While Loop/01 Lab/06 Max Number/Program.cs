string number = Console.ReadLine();
double n = double.MinValue;
while (number != "Stop")
{
    double currentNumber = double.Parse(number);
    if (currentNumber > n)
    {
        n = currentNumber;
    }
    number = Console.ReadLine();
}
Console.WriteLine(n);