class Number
{
    public double Value { get; set; }

    public int Frequency { get; set; }

    public static void Main()
    {
        List<double> numbersInput = Console.ReadLine().Split().Select(double.Parse).ToList();

        List<Number> numbers = new List<Number>() { };


        while (numbersInput.Count > 0)
        {
            //int count = 0;

            //foreach (double number in numbersInput)
            //{
            //    if (number == numbersInput[0])
            //    {
            //        count++;
            //    }
            //}

            //numbers.Add(new Number()
            //{
            //    Frequency = count,
            //    Value = numbersInput[0]
            //});

            //double numberToDelete = numbersInput[0];

            //numbersInput.RemoveAll(x => x == numberToDelete);

            double numberToDelete = numbersInput[0];

            numbers.Add(new Number()
            {
                Value = numbersInput[0],
                Frequency = numbersInput.RemoveAll(x => x == numberToDelete)
            });
        }

        foreach (Number number in numbers.OrderBy(x => x.Value).ToList())
        {
            Console.WriteLine($"{number.Value} -> {number.Frequency}");
        }
    }
}









//2
double[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

SortedDictionary<double, int> keyValuePairs = new SortedDictionary<double, int>();

foreach (double i in array)
{
    if (keyValuePairs.ContainsKey(i))
    {
        keyValuePairs[i]++;
    }
    else
    {
        keyValuePairs.Add(i, 1);
    }
}

foreach (var i in keyValuePairs)
{
    Console.WriteLine($"{i.Key} -> {i.Value}");
}