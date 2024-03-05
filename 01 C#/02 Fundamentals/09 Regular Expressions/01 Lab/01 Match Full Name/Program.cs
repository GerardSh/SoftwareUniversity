using System.Text.RegularExpressions;
string names = Console.ReadLine();

var matches = Regex.Matches(names, @"\b[A-Z][a-z]+ [A-Z][a-z]+");

Console.Write(string.Join(" ", matches));