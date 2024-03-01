string text = Console.ReadLine();
int sum = 0;
string first = "";
string second = "";
for (int i = 0; i < text.Length; i++)
{
    if (text[i] == 'a')
    {

        sum += 1;
        first += 'a';
        second += '1';

    }
    else if (text[i] == 'e')
    {
        sum += 2;
        first += 'e';
        second += '2';
    }
    else if (text[i] == 'i')
    {
        sum += 3;
        first += 'i';
        second += '3';
    }
    else if (text[i] == 'o')
    {
        sum += 4;
        first += 'o';
        second += '4';
    }
    else if (text[i] == 'u')
    {
        sum += 5;
        first += 'u';
        second += '5';
    }
    if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' || text[i] == 'o' || text[i] == 'u')
       
        for (int e = i + 1; e < text.Length; e++)
        {
            if (text[e] == 'a' || text[e] == 'e' || text[e] == 'i' || text[e] == 'o' || text[e] == 'u')
            {
                first += " + ";
                second += " + ";
                break;
            }
        }
}
if (first.Length == 1)
    Console.Write($"{sum} {first} = {second}");
else if (first.Length > 1)
    Console.Write($"{sum} {first} = {second} = {sum}");