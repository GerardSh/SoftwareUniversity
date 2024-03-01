string n = Console.ReadLine();
int sumPrime = 0;
int sumNonPrime = 0;
bool isPrime = false;
bool isNonPrime = false;

while (n != "stop")
{
    int currentNumber = int.Parse(n);
    if (currentNumber < 0)
    {
        Console.WriteLine("Number is negative.");
    }
    else
    {
        for (int i = 2; i <= currentNumber && !isPrime && !isNonPrime; i++)
        {
            if (i >= currentNumber / 2)
            {
                sumPrime += currentNumber;
                isPrime = true;
            }
            else if (currentNumber % i == 0)
            {
                isNonPrime = true;
                sumNonPrime += currentNumber;
            }
        }
    }
    isPrime = false;
    isNonPrime = false;
    n = Console.ReadLine();
}

Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");