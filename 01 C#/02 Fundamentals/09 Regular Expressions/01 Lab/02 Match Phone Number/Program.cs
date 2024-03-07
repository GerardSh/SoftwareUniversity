using System;
using System.Text.RegularExpressions;

string numbers = Console.ReadLine();

MatchCollection matches = Regex.Matches(numbers, @"\+359( |-)2\1\d{3}\1\d{4}\b");

Console.WriteLine(string.Join(", ", matches));