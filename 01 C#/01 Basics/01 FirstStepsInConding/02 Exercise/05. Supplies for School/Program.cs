int penPrice = int.Parse(Console.ReadLine());
int pencilPrice = int.Parse(Console.ReadLine());
int cleaningPrice = int.Parse(Console.ReadLine());
int percentage = int.Parse(Console.ReadLine());
double totalSum = pencilPrice * 7.2 + penPrice * 5.8 + cleaningPrice * 1.2;
Console.WriteLine(totalSum(1 - percentage * 0.01) + " лв.");