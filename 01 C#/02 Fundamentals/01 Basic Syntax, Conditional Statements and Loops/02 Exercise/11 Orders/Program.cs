using System;
using System.Diagnostics;
using System.Globalization;

int n = int.Parse(Console.ReadLine());

double sum = 0;

for (int i = 0; i < n; i++)
{
    double pricePerCapsule = double.Parse(Console.ReadLine());
    int days = int.Parse(Console.ReadLine());
    int capsulesCount = int.Parse(Console.ReadLine());

    sum += days * capsulesCount * pricePerCapsule;

    Console.WriteLine($"The price for the coffee is: ${days * capsulesCount * pricePerCapsule:f2}");
}

Console.WriteLine($"Total: ${sum:f2}");