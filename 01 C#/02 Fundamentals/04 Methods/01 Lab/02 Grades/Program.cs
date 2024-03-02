double grade = double.Parse(Console.ReadLine());

Console.WriteLine(GradesInText(grade));

static string GradesInText(double grade)
{
    string result = "";

    if (grade >= 2 && grade <= 2.99)
    {
        result = "Fail";
    }
    else if (grade <= 3.49)
    {
        result = "Poor";
    }
    else if (grade <= 4.49)
    {
        result = "Good";
    }
    else if (grade <= 5.49)
    {
        result = "Very good";
    }
    else
    {
        result = "Excellent";
    }
    return result;
}