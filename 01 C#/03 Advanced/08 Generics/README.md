# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#)

Силата на generics е когато правим структура от данни, клас и тн, да може да му разрешим да работи с типове данни, които потребителите на нашия код избират. С други думи, да може потребителите на нашия клас да избират типа данни с който класа да работи. Идеята е да се преизползва един и същи клас с единствената разлика типа данни, които приема, като се направи един само един темплейтен клас, който може да приема различни типове данни.
Както класа е шаблон за обекти, така и generics са шаблон за класове.

Параметъра в триъгълните скоби се нарича типов.

Когато ползваме generics, C# по време на compile time генерира скрито от нас нов тип данни, където Т е заместено с типа данни, който сме посочили.

Може да проверим какъв тип е даден template `T` с `typeof(T)`, или ако ползваме метода `randomVariable.GetType()`.

Не може да инициализираме `T` променливи вътре в generic method или клас, защото не е ясно каква стойност ще бъдат. Стойността може да бъде подадена като параметър или директно отвън, след като имаме вече обект и е ясно с какъв тип данни ще бъде заместено `T`:

```
namespace ConsoleApp
{
    class MyClass<T>
    {
        public T Value { get; set; } // = 2 will not work, because the type of T is unknown right before class initialization.

        public int Value2 { get; set; } = 2; // working because the type of Value2 is known.

        public void SetValue(T value)
        {
            Value = value;
        }
    }

    public class Program
    {
        static void Main()
        {
            MyClass<int> myClass = new MyClass<int>();

            myClass.Value = 2; // the initialization is now working, because type T is replaced as int.
            
            myClass.SetValue(4); // reassignment of the property of type T Value is working again, as the new value is passed as parameter after the type of T is known.
        }
    }
}
```
## Type safety
Типовата безопасност означава, че когато определим някакъв тип данни с който да работим, примерно списък от strings, тогава C# става много стриктен и всеки път като работим с този списък, ще има грешка, ако подаваме друг тип данни освен string. Когато искаме да работим с данните от този списък, C# ще знае предварително какви операции, може да приложим върху тях. Също няма как в C# където имаме типова безопасност, да сложим число в списък от стрингове.
## Classes
Когато дефинираме generic class, типа данни, който посочим при инициализирането ще бъде заместен там където имаме `T` вътре в кода на класа:

```
class GenericClass<T>
{
    public T First { get; set; }

    public T Second { get; set; }
}

class Program
{
    static void Main()
    {
        GenericClass<int> intGeneric = new GenericClass<int>();

        GenericClass<string> stringGeneric = new GenericClass<string>();
    }
}
```

В първия случай, пропъртитата First и Second ще бъдат от тип int, при втория обект, ще бъдат тип string.

Може да имаме и няколко типа данни, които да заместваме вътре в класа:

```
class GenericClass<T, T2, T3>
{
    public T First { get; set; }

    public T2 Second { get; set; }

    public T3 Third { get; set; }
}

class Program
{
    static void Main()
    {
        GenericClass<int, double, string> intGeneric = new GenericClass<int, double, string>();
    }
}
```

За пример, речниците приемат два типа данни, един за ключа и един за стойностите.
## Methods
Методите също могат да работят с generics, тоест параметрите на метода да не са фиксирани предварително, но да приемат различен тип данни. 
При дефинирането на метода, трябва да сложим `<T>`  след името му. Прието е да се пише `T`, но може да напишем нещо друго на негово място.

```
Console.WriteLine(4 + ReturnValue<int>(5)); // 9
Console.WriteLine(4 + ReturnValue<string>("5")); // 45

static T ReturnValue<T>(T value)
{
    return value;
}
```
## Generic Constraints (Apply Restrictions)
При генериране на темплейт-ни класове и методи, може да зададем ограничение, какво може да бъде `T` и всичко друго няма да бъде прието. 
Ограниченията става с  `where T :` и желаното ограничение. Изписва се под метода или класа:

```
class Generic
{
    public void MyMethod<T>()
        where T : new()
    {
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Generic genericMethod = new Generic();
        genericMethod.MyMethod<string>(); // not working, as class `string` does not accept empty constructor
        genericMethod.MyMethod<StringBuilder>(); // working
        genericMethod.MyMethod<int>(); // working
    }
}
```

В примера горе, всички типове данни, които нямат празен конструктор, няма да работят с метода. Всички останали, дори value types като `int, char, double..` работят.

Примерни възможности:
`where T : new()` - типовете данни, трябва да имат празен конструктор.
`where T : class` - типовете данни, трябва да са референтни.
`where T : struct` - типовете данни, трябва да са примитивни.
`where T : Stream` - типовете данни, трябва да са `Stream` или неговите класовете наследници примерно `BufferedStream`.
`where T : IEnumerable<int>` - типовете данни, трябва да са колекция от int, масив, списък, опашка и тн.
`where T : IComparable<T>` - типовете данни, трябва да са от сравним тип, тоест да наследяват / имплементират `IComparable`. 
`where T2 : T` - едното `T` е наследник на другото `T`.

Може да се правят и комбинации, които изреждаме със запетая, като няма ограничение в броя им. В примера долу, понеже знаем точния клас на T, може да използваме свойствата и методите му:

```
class Generic
{
    public void MyMethod<T>()
       where T : StreamWriter, new()
       //where T : class, new()
    {
        T stream = new T();
        stream.Write("Hello");
    }
}
```
## Object data type
Преди generics е имало `System.Collections`, които имат колекции, приемащи object като тип данни.
`SyStem.Collections.Generic` сa добавени малко след създаването на C#, но преди това се е ползвал оbject, който е основата на всеки тип данни. Примерно може да създадем object променлива, на която да й присвояваме каквито си искаме стойности. Може да я инициализираме като стринг, а после да й сложим цяло число или друг тип данни. 
Има като ограничение, че може да ползваме само 4 метода, които са валидни за всеки тип данни. 
Предимството е че както при generics, така и тук, може да направим клас, който да приема object като тип данни и така да работи с най-различни типове. Така губим типовата безопасност, защото в един списък от objects може да са от най-различни типове данни. За да може да използваме други методи, трябва да конвертираме object към дадения тип, стига да знаем какъв е.
# Misc
Метода Equals, който съществува за всички типове данни, работи по различен начин, спрямо дали типа данни е class или struct. При struct проверява двете стойности байт по байт дали са еднакви, а при class проверява дали сочат към едно и също място в паметта.
# ChatGPT
## Data types
Understanding the differences between delegates, enums, classes, and structs, as well as the types that are part of them, can indeed be a bit tricky at first. Let's break down each of them and clarify their distinctions:
1. **Delegate**:
    - A delegate is a type that represents references to methods with a particular parameter list and return type.
    - It provides a way to encapsulate a method and pass it as a parameter to another method or to store it for later invocation.
    - Delegates are typically used for implementing callback mechanisms and event handling in C#.
    - Example: `Action`, `Func`, custom delegates.
2. **Enum**:
    - An enum (enumeration) is a distinct type consisting of a set of named constants called the enumerator list.
    - It is used to define a group of named constants, making it easier to work with sets of related values.
    - Enums in C# are value types, and their underlying type can be any integral type such as `byte`, `short`, `int`, etc.
    - Example: `enum Color { Red, Green, Blue }`.
3. **Class**:
    - A class is a reference type that serves as a blueprint for creating objects.
    - It defines the structure and behavior of objects through fields, properties, methods, constructors, and events.
    - Classes in C# support inheritance, polymorphism, and encapsulation.
    - Example: `class MyClass { /* Fields, properties, methods, etc. */ }`.
4. **Struct**:
    - A struct (structure) is a lightweight data structure that represents a value type.
    - It is similar to a class but typically used for small data structures that have value semantics rather than reference semantics.
    - Structs are stored on the stack memory or inlined within containing objects, making them more efficient in certain scenarios.
    - Example: `struct Point { int X; int Y; }`.
    - 
Regarding "types that are part of them," each of these constructs can include various types of members or elements:
- **Delegate Types**: These are the method signatures that the delegate can point to.
- **Enum Members**: These are the named constants defined within the enum.
- **Class Members**: These are the fields, properties, methods, constructors, and events defined within the class.
- **Struct Members**: These are the fields, properties, methods, constructors, and events defined within the struct.
Understanding the distinctions between these constructs and their respective member types is essential for effectively designing and implementing software in C#. If you have specific questions or examples you'd like to discuss further, feel free to ask!

You

So class is a data type, but string for example is also a data type which is part of the class data type?

ChatGPT

Yes, that's correct! In C#, a class is indeed a data type, but it's a more general construct that defines the blueprint for creating objects. Within a class, you can define various members, including fields, properties, methods, constructors, and events.

Now, when we talk about the `string` data type, it's a specific type that is part of the .NET Framework's base class library. `string` represents a sequence of characters and is used to store text data. It's implemented as a class (`System.String`), but it's treated as a special case in the C# language, with its syntax and features optimized for common string manipulation tasks.

So, in essence:
- **Class**: A general construct defining the blueprint for creating objects. It can contain various members.
- **String**: A specific data type representing text data. It's implemented as a class (`System.String`) and provides specialized functionality for working with strings.

In summary, while `string` is implemented as a class, it represents a specific data type for handling text data, distinct from the broader concept of a class.

You

Class is the broader data type while string is a narrowed class data type?

ChatGPT

Yes, that's a good way to put it!
- **Class**: It's a broad concept in object-oriented programming that defines a blueprint for creating objects. Classes can contain various members such as fields, properties, methods, constructors, and events. They serve as templates for creating objects with specific behaviors and attributes.
- **String**: It's a specific data type in C# that represents sequences of characters (text data). In C#, `string` is implemented as a class (`System.String`), but it represents a specialized case of a class, optimized for working with text data. While it's implemented as a class, it's often treated as a fundamental data type due to its importance and ubiquity in programming.
So, in a sense, a `string` is a specific instance of a class, but it's so common and fundamental that it's often treated separately in discussions about data types and programming constructs.
The distinction between broader data types and more specialized data types is not unique to classes and strings. In programming languages like C#, you'll encounter various types that fall into different categories:
1. **Broad Data Types**: These are general-purpose types that encompass a wide range of data and functionality. Examples include:
    - Classes: Blueprints for creating objects with specific behaviors and attributes.
    - Structs: Lightweight data structures with value semantics.
    - Interfaces: Contracts that define a set of members that implementing types must support.
2. **Specialized Data Types**: These are types tailored for specific use cases or data representations. Examples include:
    - Primitive Types: Fundamental data types provided by the language, such as integers (`int`, `long`), floating-point numbers (`float`, `double`), characters (`char`), and boolean values (`bool`).
    - Enumerations (`enum`): Types used to define a set of named constants.
    - Arrays: Collections of elements of the same type, represented by square brackets (`[]`).
    - Tuples: Ordered collections of elements of different types, introduced in newer versions of C#.

Each of these types serves a particular purpose and provides a level of abstraction appropriate for different scenarios. Understanding the distinctions between broader and specialized data types is crucial for effective programming and designing robust software systems.
## Generic resolution
You

Thinking about compile time and runtime i have a question - when the user have a choice to pick the data type for a particular class to use, but we know that generics are resolved during compile time, what is happening in those situations where the exact type is determined during the runtime?

ChatGPT

In languages like C#, where generics are resolved at compile time, situations where the exact type is determined during runtime can be handled using techniques such as reflection, dynamic typing, or polymorphism.

Here's how each of these techniques can be used to handle runtime type determination:
1. **Reflection**: Reflection allows you to inspect and manipulate types, properties, and methods of objects at runtime. You can use reflection to dynamically instantiate generic types based on user input or to invoke methods on generic objects.
2. **Dynamic Typing**: C# provides the `dynamic` keyword, which allows you to defer type checking until runtime. You can use dynamic typing to work with objects whose types are not known until runtime, including generic objects.
3. **Polymorphism**: Polymorphism allows you to treat objects of different types in a uniform manner. You can design your classes and interfaces to support polymorphic behavior, allowing users to pass objects of different types to your code without needing to know the exact types at compile time.

While generics in C# are resolved at compile time for type safety and performance reasons, these runtime techniques provide ways to work with generic types in situations where the exact type is determined dynamically during program execution.
# Bookmarks 

Course completion: 12.05.2024
