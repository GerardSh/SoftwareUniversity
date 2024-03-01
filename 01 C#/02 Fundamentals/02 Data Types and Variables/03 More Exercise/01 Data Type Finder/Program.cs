string input = "";

while ((input = Console.ReadLine()) != "END")
{
    if (int.TryParse(input, out int integerType))
    {
        Console.WriteLine(input + " is integer type");
    }
    else if (bool.TryParse(input, out bool boolType))
    {
        Console.WriteLine(input + " is boolean type");
    }
    else if (char.TryParse(input, out char charType))
    {
        Console.WriteLine(input + " is character type");
    }
    else if (float.TryParse(input, out float floatType))
    {
        Console.WriteLine(input + " is floating point type");
    }
    else
    {
        Console.WriteLine(input + " is string type");
    }
}