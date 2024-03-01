int numberOfEvaluators = int.Parse(Console.ReadLine());
string nameOfExam = Console.ReadLine();

double sumAllGrades = 0;
int numberOfExams = 0;

while (nameOfExam != "Finish")
{
    double resultsCurrentPresentation = 0;

    for (int i = 0; i < numberOfEvaluators; i++)
    {
        resultsCurrentPresentation += double.Parse(Console.ReadLine());
        sumAllGrades += resultsCurrentPresentation;
    }

    double averageGrade = resultsCurrentPresentation / numberOfEvaluators;

    Console.WriteLine($"{nameOfExam} - {averageGrade:f2}.");

    sumAllGrades += averageGrade;
    numberOfExams++;
    nameOfExam = Console.ReadLine();
}
Console.WriteLine($"Student's final assessment is {sumAllGrades / numberOfExams:f2}.");