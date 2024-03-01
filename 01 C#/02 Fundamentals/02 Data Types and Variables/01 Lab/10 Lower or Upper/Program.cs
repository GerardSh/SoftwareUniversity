char a = char.Parse(Console.ReadLine());

if (a >= 65 && a <= ((int)0x5A))
{
    Console.WriteLine("upper-case");
}
else
{
    Console.WriteLine("lower-case");
}