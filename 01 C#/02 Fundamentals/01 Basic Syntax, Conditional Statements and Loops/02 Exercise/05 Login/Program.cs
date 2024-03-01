string name = Console.ReadLine();

string password = "";
bool success = false;

for (int i = 0; i < name.Length; i++)
{
    password += name[name.Length - 1 - i];
}

for (int i = 0; i < 4 && !success; i++)
{
    if (Console.ReadLine() != password)
    {
        if (i == 3)
        {
            Console.WriteLine($"User {name} blocked!");
        }
        else
        {
            Console.WriteLine("Incorrect password. Try again.");
        }
    }
    else
    {
        Console.WriteLine($"User {name} logged in.");
        success = true;
    }
}