var elements = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var nNumbers = new HashSet<int>(elements[0]);
var mNumbers = new HashSet<int>(elements[1]);

for (int i = 0; i < elements[0]; i++)
{
    int number = int.Parse(Console.ReadLine());
    nNumbers.Add(number);
}

for (int i = 0; i < elements[1]; i++)
{
    int number = int.Parse(Console.ReadLine());
    mNumbers.Add(number);
}

foreach (var nNumber in nNumbers)
{
    foreach (var mNumber in mNumbers)
    {
        if (nNumber == mNumber)
        {
            Console.Write(nNumber + " ");
        }
    }
}