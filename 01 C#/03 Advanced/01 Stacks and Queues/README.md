# General
[Methods Stack](01%20Methods.md#Stack)

[Methods Queue](01%20Methods.md#Queue)

[Commands Stack](02%20Commands.md#Stack)

[Commands Queue](02%20Commands.md#Queue)

При линейните структури от данни каквито са списъците и масивът, елементите са разположени последователно, като всеки елемент при тях е и индексиран/номериран. 

Новите линейни структури от данни в тази лекция са:
`Stack<t>` - (LIFO - last in, first out) - аналогията е на купчина чинии една върху друга, когато започнем да ги махаме, почваме от последната.
`Queue<t>` - (FIFO - first in, first out) - който дойде първи на опашката, първи ще бъде обслужен и ще си тръгне.

При стековете и опашките последователността на елементите не е толкова важна, там е важно кой елемент е влезнал последен и кой първи.
При тях пак добавяме елементите най-отзад, но при стековете нямаме достъп до предишните елементи, а само до последните, при опашките имаме достъп само до първия елемент, но не и следващите.
Това е и основната разлика със списъците, като реално стековете и опашките имат по-малко операции, но пък се извършват бързо Добавянето и махането на елементи е в точно определен ред, но е много бързо.

Вкарване на елемент при стека се нарича Push, махането е Pop, при опашката се нарича Enqueue, махането Dequeue.

Компютърната памет, също е разположена линейно, като един огромен масив и си има последователност и номерация, точно както масива, като част от него, се заделя за нашата програма.

Идемпотентна операция е тези която колкото и пъти да направим, не променя резултата си. Нещата отдолу имат логика която ползваме, те извикват друга логика и така до най-ниско ниво. Примерно ако ползваме open file което е специален метов в C#, а той извиква специален метод от операционната система Win32, който извиква специален метод от драйвера за файловата система, който на ниско ниво слиза и казва на хард диска какво да направи. Затова се нарича абстракция, пишейки на C# работим на почти най-високото ниво и нещата отдолу са вече готови, написани и проверени. Ако трябва да напишем от нула отварянето на файл, ще стане с хиляди редове, а не с един.
# Misc
Всяко нещо което може да бъде направено чрез рекурсия, може да бъде постигнато и чрез стек.

Кода който пишем в C# е на високо ниво, тоест стъпваме на готов код, който вече е написан.

C# е стек-ов език. 

Масива е базова структура, която представлява последователност от адреси в паметта на компютъра.

IEnumerable е интерфейс - който ни казва, какво може да прави дадената колекция. В дадения случай, означава че може да бъде foreach-ната. Можем да проверим дадена колекция, какви интерфейси имплементира в документацията, примерно Stack - [Stack Class (System.Collections.Generic) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-8.0)

foreach е най-лесния начин да проверим стойностите на елементите в даден стек или опашка.

Разликата между Generic collection  като `Stack<T>` и просто `Stack` е че в Generic ние определяме типа на колекцията на мястото на `<T>` , докато Non-Generic е от тип object. Всички типове в C# наследяват object, но това не е удобно за работа когато ползваме колекция. Компилатора, не може да проверява грешките, които може да допуснем и доста други усложнения. MS препоръчват да се ползват само generic collections.
# ChatGPT
## Stack indexing
Isn't it more logical and natural that the last added element in the stack is residing on the last index in the internal array not the first 0?

ChatGPT
Yes, you're correct in the logical sense. Placing the most recently added element at the end of the internal array for a stack would align more with the natural flow of adding elements to a stack. Similarly, for a queue, it would make sense to have the first element added at the beginning of the internal array and subsequent elements placed further towards the end.

However, the choice of implementation details, including the arrangement of elements within the internal array, can vary based on factors such as performance considerations, memory management, and ease of implementation. In some implementations, it may be more efficient to manage the internal array in a way that the most recently added element is at index 0 for a stack or at the end for a queue.

While it might seem more intuitive to have the last added element at the end of the array, the choice of internal representation doesn't affect the external behavior of the stack or queue as long as the required operations (`Push`, `Pop` for `Stack`; `Enqueue`, `Dequeue` for `Queue`) are provided and work as expected.
## T[] array
what is t[] array in C#

ChatGPT
In C#, `T[]` represents a generic array type where `T` is a placeholder for any valid C# data type. This notation allows you to define arrays that can hold elements of a specific type, which can be specified when declaring or creating the array.
# Bookmarks 
Два много основополагащи курса на Николай Костов:
[High-Quality Code - YouTube](https://www.youtube.com/playlist?list=PLf5IBVXYNTwJO9dE-XR9-iKbp_kw3_ZQy)
[Data Structures and Algorithms - YouTube](https://www.youtube.com/playlist?list=PLf5IBVXYNTwLwDCbpFtQLj1_587a3asv5)
Web Basics курс:
[C# Web Basics - Workshop - Web Application. Advanced CSS - Bootstrap - май 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=iG2UBr2fAqg&list=PLg6sCysjxHi2V49e08g5UPLTME8MOzRsc&index=1)
Полезна лекция как работи интернет, пак на Николай Костов:
[Internet Explained - YouTube](https://www.youtube.com/watch?v=1pSsIlU3T-s)
Бонус задача от текущата лекция:
[Бонус: Решаване на математически изрази със стекове - Софтуерен университет](https://softuni.bg/trainings/resources/video/64613/bonus-evaluate-math-expressions-using-stacks-csharp-advanced-september-2021/3483)
[Решаване на математически изрази със C# - YouTube](https://www.youtube.com/watch?v=3QOM0HJmakE&t=2s)
# Home work
### Lab
1. Reverse a String
```
string input = Console.ReadLine();

Stack<char> stack = new Stack<char>();

foreach (char c in input)
{
    stack.Push(c);
}

while (stack.Count > 0)
{
    Console.Write(stack.Pop()); 
}
```
2. Stack Sum
```
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Stack<int> stack = new Stack<int>();

foreach (int number in numbers)
{
    stack.Push(number);
}

string input;

while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] commands = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];

    if (command == "add")
    {
        stack.Push(int.Parse(commands[1]));
        stack.Push(int.Parse(commands[2]));
    }
    else
    {
        int number = int.Parse(commands[1]);

        if (stack.Count >= number)
        {
            while (number > 0)
            {
                number--;
                stack.Pop();
            }
        }
    }
}

Console.WriteLine("Sum: " + stack.Sum());
```
3. Simple Calculator
```
string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Stack<string> stack = new Stack<string>();

foreach (string number in numbers)
{
    stack.Push(number);
}

int sum = 0;

while (stack.Count > 0)
{
    int lastNumber = int.Parse(stack.Pop());

    if (stack.Count > 0 && stack.Pop() == "-")
    {
        lastNumber *= -1;
    }
    
    sum += lastNumber;
}

Console.WriteLine(sum);
```
4. Matching Brackets
```
string input = Console.ReadLine();

Stack<int> stack = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{
    
    if (input[i] == '(')
    {
        stack.Push(i);
    }

    if (input[i] == ')')
    {
        int startIndx = stack.Pop();
        int count = i - startIndx + 1;

        Console.WriteLine(input.Substring(startIndx,count));
    }
}
```
5. Print Even Numbers
```
using System.Text;

Queue<int> numbers = new Queue<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

while (numbers.Count > 0)
{
    if (numbers.Peek() % 2 == 0 )
    {
        if (numbers.Count > 1)
        {
            Console.Write(numbers.Dequeue() + ", ");
        }
        else
        {
            Console.Write(numbers.Dequeue());
        }
    }
    else
    {
        numbers.Dequeue();
    }
}
```
6. Supermarket
```
string input;
Queue<string> customers = new Queue<string>();

while ((input = Console.ReadLine()) != "End")
{
    if (input == "Paid")
    {
        while (customers.Count > 0)
        {
            Console.WriteLine(customers.Dequeue());
        }
    }
    else
    {
        customers.Enqueue(input);
    }
}

Console.WriteLine($"{customers.Count()} people remaining.");
```
7. Hot Potato
```
Queue<string> names = new Queue<string>(Console.ReadLine().Split());
int rotations = int.Parse(Console.ReadLine());

while (names.Count > 1)
{
    for (int i = 1; i <= rotations; i++)
    {
        if (i == rotations)
        {
            Console.WriteLine($"Removed {names.Dequeue()}");
        }
        else
        {
            names.Enqueue(names.Dequeue());
        }
    }
}

Console.WriteLine("Last is " + names.Dequeue());




//2 with List
List<string> names = Console.ReadLine().Split().ToList();
int n = int.Parse(Console.ReadLine());
int index = 0;

while (names.Count > 1)
{
    for (int i = 0; i < n - 1; i++)
    {
        if (index >= names.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }

    Console.WriteLine("Removed " + names[index]);

    names.Remove(names[index]);

    if (index == names.Count)
    {     
        index = 0;
    }
}

Console.WriteLine("Last is " + names[0]);
```
8. Traffic Jam
```
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
```
### Exercises 
01. Basic Stack Operations
```
int[] initialNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = initialNumbers[0];
int s = initialNumbers[1];
int x = initialNumbers[2];

int[] numbersToAdd = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> numbers = new Stack<int>(numbersToAdd.Take(n));

for (int i = 0; i < s; i++)
{
    numbers.Pop();
}

if (numbers.Count > 0)
{
    if (numbers.Contains(x))
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine(numbers.Min());
    }
}
else
{
    Console.WriteLine(0);
}
```
02. Basic Queue Operations
```
int[] initialNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = initialNumbers[0];
int s = initialNumbers[1];
int x = initialNumbers[2];

int[] numbersToAdd = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> numbers = new Queue<int>(numbersToAdd.Take(n));

for (int i = 0; i < s; i++)
{
    numbers.Dequeue();
}

if (numbers.Count > 0)
{
    if (numbers.Contains(x))
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine(numbers.Min());
    }
}
else
{
    Console.WriteLine(0);
}
```
03. Maximum and Minimum Element
```
int n = int.Parse(Console.ReadLine());

Stack<int> stack = new Stack<int>(n);

for (int i = 0; i < n; i++)
{
    int[] elements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int command = elements[0];

    if (command == 1)
    {
        int numberToAdd = elements[1];

        stack.Push(numberToAdd);
    }
    else if (command == 2)
    {
        if (stack.Count > 0)
        {
            stack.Pop();
        }
    }
    else
    {
        if (stack.Count > 0)
        {
            Console.WriteLine(command == 3 ? stack.Max() : stack.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", stack));
```
04. Fast Food
```
int amountOfFood = int.Parse(Console.ReadLine());

Queue<int> orders = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Console.WriteLine(orders.Max());

while (orders.Count > 0 && amountOfFood > 0)
{
    if (orders.Peek() <= amountOfFood)
    {
        amountOfFood -= orders.Dequeue();
    }
    else
    {
        break;
    }
}

if (orders.Count > 0)
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
else
{
    Console.WriteLine("Orders complete");
}
```
05. Fashion Boutique
```
Stack<int> clothBox = new Stack<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

int rackCapacity = int.Parse(Console.ReadLine());
int currentRackSpace = 0;
int racksUsed = 0;

if (rackCapacity == 0)
{
    racksUsed = 0;
    return;
}
while (clothBox.Count > 0)
{
    currentRackSpace += clothBox.Peek();

    if (currentRackSpace > rackCapacity)
    {
        racksUsed++;
        currentRackSpace = clothBox.Pop();

        if (clothBox.Count == 0)
        {
            racksUsed++;
        }
    }
    else if (currentRackSpace == rackCapacity)
    {
        racksUsed++;
        currentRackSpace = 0;
        clothBox.Pop();
    }
    else
    {
        clothBox.Pop();

        if (clothBox.Count == 0)
        {
            racksUsed++;
        }
    }
}

Console.WriteLine(racksUsed);
```
06. Songs Queue
```
Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

while (songs.Count > 0)
{
    string command = Console.ReadLine();

    if (command=="Play")
    {
        songs.Dequeue();
    }
    else if (command.Contains("Add"))
    {
        string song = command.Substring(4);

        if (!songs.Contains(song))
        {
            songs.Enqueue(song);
        }
        else
        {
            Console.WriteLine($"{song} is already contained!");
        }
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}

Console.WriteLine("No more songs!");
```
07. Truck Tour
```
int n = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < n; i++)
{
    int[] elements = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    pumps.Enqueue(new int[] { elements[0], elements[1] });
}

Queue<int[]> pumpsOriginal = new Queue<int[]>(pumps);
int index = 0;
for (int i = 0; i < n; i++)
{
    int remainingFuel = pumps.Peek()[0] - pumps.Peek()[1];

    if (remainingFuel >= 0)
    {
        pumps.Dequeue();

        index = i;

        while (pumps.Count > 0)
        {
            remainingFuel += pumps.Peek()[0] - pumps.Peek()[1];

            if (remainingFuel >= 0)
            {
                pumps.Dequeue();
            }
            else
            {
                pumps = new Queue<int[]>(pumpsOriginal);

                for (int j = 0; j <= i; j++)
                {
                    pumps.Enqueue(pumps.Dequeue());
                }
                break;
            }
        }

        if (pumps.Count == 0)
        {
            break;
        }

        if (i == n - 1)
        {
            index = -1;
        }
    }
    else
    {
        pumps.Enqueue(pumps.Dequeue());
    }
}

Console.WriteLine(index);




//2
public class PetrolPump
{
    public PetrolPump(int fuel, int distance)
    {
        this.Fuel = fuel;
        this.Distance = distance;
    }

    public int Fuel { get; set; }
    public int Distance { get; set; }
}

class Program
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        Queue<PetrolPump> pumps = new Queue<PetrolPump>();

        for (int i = 0; i < n; i++)
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            pumps.Enqueue(new PetrolPump(elements[0], elements[1]));
        }

        int index = 0;

        for (int i = 0; i <= n; i++)
        {
            int fuel = 0;

            foreach (PetrolPump pump in pumps)
            {
                fuel += pump.Fuel - pump.Distance;

                if (fuel < 0)
                {
                    pumps.Enqueue(pumps.Dequeue());
                    break;
                }
            }

            if (fuel >= 0)
            {
                index = i;
                break;
            }
            else if (i == pumps.Count - 1)
            {
                index = -1;
                break;
            }
        }

        Console.WriteLine(index);
    }
}
```
08. Balanced Parenthesis
```
string input = Console.ReadLine();

if (input.Length % 2 != 0 || input.Length == 0)
{
    Console.WriteLine("NO");
    return;
}

Stack<char> stack = new Stack<char>();

bool isBalanced = true;

for (int i = 0; i < input.Length && isBalanced; i++)
{
    if (input[i] == '(' || input[i] == '[' || input[i] == '{')
    {
        stack.Push(input[i]);
    }
    else
    {
        if (stack.Count == 0
            || input[i] == ')' && stack.Pop() != '('
            || input[i] == ']' && stack.Pop() != '['
            || input[i] == '}' && stack.Pop() != '{')
        {
            isBalanced = false;
            break;
        }
    }
}

if (isBalanced)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}
```
09. Simple Text Editor
```
using System.Text;
using System.Text.RegularExpressions;

int numberOfOperations = int.Parse(Console.ReadLine());
StringBuilder text = new StringBuilder("");
Stack<string> textVersions = new Stack<string>();

for (int i = 0; i < numberOfOperations; i++)
{
    string[] elements = Regex.Split(Console.ReadLine(), @" ");

    int command = int.Parse(elements[0]);
    string arg = elements.Length > 1 ? elements[1] : null;

    if (command == 1)
    {
        string textToAdd = arg;

        textVersions.Push(text.ToString());
        text.Append(textToAdd);
    }
    else if (command == 2)
    {
        int elementsToDelete = int.Parse(arg);

        textVersions.Push(text.ToString());
        text.Remove(text.Length - elementsToDelete, elementsToDelete);

        //sec variant
        //while (elementsToDelete-- > 0)
        //{
        //    text.Remove(text.Length - 1, 1);
        //}
    }
    else if (command == 3)
    {
        int index = int.Parse(arg);

        if (index <= text.Length)
        {
            Console.WriteLine(text[index - 1]);
        }
    }
    else if (command == 4)
    {
        text = new StringBuilder(textVersions.Pop());
    }
}
```
10. Crossroads
```
int greenLight = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());

Queue<string> cars = new Queue<string>();
int passedCars = 0;

string input;

while ((input = Console.ReadLine()) != "END")
{
    string currentCar = input;

    if (currentCar != "green")
    {
        cars.Enqueue(currentCar);
    }
    else
    {
        int remainingSeconds = greenLight;
        while (remainingSeconds > 0 && cars.Count > 0)
        {
            string passingCar = cars.Dequeue();          
            remainingSeconds -= passingCar.Length;
            passedCars++;

            //needed for variant 2
            //int remainingSecondsOriginal = remainingSeconds;

            if (remainingSeconds + freeWindow < 0)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{passingCar} was hit at {passingCar[passingCar.Length - (remainingSeconds + freeWindow) * -1]}.");

                //variant 2
                //Console.WriteLine($"{passingCar} was hit at {passingCar[remainingSecondsOriginal + freeWindow]}.");

                return;
            }
        }
    }
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{passedCars} total cars passed the crossroads.");
```
11. Key Revolver
```
int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize =  int.Parse(Console.ReadLine());
Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
int intelligenceValue =  int.Parse(Console.ReadLine());

int bulletsCost = 0;
int firedBullets = 0;

while (locks.Count > 0 && bullets.Count > 0)
{
    int lockSize = locks.Peek();
    int bulletSize = bullets.Pop();
    bulletsCost += bulletPrice;

    if (lockSize >= bulletSize)
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    firedBullets++;

    if (firedBullets == gunBarrelSize)
    {
        if (bullets.Count > 0)
        {
            Console.WriteLine("Reloading!");
        }

        firedBullets = 0;
    }
}

if (locks.Count > 0)
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}
else
{
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - bulletsCost}");
}
```
12. Cups and Bottles
```
Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

int wastedLittersOfWater = 0;

while (cups.Count > 0 && bottles.Count > 0)
{
    int currentCup = cups.Dequeue() - bottles.Pop();

    if (currentCup <= 0)
    {
        wastedLittersOfWater += Math.Abs(currentCup);
    }
    else
    {
        while (bottles.Count > 0)
        {
            currentCup -= bottles.Pop();

            if (currentCup <= 0)
            {
                wastedLittersOfWater += Math.Abs(currentCup);
                break;
            }
        }
    }
}

if (cups.Count > 0)
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}
else
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}

Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
```

Course completion: 26.03.2024
