int n = int.Parse(Console.ReadLine());
int biggest = 0;
int smallest = 0;
int number = 0;

for (int i = 0; i < n; i++)
{
    number = int.Parse(Console.ReadLine());
    if (i == 0)
    {
        biggest = number;
        smallest = number;
    }
    if (number > biggest)
    {
        biggest = number;
    }
    else if (number < smallest)
    {
        smallest = number;
    }


}

Console.WriteLine("Max number: " + biggest);
Console.WriteLine("Min number: " + smallest);