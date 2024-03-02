int n = int.Parse(Console.ReadLine());

var gradesByStudents = new Dictionary<string, List<double>>();

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    double grade = double.Parse(Console.ReadLine());

    if (!gradesByStudents.ContainsKey(name))
    {
        gradesByStudents.Add(name, new List<double>());
    }

    gradesByStudents[name].Add(grade);
}

Dictionary<string, double> gradesByStudentsSorted = gradesByStudents
    .Select(x => new KeyValuePair<string, double>(x.Key, x.Value.Average()))
    .Where(x => x.Value >= 4.5)
    .OrderByDescending(x => x.Value)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var student in gradesByStudentsSorted)
{
    Console.WriteLine($"{student.Key} -> {student.Value:f2}");
}