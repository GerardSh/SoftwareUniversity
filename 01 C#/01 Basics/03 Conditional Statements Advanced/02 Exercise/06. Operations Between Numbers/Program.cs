double n1 = double.Parse(Console.ReadLine());
double n2 = double.Parse(Console.ReadLine());
string operation = Console.ReadLine();
string operationWithNumbers = $"{n1} {operation} {n2}";
if (operation == "+")
{

    Console.WriteLine($"{operationWithNumbers} = {n1 + n2} - {((n1 + n2) % 2 == 0 ? "even" : "odd")}");
}

else if (operation == "-")
{

    Console.WriteLine($"{operationWithNumbers} = {n1 - n2} - {((n1 - n2) % 2 == 0 ? "even" : "odd")}");
}

else if (operation == "*")
{

    Console.WriteLine($"{operationWithNumbers} = {n1 * n2} - {((n1 * n2) % 2 == 0 ? "even" : "odd")}");
}
else if (operation == "/")
{
    if (n2 == 0)
    {
        Console.WriteLine($"Cannot divide {n1} by zero");
    }
    else
    {
        Console.WriteLine($"{operationWithNumbers} = {n1 / n2:f2}");
    }
}
else if (operation == "%")
{
    if (n2 == 0)
    {
        Console.WriteLine($"Cannot divide {n1} by zero");
    }
    else
    {
        Console.WriteLine($"{operationWithNumbers} = {n1 % n2}");
    }
}

