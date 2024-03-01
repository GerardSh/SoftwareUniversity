using System.Numerics;

int n = int.Parse(Console.ReadLine());
BigInteger bestSnowballValue = 0;
string bestResult = "";

for (int i = 0; i < n; i++)
{
    int snowballSnow = int.Parse(Console.ReadLine());
    int snowballTime = int.Parse(Console.ReadLine());
    int snowballQuality = int.Parse(Console.ReadLine());

    BigInteger snowballValue = (BigInteger)((double)snowballSnow / snowballTime);
    snowballValue = BigInteger.Pow(snowballValue, snowballQuality);


    if (snowballValue > bestSnowballValue)
    {
        bestSnowballValue = snowballValue;
        bestResult = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
    }
}
Console.WriteLine(bestResult);