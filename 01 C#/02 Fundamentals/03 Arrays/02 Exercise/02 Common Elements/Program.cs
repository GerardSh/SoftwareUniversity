string[] arr = Console.ReadLine().Split(" ");
string[] arr2 = Console.ReadLine().Split(" ");

string combined = "";

foreach (string s in arr2)
{
    foreach (string s2 in arr)
    {
        if (s2 == s)
        {
            combined += s + " ";
        }
    }
}

combined = string.Join(" ", combined.Split(" ", StringSplitOptions.RemoveEmptyEntries));
Console.WriteLine(combined);