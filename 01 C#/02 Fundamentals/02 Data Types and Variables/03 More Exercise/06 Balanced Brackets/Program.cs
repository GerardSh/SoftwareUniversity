int n = int.Parse(Console.ReadLine());

bool balanced = true;

string input = "";
string brackets = "";


for (int i = 0; i < n; i++)
{
    input = Console.ReadLine();

    if (input == "(" || input == ")")
    {
        brackets += input;
    }
}

for (int i = 0; i < brackets.Length; ++i)
{
    if (i != brackets.Length - 1 && brackets[i] == brackets[i + 1])
    {
        balanced = false;
    }
}

if (brackets.Length % 2 != 0)
{
    balanced = false;
}

if (balanced)
{

    Console.WriteLine("BALANCED");
}
else
{
    Console.WriteLine("UNBALANCED");
}