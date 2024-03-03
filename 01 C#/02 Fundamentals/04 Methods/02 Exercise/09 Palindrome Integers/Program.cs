string input;

while ((input = Console.ReadLine()) != "END")
{
    CheckPalindrome(input);

}

static void CheckPalindrome(string number)
{
    bool isValid = true;

    for (int i = 0; i < number.Length / 2; i++)
    {
        if (!(number[i] == number[number.Length - 1 - i]))
        {
            isValid = false;
            break;
        }
    }

    Console.WriteLine(isValid);
}




//2
string input;

while ((input = Console.ReadLine()) != "END")
{
    CheckPalindrome(input);
}

static void CheckPalindrome(string number)
{
    bool isValid = false;

    if (number == string.Concat(number.Reverse()))
    {
        isValid = true;
    }

    Console.WriteLine(isValid);
}