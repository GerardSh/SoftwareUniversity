int n = int.Parse(Console.ReadLine());

var students = new Dictionary<string, List<decimal>>();

for (int i = 0; i < n; i++)
{
    string[] student = Console.ReadLine().Split();

    string name = student[0];
    decimal grade = decimal.Parse(student[1]);

    if (!students.ContainsKey(name))
    {
        students.Add(name, new List<decimal>());
    }

    students[name].Add(grade);
}

foreach (var student in students)
{
    Console.Write($"{student.Key} -> ");

    foreach (var grade in student.Value)
    {
        Console.Write($"{grade:f2} ");
    }

    Console.WriteLine($"(avg: {student.Value.Average():f2})");
}