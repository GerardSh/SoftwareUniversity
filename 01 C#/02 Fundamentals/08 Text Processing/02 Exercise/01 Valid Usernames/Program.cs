string[] userNames = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

foreach (string userName in userNames)
{
    if (userName.Length >= 3 && userName.Length <= 16)
    {
        bool isValid = true;

        foreach (char c in userName)
        {
            if (!char.IsDigit(c) && !char.IsLetter(c) && c != '_' && c != '-')
            {
                isValid = false;
                break;
            }
        }

        if (isValid)
        {
            Console.WriteLine(userName);
        }
    }
}