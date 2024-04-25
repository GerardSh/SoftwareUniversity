int n = int.Parse(Console.ReadLine());

var students = new Dictionary<string, int>();

for (int i = 0; i < n; i++)
{
    string[] elements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string name = elements[0];
    int age = int.Parse(elements[1]);

    students[name] = age;
}

string commandFilter = Console.ReadLine();
int ageFilter = int.Parse(Console.ReadLine());
string[] filter = Console.ReadLine().Split();

if (commandFilter == "older")
{
    students = students.Where(x => x.Value >= ageFilter).ToDictionary(x => x.Key, x => x.Value);
}
else
{
    students = students.Where(x => x.Value < ageFilter).ToDictionary(x => x.Key, x => x.Value);
}

if (filter.Length > 1)
{
    foreach (var kvp in students)
    {
        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
    }
}
else if (filter[0] == "name")
{
    foreach (var kvp in students)
    {
        Console.WriteLine($"{kvp.Key}");
    }
}
else
{
    foreach (var kvp in students)
    {
        Console.WriteLine($"{kvp.Value}");
    }
}




//2
class Student
{
    public string Name { get; set; }

    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>(n);

        for (int i = 0; i < n; i++)
        {
            string[] elements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string name = elements[0];
            int age = int.Parse(elements[1]);

            students.Add(new Student()
            {
                Name = name,
                Age = age
            });
        }

        string commandFilter = Console.ReadLine();
        int ageFilter = int.Parse(Console.ReadLine());
        string[] filter = Console.ReadLine().Split();

        if (commandFilter == "older")
        {
            students = students.Where(x => x.Age >= ageFilter).ToList();
        }
        else
        {
            students = students.Where(x => x.Age < ageFilter).ToList();
        }

        if (filter.Length > 1)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} - {student.Age}");
            }
        }
        else if (filter[0] == "name")
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}");
            }
        }
        else
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Age}");
            }
        }
    }
}