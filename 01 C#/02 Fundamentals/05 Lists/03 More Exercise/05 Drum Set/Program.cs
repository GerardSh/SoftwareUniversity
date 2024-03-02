int n = int.Parse(Console.ReadLine());

string text = "";

for (int i = 0; i < n; i++)
{
    int number = int.Parse(Console.ReadLine());
    char letter = ' ';

    if (number == 2)
    {
        letter = 'a';
    }
    else if (number == 22)
    {
        letter = 'b';
    }
    else if (number == 222)
    {
        letter = 'c';
    }
    else if (number == 3)
    {
        letter = 'd';
    }
    else if (number == 33)
    {
        letter = 'e';
    }
    else if (number == 333)
    {
        letter = 'f';
    }
    else if (number == 4)
    {
        letter = 'g';
    }
    else if (number == 44)
    {
        letter = 'h';
    }
    else if (number == 444)
    {
        letter = 'i';
    }
    else if (number == 5)
    {
        letter = 'j';
    }
    else if (number == 55)
    {
        letter = 'k';
    }
    else if (number == 555)
    {
        letter = 'l';
    }
    else if (number == 6)
    {
        letter = 'm';
    }
    else if (number == 66)
    {
        letter = 'n';
    }
    else if (number == 666)
    {
        letter = 'o';
    }
    else if (number == 7)
    {
        letter = 'p';
    }
    else if (number == 77)
    {
        letter = 'q';
    }
    else if (number == 777)
    {
        letter = 'r';
    }
    else if (number == 7777)
    {
        letter = 's';
    }
    else if (number == 8)
    {
        letter = 't';
    }
    else if (number == 88)
    {
        letter = 'u';
    }
    else if (number == 888)
    {
        letter = 'v';
    }
    else if (number == 9)
    {
        letter = 'w';
    }
    else if (number == 99)
    {
        letter = 'x';
    }
    else if (number == 999)
    {
        letter = 'y';
    }
    else if (number == 9999)
    {
        letter = 'z';
    }

    text += letter;
}

Console.WriteLine(text);