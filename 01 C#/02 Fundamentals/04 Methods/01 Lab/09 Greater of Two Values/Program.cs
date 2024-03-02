class MyClass
{
    static void Main(string[] args)
    {

        string type = Console.ReadLine();
        string value1 = Console.ReadLine();
        string value2 = Console.ReadLine();

        if (type == "string")
        {
            Console.WriteLine(GetMax(value1, value2));
        }
        else if (type == "char")
        {
            Console.WriteLine(GetMax(value1[0], value2[0]));
        }
        else
        {
            Console.WriteLine(GetMax(int.Parse(value1), int.Parse(value2)));
        }
    }

    static string GetMax(string str1, string str2)
    {
        int result = str1.CompareTo(str2);

        if (result > 0)
        {
            return str1;
        }
        else
        {
            return str2;
        }
    }
    static char GetMax(char char1, char char2)
    {
        char greater;
        if (char1 > char2)
        {
            greater = char1;
        }
        else
        {
            greater = char2;
        }

        return greater;
    }
    static int GetMax(int int1, int int2)
    {
        int greater;
        if (int1 > int2)
        {
            greater = int1;
        }
        else
        {
            greater = int2;
        }

        return greater;
    }
}