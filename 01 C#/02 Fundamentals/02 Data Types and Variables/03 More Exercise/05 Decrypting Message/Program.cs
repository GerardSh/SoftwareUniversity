int key = int.Parse(Console.ReadLine());
int wordLenght = int.Parse(Console.ReadLine());

for (int i = 0; i < wordLenght; i++)
{
    int currentChar = char.Parse(Console.ReadLine());

    Console.Write((char)(currentChar + key));
}