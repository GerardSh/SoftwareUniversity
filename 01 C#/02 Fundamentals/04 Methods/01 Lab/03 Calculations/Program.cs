string operation = Console.ReadLine();
int numberOne = int.Parse(Console.ReadLine());
int numberTwo = int.Parse(Console.ReadLine());


switch (operation)
{
    case "add":
        Add(numberOne, numberTwo);
        break;
    case "subtract":
        Subtract(numberOne, numberTwo);
        break;
    case "multiply":
        Multiply(numberOne, numberTwo);
        break;
    case "divide":
        Divide(numberOne, numberTwo);
        break;
    default:
        break;
}
static void Add(int n1, int n2)
{
    int result = n1 + n2;

    Console.WriteLine(result);
}

static void Subtract(int n1, int n2)
{
    int result = (n1 - n2);

    Console.WriteLine(result);
}

static void Multiply(int n1, int n2)
{
    int result = (n1 * n2);

    Console.WriteLine(result);
}

static void Divide(int n1, int n2)
{
    int result = (n1 / n2);

    Console.WriteLine(result);
}
