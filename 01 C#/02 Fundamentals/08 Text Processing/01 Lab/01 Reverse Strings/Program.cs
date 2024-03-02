string input;

while ((input = Console.ReadLine()) != "end")
{
    string reversedInput = string.Concat(input.Reverse());

    Console.WriteLine(input + " = " + reversedInput);
}
