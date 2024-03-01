string bookName = Console.ReadLine();
string books = Console.ReadLine();
int booksNumber = 0;

while (books != "No More Books")
{

    if (books == bookName)
    {
        break;
    }
    booksNumber++;
    books = Console.ReadLine();
}

if (books == "No More Books")
{
    Console.WriteLine($"The book you search is not here!");
    Console.WriteLine($"You checked {booksNumber} books.");
}
else
{
    Console.WriteLine($"You checked {booksNumber} books and found it.");
}