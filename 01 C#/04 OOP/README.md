# General
Чрез наследяването, може да напишем дадена функционалност на едно място в базов клас, която да се ползва от други класове, които разширяват допълнително тази функционалност. Двете основни цели са да се преизползва код и да се разширим съществуващ код.
С други думи, наследяването ни дава възможност да напишем функционалностите в един клас наречен Superclass - Parent или най-често Base, след което други класове я получават и разширят.

Името на базовия клас трябва да е общото нещо, между всички класове, които ще го наследят.

Наследяващите класове са наречени Subclass - Child или Derived classes.

Синтаксиса е две точки след child класа и името на базовия клас - `class Child : BaseClass`

Когато имаме няколко взаимосвързани класа, се нарича йерархия.

Класовете не може да наследяват повече от един клас, но могат да имат неограничено много наследници.

Ако имаме базов клас `Person`, който е наследен от клас `Student`, който пък е наследен от `UniversityStudent`, то `UniversityStudent` има всичко което има в предишните два класа + неговата собствена функционалност.

Всички класове в C#, задължително наследяват класа `Object`, от там идват и четирите метода общи за всички - `ToString(), Equals(), GetHashCode(), GetType()`

Като добра практика е класовете които са нагоре в йерархията, да не знаят и да не ползват нищо от долните класове.
## Reusing Constructors
Конструкторите са единственото нещо, което не се наследява от базовия клас. За да ползваме базов конструктор, трябва да напишем `: base()` с въведени нужните елементи след нашия конструктор. 

Ако базовия клас няма празен конструктор, то наследяващия клас задължително трябва да има конструктор, викащ някои от наличните конструктори в базовия клас.

Когато ползваме конструктор в наследяващ клас, първо се изпълнява конструктора в базовия клас и после надолу по класовете, докато стигнем до конструктора в конкретния клас. 
## Transitive Relation
Когато клас 3 е свързан с клас 2, а клас 2 е свързан с клас 1, то клас 3 транзитивна релация с клас 1.
## Access Modifiers
Определят кой може да вижда дадения клас или негов член. Целта на тези модификатори е да направят кода по-лесен за разбиране и да скрият вътрешни детайли, които не са необходими на външния свят.

private - достъпно само в рамките на същия клас.
protected - достъпно в рамките на същия клас и в наследените класове, включително от други проекти.
internal - достъпно в рамките на същия проект (assembly).
public - достъпно от всяка точка. 

Комбинация от предишните:
protected internal - достъпно в рамките на същия проект и във всички наследени класове, независимо от проекта.
private protected - достъпно в рамките на същия клас и в наследените класове, но само в рамките на същия проект.

Ако не сложим модификатор за достъп, по подразбиране е най-ниското ниво - private, само при класовете е internal.
## Shadowing
Когато името на променливата, съвпада с името на дадено поле, трябва да използваме `this.` за да стане ясно че посочваме полето.

Друг вид shadowing е ако на даден метод му сложим ключовата дума `new` вместо `override` . Когато възможността за overriding на метод от базовия клас не е налична, може да се използва ключовата дума `new`. Това не е препоръчително, особено когато става дума за наследяване и полиморфизъм, защото новият метод няма да бъде достъпен, когато обектът се използва като инстанция от базовия клас.

Вид shadowing е и ако имаме в наследяващия клас поле със същото име като в базовия клас. Чрез [this / base](01%20Inheritance.md#Misc##base%20/%20this) може да правим разлика между двете, но е добра практика да се избягват еднаквите имена.
## Virtual Method
Ако направим даден метод или property виртуални в базовия клас, тогава може да бъдат override-нати в наследяващите класове. Това означава, че взимаме всичко от базовия клас, а метода или property-то които сме override-нали са с променено поведение. С други думи, базовия клас дава съгласието си, те да бъдат променяни.
## Sealed
За да забраним даден клас да има наследници се ползва ключовата дума sealed - `sealed class MyClass`
Това гарантира, че този клас ще остане последен в йерархията и под него няма да има други класове.

Може да се използва и при методи или properties, когато overridе-ваме даден метод или property при клас наследник. Ако напишем след`override` `sealed`, тогава забраняваме на класовете които наследяват от този клас, да променят поведението на метода или property-то. Изтрива virtual, за всички класове наследници.
## Class relations / connections
В ООП има два вида връзки между класовете:
1 - Extension (Inheritance) (IS-A relation) - когато имаме наследяване - даден клас наследява друг клас, примерно `Dog` наследява `Animal`.
2 - Composition (HAS-A relation) - когато един клас използва като property или field друг клас, без да го наследява. Пример за такава връзка са класовете `Car` и `Engine`.
# Misc
Наследниците получават интерфейсите на базовия клас.

Добре е класовете да се подреждат тематично в отделни папки вътре в проекта, за да е по прегледно. Изкарването на класовете в отделни проекти е същото като изкарването им в отделни папки, само че освен using-a, слагаме и референция към другия проект.

Винаги трябва да ползваме `Environment.NewLine` когато ни трябва нов ред, защото при различните платформи се използват различни символи: Windows използва `\r\n` за нов ред. Linux и macOS използват само `\n` за нов ред.
## base / this
Когато ползваме `this.` пред някое пропърти или поле в даден клас, това винаги означава членовете в този клас.
Ползвайки `base.` получаваме достъп само до нещата в базовия клас. Много рядко се налага да го ползваме. Примерно ако сме override-нали определен базов метод в нашия клас и искаме да ползваме базовия му вариант, трябва да сложим `base.` 
Друг вариант да се наложи да го ползваме е ако има [shadowing](01%20Inheritance.md#General##Shadowing).
## Polymorphism
Полиморфизмът позволява на обект от производен клас да бъде използван като обект от базовия клас. 
Може да направим обект от тип базов клас присвоявайки му наследник клас. В такъв случай обектът ще има само членовете (методи и свойства), дефинирани в базовия клас, но ще използва тези, които са предефинирани (overridden) в наследника, ако съществуват.
Поради тази причина, може да присвояваме всички останалите обекти на базовия клас object.

Пример за полиморфизъм:

```
IEnumerable<int> items = new List<int>() {1,2,3,4 };
IEnumerable<int> items2 = new int[] { 1, 2, 3, 4 };
```

`IEnumerable` интерфейса се явява като базов клас, където всеки от класовете които го имплементират, може да бъдат посочени. Прави се в случаите, когато не ни трябва нищо друго, освен възможността да foreach-нем дадена колекция. Много удобно е да се посочи като параметър в метод, защото по този начин, може да подадем различни колекции.
## Abstract Methods
Това са подобни на виртуалните методи, но се ползва ключовата дума `abstract` и нямат тяло, всеки един от наследниците на класа, трябва да го имплементира.
# ChatGPT
## Memory Allocation

1. **Value Types in Classes:**
    - When a value type (e.g., `int`) is a member of a class, the actual value is stored directly within the contiguous memory block allocated for the object on the heap. There is no reference or pointer for these value types within the object.
2. **Reference Types in Classes:**
    - When a reference type (e.g., `string` or `array`) is a member of a class, the class instance stores a reference (pointer) to the actual data, which is stored separately on the heap.
    - Modifying a reference type member updates the reference to point to the new location of the updated data.
3. **Heap Allocation:**
    - The object itself, along with its value type members, resides in a contiguous block of memory on the heap.
    - The object header, which includes metadata about the object, is also part of this contiguous block.
4. **Example with Value Types:**
    - For a class with `int` members, the `int` values are stored directly within the object's memory on the heap.
5. **Example with Reference Types:**
    - For a class with a `string` or an array member, the memory layout includes a reference to the string or array. The actual string or array data is stored separately on the heap.
    - For an array (e.g., `int[]`), the class instance contains a reference to the array. The array itself is a separate object on the heap, with its own header, length, and elements stored contiguously.
6. **Consistent Object Size:**
    - All instances of a class have the same size in memory regarding the space allocated for references, regardless of the size of the referenced objects.
7. **Value Types in Local Methods:**
    - When a value type is declared within a method (as a local variable), it is typically stored on the stack. The stack is used for local variables because it is fast and has a last-in-first-out (LIFO) structure.
    - If a method involves heap-allocated objects or closure contexts (e.g., lambdas or local functions capturing local variables), those value types might also be moved to the heap.
    - 
In summary:
- Value types declared as local variables in methods are typically stored on the stack.
- Value types that are members of a class are stored directly within the object's memory on the heap.
- Reference types, such as arrays or strings within a class, have their references stored in the object's memory, but their actual data is stored separately on the heap.
## .NET Framework / C# Language
You

So in simple words - the compiler is translating the source code to machine language. The source code is written using the syntaxis rules determined by the C# version. The created executable file is executed using the .Net Framework which is also responsible to provide the basic classes and libraries.

ChatGPT

Exactly, you've got it!
Here's a simplified breakdown:
1. **Compiler (Roslyn)**:
    - **Role**: Translates C# source code into Intermediate Language (IL), which is a low-level, platform-independent bytecode.
    - **C# Language Version**: Defines the syntax, semantics, and features of the C# language.
    - **Output**: Generates an assembly (`.dll` or `.exe`) containing IL code.
2. **.NET Framework/.NET Platform**:
    - **Role**: Provides the runtime environment (Common Language Runtime - CLR) that executes the IL code.
    - **Includes**: Base Class Library (BCL), Framework Class Library (FCL), and other libraries.
    - **Execution**: Manages memory, threads, exceptions, and other runtime services.
3. **Relationship**:
    - The compiler (Roslyn) translates C# source code into IL code based on the rules and features of the C# language version specified.
    - The .NET framework/platform executes the IL code using the CLR, which provides necessary runtime services and access to libraries.
4. **Summary**:
    - **Compiler**: Translates C# code into IL code based on C# language version rules.
    - **.NET Framework**: Executes IL code on the CLR, providing runtime services and libraries.
    - **C# Language Version**: Specifies the syntax and features used in the source code, influencing how it's translated into IL code.

In essence, the compiler translates your C# source code into a form (IL) that can be executed by the .NET runtime (CLR) provided by the .NET framework/platform. The framework not only executes your code but also provides essential libraries and services that your application relies on.
### Compatibility Scenarios
You
The issue if lets say the version has changed and new syntaxes rules are created or old rules are edited is that it will no longer work with the old libraries provided by the older .NET Framework? Likewise the new libraries will not work correctly with older rules defined in the previous C# versions?

ChatGPT
Yes, you've captured the essence of potential compatibility issues between different versions of the C# language and the .NET framework/platform. Let's break it down:
 1. New C# Language Features
- **New Syntax and Rules**: Newer versions of C# may introduce new syntax, language features, or modify existing rules.
- **Compiler Dependency**: The compiler must support the specific C# language version to translate the new syntax correctly.
- **Compatibility with Libraries**:
    - New language features might not be compatible with older .NET frameworks because those frameworks may not include the necessary runtime support for those features.
    - For example, newer language features like records or pattern matching introduced in C# 9 or later require a .NET runtime that supports them.
 2. Older .NET Frameworks
- **Runtime Limitations**: Older .NET frameworks (like .NET Framework 4.x) might not support the runtime features required by newer C# language versions.
- **Library Mismatch**: Libraries written using new C# features might not work on older frameworks because the framework does not recognize the new IL instructions generated by the compiler.
 3. New .NET Frameworks
- **Enhanced Libraries**: Newer .NET frameworks come with updated and new libraries, providing more functionality and performance improvements.
- **Backward Compatibility**: New frameworks strive to maintain backward compatibility, but there may be breaking changes or deprecated features.
- **New Capabilities**: They support newer C# language features, ensuring that applications can leverage the latest enhancements.

 Using New C# Features on Older .NET Frameworks
- **Compilation Issues**: The compiler might generate IL code that older frameworks cannot execute.
- **Runtime Errors**: Even if compilation succeeds, runtime errors may occur due to missing support for new features in the older runtime.
 Using Older C# Features on New .NET Frameworks
- **Full Compatibility**: Generally, this works fine as newer frameworks are designed to support older language features.
- **Deprecation**: There might be warnings about deprecated features or better alternatives in newer frameworks.
### Compilation Process
1. **Writing Source Code**: You write your C# source code using syntax rules defined by a specific C# language version.
2. **Referencing Libraries**: During development, your code references libraries provided by the .NET framework or other external libraries. These references are typically specified in your project file (`.csproj`).
3. **Compiling**: The compiler (such as `csc.exe` for C#) compiles your source code into Intermediate Language (IL) code. The output is an assembly, which is a binary file in the form of a DLL (Dynamic Link Library) or an EXE (Executable).
 Post-Compilation Process
4. **Blending with Existing Libraries**: The produced IL code (in the form of assemblies) contains references to other assemblies (libraries) it depends on. These dependencies are managed by the .NET framework, which ensures that all required libraries are available at runtime.
### Execution Process
5. **Loading Assemblies**: When you run your application, the .NET runtime (such as the .NET Core runtime, .NET 5+, or the .NET Framework runtime) loads your assembly along with its referenced assemblies (libraries).
6. **Just-In-Time Compilation (JIT)**: The runtime uses a Just-In-Time (JIT) compiler to translate the IL code into native machine code that can be executed by the operating system.
7. **Runtime Execution**: The native code is executed by the operating system. The .NET runtime provides services like garbage collection, exception handling, and type safety during execution.
### Example Scenario
- **Development**: You write code that uses classes from `System.Collections.Generic`, a part of the .NET framework.
- **Compilation**: The compiler produces an assembly (e.g., `MyApp.exe`) that contains IL code and references to `System.Collections.dll`.
- **Blending**: At runtime, the .NET runtime ensures `MyApp.exe` and `System.Collections.dll` are both loaded into memory.
- **Execution**: The JIT compiler translates IL code from both `MyApp.exe` and `System.Collections.dll` into native code. The runtime then executes this native code.
### Detailed Steps Involved in Blending and Execution:
1. **Application Startup**: When you start your application, the .NET runtime identifies the entry point (typically the `Main` method).
2. **Dependency Resolution**: The runtime checks for all referenced assemblies. This includes framework libraries (like `System.Collections.dll`) and any third-party libraries.
3. **Loading Assemblies**: The runtime loads your assembly and all referenced assemblies into memory. It ensures that the correct versions of these assemblies are available.
4. **JIT Compilation**: The IL code in your assembly and the referenced assemblies is compiled into native machine code by the JIT compiler.
5. **Execution**: The native machine code is executed, performing the tasks your application is designed to do.

By blending your new IL code with the existing library DLLs, the .NET framework ensures that your application has access to the necessary functionality provided by the framework or any other libraries you referenced. This blending process is crucial for the smooth execution of .NET applications, allowing developers to leverage the vast ecosystem of pre-built libraries.

You

All the new features that the new C# versions bring are then used in the new .NET Framework where the libraries are utilizing the new features in their code?

ChatGPT

Yes, that's correct. When new versions of C# are released, they introduce new language features, syntax improvements, and sometimes changes in behavior. These features are then utilized by developers in their source code.

When you compile your C# code, it generates Intermediate Language (IL) code, which is platform-agnostic. The .NET Framework (or .NET Core, .NET 5, .NET 6, etc.) provides libraries (in the form of DLLs) that contain implementations of various classes, methods, and functionalities.

Here's how it works:

1. **Source Code**: You write your source code using a specific version of C#.
2. **Compilation**: The C# compiler (like `csc.exe`) compiles your source code into IL code.
3. **Framework Integration**: When you use classes and methods from the .NET libraries (like `System`, `System.Collections`, etc.), you're utilizing features that are implemented in those libraries.
4. **Runtime Execution**: During runtime, when your IL code is executed, it interacts with the .NET Framework (or .NET Core/5/6), which provides the necessary runtime support for executing your code.

If your code uses new features introduced in a newer version of C#, it will compile correctly only if you're targeting a .NET Framework (or Core/5/6) version that supports those features. The libraries provided by the .NET Framework (or Core/5/6) are updated to take advantage of these new language features.

For example, if C# 9 introduces records as a new feature, the .NET Framework (or Core/5/6) will provide libraries that might include new classes or methods that use records. If you try to use records in your code and compile it with a C# 9 compiler, but run it on a system with .NET Framework 4.x (which doesn't support records), you'll get an error.

Therefore, the combination of C# version and .NET Framework (or Core/5/6) version determines which language features and library functionalities are available to you when writing and running your code.

You

.NET Framework have backward compatibility in terms if we use older C# version the code should still be executed in the newest .NET Framework, however if we use new C# version it will not be executed on older .NET Framework right?

ChatGPT

Yes, you're correct.

.NET Framework, .NET Core, .NET 5, .NET 6, and other versions generally maintain backward compatibility. Here’s how it works in terms of C# version and .NET framework version compatibility:

1. **Backward Compatibility**:
    - **Older C# Versions**: If you write C# code using an older version of the language (e.g., C# 7, C# 8) and compile it, the resulting IL code should be executable on newer versions of the .NET framework (e.g., .NET Framework 4.x, .NET Core, .NET 5, .NET 6). This is because the .NET framework versions are designed to be backward compatible with IL code generated by older versions of the compiler.
    - **Newer C# Versions**: If you use new language features introduced in a newer version of C# (e.g., C# 9, C# 10), your code will compile successfully only if you target a .NET framework version that supports those features. If you try to use features from a newer version of C# with an older .NET framework version, you'll encounter compilation errors because the older .NET framework doesn't support the new language features.
2. **Forward Compatibility**:
    - **Older .NET Framework Versions**: If you have a .NET framework application built with an older version (e.g., .NET Framework 4.x), you should be able to run it on newer .NET framework versions (like .NET 5, .NET 6) without changes. The .NET runtime is designed to run IL code from older versions.
    - **Newer .NET Framework Versions**: If you compile your code with a newer version of the .NET framework (e.g., .NET 6) and target features specific to that version, it won't run on older versions (e.g., .NET Framework 4.x) because the older runtime doesn't support the newer IL features.

In summary, .NET frameworks typically have backward compatibility for IL code generated by older versions of C# compilers. However, they do not have forward compatibility; you cannot run IL code that uses features from a newer C# version on an older .NET framework version that doesn't support those features. Therefore, to use the latest C# language features, you need to ensure you are targeting an appropriate .NET framework version that supports those features.

You

What about if we use a newer C# version but don't utilize any of the new functionality, the code should compile without issues with older .NET Framework right

ChatGPT

Yes, that's correct. If you use a newer version of the C# language but don't utilize any of the new language features introduced in that version, your code should compile without issues on older .NET framework versions.

Here's a clearer breakdown:
1. **Using a Newer C# Version**:
    - If you write your code using a newer version of the C# language (e.g., C# 9, C# 10) but you stick to using only features that are available in older versions of C# (e.g., C# 7, C# 8), then your code will compile successfully on both newer and older .NET framework versions.
2. **Compatibility Considerations**:
    - **Newer .NET Framework Versions**: If you compile your code with a newer C# version (e.g., C# 10) and target it to run on a newer .NET framework version (e.g., .NET 6), it will work seamlessly.
    - **Older .NET Framework Versions**: If you compile your code with a newer C# version but don't use any new language features, the resulting IL code will not require features from the newer .NET framework versions. Therefore, it should be able to run on older .NET framework versions (e.g., .NET Framework 4.x) without issues.
3. **Benefits of Using Newer C# Versions**:
    - Even if you don't use the newest language features immediately, using a newer C# version can be beneficial for future-proofing your code. It allows you to gradually adopt newer language features when needed without having to upgrade your entire codebase all at once.

In summary, as long as you avoid using new language features introduced in newer C# versions, your code will maintain compatibility with older .NET framework versions. This approach allows you to benefit from the stability and familiarity of older frameworks while having the flexibility to leverage newer language features when required.
# Bookmarks 

Course completion: 28.05.2024
