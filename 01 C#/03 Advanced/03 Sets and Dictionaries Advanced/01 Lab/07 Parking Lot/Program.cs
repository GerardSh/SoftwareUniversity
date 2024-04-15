HashSet<string> parkingLot = new HashSet<string>();

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] elements = input
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string command = elements[0];
    string carNumber = elements[1];

    if (command == "IN")
    {
        parkingLot.Add(carNumber);
    }
    else
    {
        parkingLot.Remove(carNumber);
    }
}

if (parkingLot.Count > 0)
{
    Console.WriteLine(string.Join("\n", parkingLot));
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}