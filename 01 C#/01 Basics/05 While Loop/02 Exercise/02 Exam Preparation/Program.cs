int badGradesAllowed = int.Parse(Console.ReadLine());
int badGradesCount = 0;
int gradesCount = 0;
double sumGrade = 0;
string examName = Console.ReadLine();
int grades = 0;
string lastExam = "";
bool hasFailed = badGradesCount == badGradesAllowed;

while (examName != "Enough")
{
    grades = int.Parse(Console.ReadLine());
    if (grades <= 4 && ++badGradesCount == badGradesAllowed)
    {
        Console.WriteLine($"You need a break, {badGradesCount} poor grades.");
        break;
    }
    gradesCount++;
    sumGrade += grades;
    lastExam = examName;
    examName = Console.ReadLine();

}
if (examName == "Enough")
{
    Console.WriteLine($"Average score: {sumGrade / gradesCount:f2}");
    Console.WriteLine($"Number of problems: {gradesCount}");
    Console.WriteLine($"Last problem: {lastExam}");
}