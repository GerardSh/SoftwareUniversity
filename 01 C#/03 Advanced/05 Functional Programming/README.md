# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#LINQ)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#LINQ)



Функционалното програмиране е парадигма(концепция / списък от възможности) и има много функционални езици като LISP, F#, Haskell и други, които са фокусирани върху този тип програмиране.

C# включва много парадигми едновременно - многонишковост, функционално програмиране, data-driven, OOП и тн. 

При императивните езици като C#, които следва приложното програмиране като подход, казваме как да се случат нещата, стъпка по стъпка.

При декларативни  езици като HTML, SQL и други, при тях казваме искаме дадено нещо и го получаваме, без да има нужда да казваме как да го направи. Regex-a също е декларативен. 

При ООП имаме наследяване, полиморфизъм, интерфейси, exceptions и други правила и под парадигми, които комбинирани правят парадигмата ООП.

Функцията се използва за ситуациите в които имаме метод, който има входни параметри, връща резултат, но вътре в себе си не променя нищо от външния свят - не пише по файлове, не пише по конзолата и тн. Работи само с данните, които сме му дали и връща резултат спрямо тях. Всичките данни с които работим са immutable - не могат да се променят. Нещата в ламбда функциите са много ограничени, но с цел бързодействие.
Резултата е винаги един и същи, при подадени еднакви параметри, това се нарича deterministic.

Една функция може да бъде от два типа:

**First-Class**
Приема обикновени параметри тип int double и тн.

**Higher-Order**
Приемат като параметър други функции. Всяка една функция, може да бъде присвоена на променлива, която може да бъде подавана на функции.

Във функционалното програмиране, няма while и for цикли, ползва се рекурсия. Не може да се променят и стойностите на променливите. Това не важи за C# а само за функционалните езици за програмиране.

**DELEGATES**

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240425171446.png)

Тип данни в програмирането, който отговаря на дадена функция, наричаме делегат, тоест самото описание / signature-a на функцията.
С други думи, делегатите в C# представляват типове, които описват сигнатурата на метод. Те се използват за представяне на методи като обекти и позволяват гъвкаво използване на функции като параметри, резултати и други. Можем да си направим собствен делегат, тоест декларираме тип данни, който описва функции, това е полезно, ако искаме да дадем име на конкретен тип функция с определен signature:

```
delegate bool Predicate(int a);

Predicate name = x => x % 2 == 0;
```

Реално `Func<>` и `Action<>` са вече декларирани делегати, нещо като shortcuts, които ние използваме на готово.

Можем да създаваме променливи от тип `Func<>`, които приемат като стойност метод, ако имат еднакъв signature, тоест ако приемат еднакъв брой аргументи и са от еднакъв тип и връщат еднакъв тип данни.

```
Func<int,int,long> funcExample = Sum;

Console.WriteLine(funcExample(5, 4));

funcExample = (x, b) => x * b;

Console.WriteLine(funcExample(5, 4));

 static long Sum(int a, int b)
{
    return a + b;
}
```

При декларирането на функцията, първите типове данни са какви аргументи трябва да се подадат, а последния тип е какво трябва да връща. В примера, `funcExample` приема два int-a и връща long. Понеже имат еднакъв signature с метода Sum, то няма проблем да присвоим като стойност на функцията `funcMethod`, метода `Sum`. Можем също и директно да зададем тялото на функцията видно от примера. 

Една от ползите на `Func<>` е че може да присвояваме нови стойности, без да се налага да създаваме отделни методи. Примерно вместо да създаваме два отделни метода, които приемат две числа и връщат резултата, като в първия метод ще търсим техния сбор а във втория ще ги умножим, може да имаме само една функция и динамично да й променяме тялото както в примера.

Силата на `Func<>` е че може да имаме метод, който получава `Func<>` като параметър. При всяко извикване на метода, ние може да дефинираме различно тяло на `Func<>`. Това позволява на кода да бъде по-гъвкав и лесно променяем, тъй като можем да променяме поведението на метода, който приема `Func<>`, без да променяме неговата имплементация. Може вместо да пишем lambda израз, да подадем друг метод, който има същия signature, като `Func<>` в метода. Примерно: 

```
string numbers = "1 2 3 4";

int[] numbersArray = numbers.Split().Select(int.Parse).ToArray();

int number = int.Parse("5");
```

Може да видим че `Select()` метода очаква метод със signature приемащ string стойност и връщащ int стойност. Точно такъв метод е `int.Parse()` и затова може да го подадем на функцията която е параметър с името selector в метода `Select()`. След като сме подали `int.Parse`, когато някъде в тялото на метода `Select()` се извиква функцията `selector`, ще се изпълнява `int.Parse` вместо нея.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240425120628.png)

С други думи, това е равносилно като да дефинираме `Func<>` който е равен  на `int.Parse`, след което функцията `selector`, ще бъде равна на метода `int.Parse()`.

```
Func<string,int> selector = int.Parse;
int number = selector("5");
```

Именно така ламбда изразите се използват в LINQ, като позволяват динамично дефиниране на функции за обработка на данни в колекции. Всички методи в LINQ приемат друга функция. Така може да се напише кратък и ясен код, който е лесен за разбиране и поддръжка.

`Action<>` е същото като `Func<>` само че за void функции.

В C# всеки един метод, който връща един return оператор, може да го опростим и напишем по следния начин:

`static bool EvenNumbers(int x) => x % 2 == 0;`

Заедно с `Func<>` и `Action<>` има също и предефиниран signature делегат `Predicate<>`, който приема само един аргумент и връща bool, примерно - `Predicate<int> predicate = x => x == 5;`

**LAMBDA EXPRESSIONS**

Това е анонимна функция, която може да се декларира и използва директно.

`intList.Where((int x) => x % 2 == 0)` - може да се съкрати до:

`intList.Where(x => x % 2 == 0)` - защото функцията може да се сети какъв е типа данни от данните, които са в списъка, в случая имаме лист от int.

Израза е разделен на две части от ляво на => където имаме подадените параметри и от дясно където е тялото на функцията. Lambda оператора => означава goes to.

Тези функции са много удобни, защото няма нужда всеки път когато полазваме метод на LINQ да създаваме метод, да му даваме име и тн, а просто създаваме анонимна функция, с конкретните цели, които имаме в дадения момент.

Анонимната функция, може да я напишем и като нормален метод със скоби за по сложни изчисления, но тогава трябва да използваме и return.

```
intList.Where(x =>
{
    x += 5;
    return x % 2 == 0;
});
```

Ако имаме няколко параметъра, трябва да ги сложим в скоби. 

Ако нямаме параметри, трябва да сложим празни скоби:

```
PrintText(() => Console.WriteLine("test"));

static void PrintText(Action func)
{
    func();
}
```

Семпла репрезентация, как работи LINQ метода Where:

```
class Program
{
    static List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

    static void Main()
    {
        List<int> newList = Where(x => x % 2 == 0);
    }

    static List<int> Where(Func<int, bool> predicate)
    {
        List<int> newList = new List<int>();

        foreach (int number in numbers)
        {
            if (predicate(number))
            {
                newList.Add(number);
            }
        }

        return newList;
    }
}
```

Предикат е функция, която връща bool, независимо какви параметри получава.

**LINQ - Language Integrated Query**
 Това е библиотека, списък от методи в C#, които може да прилагаме върху колекции и бази данни.

Имаме агрегиращи методи, тоест взимат всички елементи и ги смачкват до един единствен елемент. Това са `Sum(), Count(), Average()` и тн.
# Misc

# ChatGPT
## Delegates
Може вместо да пишем lambda израз, да подадем друг метод, който има същия signature, като `Func<>` в метода. Примерно: 

```
 string numbers = "1 2 3 4"; 
 int[] numbersArray = numbers.Split().Select(int.Parse).ToArray(); 
 int number = int.Parse("5"); 
```

Може да видим че `Select()` метода очаква метод със signature приемащ string стойност и връщащ int стойност. Точно такъв метод е `int.Parse()` и затова може да го подадем на функцията която е параметър с името selector в метода `Select()`.

ChatGPT
Да, точно така! Вашето наблюдение е правилно. В C# може да подадете метод като параметър на друг метод, ако той има същия сигнатурен тип (т.е. приема същите типове аргументи и връща същия тип). Това се нарича "предаване на метод по референция" или "делегиране на метод".

Във вашия пример, `Select()` методът очаква метод, който приема `string` и връща `int`. `int.Parse()` има същата сигнатура, поради което може да бъде подаден като параметър на `Select()`. Това е един от начините, по които можем да използваме гъвкавостта на делегатите в C# за подаване на методи като аргументи. Такива сценарии правят кода по-четим и удобен за поддръжка.

You
Tова е все едно да кажем `Func<int,string> func = int.Parse;` ?

ChatGPT
Да, точно така! Когато използвате `int.Parse` в контекста на `Func<int, string>`, това е същото като да кажете:

`Func<string, int> func = int.Parse;`

Тук `int.Parse` съвпада със сигнатурата на делегата `Func<string, int>`, който приема цяло число и връща низ. По този начин можете да използвате `int.Parse` като аргумент за всяка функция или метод, който изисква `Func<string, int>`.

Това е прекрасен пример за използване на делегати за предаване на методи като параметри, което води до по-гъвкав и четим код.

You
Declaring delegates in C# is like declaring classes?

ChatGPT
In C#, declaring delegates is similar to declaring a class, but delegates are used to define method signatures rather than defining data and behavior like classes do.

When you declare a delegate in C#, you're essentially defining a type that can reference methods with a specific signature. This allows you to treat methods as first-class citizens, passing them around as parameters, storing them in variables, and invoking them dynamically.

Here's a basic example of declaring a delegate:
```
// Define a delegate type
public delegate void MyDelegate(string message);

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the delegate
        MyDelegate delegateInstance = new MyDelegate(PrintMessage);

        // Invoke the delegate
        delegateInstance("Hello, world!");
    }

    // Method that matches the delegate signature
    static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}

```

In this example, `MyDelegate` is declared similar to how you would declare a class. It defines a delegate type that can reference methods taking a single string parameter and returning void. Then, an instance of this delegate is created and assigned to reference the `PrintMessage` method. Finally, the delegate is invoked, which in turn calls the `PrintMessage` method.

So, while delegates are defined in a similar syntax to classes, they serve a different purpose: to define method signatures that can be referenced and invoked dynamically.

You
If we have to mimic how `Func<>` works with creating our own delegate signatures, we have to create many such delegates for various inputs and outputs?

ChatGPT
Yes, if you want to mimic the behavior of `Func<>` with your own delegate signatures, you would need to define multiple delegate types for various combinations of input parameters and return types. This could lead to a lot of repetitive code, especially if you have many different method signatures.

For example, if you have methods with signatures like:

```
int Method1(int a, int b)
double Method2(string x)
string Method3(bool flag)
```

You would need to define custom delegates for each of these method signatures, like this:

```
public delegate int Method1Delegate(int a, int b);
public delegate double Method2Delegate(string x);
public delegate string Method3Delegate(bool flag);
```

Then, you could use these delegate types similarly to how you use `Func<>`:

```
Method1Delegate method1 = (a, b) => a + b;
int result1 = method1(3, 5);

Method2Delegate method2 = x => double.Parse(x);
double result2 = method2("3.14");

Method3Delegate method3 = flag => flag ? "True" : "False";
string result3 = method3(true);

```

However, this approach can become cumbersome and less maintainable as the number of different method signatures grows. This is why `Func<>` and `Action<>` delegates are provided as part of the .NET framework—they offer a convenient and generic way to define delegates for a wide range of method signatures without needing to define custom delegates for each one.
# Bookmarks 
[Tech Stage: Функционално програмиране за писане на устойчив и четим код - YouTube - Владимир Милев](https://www.youtube.com/watch?v=PCVsd4pBurg)
[C# Tips and Tricks - YouTube - Николай Костов](https://www.youtube.com/watch?v=VOIczWVQ3gg)

Course completion: 27.04.2024
