# General

## Metaprogramming
Програмиране в което използваме информация за дадена програма. Чрез мета програмиране, може да напишем програма, която да работи с информацията, която произтича от кода на друга програма. Мета програми могат да четат инструкциите на други програми и да ги разбират, обработват, разглеждат и да създават мета програми. 
Компилатора е мета програма, защото разбира текста който сме написали и създава програма от него.
Когато се анализира кода и ни се предлага подобрение, също е метапрограмиране. Примерно когато пишем в VS ни подсказва дадени неща като да махнем излишни неща или че трябва да се ползва using и тн.
Рефлешкън е частен случай на метапрограмирането и също е такъв вид, който ни позволява да прочитаме информацията за вече написана програма, тоест какъв е списъка от класове, които са направени и съществуват в нашата програма. Също може да се види какви са методите в даден клас или какви полета има.
Част от метапрограмирането е програма която се само модифицира докато работи
## Reflection
Възможността на даден език за програмиране да разглежда какво съществува в дадена програма. Чрез рефлекшън, може да видим списъка с конструкторите на даден клас и да ги foreach-нем. Може да извикаме даден конструктор или метод, да създадем даден клас, да обходим всички методи и класове и да филтрираме на база определени критерии. Тези неща се случват динамично, докато програмата работи, което е различно от това да напишем някакъв код и да го пуснем. Програми които разбират какво е написано в тях, програми които могат да разгледат информацията за самите себе си.

Примерен код, как може да извлечем информация за методите в даден код, ползвайки рефлекшън и извиквайки определен метод:

```
public class MyClass
{
    public int MyProperty { get; set; }

    public void MyMethod()
    {
        Console.WriteLine("MyMethod");
    }

    public void Mymethod2()
    {
        Console.WriteLine("MyMethod2");
    }
}

public class Program
{
    public static void Main()
    {
        MyClass myClass = new MyClass();

        var myClassMethods = myClass.GetType().GetMethods();

        foreach (var method in myClassMethods)
        {
            Console.WriteLine(method.Name);

            if (method.Name == "MyMethod")
            {
                method.Invoke(myClass, null);
            }
        }
    }
}
```

Ако искаме да извикаме даден метод и го знаем какъв ще бъде, просто го извикваме без рефлекшън. Рефлекшън ползваме, когато името на метода идва от вън и е като стринг или искаме да направим няколко проверки преди да извикаме метода и не знаем как се казва. 
Рефлекшън не може да бърка в чужд код - който не е .NET или до който нямаме достъп.
### Use Cases
Може да вмъкваме нови парчета функционалности (DLL's / Assembly's) - plugins.
Може да генерираме код или да спестяваме генерирането на код.
Концепцията за mapping e нещо от един клас с едни пропъртита прехвърля информацията в друг клас със същите пропъртита
Когато искаме да прочетем дадена програма и нейната информация вътре в нея, какви класове и методи и тн има. От тази информация се възползва Unit testing-a.
Unit testing-a е когато създаваме много методи и всеки един от тях представлява отделен тест. Теста се стартира, проверява се какво прави и ако всичко е коректно, се маркира като ок. Ако получи грешна информация, теста гърми. Unit test технологиите използват този принцип, минават, разглеждат кода, намират тест методите и ги извличат и стартират само тях. След това ги пускат и гледат дали работят коректно или не, накрая ни казват резултата.

Вид рефлекшън е и когато имаме код във формата на стринг, написан от потребителя или прочетен от някъде, от който да направим програма.

В практиката на junior програмистите, не ни се налага да пишем рефлекшън. Всяко нещо което бихме искали да ползваме свързано с рефлекшън, вече е написано. Технологиите които ще използваме ползват рефлекшън, но на нас не би ни се наложило да го пишем.
### When not to use
Ако може да не го използваме, не го ползваме. С други думи не го ползваме никога, освен ако не се наложи.
Примерно ако знаем как се казва метода, го извикваме директно. Едно и също действие да извикаме даден метод, ползвайки рефлекшън отнема много повече редове код и е няколко пъти по-бавно. Ако потребителя отвън ще казва името на метода, по динамично е да се ползва рефлекшън, но би могло да стане и с if проверки.
Друг минус на рефлекшън е, че чупи концепцията за енкапсулация, защото не се интересува от модификаторите за достъп и може да пипа private членове в други класове. 
## Type Class
В типа данни Type се съхранява информацията за типовете данни.
Взимането на Type е много важно, за да може да продължим работата с рефлекшън.
За да получим типа данни, първия вариант е по време на компилация когато ни е известен типа данни, който искаме да проверим.

Тогава ползваме ключовата думичка `typeof()`

`Type type = typeof(Person)` ако искаме да разгледаме класа `Person`

Втория вариант да вземем данните е когато знаем типа данни като стринг:

`Type type2 = Type.GetType("ReflectionAndAttributes.Person");` `ReflectionAndAttributes` е името на namespace-a.

Този подход е много мощен и се ползва често. Той ще вземе типа на класа, без да е ясен по време на компилация, понеже стринга може да дойде отвънка.

Третия вариант е когато имаме променлива и искаме на променливата да вземем типа:

`Type type3 = person.GetType()`

Има много информация която може да видим за даден клас, примерно кой е неговия базов клас или какво интерфейси имплементира.
Може да попитаме дали даден тип данни е интерфейс или клас, или абстрактен клас.
Може също да проверим дали даден клас е статичен, като проверим дали типа е abstract и sealed.

За да проверим за private полета, трябва да ползваме метода `GetFields()` с двата параметъра в кода долу, ако ни трябват публичните полета, няма нужда от параметри. Тези методи връщат публичните неща по default, ако няма параметри.
Чрез този метод виждаме и скритите полета на автоматичните пропъртита, които не се виждат в написания от нас код. В процеса на компилация, нашия код се превежда на междинен език и автоматични неща като тези пропъртита се разпъват и от един ред пропърти става на get и set методи и private поле.

```
Type type = typeof(Person);
var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

foreach (var field in fields) 
{
    Console.WriteLine(field.Name);
}
```

Ако искаме да получим всички възможни полета трябва да напишем:

`var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);`

`BindingFlags` е enum.

След като получим поле, може да проверим какъв тип е, дали е публични, дали е инстанционно и тн 
## Type Assembly
Този тип данни е над Type и ни дава възможност да вземем информация за цялото assembly:

```
Assembly assembly = Assembly.GetExecutingAssembly();
Console.WriteLine($"Current project is {assembly.GetName().Name} and has {assembly.GetTypes().Count()} classes");
```
## Creating New Instances Dynamically
Може да създаваме инстанции от променлива тип Type. Ползва се статичния метод `Activator.CreateInstance()` който връща object. Ако искаме обекта ни да е от различен тип, да имаме видимост до всичките му клас членове, трябва да го кастнем, което ни дава допълнителното удобство на compile-time проверка и IntelliSense в IDE-то. Дори типа на променливата да остане object, може да извикваме с рефлекшън методите на конкретния тип и без cast към другия тип. Рефлекшън се интересува само от типа на данните и не го интересува типа на променливата в която са записани.

```
Type type = typeof(Person);
var person = Activator.CreateInstance(type);
```

Ако типа Person в примера, няма празен конструктор, кода ще гръмне по време на runtime. Трябва да му дадем списък с аргументи: 

` var person = Activator.CreateInstance(type, 5);`

Двата реда са идентични:

```
Type type = typeof(Person);
var person = Activator.CreateInstance(type, 5) as Person;
var person2 = type.GetConstructor(new Type[1] { typeof(int) }).Invoke(new object[] { 5 }) as Person;
```

`type.GetConstructor(new Type[1] { typeof(int) })` - определя колко параметъра и от какъв тип има в конструктора с който искаме да направим обекта. Може и да не посочваме броя на параметрите, а само да ги изредим.
## MethodInfo Type
Това е тип, който съдържа информацията на даден метод.
Когато сме намерили даден метод, може да го извикваме с метода `Invoke()` - където като параметри, трябва да посочим обекта върху който да се изпълни и списъка с параметри. Ако няма параметри, се слага null.

```
Type type = typeof(Person);

MethodInfo myMethod = type.GetMethod("MyMethod");

var person = new Person();

myMethod.Invoke(person, new object[] {5});
```
## Access Modifiers
Всички членове в един клас, както и самия клас, имат следните пропъртита:

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240709154738.png)
## Attributes
За да разберем смисъла на атрибутите трябва да разберем защо са измислени. Примерно ако имаме метод, на който искаме да дадем допълнителна информация, като това кой го е направил, може да сложим коментар или да втория вариант да сложим името на създателя му в името на метода, нещо което е много грешно и не трябва да се случва. Проблема на първия вариант е че нямаме лесен начин да вземем списъка на всички методи от даден автор. 
Друг вариант е, ако искаме да маркираме всички методи като тестови методи, може да сложим коментар, но системата не може да разбере че това е тестов метод.
Атрибутите са нужни и когато искаме да дадем някаква допълнителна информация за даден клас, отново може да напишем коментар, но само хората биха го разбрали и то ако отворят кода и забележат. Ако имаме един милион класа, не може да проверим всичките дали го имат. Точно тука идва нуждата да даваме допълнителна информация за съществуващ код, но тази информация да не се бърка във функционалностите на кода, но да е част от кода именно в тази ситуация идват на помощ атрибутите. 
Атрибутите са клас, който може да залепим към друг клас, като допълнителна мета информация. Нещо средно е между коментар и код, не се бърка в работата на кода, но не е и точно коментар, защото коментара бива игнорират от компилатора. 
Атрибутите може да се приложат върху клас, поле, метод, параметър, върху връщан тип, пропърти, върху всяко едно нещо от кода.

Атрибутите са класове и се използват в ситуация в която искаме да дадем допълнителна информация, примерно за даден метод или дори параметър, че вече не е актуален и скоро ще бъде премахнат, чрез атрибута `[Obsolte]`. Това са специален тип данни, който се слага в квадратни скоби. 
Атрибутите носят допълнителна мета информация към класа. Може да гледаме на тях като таг.
Може да сложим върху даден метод атрибута `[Test]` и така маркираме че е тестове метод. Библиотеката за unit testing, чрез рефлекшън минава и намира всички методи с този атрибут, извлича ги и ги invoke-ва / стартира.
Генерално това им е идеята на атрибутите - неща които искам да ги допишем за някой, който би ги прочел после с рефлекшън или по друг начин, най-често с рефлекшън, за да може после другите системи да ги използват и да имат допълнителна информация.
Може да имаме много атрибути един върху друг.

Атрибутите могат да имат параметри в техните конструктори.

Когато искаме да използваме нещо от операционната система, примерно message box, който да изскочи, тогава може да ползваме API в windows, така наречените Windows32 API's. Нашето конзолно приложение, също може да ги ползва, трябва да си направим метод и да сложим атрибут с който да кажем на метода, че е метод от user32.dll (специална ddl-ка - код който е част от Windows вградените функционалности и може да извикваме чрез атрибути).

За да си направим атрибут, трябва да отговаря на три условия - да бъде клас, да наследява служебния клас `Attribute` и в края на името си да има Attribute. 
Когато ползваме атрибута, няма нужда да изписваме пълното му име с Attribute частта в края.
Може отново да сложим атрибут `[AttributeUsage]`, чрез който да ограничим използването на даден атрибут само за определен таргет или таргети, примерно класове и параметри:

```
[Author]
public class Person
{
    public void MyMethod([Author] int a)
    {
        Console.WriteLine("MyMethod");
    }
}

[Author]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter)]
public class AuthorAttribute : Attribute
{
}
```

Можем да слагаме пропъртита и конструктори и всеки атрибут да си слага стойности на пропъртито. Конструктора ни улеснява, защото няма нужда да пишем името на пропъртито.
В примера долу, имаме три варианта за създаване на атрибута. Може да му посочим и като параметър `AllowMultiple = true` което ще разреши един атрибут да се сложи повече от един път:

```
[Author("Gerard")]
[Author("SoftUni")]
public class Person
{
    public void MyMethod([Author] int a)
    {
        Console.WriteLine("MyMethod");
    }
}

[Author(Name = "Gerard")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    public AuthorAttribute(string name)
    {
        Name = name;
    }

    public AuthorAttribute()
    {
    }

    public string Name { get; set; }
}
```

Атрибутите могат да бъдат прочетени чрез рефлекшън.

Всеки атрибут в .NET има специфичен "потребител" или система, която го обработва и предприема съответните действия въз основа на него, примерно в `DllImport` - рови .NET, в тестовия атрибут - рови тестовия framework, който ще ползваме, в `Obsolete` - рови компилатора, за да може да ни предупреди. Всеки атрибут си има ползвател, който си ги проверява и извършва действия. Custom атрибутите обикновено се ползват от разработчиците, за да добавят метаданни към кода, които след това могат да бъдат извлечени и обработени чрез рефлексия. Има случаи, в които външни библиотеки или frameworks могат да използват персонализирани атрибути за различни цели.

Атрибута `[Flags]` се използва примерно когато имаме enum и искаме в дадена променлива да запишем повече стойности, enum го позволява. Трябва да сложим този атрибут на enum класа и да дадем числови стойности, които да са степени на двойката и да ползваме побитовия оператор или - `|`
Степените на двойката се необходими, за да може да се извършват коректно побитовите операции.
За проверка на множество стойности, трябва да използвате побитови операции, за да проверите дали определени флагове са зададени.
За проверка дали комбинация от флагове съдържа определени стойности, използваме побитовия оператор `&`:

```
[Flags]
public enum Weekday
{
    Monday = 2,
    Tuesday = 4,
    Wednesday = 8,
    Thursday = 16,
    Friday = 32,
    Saturday = 64,
    Sunday = 128
}

public class Program
{
    public static void Main()
    {
        Weekday weekday = Weekday.Monday | Weekday.Saturday;

        if ((weekday & Weekday.Monday) == Weekday.Monday && (weekday & Weekday.Saturday) == Weekday.Saturday)
        {
            Console.WriteLine("Both Monday and Saturday are set.");
        }
    }
}
```

Така работи и `BindingFlags` ползвайки флагове. 
# Misc
Всеки проект е assembly, а assembly-то е изпълним файл / DLL, който е генериран в следствие на компилацията на source код.

С първите компютри се е работило с перфокарти, където кода и данните които са се подавали, се перфорират на картонче и след като ги обработи, компютъра отново връща такава карта с резултата. След това са се появили екраните. Перфокартите са били ранни устройства за вход и изход в компютърните системи.
## `readonly keyword`
Може да се ползва само за полетата в един клас и означава, че стойността на полето се задава само в конструктора, след това не може да се сменя.
# ChatGPT
## Invoking methods
Когато използвате `Activator.CreateInstance()`, можете да създавате обекти динамично по време на изпълнение, базирани на `Type`. Методът връща обект от тип `object`, така че може да е необходимо да го кастнете към съответния тип, за да извикате методите му директно.

Ако обаче искате да извиквате методите на обекта, без да го кастнете към конкретния тип, може да използвате рефлексия. Рефлексията ви позволява да изследвате и манипулирате обекти и техните типове по време на изпълнение. Ето пример как можете да създадете инстанция и да извикате метод чрез рефлексия:

```
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Получаване на типа
        Type myType = typeof(MyClass);

        // Създаване на инстанция на типа
        object myObject = Activator.CreateInstance(myType);

        // Извикване на метод чрез кастване (със знание за типа)
        MyClass myCastedObject = (MyClass)myObject;
        myCastedObject.MyMethod();

        // Извикване на метод чрез рефлексия (без кастване)
        MethodInfo methodInfo = myType.GetMethod("MyMethod");
        methodInfo.Invoke(myObject, null);
    }
}

public class MyClass
{
    public void MyMethod()
    {
        Console.WriteLine("MyMethod is called.");
    }
}
```

В този пример:

1. Използваме `Activator.CreateInstance(myType)`, за да създадем инстанция на `MyClass`.
2. Кастваме обекта към `MyClass`, за да извикаме метода директно.
3. Използваме рефлексия, за да извикаме метода `MyMethod` без кастване.

Това ви позволява да работите с обекти от тип `object`, като използвате рефлексия за извикване на методи и достъп до членове на обекта, без да е необходимо предварително да знаете типа на обекта по време на компилация.

You

Значи рефлексията не се интересува в какъв тип променлива е запазен обекта

ChatGPT

Да, точно така! Рефлексията в C# предоставя механизми за динамично изследване и манипулиране на обекти и техните типове по време на изпълнение, независимо от конкретния тип променлива, в която е запазен обекта. Това означава, че можете да използвате рефлексия, за да взаимодействате с методи, свойства и полета на обекта, без да е необходимо предварително да знаете точния му тип.

Ето още един пример, който демонстрира как да използвате рефлексия за работа с обект, съхранен в променлива от тип `object`:

```
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Създаване на обект от тип MyClass чрез Activator.CreateInstance
        Type myType = typeof(MyClass);
        object myObject = Activator.CreateInstance(myType);

        // Извикване на метод чрез рефлексия
        MethodInfo methodInfo = myType.GetMethod("MyMethod");
        methodInfo.Invoke(myObject, null);

        // Достъп до свойство чрез рефлексия
        PropertyInfo propertyInfo = myType.GetProperty("MyProperty");
        propertyInfo.SetValue(myObject, 42);
        Console.WriteLine(propertyInfo.GetValue(myObject));

        // Достъп до поле чрез рефлексия
        FieldInfo fieldInfo = myType.GetField("myField");
        fieldInfo.SetValue(myObject, "Hello, Reflection!");
        Console.WriteLine(fieldInfo.GetValue(myObject));
    }
}

public class MyClass
{
    public int MyProperty { get; set; }
    public string myField;

    public void MyMethod()
    {
        Console.WriteLine("MyMethod is called.");
    }
}
```

В този пример:

1. **Създаване на обект**: Създаваме инстанция на `MyClass` чрез `Activator.CreateInstance`.
2. **Извикване на метод**: Извикваме метода `MyMethod` чрез рефлексия.
3. **Достъп до свойство**: Достъпваме и задаваме стойност на свойството `MyProperty` чрез рефлексия.
4. **Достъп до поле**: Достъпваме и задаваме стойност на полето `myField` чрез рефлексия.

С други думи, чрез рефлексията може да работите с членове на обект (методи, свойства, полета и т.н.) независимо от конкретния тип променлива, в която е съхранен обекта. Това е особено полезно при разработването на по-гъвкави и динамични приложения, където типовете на обектите не са известни по време на компилация.

# Bookmarks 
Лекция за по-напреднали, част от курса за C# Masterclass

[Бонус: Reflection за напреднали - Софтуерен университет](https://softuni.bg/trainings/resources/video/66659/bonus-advanced-reflection-csharp-oop-october-2021/3484)

[C# Masterclass - Reflection - октомври 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=LkWis2vrUIE&t=6s)

Множество теоретични въпроси, които са полезни за подготовка за технически интервюта.

[FullStack.Cafe - Kill Your Next Tech & Coding Interview](https://www.fullstack.cafe/)

Course completion: 14.07.2024
