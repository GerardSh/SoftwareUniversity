int n = int.Parse(Console.ReadLine());

var evenNumbers = new Dictionary<double, int>();

for (int i = 0; i < n; i++)
{
    double number = double.Parse(Console.ReadLine());

    if (!evenNumbers.ContainsKey(number))
    {
        evenNumbers[number] = 0;
    }

    evenNumbers[number]++;
}

foreach (var number in evenNumbers)
{
    if (number.Value % 2 == 0)
    {
        Console.WriteLine(number.Key + " ");
    }
}