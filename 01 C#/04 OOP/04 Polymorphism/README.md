# General
Полиморфизма е четвъртия важен стълб / принцип на ОПП, след абстракция, наследяване и енкапсулация:
При наследяването правим нещо, което другите класове разширяват и преизползват. 
Енкапсулацията има за цел да скрие данните с за да ги валидира и контролира, за да сме сигурни че нашия клас винаги получава и работи с правилна информация. 
Абстракцията скрива цялата ненужна за външния свят информация, с цел да намали сложността на класа, също така класовете ни да имат интерфейси, които да описват основните методи и идея на класа. Така може да имплементираме този интерфейс към различни класове, които да стават взаимно заменяеми.

Благодарение на факта че може да заменяме и да не се интересуваме от точната конкретика на обекта, който записваме в дадена променлива, а да използваме негов метод, където конкретната имплементация на метода зависи от записания обект, това е полиморфизма - много форми.

Полиморфизма се занимава основно с методи и тяхното поведение и това кой точно метод да бъде извикан.

Когато базовия клас дефинира даден метод като virtual и след това даден клас промени поведението му, а трети клас който наследява втория клас също промени поведението му, се получава по-сложна йерархия от класове и когато извикаме метода, става объркване какво ще е точното поведение на метода. Полиморфизма дава различни възможности за извикване на методи по назад в йерархията. Друг сценарии е когато примерно имаме клас `Аnimal` с метод `MakeSound()` то този метод има различно поведение спрямо това, какъв вид животно е наследяващия клас. Когато извикаме даден метод примерно `MakeSound()`, той може да е някой от всичките наследници на `Аnimal`, кой точно зависи от конкретния тип данни записани в променливата от тип `Animal`. Извиква се онзи метод от многото възможности на `MakeSound()`, в зависимост от това дали в променливата от тип `Animal` се намира котка, куче и тн. Това е полиморфизма - поведението на извикания метод, да има поведението на текущата форма / обект, на данните записани в променливата.

![](Pasted%20image%2020240609104437.png)
## Variable Type and Data Type
![](Pasted%20image%2020240609133436.png)

Трябва да се прави разлика между декларирането на една променлива и записването на първоначалната й стойност.
Първото нещо е типа на променливата - нещото което пишем при декларирането на променливата преди нейното име, без значение какво пишем в дясно от равното.
Примерно `IAnimal animal = new Person()` - са два различни типа данни - типа на променливата и типа на данните записани в променливата.
Разликата не може да е произволна, има правила с които трябва да се съобразяваме - типа на променливата трябва или да съвпада с типа на подадените данни или да е по базов тип от типа на подадените данни. Това правило важи и при параметрите на методите. 
Това е плюса, че в базовите променливи, може да запишем всичко нагоре по йерархията. 
Минуса на това да използваме базов тип на променливата е, че имаме достъп само до онези неща, описани в базовия тип, тоест не може да използваме пълните възможности на наследяващия клас, който се избрали като тип данни.

Много важен принцип е че когато избираме типа данни на променливата или на метода или дори какъв да е типа данни на дадена колекция, винаги избираме най-базовия възможен тип данни, който ни върши работа. Примерно ако имаме метод, който приема като параметър `IEnumerable` може да го извикаме с всички колекции, които го имплементират и които искаме просто да foreach-нем. Или когато имаме метод `MakeSound()` в интерфейса `IAnimal` и направим променлива от тип `IAnimal`, и я инициализираме с тип данни `Cat` при изпълнение на метода `MakeSound()` ще се изпълни поведението на `MakeSound()` записано в класа `Cat`. Това е полиморфизма - извикваме един метод, а от многото възможности на този метод, ще се извика онзи, който е записан в типа данни подадени по време изпълнение на програмата.

**Variable type** - е това което определяме преди името на променливата и никога не се променя. Това се случва compile time, тоест докато пишем кода, типа данни на променливата е известен.
**Data type** - е типа който записваме в променливата и който може да се променя по време на изпълнение (runtime) на програмата ни. Примерно на `IAnimal animal` може да зададем първоначално `new Cat()` и по надолу в програмата да кажем `animal = new Dog()`. Когато извикваме даден метод, се гледа типа на данните записани в променливата, неговото поведение зависи от тях.

Когато ползваме `var` вместо типа данни на променливата, това което се случва е че `var` бива заменен с типа на данните, които сме посочили. С други думи, направи типа на променливата в ляво, същия като типа на данните в дясно.

Езици като JS не разполагат с тип данни на променливата, наричат я `let` или `var`.
## Operator - is
Когато искаме да разберем какъв е типа данни записан в определена променлива, ползваме оператора `is`

```
if (animal is Dog)
{
    Console.WriteLine("Yes, it is dog!");
}
```

Тази проверка ще връща true и за всички класове, от които класа Dog е наследил.

Трябва да се избягва да се ползва подобна проверка, защото не е добра практика. Ако нещо ни трябва да е конкретен тип, трябва да направим променливата му този тип, а не да правим проверки, освен в много редки случаи. 
Вместо да се правят такива проверки за да се изпълнят дадени методи, това трябва да се решава от конкретния тип. С други думи, не проверяваме дали даден обект е куче за да извикаме метода `Bark()` или да проверяваме дали е котка за да извикаме метода `Meow()`, но трябва да имаме метод `MakeSound()`, който когато имаме куче да лая, а когато е котка да мяука.
### Casting / Converting

Ако искаме да достъпим всички методи в типа данни, които не се виждат заради по базовия тип на променливата, може да ползваме casting:

```
((Dog)animal).Bark();
```

Така се игнорира типа на променливата и се прави опит да се преобразува в `Dog`. Ако данните в `Animal` съвпадат с данните в `Dog`, вече може да ползваме пълната функционалност на `Dog`. Ако данните не съвпадат, ще хвърли exception.
#### as
Чрез оператора `as` се пробва да се преобразува типа, където при неуспешен опит, връща нулева стойност, а не exception. В примера долу са показани двата варианта за преобразуване, като в комбинация с оператора `as` ползваме и nullable оператора `?.` за да предотвратим null reference exception, ако резултата е null:

```
Animal animal = new Dog();

// Using ?. operator with as
(animal as Dog)?.Bark(); // This will call Bark() if animal is Dog, otherwise do nothing

// Direct cast without null check
((Dog)animal).Bark(); // This will throw an exception if animal is not actually a Dog
```
### is Type Pattern
Може да проверим в един ред дали даден обект е определен тип данни и да се преобразува в него, директно създавайки променлива:`

```
if (animal is Dog dog)
{
    dog.Bark();
}
```
### is Constant Pattern
По-бърз начин да използваме или оператора:

```
int a = 6;

if (a is 4 or 5 or 6)
{
    Console.WriteLine("test");
}

//The same as
int a = 6;

if (a == 4 || a == 5 || a == 6)
{
    Console.WriteLine("test");
}
```
### is var Pattern
Записва даден израз в променлива, която е валидна само в рамките на проверката и която може да се използва в дясно от създаването й:

```
        List<int> numbers = new List<int> { 1, 2, 3, 4 };
        // Using is var pattern matching
        numbers.Where(x => x % 10 is var r && r >= 1 && r <= 3)
            .ToList()
            .ForEach(x => Console.WriteLine(x));

        // Performing the same check without is var pattern matching
        numbers.Where(x => x % 10 >= 1 && x % 10 <= 3)
        .ToList()
        .ForEach(x => Console.WriteLine(x));
```

В примера `x % 10 is var r` е равносилно на `r = x % 10`. 
# Misc

# ChatGPT
## Shadowing member is private
You
What happens when the shadowing member is private in the derived class, like in the example in the code below:

```
public class BaseClass
{
    public string Property { get; set; } = "Base";

    public void MyMethod()
    {
        Console.WriteLine("From base");
    }
}

public class DerivedClass : BaseClass
{
    private string Property { get; set; } = "Derived";

    private void MyMethod()
    {
        Console.WriteLine("From derived");
    }

    public void MyMethod2()
    {
        MyMethod();
    }
}

public class Program
{
    public static void Main()
    {
        BaseClass baseClass = new BaseClass();
        DerivedClass derivedClass = new DerivedClass();

        Console.WriteLine(baseClass.Property);    // Accesses BaseClass.Property
        Console.WriteLine(derivedClass.Property); // Accesses BaseClass.Property (DerivedClass.Property is private)

        baseClass.MyMethod();      // Calls BaseClass.MyMethod
        derivedClass.MyMethod();   // Calls BaseClass.MyMethod (since DerivedClass.MyMethod is private)
        derivedClass.MyMethod2();  // Calls DerivedClass.MyMethod2 which calls DerivedClass.MyMethod
    }
}
```

- When accessing `Property` on an instance of **BaseClass**, it prints "Base".
- When accessing `Property` on an instance of **DerivedClass**, it prints "Base" because the `DerivedClass.Property` is private and not visible externally.
- When calling `MyMethod` on an instance of **BaseClass**, it prints "From base".
- When calling `MyMethod` on an instance of **DerivedClass**, it calls `BaseClass.MyMethod` because the `DerivedClass.MyMethod` is private and not visible externally. Therefore, it prints "From base".
- When calling `MyMethod2` on an instance of **DerivedClass**, it calls the private `MyMethod` within **DerivedClass**, which prints "From derived".

Summary:

- When `Console.WriteLine(derivedClass.Property)` is called, it prints "Base" because the private property in **DerivedClass** is not visible to external calls, so it accesses the public property in **BaseClass**.
- When `derivedClass.MyMethod2()` is called, it prints "From derived" because it calls the private `MyMethod` defined in **DerivedClass**.
- When `baseClass.MyMethod()` or `derivedClass.MyMethod()` is called, it prints "From base" because it calls the public `MyMethod` defined in **BaseClass**. The private `MyMethod` in **DerivedClass** is not visible to external calls.

 Conclusion:

Derived classes can shadow members from the base class. The derived class can access its own members or the base class members depending on the access modifier and the use of the `new` keyword for shadowing. From outside the derived class, if the shadowing member is public, it is accessed. If the shadowing member is private, the base class member is accessed.

In C#, derived classes can shadow members from the base class using the `new` keyword. The shadowed member in the derived class hides the base class member. When accessing these members:

- If the shadowing member in the derived class is public, it is accessed by default.
- If the shadowing member is private, the base class member is accessed from outside the derived class.
- Derived classes can still access the base class member using the `base` keyword.

For instance, if both members are public, the derived member is accessed. If the derived member is private, only the base member is accessible from outside the class.

Note:

This behavior highlights the difference between method overriding and method hiding (shadowing):

- **Overriding** involves using the `override` keyword and allows the derived class to provide a specific implementation of a virtual method defined in the base class.
- **Hiding (shadowing)** involves using the `new` keyword (though not required for private methods) and provides a new implementation that hides the base class method within the derived class scope.

Additional Note on Properties:

- **DerivedClass.Property** is private and hides the public property in **BaseClass** only within the scope of **DerivedClass**. External calls to `Property` on an instance of **DerivedClass** will access the public property in **BaseClass**.
## Memory Allocation
You
When you have a derived class, does the memory allocation follow the same order of the base class and after the base class members are written in the memory, then the new members of the derived class are added after that?

ChatGPT

Yes, in C#, the memory layout for a derived class follows a specific order that ensures compatibility and consistent access to members, adhering to the principles of inheritance and object-oriented design. Here’s how it works:

 Memory Layout of Derived Classes

When you create a derived class from a base class in C#, the memory for an object of the derived class is allocated in a way that maintains the layout of the base class first, followed by any additional members introduced by the derived class. This is important for ensuring that polymorphism and type compatibility work as expected.

Let's consider a scenario with a base class and a derived class:

```
public class BaseClass
{
    public int BaseField;
    public void BaseMethod() { }
}

public class DerivedClass : BaseClass
{
    public int DerivedField;
    public void DerivedMethod() { }
}
```

Memory Layout

1. **Base Class Memory Layout:**
- When you define `BaseClass`, its memory layout in the heap is as follows:

```
+------------------------+
| BaseField              | <-- Memory for BaseClass fields
|------------------------|
| BaseMethod()           | <-- Memory for BaseClass methods
+------------------------+
```
 
2. **Derived Class Memory Layout:**
- When you define `DerivedClass`, which inherits from `BaseClass`, the memory layout for an object of `DerivedClass` extends the layout of `BaseClass`:

```
+------------------------+
| BaseField              | <-- From BaseClass
|------------------------|
| BaseMethod()           | <-- From BaseClass
|------------------------|
| DerivedField           | <-- Additional field from DerivedClass
|------------------------|
| DerivedMethod()        | <-- Additional method from DerivedClass
+------------------------+
```

Order of Memory Allocation
- **Base Class Members:** The members of the base class are allocated first in the memory block for the derived class object.
- **Derived Class Members:** The members introduced by the derived class follow immediately after the base class members in the memory block.

```
DerivedClass obj = new DerivedClass();
obj.BaseField = 10;
obj.DerivedField = 20;

BaseClass baseVar = obj;
baseVar.BaseField = 30; // Accessing BaseClass member
// baseVar.DerivedField = 40; // Compile-time error: BaseClass does not contain a definition for 'DerivedField'

DerivedClass derivedVar = (DerivedClass)baseVar;
derivedVar.DerivedField = 40; // Accessing DerivedClass member
```

 Summary

- **Memory Allocation Order:** Base class members are allocated first in the memory block for the derived class object, followed by any additional members introduced by the derived class.
- **Accessing Members:** A variable of the base class type can access only the members of the base class. Accessing members of the derived class requires casting the base class variable to the derived class type.
- **Continuous Memory Layout:** The memory layout in the heap is continuous and includes all members of both the base class and the derived class.

This memory layout ensures that polymorphism and inheritance work seamlessly, allowing derived class objects to be treated as base class objects when needed, while also providing access to their specific members when appropriately casted.

You
So that's why the base class type can only access its members, because it has visibility only to the initial portion of the allocated memory (which corresponds to the size needed for the base class) of the derived class.

ChatGPT

Exactly, that's correct!

When you have a base class variable that references an object of a derived class, the base class variable can only directly access members that are defined in the base class itself. This is because the base class variable only knows about the layout and members of the base class.

Here's a summary of why this happens:

1. **Memory Layout**:
- The memory for an object of a derived class includes all the members of the base class followed by the members of the derived class.
- For example, if you have a `BaseClass` with fields and methods, and then you derive from it with a `DerivedClass` that adds more fields and methods, the memory is laid out in that order.
2. **Base Class Variable**:
- When you use a base class variable to reference an object of the derived class, the variable only "sees" the members that belong to the base class part of the object's memory layout.
- Any additional members that are part of the derived class are beyond the scope of what the base class variable can directly access.
3. **Accessing Derived Class Members**:
- To access members that are specific to the derived class (those not present in the base class), you need to cast the base class variable to the derived class type.
- This casting operation tells the compiler to treat the base class reference as if it were a reference to the derived class, allowing access to those additional members.

Here's a simple example to illustrate this:

```
public class BaseClass
{
    public int BaseField;
    public void BaseMethod() { Console.WriteLine("Base Method"); }
}

public class DerivedClass : BaseClass
{
    public int DerivedField;
    public void DerivedMethod() { Console.WriteLine("Derived Method"); }
}

public class Program
{
    static void Main()
    {
        DerivedClass derivedObj = new DerivedClass();
        derivedObj.BaseField = 10;  // Accessing BaseClass member
        derivedObj.DerivedField = 20;

        BaseClass baseVar = derivedObj;
        baseVar.BaseField = 30;  // Accessing BaseClass member
        // baseVar.DerivedField = 40;  // Compile-time error: BaseClass does not contain a definition for 'DerivedField'

        // Casting to access DerivedClass members
        DerivedClass derivedVar = (DerivedClass)baseVar;
        derivedVar.DerivedField = 40;  // Accessing DerivedClass member
        derivedVar.DerivedMethod();   // Output: Derived Method
    }
}
```

Explanation:

- `BaseClass` defines `BaseField` and `BaseMethod`.
- `DerivedClass` extends `BaseClass` by adding `DerivedField` and `DerivedMethod`.
- When you create an object of `DerivedClass`, memory is allocated for both `BaseClass` and `DerivedClass` members.
- A `BaseClass` variable (`baseVar`) can access `BaseField` and `BaseMethod`.
- To access `DerivedField` and `DerivedMethod`, you need to cast `baseVar` to `DerivedClass`.

This mechanism ensures that base class references are type-safe and that the correct members are accessed, maintaining the principles of encapsulation and inheritance in object-oriented programming.

You
Is having a variable of the interface type and assigning it an instance of the class that implements the interface similar to the concept of base and derived class inheritance? When we create an instance of the class, all the members defined by the interface are initialized along with the class-specific members. When the variable is of the interface type, only the interface members are accessible. Are the interface members allocated first in memory followed by the class-specific members, similar to how memory allocation works with base and derived classes?

ChatGPT
Yes, the concept of having a variable of the interface type and assigning it an instance of a class that implements the interface is very similar to the concept of base and derived class inheritance. Here’s a detailed explanation of this similarity and how memory allocation works in both cases:

Similarity to Inheritance

1. **Interface and Implementing Class**:
- When you have a variable of the interface type, it can hold a reference to any object of any class that implements that interface.
- When you create an instance of the class, all the members defined in the interface, as well as the unique members of the class, are initialized.
- When you access the instance through the interface variable, you can only access the members defined by the interface.
2. **Base and Derived Classes**:
- When you have a variable of the base class type, it can hold a reference to any object of any class that derives from that base class.
- When you create an instance of the derived class, all the members of the base class, as well as the additional members of the derived class, are initialized.
- When you access the instance through the base class variable, you can only access the members defined by the base class.

Memory Allocation

The memory allocation in both cases follows a similar logical structure, but there are some nuances:
1. **Base and Derived Classes**:

- The base class members are allocated first in the memory layout of the object.
- The derived class members are allocated after the base class members in memory.
- This is why a base class reference can only see and access the base class members, as it only knows about and has access to the initial portion of the object's memory that corresponds to the base class.
2. **Interface and Implementing Class**:
- When an instance of a class implementing an interface is created, all the members of the class are allocated together in a single memory block.
- The interface reference can access the members that are part of the interface.
- The interface reference essentially points to the object, and the runtime ensures that calls to interface methods are dispatched correctly to the class's implementation.
- The exact layout in memory might not be strictly "interface members first", but the runtime handles method dispatch to ensure the correct methods are called.

Example Code

```
public interface IExample
{
    void InterfaceMethod();
}

public class ExampleClass : IExample
{
    public int ClassMember { get; set; }

    public void InterfaceMethod()
    {
        Console.WriteLine("InterfaceMethod implemented in ExampleClass");
    }

    public void ClassMethod()
    {
        Console.WriteLine("ClassMethod in ExampleClass");
    }
}

public class Program
{
    public static void Main()
    {
        IExample example = new ExampleClass();
        example.InterfaceMethod();  // Accessible
        // example.ClassMethod();   // Not accessible, compile-time error

        ExampleClass specificExample = new ExampleClass();
        specificExample.InterfaceMethod(); // Accessible
        specificExample.ClassMethod();     // Accessible
    }
}
```

Summary

- When you use a variable of the interface type, it can only access the members defined by the interface, similar to how a base class variable can only access base class members.
- The actual memory layout ensures that all members are accessible, but the type of the reference (interface or base class) dictates which members are visible and accessible.
- The runtime manages method dispatch to ensure the correct implementations are called, whether the reference is of the interface type or the base class type.
### Memory size
You
Is it correct to say that in C#, the memory allocation size for a variable is determined by the data type, not the variable type, and that the variable type dictates the level of visibility we have over the underlying data type?

ChatGPT
In C#, the memory allocation and the way data is stored indeed depend on the data type, not the variable type. The variable type determines how much visibility and control we have over the data stored in memory. Here's a detailed explanation of these concepts:

Data Type and Memory Allocation

The data type (e.g., `int`, `double`, `string`, `CustomClass`) dictates how much memory is allocated for a variable and how that memory is structured. Each data type has a predefined size and layout in memory:

- **Value Types** (e.g., `int`, `double`, `struct`): These types store the actual data directly in the memory allocated for the variable.
- **Reference Types** (e.g., `string`, `class`): These types store a reference (or pointer) to the actual data, which is stored on the heap.

Variable Type and Visibility

The variable type determines how we can interact with the data and which members (properties, methods, fields) are visible to us. This is crucial for polymorphism and encapsulation:

- **Base Class Reference to Derived Class Object**: If a variable is declared as a base class type but assigned an instance of a derived class, the variable can only access the members defined in the base class. However, if a method in the base class is overridden by the derived class, the overridden method in the derived class will be called.
- **Interface Reference to Implementing Class Object**: If a variable is declared as an interface type but assigned an instance of a class implementing that interface, the variable can only access the members defined in the interface.

Let's consider an example to illustrate these concepts:

```
public class BaseClass
{
    public virtual void MyMethod()
    {
        Console.WriteLine("From base");
    }
}

public class DerivedClass : BaseClass
{
    public override void MyMethod()
    {
        Console.WriteLine("From derived");
    }
}

public interface IMyInterface
{
    void InterfaceMethod();
}

public class ImplementingClass : IMyInterface
{
    public void InterfaceMethod()
    {
        Console.WriteLine("From interface implementation");
    }
}

public class Program
{
    public static void Main()
    {
        // Base class reference, derived class object
        BaseClass baseRef = new DerivedClass();
        baseRef.MyMethod(); // Outputs: "From derived"

        // Interface reference, implementing class object
        IMyInterface interfaceRef = new ImplementingClass();
        interfaceRef.InterfaceMethod(); // Outputs: "From interface implementation"

        // Trying to access members not defined in the variable type
        // baseRef.DerivedClassMethod(); // Error: BaseClass does not contain a definition for 'DerivedClassMethod'
        // interfaceRef.ImplementingClassMethod(); // Error: IMyInterface does not contain a definition for 'ImplementingClassMethod'
    }
}
```

Summary

- **Memory Allocation**: Determined by the data type. Value types store data directly, while reference types store a reference to the data on the heap.
- **Variable Type**: Determines visibility and access. When a variable is declared as a base class or interface type, it only has access to the members defined in that base class or interface, even if the actual object is of a derived or implementing type.
- **Polymorphism**: Allows methods to be overridden in derived classes and ensures that the correct method is called at runtime based on the actual object type.

This separation of memory allocation and visibility allows for powerful features like polymorphism and encapsulation in C#.
## Casting
You
Why Casting is Necessary?

ChatGPT
The need for casting arises because of how C# handles type safety and polymorphism:

- **Interface Type**: The `example` variable is of type `IExample`, so the compiler only knows about the members defined in the `IExample` interface.
- **Class Type**: The `specificExample` variable is of type `ExampleClass`, so it can access all members of `ExampleClass`.
### Safe Casting

You can use the `as` keyword for safe casting, which returns `null` if the cast fails, or the `is` keyword to check the type before casting. Here are examples of both:

Using `as` for Safe Casting:

```
ExampleClass specificExample = example as ExampleClass;
if (specificExample != null)
{
    specificExample.ClassMethod();  // Safe to access
    specificExample.ClassMember = 42;
    Console.WriteLine($"ClassMember value: {specificExample.ClassMember}");
}
else
{
    Console.WriteLine("Casting failed");
}
```

Using `is` for Type Checking:

```
if (example is ExampleClass specificExample)
{
    specificExample.ClassMethod();  // Safe to access
    specificExample.ClassMember = 42;
    Console.WriteLine($"ClassMember value: {specificExample.ClassMember}");
}
else
{
    Console.WriteLine("Casting failed");
}
```

Summary

- **Direct Assignment**: `ExampleClass specificExample = example` is not allowed without casting because `example` is of type `IExample`.
- **Casting**: Use explicit casting `(ExampleClass)example`, or safe casting using `as` or `is` to access members specific to `ExampleClass`.
- **Type Safety**: The compiler ensures type safety by requiring casts when assigning a more general type (interface) to a more specific type (class).
# Bookmarks 
