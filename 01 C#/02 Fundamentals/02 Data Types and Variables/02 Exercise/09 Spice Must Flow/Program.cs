int spiceCrop = int.Parse(Console.ReadLine());

int spiceTotal = 0;
int daysCount = 0;

while (spiceCrop >= 100)
{
    spiceTotal += spiceCrop - 26;
    spiceCrop -= 10;
    daysCount++;
}

Console.WriteLine(daysCount);
Console.WriteLine(spiceTotal > 0 ? spiceTotal - 26 : spiceTotal);