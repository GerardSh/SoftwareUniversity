int students = int.Parse(Console.ReadLine());
int lectures = int.Parse(Console.ReadLine());
int additionalBonus = int.Parse(Console.ReadLine());

double maxBonus = 0;
int bestStudentAttendances = 0;

for (int i = 0; i < students; i++)
{
    int attendances = int.Parse(Console.ReadLine());

    double bonus = 1.0 * attendances / lectures * (5 + additionalBonus);

    if (bonus > maxBonus)
    {
        maxBonus = bonus;
        bestStudentAttendances = attendances;
    }
}

Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");




//2
int n = int.Parse(Console.ReadLine());

int totalNumberLectures = int.Parse(Console.ReadLine());

int bonus = int.Parse(Console.ReadLine());

double bestStudentBonus = 0;
double bestStudentAttendances = 0;

for (int i = 0; i < n; i++)
{
    double attendancesCount = int.Parse(Console.ReadLine());

    double totalBonus = attendancesCount / totalNumberLectures * (5 + bonus);

    if (totalBonus > bestStudentBonus)
    {
        bestStudentBonus = totalBonus;
        bestStudentAttendances = attendancesCount;
    }
}

Console.WriteLine($"Max Bonus: {Math.Ceiling(bestStudentBonus)}.");
Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");