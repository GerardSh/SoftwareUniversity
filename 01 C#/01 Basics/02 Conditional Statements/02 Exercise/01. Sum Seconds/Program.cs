int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

double min = (a + b + c) / 60;
double sec = (a + b + c) % 60;

if (sec < 10)
{
    Console.WriteLine($"{min}:0{sec}");
}

else
{
    Console.WriteLine($"{min}:{sec}");
}