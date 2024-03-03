double n1 = double.Parse(Console.ReadLine());
double n2 = double.Parse(Console.ReadLine());
double n3 = double.Parse(Console.ReadLine());

double biggest = 0;
double medium = 0;
double smallest = 0;

if (n1 >= n2 && n1 >= n3)
{
    biggest = n1;
}
else if (n2 >= n3 && n2 >= n1)
{
    biggest = n2;
}
else if (n3 >= n1 && n3 >= n2)
{
    biggest = n3;
}

if (n1 <= n2 && n1 <= n3)
{
    smallest = n1;
}
else if (n2 <= n3 && n2 <= n1)
{
    smallest = n2;
}
else if (n3 <= n2 && n3 <= n1)
{
    smallest = n3;
}

if (n1 < biggest && n1 > smallest)
{
    medium = n1;
}
else if (n2 < biggest && n2 > smallest)
{
    medium = n2;
}
else if (n3 < biggest && n3 > smallest)
{
    medium = n3;
}
else if (n1 == n2 && (n1 != n3))
{
    medium = n2;
}
else if (n1 == n3 && (n1 != n2))
{
    medium = n3;
}
else if (n2 == n3 && n2 != n1)
{
    medium = n2;
}
else
{
    medium = n1;
}

Console.WriteLine(biggest);
Console.WriteLine(medium);
Console.WriteLine(smallest);




//2
// Find the smallest
int smallest = n1;
if (n2 < smallest)
{
    smallest = n2;
}
if (n3 < smallest)
{
    smallest = n3;
}

// Find the largest
int largest = n1;
if (n2 > largest)
{
    largest = n2;
}
if (n3 > largest)
{
    largest = n3;
}

// Find the medium
int medium = n1 + n2 + n3 - smallest - largest;
