double quantityFood = double.Parse(Console.ReadLine()) * 1000;
double quantityHay = double.Parse(Console.ReadLine()) * 1000;
double quantityCover = double.Parse(Console.ReadLine()) * 1000;
double weigth = double.Parse(Console.ReadLine()) * 1000;

for (int i = 1; i <= 30; i++)
{
    quantityFood -= 300;

    if (i % 2 == 0)
    {
        double neededHay = quantityFood * 0.05;

        quantityHay -= neededHay;
    }

    if (i % 3 == 0)
    {
        double neededCover = weigth / 3;
        quantityCover -= neededCover;
    }

    if (quantityFood <= 0 || quantityHay <= 0 || quantityCover <= 0)
    {
        Console.WriteLine("Merry must go to the pet store!");
        return;
    }
}

Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityFood / 1000:f2}, Hay: {quantityHay / 1000:f2}, Cover: {quantityCover / 1000:f2}.");
