# General

[Methods](01%20Methods.md#)

[Commands](02%20Commands.md#List)

Имената на класовете са съществителни, PascalCase и са в единствено число.
Всички класове са типове данни и са reference вид.
Класа, дава описанието на обектите и създава структурата за тях. 
Служат и като темплейт за обекти от еднакъв тип. Може да си ги представим като рецепта, където имаме съставките, действията и тн, за да може да имаме готов продукт.
Всеки клас има състояния и поведение. 
Състоянието са properties. Примерно човека има име, възраст, адрес и тн.
Поведението са неговите методи. За класа куче имаме метода Bark().
Обект и инстанция е едно и също нещо. 
Всеки клас, може да има много инстанции. Примерно от class Dog, може да имаме обекти sparky и rufus.

Всеки клас се дефинира с ключовата дума class и става равноправен на останалите тип данни в езика. 
Ако не зададем стойности на състоянията в обекта, ще останат стойностите по подразбиране.

За да използваме автоматични пропъртита, пишем pro + Тab

Има три начина да инициализираме обекта, първия е след като сме създали обекта да изредим пропъртитата:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240207013042.png)

Втория начин е така наречения Object initializer където с Ctrl + Space в азбучен ред ни изрежда различните пропъртита.
Object initializer работи по същия начин и когато даваме първоначалните values на обикновени масиви или списъци.
Третия е чрез конструктор.

Имаме и анонимни обекти, които се дефинират така:
`var hero3 = new { Age = 5, Name = "hero" };`

Създаването на обекти се нарича instantiation - инстанциране, тъй като object = instance.

Инстанцията е обекта който се създава по време на runtime.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240207154334.png)

За да работи приложението, към .NET Core вървят и вградените класове, като подхода кои класове влизат в приложението е модулен. Влизат само тези които се ползват + някои задължителни, които заемат около 11мб.

Класовете се делят на статични и инстанционни. Статичните класове са само един и няма как да имаме различна инстанция. Това е нещо като клас и обект в едно. Нямат конструктори и не могат да бъдат създавани. Проблема на статичния клас е че той е само един и ако се направи промяна, тя важи за всички. 
Статичния клас, не може да има не статични методи, защото те изискват обекти, за да бъдат използвани.

Когато имаме втори проект (assembly) в solution-a, за да ползваме класовете от другия проект, те трябва да са public и трябва да отидем в Dependencies и да дадем add project reference. Ако класа е public, но метода е internal, то тогава нямаме достъп само до метода. С други думи, ако имаме internal клас, то той работи само в рамките на проекта в който е създаден.
Не може да имаме private class, който се води топ левел клас, тоест който е на root ниво в даден namespace, трябва да е nested в друг клас.

Всеки клас в C# има по подразбиране, празен конструктор, тоест скобите в края, когато инстанцираме даден клас. Ако направим наш конструктор в класа, deffault-натия празен изчезва.

В класовете имаме освен пропъртита, но и полета - fields. 
Автоматичните пропъртита са кратък запис на това което се създава в дадения клас. 
Имаме и Calculated property - това са пропъртита, което реално няма нужда да пази стойността си някъде във field, макар че този field го има, то property-то ползва getter-а за да изчисли своята стойност:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240209232304.png)

Имаме и [Composition Properties](06%20Objects%20and%20Classes.md#Composition%20Properties)

Пропъртитата са публични и достъпни отвънка и предоставя механизъм за достъп до полетата на класа.
Полетата пазят вътрешното състояние на класа. Пропъртитата са просто механизма за достъп, до вътрешното състояние на класа.
Когато създадем автоматично пропърти, това което се случва отдолу, може да видим, ако напишем propfull + Tab. Това записва целия pattern, така както трябва да бъде:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240207213515.png)

Имаме private поле age, което не може да бъде достъпено, по никакъв начин отвън. Именоването на пропъртито и полето, трябва да е едно и също, с разликата че второто е с малка буква. Всяко пропърти, има два специални метода, get и set познати като getter и setter. Идеята им е контрол на достъпа до самото поле. Getter-а ще прочете стойността на age и ще я предаде нататък.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240207214040.png)

Това нещо вика getter-a и ще получим стойността на age. Ако напишем `dice.Age=9` то тогава тази деветка, ще бъде подадена на setter-a като value. По този начин, стойността на age ще стане 9. Преимуществото да ползваме целия pattern е защото може да слагаме проверки:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240207214559.png)

По същия начин, можем да сложим проверки и в setter-a и примерно да върне exception. Можем да сложим и private set, което ще рече че age=a може да бъде променян само отвътре.
С други думи, когато private field-a получи някаква стойност, се задейства getter-a в пропъртито, а когато пропъртито получи стойност, то това задейства setter-a. Също ако повикаме извън класа пропъртито, то пак се задейства getter-a и се изпълнява блока от код вътре.

Конструктора е специален метод, който се ползва за създаване на обекта. Името му съвпада с името на класа. Всеки клас има конструктор и се достъпва с ctor + Tab.  Чрез конструктора, може да зададем начално състояние на обекта, когато го създаваме. Ако искаме да ползваме Object initializer, то трябва да имаме добавен празен конструктор в класа. Идеята е че можем да го ползваме като метод и по този начин, да си създадем обекта:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240207232244.png)

След като подадем стойностите, то тогава те се подават към setter-a в конкретното пропърти и се изпълнява логиката там.
Ако в конструктора променяме директно field-a то е много важно да използваме this.age , ако името на параметъра съвпада с името на field-a.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240208113916.png)

Main() метода е входната точка на конзолните програми, както и на по семпли други програми. При по сложните програми, входната точка се изчислява различно.
# Misc
Класовете и namespace-овете, не трябва да са с еднакви имена. 
Когато достъпваме обект, който има не инициализирано reference type property, примерно List то трябва първо да го инициализираме, преди да може да работим с него, иначе дава грешка.
Ако класа в който работим, не се намира в namespace-а в който се намира даден друг клас с който искаме да работим, то трябва да използваме using и да посочим името на namespace-a. Иначе трябва да пишем пълното име на класа и namespace-a.
Всеки клас си има namespace и всеки метод си има клас. Ако нищо не напишем, отиват в  глобал.

Ако добавим кода в началото при дефинирането на метода:
```
public override string ToString()
{
    return $"{FirstName} {LastName} is {Age} years old.";
}
```
Може да променим default поведението, което връща името на класа, ако изберем да отпечатаме някой от елементите в колекция, състоящ се от обекти.

Като general rule - ако трябва да запишем даден обект с повече от едно пропърти и не знаем колко пъти ще бъде подаван този обект, трябва да направим клас с прилежащите пропъртита и след това да сложим всяка от инстанциите в списък.
## Public - internal - private, static - instance
Информацията долу важи за всички, било метод, клас или променлива.
Mодификаторите за достъп (public, private, internal) определят видимостта на членовете, докато static и instance описват дали даденият член е асоцииран със самия клас или с конкретни инстанции на класа.
public - Видимост във всички проекти в рамките на solution-a. 
private - Видимост само в рамките на класа. 
internal - Видимост в рамките на проекта.
static - означава че дадения член е част директно от класа и всички промени се отразяват за целия клас.
instance - означава че промените се запазват само в рамките на конкретната инстанция - обект.
# ChatGPT
**Static - Instance:**
 You mentioned that "static means that the object is accessed directly through the class." While this is generally true, it might be helpful to clarify that static members are associated with the class itself and not with instances of the class. They are accessible through the class name, but the term "object" might be more commonly associated with instances.
 **Internal:**
  You correctly stated that internal visibility is within the same project, but it might be worth noting that it includes all types in the same assembly, not just the same project. An assembly is a compiled unit that may consist of one or more projects.
 **Instance Field:** Declared without the `static` keyword, associated with instances of the class.
 **Static Field:** Declared with the `static` keyword, shared among all instances of the class.
 **Local Variable:** Declared within a method or code block, limited to the scope of that block.

In the non-static version of the `Test` method, you are able to access the properties of the `Student` class without the need for an instance because the method is an instance (non-static) method. Instance methods have access to instance members (properties, fields, methods) of the class without needing an explicit instance reference, as they implicitly operate on the instance on which they are called.

However, in the static version of the `Test` method, it is marked as static. Static methods belong to the class itself rather than an instance of the class. They cannot directly access instance members without an instance reference because they do not have access to an instance of the class.

When you try to access the `Age` property in the static method:

`static public void Test() {     int age = Age; // Error: An object reference is required for the non-static field, method, or property 'Student.Age' }`

You get an error because there is no instance of the class associated with the static method, and you are attempting to access a non-static (instance) member.
### Difference between autocomplete property and manually setting one: 
```
class Box
{
    public string SerialNumber { get; set; }
    public Item Item { get; set; }
    public int ItemQuantity { get; set; }

    public double MyProperty2 { get; set; } = ItemQuantity * Item.Price;

    private double myProperty;

    public double MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            myProperty = Item.Price * ItemQuantity;
        }
    }
}

```

1. **MyProperty2:**
    
    - `MyProperty2` is initialized using a property initializer: `public double MyProperty2 { get; set; } = ItemQuantity * Item.Price;`
    - In this case, `ItemQuantity` and `Item.Price` are directly used in the property initializer.
    - Property initializers are evaluated at the time of object construction, before the constructor is called.
    - At the time of property initialization, `ItemQuantity` and `Item.Price` are not yet assigned, leading to potential issues.
2. **MyProperty:**
    
    - `MyProperty` has a private backing field `myProperty` and a custom getter and setter.
    - The getter directly returns the value of the private field: `return myProperty;`
    - The setter calculates the value based on `Item.Price` and `ItemQuantity`: `myProperty = Item.Price * ItemQuantity;`
    - This ensures that the calculation happens at the time of accessing the property, which can be after the object is fully constructed.

To handle the initialization of `MyProperty2` properly, you may consider setting its value in the constructor:

```
public class Box
{
    // ... (other properties)

    public double MyProperty2 { get; set; }

    private double myProperty;

    public double MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            myProperty = Item.Price * ItemQuantity;
        }
    }

    public Box()
    {
        MyProperty2 = ItemQuantity * Item.Price;
    }
}
```

In the constructor, you have access to the fully constructed object, allowing you to initialize `MyProperty2` based on the values of `ItemQuantity` and `Item.Price`.

You
So in short the MyProperty methods are called after the object is fully constructed

ChatGPT
Yes, that's correct. The methods in the `MyProperty` property, including the getter and setter, are called after the object is fully constructed. In C#, the property getter and setter are invoked when you access or modify the property, and this typically occurs after the object has been constructed.

In contrast, property initializers (like the one used in `MyProperty2`) are executed during the object's construction, before the constructor is called. As a result, when using property initializers, you should be cautious about relying on the values of other properties or fields that might not have been initialized yet.

By placing the logic in the getter or setter, as in `MyProperty`, you ensure that the calculations occur when the property is accessed, allowing you to use the fully constructed state of the object.
### Composition properties
In object-oriented programming, classes can have properties and fields that are of other classes or objects. This concept is known as composition. By composing classes together, you can model more complex structures and relationships in your program.

Here's a simple example in C#:
```
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address HomeAddress { get; set; }  // Composition: Address is a property of Person
}

```
In this example, the `Person` class has a property `HomeAddress`, which is of type `Address`. `Address` itself is another class with its own properties (`Street`, `City`, `ZipCode`). This is an example of composition, where a more complex class (`Person`) is composed of simpler classes (`Address`).

You can then use these classes as follows:
```
Person person = new Person
{
    FirstName = "John",
    LastName = "Doe",
    HomeAddress = new Address
    {
        Street = "123 Main St",
        City = "Exampleville",
        ZipCode = "12345"
    }
};

Console.WriteLine($"{person.FirstName} {person.LastName} lives at {person.HomeAddress.Street}, {person.HomeAddress.City}, {person.HomeAddress.ZipCode}");
```
This structure allows you to represent and organize data in a hierarchical and modular way. It's a fundamental concept in object-oriented design.
### The power of objects
I just realized the beauty of creating instances of classes. Objects of classes are storing preset variables, objects serve as a repository for them so lets say we have a program where we are expecting different teams with their team names, members, creators and other variables to be received. If we know their number we can create separate sets of the same variable types and assign each set to each team, however the beauty of the object instances comes from the fact that if we dont know how many teams we will receive, we have the objects and we can store huge amount of teams and the best part is we dont have to create the same set of variables over and over again for each team. Am i correct in my thinking, did i grasp the importance of objects?

ChatGPT

Absolutely! You've captured a fundamental aspect of object-oriented programming and the power of using objects and classes.

In object-oriented programming (OOP), objects are instances of classes, and classes define the blueprint for creating objects. Each object is a self-contained unit that encapsulates both data (attributes or properties) and behavior (methods or functions). This allows you to model real-world entities, like teams in your example, in a more natural and intuitive way.

Here are some key points you've highlighted:

1. **Abstraction**: Classes provide a way to abstract and encapsulate related data and behavior. In your example, the `Team` class encapsulates information about a team, including its name, members, and creator.
    
2. **Reusability**: Once you have defined a class, you can create multiple instances (objects) of that class. This enables you to reuse the same blueprint for different entities. You don't have to redefine the structure for each new team; you can create as many instances as needed.
    
3. **Flexibility and Scalability**: Objects allow you to handle varying amounts of data dynamically. As you mentioned, if you don't know in advance how many teams you will have, you can create objects on the fly and store them in a collection (like a list). This flexibility makes your code more adaptable to different scenarios.
    
4. **Readability and Maintainability**: Object-oriented code tends to be more readable and maintainable. Each object represents a real-world entity, making the code more intuitive and easier to understand.
    
5. **Encapsulation**: Objects encapsulate their internal state, providing a clear interface for interacting with the outside world. This helps in managing complexity and reducing potential errors.
    

By recognizing and embracing these principles, you're on the right track to understanding the core concepts of OOP. Objects and classes are powerful tools for organizing and modeling complex systems, providing a clean and modular structure to your code.

## Example classes
```
namespace Animals
{
    internal class Dog
    {
        public Dog()
        {

        }

        public Dog(int age, string name, string breed, string color)
        {
            Name = name;
            Breed = breed;
            this.age = age;
            this.color = color;
        }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Size { get; set; }

        private readonly string color;

        internal static string country { get; set; }

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /// <summary>
        /// The dog will bark.
        /// </summary>
        public void Bark()
        {
            Console.WriteLine("Bau");
        }
    }
}

namespace Auto
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }

        public static void Honk()
        {
            Console.WriteLine("Honk");
        }
    }
}
```

# Bookmarks 
Course completed: 13.02.2023
