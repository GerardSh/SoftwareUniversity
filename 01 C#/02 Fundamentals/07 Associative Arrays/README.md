# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#Associative)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#Dictionaries)

JSON е един от най-разпространените формати за обмяна на данни в web приложенията писани на различни езици и реално представлява асоциативен масив. Той съдържа колекция от KVP - key value pair стойности. Достъпа до елементите в този масив не става чрез индекси, а чрез ключове. Тези ключове обикновено са текст, но може да бъдат всичко, включително числа. Ако са числа, то реално си става нормален масив. Имаме свободата да избираме какви са индексите.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240214142906.png)

В едно dictionary ключовете трябва да са от еднакъв тип, стойностите може да са друг тип но пак трябва да са еднакви.
Всички ключове трябва да са уникални и трябва да се подържат в реда в който са добавени.
Използва се hash-table + list за да се намират бързо елементи.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240214143729.png)

Имаме и SortedDictionary което пази елементите не в реда който сме ги вкарали, но сортирани по ключове.
Използва балансирано дърво за търсене за да подрежда ключовете.
Когато някой метод е generic, означава че може да работи с различни типове.

## Lambda Functions
Анонимна функция, която се ползва много често в LINQ.

Lambda expression:
`a => a > 5`
Реално макар и да не се вижда, винаги има все едно return, който ще върне израза горе.

Знака => означава goes to и разделя параметрите на функцията от резултата.
Водят се inline methods защото там където ги ползваме, там ги и дефинираме, а не на отделно място.
Може да имаме и по сложно изписване на lambda-та, но трябва да добавим къдрави скоби и да сложим return:
```
string[] array = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(x =>
    {
        int test = 5;
        return x.Length % 2 + test == 0;
    }
    )
    .ToArray();
```
Когато няма параметри или параметрите са повече от един, трябва да сложим скоби:
`() => 42`
`(x, z) => x * z`

Примерно и опростено представяне на LINQ Select метода:
```
int[] arr = { 1, 2, 3 };
arr = Select(arr, IntManipulator);

static int[] Select(int[] array, Func<int, int> Selector)
{
    int[] newArr = new int[array.Length];

    for (int i = 0; i < array.Length; i++)
    {
        newArr[i] = Selector(array[i]);
    }

    return newArr;
}

static int IntManipulator(int x)
{
    return x * 2;
}
```
На мястото на анонимната функция, може да сложим друг метод със същия signature, тоест ако функцията очаква да вземе int и да върне int, трябва да се подаде такъв метод.
Важното е да запомним, че анонимната функция бива извиквана вътре в метода и предимството е че имаме възможност да променяме логиката й динамично, а не е hard code-ната както в примера долу, където винаги имаме една и съща манипулация.
```
int[] arr = { 1, 2, 3 };
arr = Select(arr);

static int[] Select(int[] array)
{

    int[] newArr = new int[array.Length];

    for (int i = 0; i < array.Length; i++)
    {
        newArr[i] = IntManipulator(array[i]);
    }

    return newArr;
}

static int IntManipulator(int x)
{
    return x * 2;
}
```
## LINQ
Обикновено връща колекция във вида [IEnumerable](https://github.com/GerardSh/SoftwareUniversity/tree/main/01%20C%23/02%20Fundamentals/07%20Associative%20Arrays#readme#ChatGPT##LINQ), което е колекция, върху която може да бъде изпълнен foreach, но не е ясно каква колекция точно. Реално единственото нещо което може да правим с такава колекция е да я foreach-ваме.
Ако ползваме примерно Where метод-а и няма нито един елемент който да отговаря на филтъра, то пак ще получим колекция от 0 елемента.
# Misc
Елементите на Dictionary масивите, са KeyValuePair и спокойно може да направим следното:
`KeyValuePair<int, int> kVp = new KeyValuePair<int, int>(5, 3);`

Когато като стойност имаме втори масив или обект, то трябва да ги инициализираме със създаването на ключа, като тази стойност може да бъде `null`.

Споделените речници, са речници, които имат еднакви ключове, но различни стойности.

`dictionary.Keys.Contains(search by key type)` - може да търсим сред всичките ключове или стойности, равносилно на:
``dictionary.ContainsKey(search by key type)``
`FirstOrDeffault(optional predicate)` - може да намерим, кой е дадения key на определена стойност.

Когато достъпим дадено dictionary чрез .Keys или .Values, реално почваме да търсим само сред тези стойности и ако ползваме метод който връща елемент, то той няма да върне kvp, но ще върне елемент от типа на Keys или Values, според зависи къде търсим. В примера долу, x се явява key и върнатия резултат зависи какво стои зад First метода, в случая е key който е от типа стринг:
```
            var test = new Dictionary<string, int>()
            {
                {"test",2}
            };

            Console.WriteLine(test.Keys.First(x => x == "test"));
```
Върнатия резултат ще е kvp:
```
            var test = new Dictionary<string, int>()
            {
                {"test",2}
            };

            Console.WriteLine(test.First(x => x.Key == "test"));
```
Това важи и за foreach, където item ще бъде всяко едно от стойностите записани в речника:
```
       foreach (var item in test.Values)
            {
                Console.WriteLine(item);
            }
```
Реално когато ползваме .Values или .Keys properties то това връща колекция само с даденото пропърти и освен че може да foreach-нем може и да я запишем в списък или масив.
Когато работим с Dictionaries имаме три възможности за итерация - едната е по стойности, втората по ключове и трета е и по двете, в зависимост какво търсим.

Това е друг възможен начин да добавяме елемент, освен чрез Add метода:
```
  if (!gradesByStudents.ContainsKey(name))
    {
        gradesByStudents[name] = 0;
    }
```

С курсора на мишката върху даден елемент може да видим с какво value и key е:
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240220171053.png)

Можем да ползваме като Key - KeyValuePair, това е много подходящо, когато имаме проблем със сортирането, както в задача 04. Snowwhite, където решение 5 е с такъв подход.
`var dwarfs = new Dictionary<KeyValuePair<string, string>, int>();`

Тернарен оператор има три операнда - bool expression ? if true do something : else do something
# ChatGPT
## Generic methods:
In C#, you can have both generic methods and methods that are specific to certain types.

1. **Generic Methods:**
    
    - Generic methods are methods that can work with different types without specifying the actual type until the method is called.
    - They are defined with one or more type parameters, allowing the method to operate on a wide range of types.
    - Example of a generic method:
        
        csharpCopy code
        
        `public T GetMax<T>(T x, T y) where T : IComparable<T> {     return x.CompareTo(y) > 0 ? x : y; }`
        
    - In the example above, `T` is a type parameter, and the method can be used with different types that implement the `IComparable<T>` interface.
2. **Type-Specific Methods:**
    
    - Type-specific methods are methods that operate on a specific type or a set of related types.
    - They are defined with a fixed type or set of types, and the method can only be used with those specific types.
    - Example of a type-specific method:
        
        csharpCopy code
        
        `public int Square(int x) {     return x * x; }`
        
    - In this example, the `Square` method specifically works with integers.

Both generic methods and type-specific methods have their use cases. Generic methods provide flexibility and code reuse across different types, while type-specific methods may offer more specialized behavior for a particular type or set of types. The choice between them depends on the requirements of your code and the level of abstraction you need.
## Values and Keys properties
The properties values and keys returns a collection and that's why we have to iterate over them to check the exact values?

Exactly, the `Keys` and `Values` properties of a dictionary return collections (specifically, `KeyCollection` and `ValueCollection`), and if you want to work with the individual keys or values, you generally need to iterate over them using a loop, such as a `foreach` loop.
## LINQ
`IEnumerable` is an interface in C# that represents a collection of objects that can be enumerated (iterated) one at a time. It is part of the `System.Collections` namespace.
## Using LINQ with for nested Dictionaries
```
// How to get the sum of two nested dictionaries.
x => x.Value.Values.Sum(innerDict => innerDict.Values.Sum())
```
I understand now why we need to sum after the first values, and then use sum again. Its because the middle dictionary can have more elements each containing its version of the inner dictionary.

ChatGPT

Exactly! Your understanding is spot on. The nested structure of dictionaries means that you have to navigate through multiple levels to reach the innermost values. The first `Sum` is used to calculate the sum of values within each middle dictionary, and the second `Sum` then calculates the sum of those sums across all middle dictionaries for a given outer dictionary.

This approach is flexible and works well for nested structures where each level may have a variable number of elements. It allows you to aggregate values at different levels of nesting, and the use of `Sum` makes it easy to perform the necessary calculations in a concise manner.

If you have any more questions or if there's anything else you'd like clarification on, feel free to ask!

# Bookmarks 
Course completed: 23.02.2023
