int firstNum = int.Parse(Console.ReadLine());
int secondNum = int.Parse(Console.ReadLine());
int magicNum = int.Parse(Console.ReadLine());
int combination = 0;
bool stop = false;
string result = "";

for (int i = firstNum; i <= secondNum; i++)
{
    for (int j = firstNum; j <= secondNum; j++)
    {
        combination++;
        if (i + j == magicNum)
        {
            result = $"({i} + {j} = {magicNum})";
            stop = true;
            break;

        }
    }
    if (stop)
    {
        break;
    }
}
if (stop)
{
    Console.WriteLine($"Combination N:{combination} {result}");

}
else
{
    Console.WriteLine($"{combination} combinations - neither equals {magicNum}");
}