int stepsSum = 0;
const int goal = 10000;
string command = Console.ReadLine();

while (command != "Going home")
{
    stepsSum += int.Parse(command);
    if (stepsSum < goal)
    {
        command = Console.ReadLine();
    }
    else
    {
        break;
    }
}

if (command == "Going home")
{
    stepsSum += int.Parse(Console.ReadLine());
}

if (stepsSum >= goal)
{
    Console.WriteLine("Goal reached! Good job!");
    Console.WriteLine($"{stepsSum - goal} steps over the goal!");
}
else
{
    Console.WriteLine($"{goal - stepsSum} more steps to reach goal.");
}