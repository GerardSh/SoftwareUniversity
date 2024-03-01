int n = 0;

while ((n = int.Parse(Console.ReadLine())) % 2 != 0)
{
    Console.WriteLine("Please write an even number.");
}

Console.WriteLine("The number is: " + Math.Abs(n));