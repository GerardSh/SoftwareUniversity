int n = int.Parse(Console.ReadLine());

Queue<string> cars = new Queue<string>();
int carsCount = 0;

string input = "";

while ((input = Console.ReadLine()) != "end")
{
    if (input == "green")
    {
        for (int i = 0; i < n; i++)
        {
            if (cars.Count > 0)
            {
                Console.WriteLine(cars.Dequeue() + " passed!");
                carsCount++;
            }
            else
            {
                break;
            }
        }
    }
    else
    {
        cars.Enqueue(input);
    }
}

Console.WriteLine($"{carsCount} cars passed the crossroads.");