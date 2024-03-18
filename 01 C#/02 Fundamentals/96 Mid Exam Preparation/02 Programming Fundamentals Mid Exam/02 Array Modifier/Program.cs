int[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string input;

while ((input = Console.ReadLine()) != "end")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "swap" || command == "multiply")
    {
        int indexOne = int.Parse(commands[1]);
        int indexTwo = int.Parse(commands[2]);

        if (command == "swap")
        {
            int temp = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = temp;
        }
        else
        {
            array[indexOne] *= array[indexTwo];
        }
    }
    else
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] -= 1;
        }
    }
}

Console.WriteLine(string.Join(", ", array));