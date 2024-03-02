int n = int.Parse(Console.ReadLine());

string[] array = new string[]
{
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
};

if (n - 1 > 6 || n - 1 < 0)
{
    Console.WriteLine("Invalid day!");
}
else
{
    Console.WriteLine(array[n - 1]);
}