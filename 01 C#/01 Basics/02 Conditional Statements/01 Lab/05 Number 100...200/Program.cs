int number = int.Parse(Console.ReadLine());

if (number < 100)
{
    Console.WriteLine("Less than 100");
}
else if (number > 99 && number < 201)
{
    Console.WriteLine("Between 100 and 200");
}
else
{
    Console.WriteLine("Greater than 200");
}