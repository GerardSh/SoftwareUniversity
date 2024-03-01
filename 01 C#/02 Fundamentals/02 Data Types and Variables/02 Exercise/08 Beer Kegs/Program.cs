int n = int.Parse(Console.ReadLine());
double biggestVolume = 0;
string biggestKeg = "";

for (int i = 0; i < n; i++)
{
    string kegModel = Console.ReadLine();
    double radius = double.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());

    double volume = Math.PI * radius * radius * height;

    if (volume > biggestVolume)
    {
        biggestVolume = volume;
        biggestKeg = kegModel;
    }
}

Console.WriteLine(biggestKeg);