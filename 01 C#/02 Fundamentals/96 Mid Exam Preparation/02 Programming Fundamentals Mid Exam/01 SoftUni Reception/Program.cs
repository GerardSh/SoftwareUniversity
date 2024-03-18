int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());
int capacityHour = n1 + n2 + n3;
int students = int.Parse(Console.ReadLine());

int hours = 0;

while (students > 0)
{
    hours++;

    if (hours % 4 == 0)
    {
        continue;
    }

    students = students - capacityHour;
}

Console.WriteLine($"Time needed: {hours}h.");