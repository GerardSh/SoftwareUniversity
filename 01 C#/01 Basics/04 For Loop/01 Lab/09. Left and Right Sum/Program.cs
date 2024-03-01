using System.Threading.Channels;

int n = int.Parse(Console.ReadLine());
int firstHalf = 0;
int secondHalf = 0;

for (int i = 0; i < n * 2; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (i < n)
    {
        firstHalf += currentNumber;
    }
    else
    {
        secondHalf += currentNumber;
    }

}
if (firstHalf == secondHalf)
{
    Console.WriteLine($"Yes, sum = {firstHalf}");
}
else
    Console.WriteLine($"No, diff = {Math.Abs(firstHalf - secondHalf)}");