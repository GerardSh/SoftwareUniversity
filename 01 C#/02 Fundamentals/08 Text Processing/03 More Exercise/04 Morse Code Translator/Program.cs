using System.Text;

string input = Console.ReadLine();

string[] morseCode = input
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

StringBuilder decodedTransmission = new StringBuilder();

foreach (string letter in morseCode)
{
    if (letter == ".-")
    {
        decodedTransmission.Append('A');
    }
    else if (letter == "-...")
    {
        decodedTransmission.Append('B');
    }
    else if (letter == "-.-.")
    {
        decodedTransmission.Append('C');
    }
    else if (letter == "-..")
    {
        decodedTransmission.Append('D');
    }
    else if (letter == ".")
    {
        decodedTransmission.Append('E');
    }
    else if (letter == "..-.")
    {
        decodedTransmission.Append('F');
    }
    else if (letter == "--.")
    {
        decodedTransmission.Append('G');
    }
    else if (letter == "....")
    {
        decodedTransmission.Append('H');
    }
    else if (letter == "..")
    {
        decodedTransmission.Append('I');
    }
    else if (letter == ".---")
    {
        decodedTransmission.Append('J');
    }
    else if (letter == "-.-")
    {
        decodedTransmission.Append('K');
    }
    else if (letter == ".-..")
    {
        decodedTransmission.Append('L');
    }
    else if (letter == "--")
    {
        decodedTransmission.Append('M');
    }
    else if (letter == "-.")
    {
        decodedTransmission.Append('N');
    }
    else if (letter == "---")
    {
        decodedTransmission.Append('O');
    }
    else if (letter == ".--.")
    {
        decodedTransmission.Append('P');
    }
    else if (letter == "--.-")
    {
        decodedTransmission.Append('Q');
    }
    else if (letter == ".-.")
    {
        decodedTransmission.Append('R');
    }
    else if (letter == "...")
    {
        decodedTransmission.Append('S');
    }
    else if (letter == "-")
    {
        decodedTransmission.Append('T');
    }
    else if (letter == "..-")
    {
        decodedTransmission.Append('U');
    }
    else if (letter == "...-")
    {
        decodedTransmission.Append('V');
    }
    else if (letter == ".--")
    {
        decodedTransmission.Append('W');
    }
    else if (letter == "-..-")
    {
        decodedTransmission.Append('X');
    }
    else if (letter == "-.--")
    {
        decodedTransmission.Append('Y');
    }
    else if (letter == "--..")
    {
        decodedTransmission.Append('Z');
    }
    else
    {
        decodedTransmission.Append(" ");
    }
}

Console.WriteLine(decodedTransmission);






//2
using System.Text;

Dictionary<string, string> morseAlphabet = new Dictionary<string, string>()
{
                                       { ".-"   ,"A"},
                                       { "-..." ,"B"},
                                       { "-.-." ,"C"},
                                       { "-.."  ,"D"},
                                       { "."    ,"E"},
                                       { "..-." ,"F"},
                                       { "--."  ,"G"},
                                       { "...." ,"H"},
                                       { ".."   ,"I"},
                                       { ".---" ,"J"},
                                       { "-.-"  ,"K"},
                                       { ".-.." ,"L"},
                                       { "--"   ,"M"},
                                       { "-."   ,"N"},
                                       { "---"  ,"O"},
                                       { ".--." ,"P"},
                                       { "--.-" ,"Q"},
                                       { ".-."  ,"R"},
                                       { "..."  ,"S"},
                                       { "-"    ,"T"},
                                       { "..-"  ,"U"},
                                       { "...-" ,"V"},
                                       { ".--"  ,"W"},
                                       { "-..-" ,"X"},
                                       { "-.--" ,"Y"},
                                       { "--.." ,"Z"},
                                       { "-----","0"},
                                       { ".----","1"},
                                       { "..---","2"},
                                       { "...--","3"},
                                       { "....-","4"},
                                       { ".....","5"},
                                       { "-....","6"},
                                       { "--...","7"},
                                       { "---..","8"},
                                       { "----.","9"}
};

string[] letters = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

var decodedTransmission = new StringBuilder();

foreach (string s in letters)
{
    if (s == "|")
    {
        decodedTransmission.Append(" ");
    }
    else
    {
        decodedTransmission.Append(morseAlphabet[s]);
    }
}

Console.WriteLine(decodedTransmission);