string numbersCombined = Console.ReadLine();
int countNumbers = 0;
//3     3    3333   //

for (int i = 0; i < numbersCombined.Length; i++)
{
    if (numbersCombined[i] == ' ' || i == numbersCombined.Length - 1)
    {
        if (i != 0 && numbersCombined[i - 1] != ' ' || i == numbersCombined.Length - 1 && numbersCombined[i] != ' ')
        {
            countNumbers++;

        }
    }
}

double[] realNumbers = new double[countNumbers];
countNumbers = 0;
string wholeNumber = "";

for (int i = 0; i < numbersCombined.Length; i++)
{
    if (numbersCombined[i] != ' ')
    {
        wholeNumber += numbersCombined[i];

        if (i == numbersCombined.Length - 1)
        {
            realNumbers[countNumbers] = double.Parse(wholeNumber);
            wholeNumber = "";

            if (realNumbers[countNumbers] == -0)
            {
                realNumbers[countNumbers] = 0;
            }

            countNumbers++;
        }
    }
    else if (wholeNumber.Length > 0)

    {
        realNumbers[countNumbers] = double.Parse(wholeNumber);
        wholeNumber = "";

        if (realNumbers[countNumbers] == -0)
        {
            realNumbers[countNumbers] = 0;
        }

        countNumbers++;
    }
}

for (int i = 0; i < realNumbers.Length; i++)
{
    Console.WriteLine($"{realNumbers[i]} => {Math.Round(realNumbers[i], MidpointRounding.AwayFromZero)}");
}

////2
//string numbersCombined = Console.ReadLine();
//int countNumbers = 0;

//for (int i = 0; i < numbersCombined.Length; i++)
//{
//    if (i == numbersCombined.Length - 1 && numbersCombined[i] != ' ' || numbersCombined[i] != ' ' && numbersCombined[i + 1] == ' ')
//    {
//        countNumbers++;
//    }

//}

//double[] realNumbers = new double[countNumbers];
//countNumbers = 0;
//string wholeNumber = "";

//for (int i = 0; i < numbersCombined.Length; i++)
//{
//    if (numbersCombined[i] != ' ')
//    {
//        wholeNumber += numbersCombined[i];

//    }

//    if (wholeNumber.Length > 0 && (i == numbersCombined.Length - 1 || numbersCombined[i + 1] == ' '))

//    {
//        realNumbers[countNumbers] = double.Parse(wholeNumber);
//        wholeNumber = "";

//        if (realNumbers[countNumbers] == -0)
//        {
//            realNumbers[countNumbers] = 0;
//        }

//        countNumbers++;
//    }
//}

//for (int i = 0; i < realNumbers.Length; i++)
//{
//    Console.WriteLine($"{realNumbers[i]} => {Math.Round(realNumbers[i], MidpointRounding.AwayFromZero)}");
//}

////3
//string numbers = Console.ReadLine();

//double[] realNumbers = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();


//for (int i = 0; i < realNumbers.Length; i++)
//{
//    if (realNumbers[i] == -0)
//    {
//        realNumbers[i] = 0;
//    }

//    Console.WriteLine($"{realNumbers[i]} => {Math.Round(realNumbers[i], MidpointRounding.AwayFromZero)}");
//}

////4
//double[] doubles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

//int[] ints = new int[doubles.Length];

//for (int i = 0; i < doubles.Length; i++)
//{
//    ints[i] = (int)Math.Round(doubles[i], MidpointRounding.AwayFromZero);
//    Console.WriteLine($"{doubles[i]} => {ints[i]}");
//}