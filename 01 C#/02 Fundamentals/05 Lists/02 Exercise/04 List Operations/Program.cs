using System;
using System.Collections.Generic;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "Add")
    {
        int number = int.Parse(commands[1]);
        numbers.Add(number);
    }
    else if (command == "Insert")
    {
        int number = int.Parse(commands[1]);
        int index = int.Parse(commands[2]);
        bool validIndex = CheckIndexIfValid(numbers, index);

        if (validIndex)
        {
            numbers.Insert(index, number);
        }
    }
    else if (command == "Remove")
    {
        int index = int.Parse(commands[1]);
        bool validIndex = CheckIndexIfValid(numbers, index);

        if (validIndex)
        {
            numbers.RemoveAt(index);
        }
    }
    else if (command == "Shift")
    {
        string direction = commands[1];
        int count = int.Parse(commands[2]);

        if (direction == "left")
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[0];

                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }

                numbers[numbers.Count - 1] = temp;
            }
        }
        if (direction == "right")
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[numbers.Count - 1];

                for (int j = numbers.Count - 1; j > 0; j--)
                {
                    numbers[j] = numbers[j - 1];
                }

                numbers[0] = temp;
            }
        }
    }
}

Console.WriteLine(string.Join(" ", numbers));
static bool CheckIndexIfValid(List<int> list, int index)
{
    if (index < 0 || index >= list.Count)
    {
        Console.WriteLine("Invalid index");
        return false;
    }
    else
    {
        return true;
    }
}




//2
using System;
using System.Collections.Generic;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "Add")
    {
        int number = int.Parse(commands[1]);
        numbers.Add(number);
    }
    else if (command == "Insert")
    {
        int number = int.Parse(commands[1]);
        int index = int.Parse(commands[2]);
        bool validIndex = CheckIndexIfValid(numbers, index);

        if (validIndex)
        {
            numbers.Insert(index, number);
        }
    }
    else if (command == "Remove")
    {
        int index = int.Parse(commands[1]);
        bool validIndex = CheckIndexIfValid(numbers, index);

        if (validIndex)
        {
            numbers.RemoveAt(index);
        }
    }
    else if (command == "Shift")
    {
        string direction = commands[1];
        int count = int.Parse(commands[2]);

        if (direction == "left")
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(temp);
            }
        }
        if (direction == "right")
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, temp);
            }
        }
    }
}

Console.WriteLine(string.Join(" ", numbers));


static bool CheckIndexIfValid(List<int> list, int index)
{
    if (index < 0 || index >= list.Count)
    {
        Console.WriteLine("Invalid index");
        return false;
    }
    else
    {
        return true;
    }
}
