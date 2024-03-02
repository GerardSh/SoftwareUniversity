int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    string name = GetPersonInformation(input, '@', '|');
    int age = int.Parse(GetPersonInformation(input, '#', '*'));

    Console.WriteLine($"{name} is {age} years old.");
}

string GetPersonInformation(string? input, char v1, char v2)
{
    int inxStart = input.IndexOf(v1) + 1;
    int inxEnd = input.IndexOf(v2);
    int lenght = inxEnd - inxStart;

    return input.Substring(inxStart, lenght);
}