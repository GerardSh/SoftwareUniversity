# General
Един метод, за да приключи работата си, трябва да върне стойност, ако не е void или да приключи работата си до край. Третия начин е чрез exception - методите извикани преди метода, където е exception-а, един по един ще получат съобщението за грешка и могат да обработят грешката, тоест да изпълнят някакъв код и да игнорират грешката или нищо да не направят. Ако нищо не направят - грешката продължава нагоре и ако никой от методите не реагира, грешката стига до потребителя.

Много по-добре е да се върне грешка, отколкото метода да продължи да работи и да върне грешни данни.

В езиците, които няма ексепшъни, методите които са били void са връщали цяло число, което представлява код за грешка. Ако върне 0, значи няма проблем, ако върне друго число, означава че метода е върнал грешка. По номера на грешката се гледа в таблица за да се види, какво означава точно. Това е било неудобно, защото за всеки метод е имало собствен списък от грешки и тн.
Друг начин да се уведоми за грешка, както е в SQL се записва в една глобална променлива - примерно заявка към базите данни не си свършва работата, трябва да се извика метод, който да върне точната грешка. Този подход не работи добре при многонишково програмиране.
Алтернативата на тези неудобни подходи са ексепшъните. Самата концепция за грешка използва йерархия от класове и когато говорим за грешка, се има предвид конкретен клас грешка.  Когато даден метод приключи с грешка, метода който го е извикал, може да не я остави да стигне до горе, защото иначе програмата спира да работи. 

Ако имаме необработена грешка (unhandled exception), обикновено се изкарва следната информация:
1. Типът на грешката: Това е името на изключението, което е хвърлено.
2. Съобщение за грешка - Message - текстово съобщение, което дава допълнителна информация, се пише за другите програмисти, а не за крайния потребител. За потребителите има други системи, които да покажат грешката в по четим за тях вид. Обикновено информацията от едно съобщение, се запазва някъде в някаква система, в която се записват всички възникнали грешки с пълната информация за тях, примерно в Windows -> Event Viewer -> Windows Logs -> Application или Azure.
3. Stack trace: Това е списък с извикванията на функции (методи), които са довели до изключението. Stack trace показва последователността от извиквания на функции и редовете в кода, където тези извиквания са направени.
4. Inner Exception - даден метод, който след като получи грешка от друг метод, не може да я обработи, но преди да я прехвърли към другите методи, я обвива в допълнителна информация - в `InnerException` пропъртито слага вътрешната грешка, а exception-a който се прехвърля нагоре има допълнителна по описателна информация.
5. Reflection информацията за метода.

Всеки ексепшън, може да си дефинира собствени пропъртита, като допълнителна информация - примерно argument exception, където освен съобщението за грешка, имаме възможност да посочим точното име на проблемния параметър.

Информацията за грешката идва при нас под формата на обект с пропъртита, методи, конструктори и тн, те са класове. 

Ексепшъни се ползват само в случаите, когато искаме да уведомим че не може да продължим с метода, не може да върне резултат. Никога не се използва ексепшъна, за контрол на flow-a, - да изпълним различен код, при различни условия. Трябва да се хвърля само в ситуациите, когато наистина не може да се направи нищо.

`try + Tab x 2` - генерира try catch конструкция.
### Exception Hierarchy in .NET
1. `System.Object`: Това е базовият клас за всички класове в .NET, включително и за изключенията.
2. `System.Exception`: Това е базовият клас за всички изключения в .NET. Той съдържа основни свойства като `Message`, `StackTrace`, `InnerException` и методи за работа с изключения.
3. `System.SystemException`: Този клас наследява `System.Exception` и е базов клас за много от системните изключения, които се хвърлят от CLR (Common Language Runtime).

По типа на грешката се ориентираме какъв е проблема точно. Ако задържим курсора върху даден метод, може да видим типа на грешките, които може да получим, като за вградените методи, това вече е описано, а за нашите методи, трябва да го опишем допълнително.
## Common Exception Types
### `ArgumentException` 
Невалиден аргумент, примерно са подадени 11 цифри вместо 10.
### `FormatException`
Невалиден формат, примерно е подаден текст, а е трябвало цифри.
### `ArgumentOutOfRangeException`
Когато очакваме примерно години, а някой даде отрицателно число или много голямо, извън определения интервал.
### `ArgumentNullException`
Получава се ако подадем null като стойност на даден метод.
### `NullReferenceException`
Предизвиква се, когато имаме променлива равна на null и се опитваме да направим някакво действие с нея.
## try - catch
В try конструкцията, слагаме кода, който подозираме че ще хвърли грешка, а в catch слагаме код, който да се изпълни, ако грешката възникне. А
ко няма грешка, кода продължава изпълнението си след catch конструкцията. 
При възникнала грешка, всичко под реда, където е възникнала грешката не се изпълнява и програмата продължава в catch конструкцията, където след изпълнението програмата продължава изпълнението си след catch блока.
В скобите в catch пишем точния тип грешка, който очакваме, като много важна е йерархията, защото ще хващаме освен посочения ексепшън тип, но и неговите наследници. Ако напишем само Exception, ще хванем всички възможно ексепшъни. Може и да не използваме скоби за catch, което ще е равносилно на това да имаме скоби с тип Exception - ще хване всички ексепшъни.
Може да имаме много catch конструкции, под един try, където всеки catch хваща различен тип грешка. Когато има грешка, се проверяват в последователен ред, дали някоя от catch конструкциите ще я хване. 

```
try
{
    int.Parse(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("An error occurred.");
}
catch (FormatException)
{
    Console.WriteLine("Input string is not a correct format.");
}
```

В примера, първия catch ще хване каквато и да е тип грешка и няма как да стигне до `FormatException` блока, дори да е точно такава грешката, защото `Exception` включва и `FormatException`, това ще доведе и до компилационна грешка. Трябва да се поставят най-специфичните изключения преди по-общите, защото иначе по-общите изключения ще уловят всички изключения, включително и тези, които спадат към по-специфичните. Ако два ексепшъна са от и също ниво в наследяването, избираме първо този, който е най-вероятно да се случи.

`StackOverflowException` и `OutOfMemoryException`, не могат да бъдат catch-нати, защото програмата няма ресурс за тях.

В скобите след типа на очаквания ексепшън, може да напишем името на обект, който е с информация за грешката:

```
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
```
### throw / finally
Оператора throw се използва в catch конструкцията, където след като е извършено някакво действие, грешката продължава пътя си нагоре, където може да бъде хваната от друга try-catch конструкция, ако има такава. Идеята е че след като грешката е регистрирана, използвайки throw, ние решаваме че не искаме да я скрием, това позволява грешката да бъде обработено на друго място в стека на извикванията, ако има подходяща try-catch конструкция. Всичко, което е във finally конструкцията, ще се изпълни, без значение дали има грешка или няма, обикновено се използва за да се освободят всички използвани ресурси, примерно чрез метода `Dispose()`. Може да имаме и само try - finally конструкция, без catch.

```
public class Program
{
    public static void Main()
    {
        try
        {
            int number = ParseNumber(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught in Main: {ex.Message}");
        }
    }

    private static int ParseNumber(string value)
    {
        int number = 0;

        try
        {
            number = int.Parse(value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught in ParseNumber: {ex.Message}");
            throw;
        }
        finally
        {
            Console.WriteLine("ALWAYS EXECUTE!!!");
        }

        return number;
    }
}
```

`throw` също се използва, когато искаме да предизвикаме грешка:

```
public class Program
{
    public static void Main()
    {
        ValidateLength(Console.ReadLine());
    }

    private static void ValidateLength(string value)
    {
        if (value.Length > 10)
        {
            throw new ArgumentException($"Allowed value length is 10, current is: {value.Length}");
        }
    }
}
```

Пишем `new` защото грешката е обект, в конструктора на повечето ексепшъни, може да подадем и допълнителна информация.
# Misc
Може да имаме празен блок. В C# декларираните променливи вътре в блок, имат обхват вътре само в него, по същия начин както всички останали блокове.

```
public static void Main()
{
    {
        int number = 5;
    }
}
```

# ChatGPT
## throw ex
You
What exactly is the difference between this:

```
catch (Exception ex)
{
    Console.WriteLine($"Caught in ParseNumber: {ex.Message}");
    throw;
}
```

and this:

```
catch (Exception ex)
{
    Console.WriteLine($"Caught in ParseNumber: {ex.Message}");
    throw ex;
}
```

ChatGPT
Good question! The difference between `throw` and `throw ex` in a `catch` block is important for understanding how exceptions are rethrown in C#.

 `throw`

When you use just `throw` in a `catch` block, the exception is rethrown up the stack, preserving the original stack trace. This means that the full information about where the exception originally occurred remains intact.


```
catch (Exception ex)
{
    Console.WriteLine($"Caught in ParseNumber: {ex.Message}");
    throw; // Rethrows the exception, preserving the original stack trace
}
```

`throw ex`

When you use `throw ex` in a `catch` block, the exception is also rethrown, but the original stack trace is replaced with a new one starting from the point of the `throw ex`. This means that the information about where the exception initially occurred is lost.

```
catch (Exception ex)
{
    Console.WriteLine($"Caught in ParseNumber: {ex.Message}");
    throw ex; // Rethrows the exception but replaces the original stack trace with a new one
}
```

Let's look at the following example to see the difference in action:

```
using System;

public class Program
{
    public static void Main()
    {
        try
        {
            Method1();
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Caught in Main: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }

    private static void Method1()
    {
        try
        {
            Method2();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught in Method1: {ex.Message}");
            throw; // or throw ex;
        }
    }

    private static void Method2()
    {
        throw new InvalidOperationException("An error occurred in Method2");
    }
}
```

Difference in Stack Trace

1. **Using `throw`**:
When using `throw` in the `catch` block of `Method1`, the stack trace will look like this:

```
Caught in Method1: An error occurred in Method2
Caught in Main: An error occurred in Method2
at Program.Method2()
at Program.Method1()
at Program.Main()
```

The original stack trace is preserved, showing the full path of the exception.
Exception Object: The same exception object is rethrown.
Stack Trace: The original stack trace is preserved, providing full information about where the exception was originally thrown.

2. **Using `throw ex`**:
When using `throw ex` in the `catch` block of `Method1`, the stack trace will look like this:

```
Caught in Method1: An error occurred in Method2
Caught in Main: An error occurred in Method2
at Program.Method1()
at Program.Main()

```

The original stack trace from `Method2` is lost, showing only the point from which the exception was rethrown.
Exception Object: The same exception object is rethrown. 
Same Exception Information: All the information in the exception object remains the same (message, type, properties, etc.).
Stack Trace: The stack trace is reset to the point of the `throw ex`, effectively losing the original call stack information.

Conclusion:

- **`throw`**: Rethrows the exception, preserving the original stack trace.
- **`throw ex`**: Rethrows the exception but replaces the original stack trace with a new one. 
- While there are scenarios where `throw ex` can be useful, they are typically outweighed by the advantages of using `throw`, which preserves the original stack trace and provides more detailed debugging information. In general, you should prefer `throw` unless you have a specific, justified reason to use `throw ex`.

Use `throw` to retain the full information about the exception, making debugging easier by showing exactly where the exception originally occurred.
## Redeclaring the Interface
You
Why there is a difference if the derived class re-declares the interface like it is the case with `MyClass3` in the example below?
`MyClass2` and `MyClass3` are both hiding the `MyMethod()` implementation in `MyClass` with new implementations, however when we make a variable of `MyInterface` type and initialize it with `MyClass2` and `MyClass3` data, only `MyMethod()` in the `MyClass3` was overridden successfully, `MyClass2` still uses the `MyClass` implementation. The only difference between the two is that `MyClass3` re-declares `MyInterface`, where `MyClass2` is inheriting it thru `MyClass`:

```
public interface MyInterface
{
    void MyMethod();
}

public class MyClass : MyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyClass");
    }
}

public class MyClass2 : MyClass
{
    public new void MyMethod()
    {
        Console.WriteLine("MyClass2");
    }
}
// Re-declaring MyInterface
public class MyClass3 : MyClass, MyInterface
{
    public new void MyMethod()
    {
        Console.WriteLine("MyClass3");
    }
}

public class Program
{
    public static void Main()
    {
        MyInterface myInterface = new MyClass2();
        myInterface.MyMethod(); // Output: MyClass

        MyInterface myInterface2 = new MyClass3();
        myInterface2.MyMethod(); // Output: MyClass3
    }
}
```

When we redeclare the interface is like we start a new chain where the classes below will use the new interface implementation if there is any?

ChatGPT
Yes, redeclaring the interface in a derived class effectively creates a new implementation chain for that interface starting from the derived class. This can be useful when you want to ensure that a specific implementation of the interface method is used from that point in the hierarchy onwards, regardless of the base class's implementation.

Here's an example to demonstrate how redeclaring the interface affects the method resolution:

```
public interface MyInterface
{
    void MyMethod();
}

public class MyClass : MyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyClass");
    }
}

public class MyClass2 : MyClass
{
    public new void MyMethod()
    {
        Console.WriteLine("MyClass2");
    }
}

public class MyClass3 : MyClass2, MyInterface
{
    // Explicitly redeclare the interface implementation
    public new void MyMethod()
    {
        Console.WriteLine("MyClass3");
    }
}

public class Program
{
    public static void Main()
    {
        MyInterface myClass = new MyClass();
        myClass.MyMethod(); // Output: MyClass

        MyInterface myClass2 = new MyClass2();
        myClass2.MyMethod(); // Output: MyClass

        MyInterface myClass3 = new MyClass3();
        myClass3.MyMethod(); // Output: MyClass3
    }
}

```

Explanation

1. **Initial Implementation**: `MyClass` implements `MyInterface` and provides a method `MyMethod`.
2. **Method Hiding**: `MyClass2` hides `MyMethod` with the `new` keyword. This does not affect calls through the interface.
3. **Redeclaring the Interface**: `MyClass3` redeclares the `MyInterface` and provides a new implementation of `MyMethod`.

Behavior

- When `MyMethod` is called on an instance of `MyClass` through `MyInterface`, it uses `MyClass`'s implementation.
- When `MyMethod` is called on an instance of `MyClass2` through `MyInterface`, it still uses `MyClass`'s implementation because `MyClass2` hides the method but does not affect the interface implementation.
- When `MyMethod` is called on an instance of `MyClass3` through `MyInterface`, it uses `MyClass3`'s implementation because `MyClass3` redeclares the interface and provides a new implementation.

 Key Points

- **Redeclaring an Interface**: When a derived class redeclares an interface, it starts a new chain for that interface, ensuring that its implementation is used from that point onward.
- **Method Hiding vs. Overriding**: Use `new` to hide a method but remember it does not affect the interface method resolution. Use `override` to change the method behavior in the derived class while preserving polymorphism.

Conclusion

Redeclaring an interface in a derived class is like starting a new implementation chain for that interface. This ensures that any calls to the interface methods on instances of that derived class (or its subclasses) will use the new implementation provided in the derived class.

You
We can achieve the same result if we make the method virtual in the base class that implements the interface?

ChatGPT
Yes, making the method virtual in the base class that implements the interface allows derived classes to override that method, which is a more typical and straightforward approach in object-oriented programming. This approach maintains polymorphism and allows the method's behavior to be customized in derived classes without needing to redeclare the interface.
## Explicit interface implementation
You
When we do explicit interface implementation, the method will not be available when we call the method thru an instance of the class and not the interface?

ChatGPT
Yes, you are correct. The difference between the two forms of implementation lies in the visibility and accessibility of the method when dealing with instances of the class versus instances of the interface. Here's a detailed explanation:

Implicit Interface Implementation

```
public class MyClass3 : MyClass2, MyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyClass3");
    }
}
```

Characteristics:

1. **Visibility**:
- The `MyMethod` is public and accessible through instances of both `MyClass3` and `MyInterface`.
2. **Method Resolution**:
- When you call `MyMethod` on an instance of `MyClass3`, it will execute `MyClass3`'s implementation.
- When you call `MyMethod` on an instance of `MyInterface`, which is implemented by `MyClass3`, it will also execute `MyClass3`'s implementation.

`MyClass3 myClass3 = new MyClass3(); myClass3.MyMethod(); // Output: MyClass3  MyInterface myInterface = new MyClass3(); myInterface.MyMethod(); // Output: MyClass3`

Explicit Interface Implementation

```
public class MyClass3 : MyClass2, MyInterface
{
    void MyInterface.MyMethod()
    {
        Console.WriteLine("MyClass3");
    }
}
```

Characteristics:

1. **Visibility**:
- The `MyMethod` is only accessible through instances of `MyInterface`.
- It is not accessible directly through instances of `MyClass3`.
2. **Method Resolution**:
- When you call `MyMethod` on an instance of `MyInterface`, it will execute the explicit interface implementation in `MyClass3`.
- When you call `MyMethod` on an instance of `MyClass3`, there is no direct method to call, and the compiler will raise an error if you try to call `MyMethod`.

Example:

```
MyClass3 myClass3 = new MyClass3();
// myClass3.MyMethod(); // Error: 'MyClass3' does not contain a definition for 'MyMethod'

MyInterface myInterface = new MyClass3();
myInterface.MyMethod(); // Output: MyClass3

```

Summary:

- **Implicit Implementation**: The method is public and part of the class's public interface. It can be called directly on the class instance and through the interface.
- **Explicit Implementation**: The method is only part of the interface and can only be called through an interface reference. It is not part of the class's public interface, meaning you cannot call it directly on the class instance.

Practical Use Cases:

- **Implicit Implementation**: Useful when the method should be publicly accessible and used both through the class instance and the interface.
- **Explicit Implementation**: Useful when you want to provide a specific implementation for an interface method that should not be part of the class's public API. This can help avoid naming conflicts and make the class's API cleaner.

You
If we redeclare an interface, we begin a new interface implementation down the chain of derived classes, however if we don't change the method behavior, the default implementation in the base class is still active?

ChatGPT
Yes, your understanding is correct. When you redeclare and implement an interface in a derived class, you effectively provide a new implementation for that interface method within the derived class. This new implementation will be used when the derived class is referenced through the interface type. However, if you don't redeclare and implement the interface method in the derived class, the default implementation from the base class will be used.

Here's a detailed explanation with examples:

Default Behavior Without Redeclaration

If you don't redeclare the interface in a derived class, the implementation from the base class will be used.

```
public interface MyInterface
{
    void MyMethod();
}

public class MyClass : MyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyClass");
    }
}

public class MyClass2 : MyClass
{
    // No redeclaration of MyInterface
}

public class Program
{
    public static void Main()
    {
        MyInterface myInterface = new MyClass2();
        myInterface.MyMethod(); // Output: MyClass
    }
}
```

Redeclaring the Interface

When you redeclare the interface in a derived class, you provide a new implementation for the interface method.

```
public interface MyInterface
{
    void MyMethod();
}

public class MyClass : MyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyClass");
    }
}

public class MyClass2 : MyClass, MyInterface
{
    // Redeclaring the interface and providing a new implementation
    public new void MyMethod()
    {
        Console.WriteLine("MyClass2");
    }
}

public class Program
{
    public static void Main()
    {
        MyInterface myInterface = new MyClass2();
        myInterface.MyMethod(); // Output: MyClass2
    }
}
```

Explicit Interface Implementation

If you explicitly implement the interface in a derived class, the method will be accessible only through the interface type. Additionally, you cannot explicitly implement a method without redeclaring the interface.

```
public interface MyInterface
{
    void MyMethod();
}

public class MyClass : MyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("MyClass");
    }
}

public class MyClass2 : MyClass, MyInterface
{
    // Explicit interface implementation
    void MyInterface.MyMethod()
    {
        Console.WriteLine("MyClass2");
    }
}

public class Program
{
    public static void Main()
    {
        MyClass2 myClass2 = new MyClass2();
        // myClass2.MyMethod(); // This would result in a compile-time error

        MyInterface myInterface = myClass2;
        myInterface.MyMethod(); // Output: MyClass2
    }
}
```

Summary

1. **Default Behavior Without Redeclaration**: The base class implementation of the interface method is used.
2. **Redeclaring the Interface**: You provide a new implementation in the derived class, which overrides the base class implementation when accessed through the interface type.
3. **Explicit Interface Implementation**: The method is only accessible through the interface type, not the class type. Additionally, you must redeclare the interface to explicitly implement a method.

This allows you to control how interface methods are implemented and accessed in different classes in your inheritance hierarchy.
# Bookmarks 