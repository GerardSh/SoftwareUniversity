int number = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split();

Func<string, int, bool> calculateNameSum = (name, number) =>
{
    int sum = 0;

    foreach (var c in name)
    {
        sum += c;
    }

    return sum >= number;
};

Func<string[], Func<string, int, bool>, string> getFirstNameGreaterThanFilterNumber = (names, calculateNameSum) =>
{
    foreach (var name in names)
    {
        if (calculateNameSum(name, number))
        {
            return name;
        }
    }

    return "No name found";
};

Console.WriteLine(getFirstNameGreaterThanFilterNumber(names, calculateNameSum));




//2
int filterNumber = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split();

Func<string, int, bool> calculateNameSum = (name, filterNumber) => name.Sum(c => c) >= filterNumber;

Func<string[], int, Func<string, int, bool>, string> getFirstNameGreaterThanFilterNumber = (names, number, calculateNameSum) => names.FirstOrDefault(name => calculateNameSum(name, number));

Console.WriteLine(getFirstNameGreaterThanFilterNumber(names, filterNumber, calculateNameSum));