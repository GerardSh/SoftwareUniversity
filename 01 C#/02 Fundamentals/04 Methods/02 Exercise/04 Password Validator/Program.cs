string input = Console.ReadLine();

bool isLenghtValid = ValidateLength(input);
bool isLettersDigitsValid = ValidateLettersDigits(input);
bool isDigitsCountValid = ValidateDigitsCount(input);

if (isLenghtValid && isLettersDigitsValid && isDigitsCountValid)
{
    Console.WriteLine("Password is valid");
}

static bool ValidateLength(string str)
{
    bool passLength = false;

    if (str.Length < 6 || str.Length > 10)
    {
        Console.WriteLine("Password must be between 6 and 10 characters");
    }
    else
    {
        passLength = true;
    }

    return passLength;
}

static bool ValidateLettersDigits(string str)
{
    bool passLettersDigits = false;

    str = str.ToLower();

    foreach (char c in str)
    {
        if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
        {
            passLettersDigits = true;
        }
        else
        {
            Console.WriteLine("Password must consist only of letters and digits");
            passLettersDigits = false;
            break;
        }
    }

    return passLettersDigits;
}

static bool ValidateDigitsCount(string str)
{
    bool passDigitsCount = false;
    int digitsCount = 0;

    foreach (char c in str)
    {
        if (c >= '0' && c <= '9')
        {
            digitsCount++;
        }
    }

    if (digitsCount < 2)
    {
        Console.WriteLine("Password must have at least 2 digits");
    }
    else
    {
        passDigitsCount = true;
    }

    return passDigitsCount;
}

////2
//string input = Console.ReadLine();

//bool isLenghtValid = ValidateLength(input);
//bool isLettersDigitsValid = ValidateLettersDigits(input);
//bool isDigitsCountValid = ValidateDigitsCount(input);

//if (isLenghtValid && isLettersDigitsValid && isDigitsCountValid)
//{
//    Console.WriteLine("Password is valid");
//}

//static bool ValidateLength(string str)
//{
//    bool passLength = false;

//    if (str.Length < 6 || str.Length > 10)
//    {
//        Console.WriteLine("Password must be between 6 and 10 characters");
//    }
//    else
//    {
//        passLength = true;
//    }

//    return passLength;
//}

//static bool ValidateLettersDigits(string str)
//{
//    bool passLettersDigits = true;

//    str = str.ToLower();

//    foreach (char c in str)
//    {
//        //if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
//        if (c < '0' || c > '9' && c < 'a' || c > 'z')
//        {
//            Console.WriteLine("Password must consist only of letters and digits");

//            passLettersDigits = false;

//            break;
//        }
//    }

//    return passLettersDigits;
//}

//static bool ValidateDigitsCount(string str)
//{
//    bool passDigitsCount = false;
//    int digitsCount = 0;

//    foreach (char c in str)
//    {
//        if (c >= '0' && c <= '9')
//        {
//            digitsCount++;
//        }
//    }

//    if (digitsCount < 2)
//    {
//        Console.WriteLine("Password must have at least 2 digits");
//    }
//    else
//    {
//        passDigitsCount = true;
//    }

//    return passDigitsCount;
//}