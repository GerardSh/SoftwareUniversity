# General

[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#List)
[Commands](02%20Commands.md#List)

Всеки един списък е масив, който ни дава разширена функционалност.
Данните на списъка, се пазят като масив в паметта на компютъра и трябва да се спазват всички правила. Списъка може да расте, за разлика от масива. 
Ако не укажем размер се създава масив от 0 елемента. В момента в който се опитаме да сложим данни в клетка която не съществува, C# ще създаде масив, който е 2 пъти по-голям. Ще изкопира наличните и ще почне да пълни новите клетки. Списъка е бавен, тогава когато се налага да расте. Когато имаме нужда от много бърза структура е по-добре да ползваме масив, но трябва да знаем размера му. Или да се направи списък с определения размер и пак ще имаме бърз достъп, но и възможност да расте, при нужда. В обобщение, списъка е масив, който може да расте, но порастването му е бавен процес в който се копира масива на ново място в паметта но с удвоен размер.

Списъците са generic структура, което означава че може да приема различни типове, тоест всички типове в C#. Държи само и единствено елементи от един тип.

Деклариране на списък:
`List<String> name = new List<string>();`

Чрез метода Add(), добавяме данни вътре.
Property Capacity е размера на списъка.
Count е броя на наличните елементи в списъка.

Предикат се нарича всяка функция, която връща булева стойност.
Метода Where() работи като метода Select() с разликата че очаква предикат.
Ако резултата е true, включва елемента в резултатната колекция. Реално Where() премахва елементите, които не отговарят на дадено условие.
Lambda expression - анонимна функция:
Where(n => n >= 0 )  преди стрелката, стоят параметрите, след стрелката резултата от функцията. n е всеки един елемент от колекцията и елементите които отговарят на условието, биват включени в резултатната колекция. Без никакъв проблем, може в Where() да сложим наша нормална функция, която е предикат, просто Lambda е анонимна функция, по лесна за ползване.

# Misc
Основна разлика между масив и списък е че когато създадем масив, той освен конкретна дължина, всичките елементи в него имат зададени стойности по подразбиране. При списъците, дори да сложим даден размер, то елементите нямат инициализирана никаква стойност и ако пробваме да достъпим някой от тях, ще даде exception. Трябва първо да се даде стойност на елементите, преди да може да се достъпват по индекс.

Lambda функциите, могат да се използват като самостоятелни функции, където не се различават от обикновените методи. Трябва да се декларирани нагоре в кода, преди да бъдат извикани.
```
Func<int, int, int> add = (a, b) => a + b;

Console.WriteLine(add(4, 5));
```
В първата част чрез "Func" казваме че искаме функция, която връща резултат int(третия инт в поредицата), и има две променливи от тип int и се казва add. След знака за = я инициализираме и казваме как да се казват двете променливи, във скобите а след знака => казваме какво се случва с подадените променливи:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240131104402.png)

Истинската сила на тези функции идва че могат да се декларират като параметър в стандартен метод и реално всеки път когато извикваме стандартната функция, ние инициализираме lambda функцията, това дава голяма гъвкавост и означава, че може да променяме имената на променливите и тяхната логика:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240131110320.png)

Това е и принципа, на който работи Where() метода в LINQ.

Също можем като стандартна променлива, да даваме нова стойност на създадената функция:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240131110637.png)

Гъвкавостта особено много се вижда в примера долу, където само с една функция, ние променяме логиката при инициализирането, а иначе имаме нужда от два метода:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240131112648.png)

```
List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


List<int> list2 = Where(list, x => x % 2 == 0);

//List<int> list2 = Where(list, Predicate);

foreach (int x in list2)
{
    Console.WriteLine(x);
}

static bool Predicate(int x)
{
    return x % 2 == 0;
}


static List<int> Where(List<int> list, Func<int, bool> predicate)
{
    List<int> tempList = new List<int>(list.Count);

    foreach (int i in list)
    {
        if (predicate(i))
        {
            tempList.Add(i);
        }
    }

    return tempList;
}
```

В този код виждаме семпла репрезентация на Where() в LINQ. В Where метода, очакваме като параметър листа и функция която получава int и връща число. 
В първия случай, predicate тялото е попълнено директно при инициализирането на list2. 
Във втория случай, имаме обикновен Predicate метод, който се ползва като делегат в Where(), но без скобите. Тогава C# разбира, че метода не трябва да се изпълни веднага, но ще бъде изпълнен там, където predicate от Func бива извикан. Тоест делегата, Predicate, ще замести Func predicate:
1. You have a `List<int>` named `list` containing some integers.
2. You define a delegate `Func<int, bool>` named `Check`, which is essentially a delegate that takes an `int` as an input parameter and returns a `bool`.
3. You have a method named `MyMethod`, which matches the signature of the `Func<int, bool>` delegate. It takes an `int` and returns a `bool`, and it is used as the delegate parameter for the `Where` method.
4. The `Where` method is a generic method that takes a `List<int>` and a `Func<int, bool>` delegate as parameters. It filters elements from the input list based on the delegate's condition.
5. 
Делегата може да бъде всеки метод, който има същата сигнатура, като функцията като параметър в дадения метод.

# ChatGPT
In C#, when you use a delegate, the signature of the delegate must match the signature of the method or lambda expression that you assign to it. The term "signature" refers to the method's return type, parameter types, and the number of parameters.

In your example:

`static bool MyMethod(int x) {     return x % 2 == 0; }  // Declaration of the delegate Func<int, bool> Check = MyMethod;`

Here, `MyMethod` has a signature that matches the signature of `Func<int, bool>`. It takes an `int` as a parameter and returns a `bool`. Therefore, you can assign `MyMethod` to a delegate of type `Func<int, bool>`. If the signatures didn't match, the assignment would result in a compilation error.

Delegates provide a way to pass methods as parameters, which can be particularly useful for creating flexible and reusable code. They are often employed in scenarios like event handling, LINQ, and other cases where you want to pass behavior as a parameter.

# Bookmarks 
