string name = Console.ReadLine();
int poorGrades = 0;
int grade = 1;
double sumGrades = 0;

while (grade <= 12)
{
    double grades = double.Parse(Console.ReadLine());
    if (grades < 4)
    {
        poorGrades++;
        if (poorGrades == 2)
        {
            Console.WriteLine($"{name} has been excluded at {grade} grade");
            break;
        }
        continue;
    }
    poorGrades = 0;
    sumGrades += grades;
    grade++;
}

if (grade > 12)
{
    Console.WriteLine($"{name} graduated. Average grade: {sumGrades / 12:f2}");
}