int n = int.Parse(Console.ReadLine());
string gender = "";

if (n >= 0)
{
    if (n <= 2)
    {
        gender = "baby";
    }
    else if (n <= 13)
    {
        gender = "child";
    }
    else if (n <= 19)
    {
        gender = "teenager";
    }
    else if (n <= 65)
    {
        gender = "adult";
    }
    else if (n >= 66)
    {
        gender = "elder";
    }
}
Console.WriteLine(gender);