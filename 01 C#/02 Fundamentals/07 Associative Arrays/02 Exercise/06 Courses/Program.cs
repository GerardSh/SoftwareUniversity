var namesByCourses = new Dictionary<string, List<string>>();

string input;

while ((input = Console.ReadLine()) != "end")
{
    string[] courseData = input
        .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

    string course = courseData[0];
    string name = courseData[1];

    if (!namesByCourses.ContainsKey(course))
    {
        namesByCourses.Add(course, new List<string>());
    }

    namesByCourses[course].Add(name);
}

namesByCourses = namesByCourses
    .OrderByDescending(x => x.Value.Count)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var kvp in namesByCourses)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

    foreach (var name in kvp.Value.OrderBy(x => x))
    {
        Console.WriteLine($"-- {name}");
    }
}




//2
var namesByCourses = new Dictionary<string, List<string>>();

string input;

while ((input = Console.ReadLine()) != "end")
{
    string[] courseData = input
        .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

    string course = courseData[0];
    string name = courseData[1];

    if (!namesByCourses.ContainsKey(course))
    {
        namesByCourses.Add(course, new List<string>());
    }

    namesByCourses[course].Add(name);
}

foreach (var kvp in namesByCourses)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

    foreach (var name in kvp.Value)
    {
        Console.WriteLine($"-- {name}");
    }
}