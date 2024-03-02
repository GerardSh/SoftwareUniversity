int n = int.Parse(Console.ReadLine());

string[] names = new string[n];

int[] encryptedNames = new int[n];

for (int i = 0; i < names.Length; i++)
{
    names[i] = Console.ReadLine();

    for (int j = 0; j < names[i].Length; j++)
    {
        if (names[i][j] == 'A' || names[i][j] == 'a' || names[i][j] == 'E' || names[i][j] == 'e' || names[i][j] == 'I' || names[i][j] == 'i' || names[i][j] == 'O' || names[i][j] == 'o' || names[i][j] == 'U' || names[i][j] == 'u')
        {
            encryptedNames[i] += names[i][j] * names[i].Length;
        }
        else
        {
            encryptedNames[i] += names[i][j] / names[i].Length;
        }
    }
}

Array.Sort(encryptedNames);

foreach (var i in encryptedNames)
{
    Console.WriteLine(i);
}