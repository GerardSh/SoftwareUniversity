# General
Концепцията за абстракция означава, да игнорираме детайлите и да се концентрираме върху важното за един клас, за което много помагат интерфейсите, описвайки списъка от методи / пропъртита, които да описват същината и най-важното за класа. Еволюцията на езиците за програмиране и концепциите в програмирането реално са абстракция. Примерно циклите са абстракция на много процеси под тях. Езиците на високо ниво са абстракция на езиците от ниско ниво и тн. Пример за постигане на цикъл в BASIC:

```
        int i = 0;

    Cycle:

        Console.WriteLine(i++);

        if (i <= 5) goto Cycle;
```

Абстракцията, също като при енкапсулацията се опитва да скрива разни неща от класа, но при нея се скрива функционалност, която не е необходима на външния свят, за да не го разсейват с излишни детайли. Енкапсулацията се занимава основно със скриване и валидация на данните, то абстракцията се занимава повече с публичните неща, които един клас предлага, повече с функционалността и публичните възможности. С други думи, абстракцията намалява сложността по разбирането какво прави нашия клас и дава възможност на външния свят да достъпят само онези неща, които са важни за тях и да се абстрахират и игнорират детайлите. Това се постига чрез интерфейси, абстрактни класове и виртуални / абстрактни методи.

Скриването, игнорирането, премахването на методи, пропъртита, функционалност която ще си я имаме в класа, но ако не е нужна на външния свят, принципа е да я скриваме. Примерно помощен метод вътре в класа, трябва да си остане вътре. Публичните методи, трябва да са само тези, които са важни за класа.

Абстракцията има две направления / гледни точки:
1 - Скриването на ненужните неща от външния свят. Примерно ако имам клас студент, с вътрешен метод който му осреднява оценката, това за външния свят не е важно. Това което е важно е да извика един метод, който да върне оценката на студента, а не точно как се изчислява.
2 - Имаме нещо от реалния свят, което пренасяме в клас. Трябва да се вземат само детайлите, които са релевантни и важни за нашия клас и да се игнорира останалото. Примерно при клас студент, ние не се интересуваме от това колко е висок, как изглежда и тн, но взимаме само важните неща за нас като име, възраст, пол, оценки и тн..

Трябва да правим публични само членовете на класа, които ще се ползва отвън. Основната цел е да намалим сложността на кода, защото един проект с хиляди класове, ако всичко им е публично ще е много трудно да ги използваме. Примерно ако в даден клас има 20 метода, но реално само 3 са важните, а другите са помощни, ние няма да знаем кой от всичките да ползваме. Трябва да ровим в документацията, кода на класа, все неща които отнемат много време и точно това е идеята на абстракцията, да си го спестим. Трябва така да е направен класа, че само с поглед на публичните методи да се ориентираме какво правят.
Абстракцията ни помага да се фокусираме върху това какво прави даден клас, а не как го прави.

Правилната терминология когато говорим за интерфейси и наследяване е че един клас наследява друг клас и имплементира интерфейс, а интерфейсите, наследяват други интерфейси.

Принципа на абстракцията е да използваме най-базовия тип данни, който има всичко което ни трябва.

Абстракцията се постига чрез два подхода: интерфейси и абстрактни класове.
## Interface
Създава се както се създава клас, но вместо `class` се пише `interface`. Името трябва да започва с `I`. Интерфейса е нещо като договор, списък от публичните членове, които трябва да има един клас, в над 90% това са методи, също така има и пропъртита, events(свързани с мобилни и desktop приложения) и indexers. Това е само списък, без нищо друго - няма имплементация, няма тяло, само метод signature-a. Всеки клас, който подписва този договор е задължен да има нещата описани в интерфейса, с единственото изключение - името на параметрите на методите, може да се ползват и други имена.

Всички членове в интерфейса са публични.

Интерфейсите ни позволяват да групираме няколко класа с една и съща функционалност под една обща шапка. Примерно `IEnumerable` се имплементира от много класове.
Те имат много различна функционалност, но всички отговарят на общото свойство, че имат метода `GetEnumerator` и по конкретно, че могат да бъдат foreach-вани. Това ни дава голямо предимство и гъвкавост, че може да променяме в последствие, конкретиката с която работим. Когато даден код работи с базов клас или интерфейс и когато даден метод иска от нас  като параметър `IEnumerable` ние може да му подадем всеки един от класовете, които са имплементирали тоя интерфейс. Докато ако искания параметър е само List<Т>, то тогава нямаме гъвкавост. С други думи, абстракцията е важна и от тази гледна точка, че когато искаме по базов параметър, тогава нашия код може да бъде използван с много повече опции.
Един клас може да наследи само един друг клас, но може да имплементира много интерфейси, защото интерфейса е само списък от методи и пропъртита, докато класа има и функционалност и нещата стават по-сериозни.

Методи които нямат тяло, се наричат абстрактни. Всеки такъв метод, може да бъде в интерфейс или абстрактен клас. Ако е интерфейс няма нужда да се пише `abstract` при дефинирането му.

Интерфейса, може да стане тип данни на променлива, но тя не може да е равна на самия интерфейс, защото самия интерфейс няма никаква имплементация на списъка от методи в него, задължително трябва да посочим даден клас, който е имплементирал интерфейса, защото при него е добавена логика и тяло на методите. Такава променлива се нарича абстрактна. С други думи не можем да създаваме инстанция на интерфейс директно, защото интерфейсът е абстрактен тип, който само дефинира методите, които класовете трябва да имплементират. Интерфейсите не могат да бъдат инстанцирани директно. Вместо това, можем да създадем инстанции на класове, които имплементират даден интерфейс:

```
public interface IMyInterface
{
    void MyMethod();
}

public class MyClass : IMyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyMethod implemented in MyClass");
    }
}

public class MyClass2 : IMyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyMethod implemented in MyClass2");
    }
}

public class Program
{
    static void Main()
    {
        // IMyInterface @interface = new IMyInterface(); // Това е грешка

        // Създаване на инстанция на клас, който имплементира интерфейса
        IMyInterface @interface = new MyClass();
        @interface.MyMethod(); // Извикване на метода, имплементиран в MyClass

        // Пренасочване на променливата към друга инстанция, имплементираща интерфейса
        @interface = new MyClass2();
        @interface.MyMethod(); // Извикване на метода, имплементиран в MyClass2
    }
}

```

Общото между всички класове, които са имплементирали даден интерфейс е че всички ще имат описаните методи и пропъртита в интерфейса. Всички те влизат в групата на интерфейса. 

Можем да създадем променлива от типа на интерфейса и посочим даден клас, който е имплементирал този интерфейс, то ние ще имаме достъп, само до имплементацията на методите и пропъртитата в дадения клас и до нищо друго, което се съдържа в класа. Така имаме предимство че можем да присвоим всеки един от тези класове на променливата, но и ограничението да не може да ползваме другите неща намиращи се в класа.
Друго предимство е, че може да направим списък от типа на интерфейса и в него може да добавяме различни обекти от типа на класовете имплементиращи интерфейса и така ще имаме достъп само до техните имплементации на методите описани в интерфейса.
Трето предимство е, че може да имаме метод, който да приема като параметър типа на интерфейса и така може да му подадем всеки клас, който имплементира този интерфейс, няма да сме ограничени само до един клас. Този метод става абстрактен и може да работи с много различни типове. 

Може да имаме default метод в интерфейса, който да прави нещо и този метод ще бъде наличен за всички променливи, които са от типа на интерфейса, независимо кой клас са инициализирали. Това е добавено в C# 8.0 и не се ползва много.

```
public interface IMyInterface
{
    void MyMethod();

    // Default method implementation in the interface
    void Print()
    {
        Console.WriteLine("test");
    }
}

public class MyClass : IMyInterface
{
    public void MyMethod()
    {
        throw new NotImplementedException();
    }
}

public class MyClass2 : IMyInterface
{
    public void MyMethod()
    {
        throw new NotImplementedException();
    }
}

public class Program
{
    static void Main()
    {
        IMyInterface myInterface = new MyClass();
        IMyInterface myInterface2 = new MyClass2();

        // Using the default implementation of Print method
        myInterface.Print();
        myInterface2.Print();
    }
}
```

Предимство на интерфейсите пред класовете и абстрактните класове е, че може да имплементираме повече от един интерфейси в даден клас. 

Когато имаме наследяване и имплементация на клас, винаги въпрос записваме класа от който наследяваме след `:` и след това изреждаме със запетайка интерфейсите.

Един интерфейс, може да наследи друг интерфейс, където добавя методите на този интерфейс и добавя свои методи.

Всеки клас също имплементира интерфейсите, на друг клас когото наследява.
## Abstract class
Създава се както като клас, с ключовата дума `abstract` преди класа. Това са специални класове, които се правят с цел да бъдат наследявани. Могат да бъдат само базов клас за други класове, играе ролята на основа, върху която конструираме основата на други класове.

Също като интерфейсите, абстрактните класове, не могат да бъдат инстанцирани, тоест не може да направим обекти от тях, защото съдържат празни абстрактни методи. Можем да ги ползваме като базов тип данни на който да присвоим някой от класовете, който ги е наследил.

Абстрактен е като интерфейса, но в същото време е и клас - може да има имплементация на методи, но може да има и методи, без имплементация. По средата между клас и интерфейс, което ни дава по-голяма гъвкавост, но и някои ограничения.

Абстрактните методи са имплицитно виртуални методи без тяло и могат да бъдат създавани само в абстрактни класове. Всеки клас който наследява абстрактен клас, трябва задължително да override-не абстрактните методи.

Всеки клас, който не е абстрактен и имплементира абстрактен клас, е длъжен да имплементира абстрактните методи, тоест да ги override-не.

Разлика с интерфейсите е, че може да имаме и конструктори.

Ако абстрактен клас имплементира интерфейс задължително трябва да сложи ключовата дума `abstract` при методите от интерфейса, които ще остави празни.
## Interface vs Abstract Class
### Interface
Интерфейса дава списък от методи и пропъртита, които винаги са публични и трябва да ги имплементираме.
Един клас може да имплементира много интерфейси.
Всички членове са публични.
Няма конструктори.
Не може да се дефинират полета и константи.
Ако добавим нов метод, трябва да променим съществуващите класове, като добавим поведение на метода, където интерфейса е имплементиран. От C# 8.0 може да се добави default-но поведение, като по този начин, класовете имплементиращи интерфейса, не са длъжни да добавят този метод в кода си. Тези default методи могат да бъдат достъпвани, само ако типа на променливата е интерфейса и класа който ги е имплементирал, не ги е добавил в кода си. Ако са добавени в кода, вече default поведението на метода, няма как да бъде достъпено както е видно от `MyMethod2` в примера, докато `MyMethod3` може да бъде достъпен, но само ако типа на променливата е интерфейса:

```
using System;

public interface IMyInterface
{
    void MyMethod();

    void MyMethod2()
    {
        Console.WriteLine("Default MyMethod2 method in IMyInterface");
    }
    void MyMethod3()
    {
        Console.WriteLine("Default MyMethod3 method in IMyInterface");
    }
}

public class MyClass : IMyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyMethod implementation in MyClass");
    }

    // MyClass provides its own implementation of MyMethod2()
    public void MyMethod2()
    {
        Console.WriteLine("MyMethod2 method in MyClass");
    }
}

public class Program
{
    static void Main()
    {
        Console.WriteLine("MyClass type");
        Console.WriteLine("***************************");

        // Create an instance of MyClass
        MyClass myClass = new MyClass();

        // Accessing method from MyClass
        myClass.MyMethod();    // Output: MyMethod implementation in MyClass
        myClass.MyMethod2();    // Output: MyMethod2 method in MyClass
        // myClass.MyMethod3();    // Not reachable, because it's not implemented in MyClass

        Console.WriteLine();
        Console.WriteLine("IMyInterface type");
        Console.WriteLine("***************************");

        // Accessing default method from IMyInterface
        IMyInterface myInterface = new MyClass();

        myInterface.MyMethod();    // Output: MyMethod implementation in MyClass
        myInterface.MyMethod2();    // Output: MyMethod2 method again as found in MyClass. The default implementation in IMyInterface is unreachable, because MyMethod2 has been implemented in MyClass
        myInterface.MyMethod3();    // Output: Default MyMethod3 method in IMyInterface
    }
}
```
### Abstract class
Абстрактния клас може да има абстрактни методи - без тяло, но може да имаме и методи с тяло.
Ако абстрактния клас бъде наследен от даден клас, дадения клас не може да наследи друг клас.
Може да имаме конструктори.
Това което абстрактния клас дава като предимство пред обикновения клас е че може да имаме абстрактни методи и пропъртита.
Може да се дефинират полета и константи.
Ако добавим нов метод, може да му добавим default-но поведение и така съществуващия код ще работи.
### Similarities
И двете си приличат по това че не може да бъдат инстанцирани.
И двете са абстракция и не може да правим обекти, защото не са нищо конкретно.
## Abstraction vs Encapsulation
### Encapsulation
При енкапсулацията, скриваме основно данните минавайки ги през методи и код, който да ги валидира, това е с цел да защитим информацията, от външния свят. Трябва да сме сигурни че имаме коректно подадени данни, за да работи класа ни правилно.
Постига се основно чрез access modifiers и пропъртита.
### Abstraction
При абстракцията ние скриваме имплементационни детайли. Това означава метод, който върши помощна работа и който не е нужен на външния свят. Основната цел е да не затормозяваме колегата, който използва класа с неща които не го интересуват и да му дадем списък, само с важните неща от нашия клас, които трябва да са публични, другите модификатори нямат значение.
Постига се чрез абстрактни класове и интерфейси.
## Public API
Само важните неща от класа трябва да са публични, всичко останало трябва да е private.
## Virtual vs Abstract
Общото между `virtual` и `abstract` e че в двата случая можем да override-нем, но при abstract сме длъжни да го направим.
## Methods conflict between two Interfaces - Explicit Interface Implementation
Ако имаме клас, който имплементира два интерфейса имащи методи с еднакво име, параметри и връщан тип, тогава няма да имаме конфликт, но ако има разлика в параметрите или типа се получава проблем. За да се реши, се използва `Explicit Interface Implementation` - преди името на метода се написва името на интерфейса. За да се достъпи такъв метод, трябва да се направи променлива от типа на интерфейса, както виждаме с променливата в примера `iMyInterface2`:

```
using System;

public interface IMyInterface1
{
    public string MyMethod();
}

public interface IMyInterface2
{
    public void MyMethod();
}

public class MyClass : IMyInterface1, IMyInterface2
{
    public string MyMethod()
    {
        return "IMyInterface1";
    }

    void IMyInterface2.MyMethod()
    {
        Console.WriteLine("IMyInterface2");
    }
}

public class Program
{
    static void Main()
    {
        MyClass myClass = new MyClass();
        Console.WriteLine(myClass.MyMethod()); // Output: IMyInterface1

        IMyInterface1 iMyInterface1 = new MyClass();
        Console.WriteLine(iMyInterface1.MyMethod()); // Output: IMyInterface1

        IMyInterface2 iMyInterface2 = new MyClass();
        iMyInterface2.MyMethod(); // Output: IMyInterface2
    }
}
```
# Misc
Един от най-честите въпроси при интервютата за работа е каква е разликата между интерфейс и абстрактен клас.

Външните библиотеки се инсталират и управляват чрез NuGet. NuGet е пакетен мениджър за .NET, който улеснява добавянето на библиотеки и зависимости към проектите.
## .NET / CSharp
.Net е цялостната платформа, SDK, компилатора, всичките готови неща, които ползваме. 
C# е език, който ни позволява да пишем върху .NET, има много други езици, които може да пишат в .NET, C# е най-използвания.
## Public API - Application Programming Interface
Само важните неща от класа трябва да са публични, всичко останало трябва да е private. Една от основните отговорности на интерфейсите е - да опишат нещата които са публични за даден клас. Това са нещата които хората от вън, може да използват за да работят с нашето приложение / програма. Ако това е клас, това са публичните методи, ако е web service, това са адресите / функционалностите, които може да достъпят. API както и много други неща в IT сферата, като service, interface и тн, могат да значат различни работи в зависимост от контекста. 
## Class
По дефиниция, класа е описание върху даден език за програмиране на обект съществуващ в реалния свят. Класа проектира част от възможностите на този обект в езика за програмиране.
# ChatGPT
## Properties
You

If we have an interface with property that has only getter then when we implement it on a class, why we are allowed to set a setter as well

ChatGPT

When you implement an interface in C#, the property in the interface specifies the minimum contract that the implementing class must adhere to. If the interface specifies a property with only a getter, it means that any class implementing this interface must have at least a getter for that property. However, the implementing class is allowed to provide more functionality than the interface specifies, such as adding a setter.

 Why It Is Allowed

1. **Extended Functionality**: The class can extend the functionality of the interface by adding a setter. The interface only defines what must be present (a getter in this case), but the class can choose to provide more functionality.
2. **Encapsulation and Implementation Details**: The interface defines the public API that consumers of the interface will use. The implementing class can encapsulate additional behavior and implementation details, such as internal or private setters, without violating the interface contract.
3. **Flexibility**: Allowing the setter provides flexibility for the class to manage its state internally while exposing a read-only property through the interface.

 Summary

When you implement an interface with a property that only has a getter, you are required to provide at least a getter in the implementing class. However, you can also provide a setter (public, private, or protected) if needed. This allows for greater flexibility and enables the class to manage its internal state while fulfilling the interface contract.

You

Why we cannot have a private setter in the interface?

ChatGPT
You cannot have a private setter in an interface in C#. In an interface, all members are implicitly public because an interface is meant to define a contract for classes to implement. The interface should only specify what needs to be done (the methods and properties that need to be implemented), not how it is done. Here’s a summary of why this is the case and how you can manage property access:

 Why Interfaces Can't Have Private Setters

1. **Purpose of Interfaces**: Interfaces are designed to define a public contract. They specify what members a class must implement, ensuring a consistent interface for consumers of the class. Private members are implementation details and thus are not included in the interface definition.
2. **Access Modifiers**: Interfaces in C# do not allow explicit access modifiers on their members. All members of an interface are implicitly public.
## Interface Members are Abstract
You
In the context of interfaces, all members in the interface are implicitly abstract by default, but even if we explicitly use the `abstract` keyword for lets say a method, we have to only create this method in the class that implements the interface. If we have abstract method in a abstract class then the derived class have to override the method, not only create it?

ChatGPT

Exactly! You've summarized it perfectly.

 Interfaces

- **Abstract Methods**: In interfaces, all methods are abstract by default, meaning they have no implementation. When a class implements an interface, it must provide implementations for all interface methods.

```
public interface IExample
{
    void Method1();  // Abstract method, must be implemented by any implementing class
}

public class MyClass : IExample
{
    public void Method1()
    {
        // Implementation of Method1
    }
}
```

Abstract Classes

- **Abstract Methods**: In abstract classes, abstract methods are declared using the `abstract` keyword, and they do not have implementations. Any derived class that inherits from an abstract class must provide implementations for all abstract methods by using the `override` keyword.

```
public abstract class AbstractClass
{
    public abstract void Method1();  // Abstract method, must be overridden by derived classes
}

public class DerivedClass : AbstractClass
{
    public override void Method1()
    {
        // Implementation of Method1
    }
}
```

Key Differences

- **Interfaces**: All methods are implicitly abstract, and any class implementing the interface must provide implementations for these methods.   
- **Abstract Classes**: Abstract methods are explicitly marked with the `abstract` keyword, and derived classes must override these methods.

Summary

- **Interfaces**:
    - Methods are implicitly abstract.
    - Implementing classes must provide implementations (`override` is not used).
- **Abstract Classes**:
    - Abstract methods are explicitly marked with `abstract`.
    - Derived classes must provide implementations using `override`.

This distinction is important because interfaces allow for multiple inheritance of behavior, whereas abstract classes provide a way to define a base class that can be extended by subclasses, forcing them to provide specific implementations.
## Difference between Overriding and Shadowing

```
public abstract class AbstractClass
{
    public virtual void AbstractMethod()
    {
        Console.WriteLine("From Abstract class");
    }

    public void AbstractMethod2()
    {
        Console.WriteLine("From Abstract class");
    }
}

public class Class : AbstractClass
{
    public override void AbstractMethod()
    {
        Console.WriteLine("From class");
    }

    public new void AbstractMethod2()
    {
        Console.WriteLine("From class");
    }
}

public class Program
{
    public static void Main()
    {
        Class myClass = new Class();
        AbstractClass abstractClass = new Class();

        myClass.AbstractMethod();     // Output: From class
        myClass.AbstractMethod2();    // Output: From class
        abstractClass.AbstractMethod();   // Output: From class
        abstractClass.AbstractMethod2();  // Output: From Abstract class
    }
}
```

ChatGPT

Summary of the Code:

This code demonstrates the difference between overriding a method and shadowing (hiding) a method in C#.

Classes:

1. **AbstractClass**:
- `AbstractMethod`: A virtual method that can be overridden by derived classes.
- `AbstractMethod2`: A regular method that can be hidden (shadowed) by derived classes.
2. **Class**:
- Inherits from `AbstractClass`.
- `AbstractMethod`: Overrides the base class's virtual method using the `override` keyword.
- `AbstractMethod2`: Hides the base class's method using the `new` keyword.

Program:

- **Main Method**:
- Creates instances of `Class` and assigns one of them to a variable of type `AbstractClass`.
- Calls the methods `AbstractMethod` and `AbstractMethod2` on both instances and observes the behavior.

 Key Differences:

1. **Override**:
- When `Class` overrides `AbstractMethod`, it provides a new implementation for the method defined in `AbstractClass`.
- Regardless of the reference type (`Class` or `AbstractClass`), the overridden method in `Class` is called.
2. **Shadow (Hide)**:
- When `Class` hides `AbstractMethod2`, it provides a new implementation that is independent of the base class's method.
- The hidden method in `Class` is called only when the reference type is `Class`.
- When the reference type is `AbstractClass`, the base class's version of `AbstractMethod2` is called.

Code Execution:

```
public class Program
{
    public static void Main()
    {
        Class myClass = new Class();
        AbstractClass abstractClass = new Class();

        myClass.AbstractMethod();     // Output: From class
        myClass.AbstractMethod2();    // Output: From class

        abstractClass.AbstractMethod();   // Output: From class
        abstractClass.AbstractMethod2();  // Output: From Abstract class
    }
}
```

- `myClass.AbstractMethod()`: Calls the overridden method in `Class`.
- `myClass.AbstractMethod2()`: Calls the hidden method in `Class`.
- `abstractClass.AbstractMethod()`: Calls the overridden method in `Class` (due to polymorphism).
- `abstractClass.AbstractMethod2()`: Calls the base class's method in `AbstractClass` (due to method hiding and the reference type being `AbstractClass`).

Highlighting the Difference:

- **Overridden Method**:
- `AbstractMethod` in `Class` is an override of the `AbstractMethod` in `AbstractClass`. This means it uses the same method signature and memory location, providing a new implementation that is accessible regardless of whether the reference type is `Class` or `AbstractClass`.
- **Hidden (Shadowed) Method**:
- `AbstractMethod2` in `Class` is a completely different method from `AbstractMethod2` in `AbstractClass`, residing in a different location in memory. When `Class` hides `AbstractMethod2` using the `new` keyword, the derived class's version of the method is only accessible when the reference type is `Class`. If the reference type is `AbstractClass`, it uses the base class's `AbstractMethod2` implementation.

This distinction clarifies that hiding creates a separate method in the derived class, while overriding modifies the existing method in the base class.
# Bookmarks 

Course completion: 07.06.2024