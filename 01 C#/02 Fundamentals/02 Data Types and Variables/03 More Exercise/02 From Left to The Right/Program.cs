int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    bool secondNumber = false;
    string firstNum = "";
    string secondNum = "";
    int countFirstDigits = 0;
    int countSecondDigits = 0;

    for (int j = 0; j < input.Length; j++)
    {


        if (input[j] == ' ')
        {
            secondNumber = true;
        }

        else if (secondNumber)
        {
            secondNum += input[j].ToString();

            if (input[j] == '-')
            {
                continue;
            }
            countSecondDigits += int.Parse(input[j].ToString());
        }
        else
        {
            firstNum += input[j].ToString();

            if (input[j] == '-')
            {
                continue;
            }

            countFirstDigits += int.Parse(input[j].ToString());
        }
    }

    if (long.Parse(firstNum) >= long.Parse(secondNum))
    {
        Console.WriteLine(countFirstDigits);
    }
    else
    {
        Console.WriteLine(countSecondDigits);
    }
}




//2
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    bool secondNumber = false;
    string firstNum = "";
    string secondNum = "";

    for (int j = 0; j < input.Length; j++)
    {
        if (input[j] == ' ')
        {
            secondNumber = true;
        }

        else if (secondNumber)
        {
            secondNum += input[j].ToString();

        }
        else
        {
            firstNum += input[j].ToString();
        }
    }

    long biggerNumber = 0;

    if (long.Parse(firstNum) >= long.Parse(secondNum))
    {
        biggerNumber = long.Parse(firstNum);
    }
    else
    {
        biggerNumber = long.Parse(secondNum);
    }

    long digitSum = 0;

    while (biggerNumber != 0)
    {
        digitSum += biggerNumber % 10;
        biggerNumber /= 10;
    }
    Console.WriteLine(Math.Abs(digitSum));
}