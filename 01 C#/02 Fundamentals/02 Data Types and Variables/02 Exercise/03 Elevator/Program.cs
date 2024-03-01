double persons = int.Parse(Console.ReadLine());
int capacity = int.Parse(Console.ReadLine());

double courses = persons / capacity;

Console.WriteLine(Math.Ceiling(courses));