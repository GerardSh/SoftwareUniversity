int lenght = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int tall = int.Parse(Console.ReadLine());
double percent = double.Parse(Console.ReadLine()) * 0.01;

Console.WriteLine((lenght * width * tall * 0.001) * (1 - percent));