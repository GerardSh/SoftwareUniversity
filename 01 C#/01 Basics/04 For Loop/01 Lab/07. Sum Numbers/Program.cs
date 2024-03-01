int n = int.Parse(Console.ReadLine());
int number = 0;

for (int i = 0; i < n; i++)
{
    number += int.Parse(Console.ReadLine());
}
Console.WriteLine(number);