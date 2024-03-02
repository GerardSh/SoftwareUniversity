int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());


int result = Sum(n1, n2);
result = Subtract(result, n3);

Console.WriteLine(result);

static int Subtract(int n1, int n2)
{
    return n1 - n2;
}

static int Sum(int n1, int n2)
{
    return n1 + n2;
}