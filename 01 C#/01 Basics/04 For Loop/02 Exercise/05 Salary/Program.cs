int openTabs = int.Parse(Console.ReadLine());
int salary = int.Parse(Console.ReadLine());

int fine = 0;

for (int i = 1; i <= openTabs; i++)
{
    string currentString = Console.ReadLine();
    switch (currentString)
    {
        case "Facebook": fine += 150; break;
        case "Instagram": fine += 100; break;
        case "Reddit": fine += 50; break;
    }
    if (salary <= fine)
    {
        Console.WriteLine("You have lost your salary.");
        break;
    }
    if (i == openTabs)
    {
        Console.WriteLine(salary - fine);
    }
}