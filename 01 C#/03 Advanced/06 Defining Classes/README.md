# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240425171446.png)

Класът е тип данни в .Net и е концепция в повечето големи програмни езици с изключение на функционалните и JavaScript. 

Клас се дефинира с ключовата дума class и име на класа с PascalCase, което задължително трябва да е съществително и да описва много добре какво точно се съхранява вътре в класа. 

Класът описва неща от реалния свят. Съдържа групирани в себе си общи данни и обща функционалност. Може да се погледне като изолирано парче функционалност от данни, което може да преизползваме много пъти. 

Служи като шаблон за създаване на променливи - описва какви подданни, каква информация ще има в дадена променлива. 
На практика е списък от променливи - полета, свойства и списък от методи в рамките на този клас. 

Един клас може да наследява друг клас и да наследява неговите функционалности. Класа е групиране на данни в едно общо нещо.

Вътре в класа може да имаме:

Методи
Конструктори
Полета (fields) - директни променливи, обикновено се правят за данни, които са private - частни за класа, а когато искаме да правим нещо публично, да го виждат и останалите класове, правим properties.
Свойства (properties) - това са полета с два закачени метода към тях, за взимане и слагане на стойност - контролират информацията която влиза и излиза от тези полета.

Сравнително рядко използвани:

Делегати
Вътрешни класове (nested class)
Събития (events)
Деструктори (destructors)

Property-тата служат да може field-овете да бъдат достъпни отвън. Ако дадено property няма свой field, то автоматично му се генерира такъв, но скрит и не го виждаме.

Добре е да се избягват абревиатури при именуването на клас. 

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240429143201.png)

Класа е нещо което дефинираме като код, който представлява шаблон за създаване на обекти. Обект е това което създадем с ключовата дума `new`, вече създадена променлива която сочи към паметта и отговаря на шаблона на класа. С други думи, класа е като темплейт / скица за направа на обувки, а обекта е вече направена обувка. Може да имаме много обекти или наричани още инстанции.

Всеки един клас, структура, тип данни, наследяват object. 
Методите `Equals(), GetHashCode(), ToString(), GetType()` са наследени от там, затова ги има при всички класове.
## Methods
Методите са наименувано парче код, което може да се преизползва. Ако всичко е набутано в Main(), няма как да извикаме дадена повторяема част от кода. Може да ги слагаме в произволно избран клас.
Методите в класа имат пълен достъп до информацията в класа, според това дали са статични, тоест имат ключовата дума static или са инстанционни(без static).

Ако метода не е статичен, то тогава за да се ползва, трябва да се направи обект от дадения клас и през него да се извиква метода. Инстанционни-те методи имат достъп до всички полета и пропъртита, докато статичните методи, нямат достъп до не статични такива, не могат да пипат неща от класа, които не са статични. Това е така, защото всеки обект има различни стойности на дадените не статични полета и пропъртита и от перспективата на един статичен метод вътре в класа, инстанционни-те пропъртита и полета нямат зададени никакви стойности и реално няма как да работи с тях. Те имат стойности само когато са в контекста на даден обект от същия клас. Инстанционни-те методи обработват инстанционни-те полета и пропъртита само в рамките на конкретния обект чрез който са извикани.

Инстанционни-те методи имат достъп до статичните полета и пропъртита, защото те винаги имат стойност в рамките на класа, ако им е зададена такава. Тази стойност се запазва до приключване на програмата и от където и да я взимаме или променяме, стойността е еднаква. Всички статични член данни в класа, се достъпват без нуждата от обект, а директно чрез името на класа. Няма как да достъпим статичен метод или друг статичен class member през обекта.

```
class Person
{
    private string firstName;
    private string lastName;

    public static int Age = 50;

    public static void MyMethod()
    {
        Age--; 
    }
}

class Program
{
    static void Main()
    {
        Person.Age--; //Age decreased to 49

        MyMethod(); //Age decreased to 48

        Person.MyMethod(); //Age decreased to 47

        Console.WriteLine(Person.Age);
    }

   static void MyMethod()
    {
        Person.Age--; 
    }
}
```
## Properties - Getter and Setter
Целта на пропъртитата е да си защитим класа и данните, които се подават към полетата. Ако полетата бяха public, тоест може директно да се модифицират извън класа, то тогава нямаше да може да валидираме данните в тях и да ограничим подаването на неправилна информация. 
Aко имаме клас person с полета за `firstName`, `lastName` и `age`, някой може да ги промени с невалидни стойности - да посочи за възраст отрицателно число или в името да сложи цифри. 
За да избегнем тези проблеми и да имаме контрол на подадената информация, трябва да направим полето private тоест да забраним на външния свят да му слага стойност. След това да направим метод, който да получава стойност от вън и да я проверява и ако не отговаря на изискванията, да слага стойност по подразбиране или да върне грешка. След като стойността е проверена и при нужда модифицирана, вече чрез метода може да я зададем на полето. Сега ако някой иска да зададе стойност на полето age, трябва да мине през set метода който направихме: 

```
class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public void SetAge(int value)
    {
        if (value < 0 || value > 200)
        {
            value = 0;
        }

        age = value;
    }
    public int GetAge()
    {
        return age;
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person();

        person.SetAge(-5);
        Console.WriteLine(person.GetAge()); 
    }
}
```

Имаме и втори метод - `GetAge()` чрез който външния свят взима стойността на private полето age.
Чрез тази методика използвайки два метода, кода става по-дълъг, но имаме контрол и валидация над подадените стойности към полетата.
Това скриване от външния свят на полетата, се нарича енкапсулация.
Когато едно поле е private, трябва да бъде с малки букви, а някои слагат и `_` пред името `_age`.
За всяко едно поле, трябва да направим същите get и set методи.
Използвайки тези методи, по всяко време може да решим да направим валидация или поправка на данните (да направим първата буква главна за име и тн) и просто да я добавим в set метода, без да се налага да правим други промени по кода.

Това е начина по който работят нещата и в Java, но в C# имаме съкратен начин да изписваме тези методи, чрез property-тата. 
Property-то се изписва като напишем - `prop` + Tab х 2:
`public string FirstName { get; set; }`
Пропъртито генерира автоматично двата метода, които направихме get и set с един единствен ред. Оставено по този начин, ние виждаме само пропъртито, а полето е скрито. 
Винаги трябва да правим пропъртита, защото по всяко време може да добавим код на get и set метода. 

На get и set може да зададем различен достъп, примерно да сложим private set и така пропъртито ще може само да се чете от вън.

Пропъртито се достъпва от вън, без нуждата от методи а директно. 
Ако искаме да добавим нещо в get или set методите, то трябва да изпишем пълното property и за двата метода и да декларираме private field полето, което при съкратеното изписване е скрито:

```
class Person
{
    private string firstName;
    private string lastName;

    private int age;
    
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 0 || value > 200)
            {
                value = 0;
            }

            age = value;
        }
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person();

        person.Age = -5;
        Console.WriteLine(person.Age);
    }
}
```

По този начин изписано, всеки път като подадем стойност, тя влиза като `value` в set или като извикаме пропъртито, get връща стойността на полето.  Така е много по подредено.
Бърз начин да изпишем пълното пропърти е `propfull` + Тab х 2.
Съкратеното пропърти се нарича автоматично.

Валидацията задължително трябва да я правим през setter-a защото ако я направим в конструктора, то пак минава през setter-a, стига да не променяме директно field-a в конструктора. Така дори на по късен етап да сменим стойността, то при промяната пак ще минат през валидацията на setter-а. Иначе валидация на ниво конструктор, минава само веднъж на ниво създаване на обект и после вече ако се променят стойности, няма се проверяват данните.

Можем да задаваме и стойност по подразбиране на пропъртитата -`public int Age { get; set; } = 0;`

В полиморфизма, всеки един клас трябва да си гарантира, че във всеки един момент данните, които притежава са в допустими стойности. 
## Access modifiers
При класовете имаме модификатори за достъп. Те определят, дали външния свят може да вижда, достъпва, чете и тн тази информация. Някои от възможностите са:

Public - външния свят (другите класове) виждат даденото свойство или поле.
Private - не се вижда от вън, променливата се вижда само от класа.
Internal - да се вижда само от текущото assembly / проект.

Методите които създаваме вътре в класа, имат достъп до цялата информация в неговия клас. Дори информацията да е private, то метода пак може да я достъпи понеже е отвътре в класа.

Ако метода е static то тогава за да го извикаме, трябва да напишем името на класа само. Статичните методи имат достъп само до статичните член данни на класа, но нямат достъп до другите, защото нямат променлива и данните не са присвоени като стойност, те са достъпни само за инстанции. Ако дадена статична част в класа бъде променена, тя запазва своята стойност, примерно:

```
class Person
{
    public static string Country;
    public string FirstName;
    private string LastName;
}

class Program
{
    static void Main()
    {
        Person.Country = "Bulgaria";
        Console.WriteLine(Person.Country);
    }
}
```

Ако метода е инстанция на класа, тоест няма ключовата дума static, то тогава за да го ползваме, трябва да създадем обект и чрез обекта, може да достъпим метода. Метода има достъп, само до инстанционни член данни, тези които не са static.

За качествен програмен код е важно да използваме принципа на encapsulation - скриване на детайлите и достъпа до определени данни, така че да не може отвънка да ни променят информацията без наше знание. Важно е промяната да минава през наш код - така наречените properties.

Класа ако няма зададен модификатор е internal, а всичко останало private.
## Reference memory
Динамична памет, референтна памет, референция и тн означават сочене към дадено заделено парче памет.

Когато имаме даден клас, примерно `Person` и създадем две променливи от този клас:

```
Person person1 = new Person();
Person person2 = new Person();
```

С ключовата дума `new`, ние казваме да се задели парче памет за информацията която имаме вътре в Person класа. В примера, двете променливи пазят референция към различни места в паметта. Ако кажем че `person2 = person1` това не означава, че стойността в паметта за person1 ще се копира в паметта за person2, а означава че променливата person2 вече сочи към същото парче памет, заделено за person1. Ако направим промяна в някоя от двете променливи, промяната ще се отрази и на двете. Понеже нищо не сочи вече към първоначално заделената памет на person2, то garbage collector-a ще мине и ще я изчисти по някое време. Това важи и ако подадем даден обект като параметър в метод. Работейки с променливата вътре в метода, промените ще бъдат отразени и в обекта извън метода, тъй като референцията е еднаква.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240428192525.png)

Паметта на компютъра се нарича RAM е една дълга последователност от единици и нули, които групираме в байтове. Операционната система менажира тази памет. Заделя си памет само за нея и никой не може да я пипа, защото е защитена. За всеки процес, който създаваме ОС заделя количество памет. 

Самия процес си заделя негова си памет, за всички променливи вътре. Програмите които правим, също си заделят памет и я разделят на две части. 
Една малка част, която наричаме статична памет (Stack) и една доста по голяма част, която се нарича динамична (Heap). Статичната памет в C# е около 1mb. Динамичната памет се определя от необходимостта на нашата програма и се променя динамично. 
Има и трета част която е една малка част от програмата и представлява самия й код. Намира се в малко парче памет, където са всичките инструкции на програмата, заедно с мета данните - какво има в класовете, какво има в даден метод, коя инструкция след коя следва и тн. Нямаме достъп и контрол до тази част, но ОС си заделя мястото и проследява на коя инструкция е в момента, на коя ще скочи, даден метод кой друг ще извика и тн.

Стартовата точка на нашата програма, обикновено е метода `Main()`, който има различни парчета код, като това да викне друг метод или да инициализира променлива и тн. Част от тези неща влизат в статичната памет, а другите в динамичната. 

Статичната памет се нарича още и стекова памет и в нея се намира call stack-a, където се записват извикванията на методите и техните параметри и локални променливи. Начина по който се пише в статичната памет и работата на колекцията stack много си приличат. Stack Overflow Exception се получава когато статичната памет се препълни. Когато извикаме метода Main и с него започне изпълнението на програмата в статичната памет се отбелязва че дадения метод е извикан. Когато извикаме друг метод в Main в статичната памет, това ще се отбележи че от дадена инструкция в Main е извикан този метод заедно с параметрите му. Когато на дадения метод му потрябват параметрите, ги изважда от стека и ги ползва. След приключване на работа, самия той излиза от стека. 
С други думи, всяко извикване на метод се вкарва нещо в стека, при излизане, се изкарва. Излизането става в обратния ред на влизане и от там идва приликата със колекцията стек. 

Друго важно което се запазва в стековата памет, примерно ако създадем инстанция на даден клас, в стека се пази само референция към динамичната памет, където се записва самата информация за конкретния обект. Това важи за всички класове, техните инстанции се пазят в динамичната памет. В зависимост от имплементацията, референцията заема между 4 и 8 байта в стека. Референцията е адрес  записан в hexadecimal числа.

В динамичната памет влизат и всички типове масиви и интерфейси. С други думи в статичната памет, влизат методите, техните параметри и референтните променливи, на които истинската памет се намира в динамичната. Ако направим безкрайна рекурсия на даден метод, той ще препълни стека, който е 1мб. 1мб е достатъчен за около 40 000 извиквания на методи един в друг.

Статичната памет е доста по-бърза, защото процесорите обикновено я кешират.
Простите типове данни (value types) - се записват директно в стека. 

Ако искаме да проверим дали два обекта сочат към една и съща памет, това става чрез вградения метод за всеки клас или ако проверим двата обекта с `==`
`ClassName.ReferenceEquals(object1, object2)

Стринговете се записват в динамичната памет и за тях има заделено цяло отделение, което се нарича стрингова таблица. Стринговете са immutable - тоест при промяната на стринг, се прави изцяло нов стринг записан на ново място в паметта. Референцията в променливата се променя да сочи към новото място и стария стринг ще бъде почистен от garbage collector-a.

Концепцията при паметта е че по простите неща отиват в стековата памет, по сложните и обемни в динамичната памет.
## Struct
Структурите влизат изцяло в статичната памет и с това се отличава от класовете. Другите разлики между тях са минимални.

Декларират се с ключовата дума struct.

Работи се по много подобен начин, както с класовете.

Една от основните разлики е, че ако инициализираме два struct обекта и кажем един от тях да е равен на другия, то тогава паметта се копира и всеки обект има отделно заделена памет. 

Ако в даден struct имаме референтни типове, примерно масиви, то те ще бъдат записани в динамичната памет, докато самия struct ще е в статичната. В тази връзка, ако направим втори struct обект и кажем че е равен на първия, то ако в struct-a има референтни типове примерно масив, то и двата обекта ще имат еднаква референция и промените ще се отразяват и на двете места. При стойностните типове, промените на едното място, няма да се отразяват на другото.

Ако направим проверка дали един struct е равен на друг при условие че имат еднакви стойности, ще върне true, за разлика от класовете където ще е false.

Структурата се използва в редки ситуации, защото може да препълни стека. 
## Constructors
Конструктора е специален метод, който се пише по специален начин, извиква се с `new`. Това е метод, който носи името на класа и не връща нищо. 
Когато създаваме нов обект от даден клас, се ползва конструктор. 
`Car car = new Car();` - конструктора е след ключовата дума `new`.
Всяко нещо което има отварящи и затварящи скоби в .NET е метод или описание на метод.
Всеки един клас има поне един конструктор. Ако даден клас няма деклариран такъв, за него се създава скрит празен конструктор, който само заделя необходимата памет скрито от нас.
Може да създадем допълнителни конструктори, с различни параметри. След като създадем наш конструктор, ако искаме да имаме възможност да инициализираме обекти без да подаваме параметри в конструктора, трябва експлицитно да направим празен конструктор. Правилата за Overloading при методите, важат и при конструктора.

Shortcut - `ctor + Tab`
Ако селектираме няколко пропъртита и полета и натиснем Ctrl + . ще създаде конструктор с тях като параметри.

Идеята на конструктора е да инициализира първоначалните стойности на желаните член данни на даден обект. Трябва да получи като параметри някаква информация при създаването на обекта.

```
internal class Car
{
    public Car(string make, string model)
    {
        Make = make;
        Model = model;
    }

    public string Make { get; set; }

    public string Model { get; set; }
}
public class Program
{
    static void Main()
    {
        Car car = new Car("BWM", "M3");
    }
}
```

Когато имаме конструктор, който приема дадени параметри и променя член данните в класа, е добре да променя пропъртитата а не директно private полетата, за да може да се изпълни дадена проверка / валидация в setter-a, ако има такава. 

По време на debug може да забележим, че вътре в класа когато сме в конструктор или се изпълнява не статичен метод, има една променлива, която е тип на класа и се казва `this`. Данните вътре са данните на текущия обект, който се създава или чрез който сме извикали променливата. Трябва да се внимава, защото може да има ситуация в която името на параметъра е същото като името на дадено поле в класа и тогава ще има проблем, защото конструктора ще мисли че става въпрос за неговия параметър. За да се избегне проблема трябва да напишем `this.` пред името на полето:

```
    public Car(string model)
    {
       this.model = model;     
    }

    public string model;
```
### Chaining
Конструкторите може да се извикват един друг, това се нарича chain-ване и се прилага когато имаме конструктори с преповтарящи се параметри. По-големия конструктор вика по-малкия за да напълни общите параметри и после пълни останалите:

```
   public Car(string make, string model)
    {
        Make = make; 
        Model = model;
    }
    public Car(string make, string model, int year) : this(make, model)
    {
        Year = year;
    }
```

Това което се случва е, че когато използваме `this()` проверява дали типа и броя на параметрите вътре, отговаря на някой от другите конструктори. Само един конструктор може да отговаря, тъй като ще се получи конфликт при еднакъв Overloading. Името на параметрите няма значение. Може да подадем на `this()` вместо някоя от променливите, директно стойност. Това е полезно в случай че искаме да имаме default стойност за дадени член данни, викайки определен конструктор:

```
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
        }
        public Car(string make, string model, int year) : this("BWM", model)
        {
            Year = year;
        }
```

С този пример виждаме, че когато втория конструктор бива използван, всичките обекти ще имат BWM като марка.
## Enumerations

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240430213610.png)

Изброим тип - `enum` от ранга на class, struct, delegate.. 
Позволява да дефинираме тип данни, който има само определен списък от стойности. 
Няма пропъртита, конструктори и тн.

```
enum Season
{
Spring, Summer, Autumn, Winter
}
```

На всяка стойност, може да задаваме целочислена стойност, а ако нищо не сме посочили, по подразбиране започва от 0. 
Това е полезно, защото може да обръщаме дадена стойност в число и обратното:

```
    enum Season
    {
        Spring = 0, Summer = 1, Autumn = 2, Winter = 3
    }

    public class Program
    {
        static void Main()
        {
          Season season = Season.Autumn;
          Console.WriteLine((int)season); // 2
          Console.WriteLine((Season)3); // Winter
        }
    }
```
## Namespaces
Използват се за подредба и организация на класовете. Групираме няколко типа данни, като class, struct, enum и тн в едно нещо. Може да се погледне като папки с класове.
За да използваме групираните класове в друго парче от кода, трябва да се добави n чрез ключовата дума и името на namespace-a -`using namespaceName`
Ако направим нов файл, със същия namespace класовете от всички файлове които имат този namespace, ще бъдат групирани.
# Misc
## Instant Fields / Properties initialization
Когато правим non static полета или проръти-та в класа, не може да им даваме за стойност друго поле или пропърти, защото преди да мине конструктора, полетата не са напълно инициализирани и ще даде грешка.
При създаването на нов обект, първо се инициализират полетата и след това се влиза в конструктора. Ако искаме `anotherField` да е равно на `field`, равенството трябва да го изнесем вътре в конструктора:

```
    internal class Car
    {
        int field = 5;

        int anotherField = field;
    }
```

Има съкратен начин на изписване на read-only property. 
Двата записа правят едно и също:

    internal class Car
    {
        int field = 5;

        //Option1
        int Field => field;

        //Option 2
        public int Field
        {
            get
            {
                return field;
            }
        }
    }
## Nullable and Non-nullable 
Понякога може да получим `Warning	CS8618	Non-nullable property 'Model' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.`	
Това е защото референтните типове са non nullable по подразбиране и компилатора ни напомня, че дадено пропърти или поле няма да получи гарантирано стойност в конструктора на класа, което после може да доведе до грешка, ако опитаме да достъпим вътрешно пропърти, забравяйки че не сме му дали стойност. Примерно ако имаме пропърти от тип string и не го инициализираме с някаква стойност, то ще получи по подразбиране null. Ако опитаме да го достъпим, няма да има грешка, но ако опитаме да достъпим неговото пропърти Length ще гръмне. За да решим проблема, трябва да инициализираме обекта, за да може вътрешните му пропъртита и полета да са инициализирани с default стойности, пък било то и null, но поне няма да върне exception при опит да се достъпят.
Можем да го променим на nullable като добавим `?` пред типа данни: `public Engine? Engine { get; set; }` Това ще изчисти грешката. 
Kои типове по подразбиране да са nullable и non nullable, се наглася от настройките на компилатора.
# ChatGPT
## Nullable types
- Nullable value types, such as `int?`, can store both a value and null.
- When a nullable value type contains a non-null value, that value is stored on the stack, just like non-nullable value types.
- When a nullable value type contains null, it doesn't directly store a null value on the stack. Instead, its nullness is indicated through internal mechanisms, typically by adding a bit to the underlying value type.
- Nullable value types occupy slightly more memory than their non-nullable counterparts because of the additional nullness indicator.

You
```
string text = null; 
int? length = text?.Length;
```

 why do we need the second `?`?

ChatGPT
The `?` in `int?` is commonly referred to as the "nullable type modifier", indicating that the variable can hold null in addition to the specified type.
The `?.` is called the "null-conditional operator", used for accessing members of an object while guarding against null references.

Both are important features in C#, but they serve different purposes and are referred to by different names
The second `?` is part of the null-conditional operator `?.`, which is used to access members of an object or invoke methods on it while guarding against a null reference.

In the code snippet you provided:

```
string text = null;
int? length = text.Length;
```

Without the second `?`, attempting to access the `Length` property of `text` directly would result in a null reference exception because `text` is null.
So, by using `text?.Length`, you're essentially saying "if `text` is not null, then access its `Length` property; otherwise, return null". This way, if `text` is null, `length` will be assigned null rather than throwing an exception.

Thus, the second `?` is crucial to ensure that the code does not throw a null reference exception when accessing members of potentially null objects.

in summary:  
The first `?` is used to denote a nullable type. In this case, `int?` indicates that the variable `length` can hold either an integer value or null.
- The second `?` is part of the null-conditional operator `?.`. It's used to check if the object (`text` in this case) is null before attempting to access its member (`Length`).

Combining these two, `int? length = text?.Length;` ensures that if `text` is null, `length` will be assigned null without throwing a null reference exception. If `text` is not null, then `length` will hold the length of the string.
## Instant and Static Class Members
1. **Static vs. Instance Members**:
    - Static members (fields, properties, methods) belong to the class itself rather than to instances of the class. They are accessed using the class name directly.
    - Instance members belong to individual instances (objects) of the class. They are accessed using an instance of the class.
2. **Access to Class Members**:
    - Instance methods have access to both static and instance members of the class.
    - Static methods have access only to other static members of the class. They cannot directly access instance members unless through an instance reference.
3. **Visibility of Members**:
    - Private members (fields, properties, methods) are accessible only within the same class.
    - Public static members are accessible from outside the class using the class name.
4. **Interaction with Instance Members**:
    - Instance methods can access instance fields and properties, and they operate on the specific data associated with the object they are called on.
    - Static methods don't operate on specific object data and are often used for general-purpose operations or utility functions.
## Field initialization
You
Fields are not fully initialized before the constructor is executed?

ChatGPT
Yes, that's correct. In C#, fields are initialized before the constructor is executed, but the order of field initialization is determined by their declaration within the class.

When an object is created, memory is allocated for all fields of the class, and each field is initialized to its default value (e.g., 0 for numeric types, null for reference types) before the constructor is executed. Then, the constructor is called to perform additional initialization logic.

The issue arises when one field tries to use the value of another field during its initialization. At that point, the field being referenced might not have been initialized yet, leading to unexpected behavior or compilation errors.

To ensure that fields are initialized properly and that they can reference each other's values during initialization, it's often necessary to initialize them in the constructor, where you have more control over the order of initialization. Alternatively, you can directly assign the same initial value to multiple fields, as shown in the corrected code snippets provided earlier.

In C#, static fields are initialized before any instance of the class is created, typically during the class initialization process, which occurs before the runtime. These static fields are initialized only once, and their values are shared across all instances of the class.

On the other hand, instance fields, also known as non-static fields or member variables, are initialized when an instance of the class is created, which happens during runtime. These instance fields are initialized separately for each instance of the class, and their values are specific to each instance.

The error you're encountering, "A field initializer cannot reference the non-static field, method, or property," is indeed due to the fact that C# doesn't allow field initializers to reference other instance fields. This restriction is in place to prevent potential issues with initialization order, particularly in more complex scenarios where dependencies between fields might exist.

In your example, `field2` attempts to initialize itself using the value of `field`. While there's no circular dependency between `field` and `field2`, the compiler still enforces this rule to maintain consistency and prevent possible pitfalls.
## Properties
You
In a way, properties are like methods which have two inside methods - getter and setter?

ChatGPT
That's a great way to think about it! In object-oriented programming, properties can indeed be seen as special methods that provide controlled access to the internal state of an object. They encapsulate the logic for getting and setting the value of a particular piece of data (the property) within an object.

Here's a breakdown of how properties are similar to methods:

1. **Getter Method**: The getter part of a property is similar to a method that retrieves the value of the property. It encapsulates the logic for accessing and returning the value of the property.
    
2. **Setter Method**: If the property has a setter, it's similar to a method that sets the value of the property. It encapsulates the logic for modifying the value of the property.
    
3. **Encapsulation**: Properties, like methods, encapsulate the internal implementation details of how the value is stored or computed. They provide a clear interface for interacting with the object's state, hiding the implementation details from external code.
    
4. **Abstraction**: Properties, like methods, can provide a level of abstraction by allowing controlled access to the internal state of an object. They can enforce constraints, perform validation, or compute values on the fly, all without exposing the underlying implementation details.
    

So, indeed, properties can be thought of as a special kind of method pair (getter and setter) that provides controlled access to the state of an object. This abstraction helps improve the maintainability, flexibility, and security of the codebase.
## Compile time vs Runtime
Runtime: Imagine your code as a play. Runtime is when the play is being performed on stage. Everything that happens during the play's performance is runtime. In programming, runtime refers to when your code is actually running, and you can see its behavior, like when you run your program and it performs tasks or calculations.

Compile time: Going back to our play analogy, compile time is like the rehearsal before the play. It's when the actors practice their lines and actions, and the director (the compiler) checks for any mistakes in the script (your code). In programming, compile time is when your code is being translated into instructions that the computer can understand. The compiler checks your code for errors and prepares it for runtime.

Now, let's apply these concepts to your question:
- Runtime: When you run your program and see the actual output or behavior of your code, that's runtime. For example, printing a variable's value or performing calculations happens at runtime.
- Compile time: This is when the compiler checks your code for errors and prepares it to run. If there are any mistakes or warnings in your code, the compiler will catch them during this stage. It's like rehearsing your play to catch any mistakes before the actual performance (runtime).

In the context of your question, the difference in behavior between `string name;` and `string test = null;` might be due to how the compiler treats uninitialized variables versus explicitly initialized variables. The compiler might give warnings or errors for uninitialized variables because accessing them without initialization can lead to problems at runtime. But both variables will have the value `null` at runtime.

1. **Development Phase**: This includes everything from conceptualizing your program to writing, editing, and refining your code. It encompasses the entire process of creating your software solution.
2. **Compile Time**: When you've finished writing your code and you hit the compile or build button, this is the compile time. Here, your code is translated into machine-readable instructions by the compiler. The compiler checks for syntax errors, type mismatches, and other issues, providing feedback to help you correct any mistakes.
3. **Runtime**: Once your code has been successfully compiled and you execute the program, it enters the runtime phase. This is when your code is actually running, and you can observe its behavior and output as it performs tasks or calculations.
# Constants
A constant value, in programming, refers to a value that remains unchanged throughout the execution of a program. Constants are used to represent fixed values that are known at compile time and are not expected to change during the execution of the program.

Here are some key characteristics of constant values:
1. **Fixed Value**: Constants have a fixed value that does not change during the program's execution.
2. **Known at Compile Time**: The value of a constant is known to the compiler at compile time. This means that the value must be explicitly defined in the code and cannot be altered or determined at runtime.
3. **Immutability**: Constants are immutable, meaning they cannot be modified or reassigned once they are defined.
4. **Compile-Time Evaluation**: Constants are typically evaluated by the compiler rather than at runtime. This allows the compiler to optimize the code and replace references to constants with their actual values, which can improve performance.
5. **Naming Convention**: Constants are often named using uppercase letters and underscores to distinguish them from variables and convey that their values are fixed.

When you use a constant value in your code, the compiler typically replaces references to that constant with the actual value during compilation. This process is known as "constant folding" or "compile-time evaluation".

Here's how it works:

1. **Declaration**: You define a constant with a specific value in your code. For example:

```
const int MaxValue = 100;
```

2. **Usage**: You use the constant in your code, such as in assignments, calculations, or comparisons:

```
int x = MaxValue;
```

3. **Compilation**: When you compile your code, the compiler replaces references to the constant with its actual value. So, the line `int x = MaxValue;` effectively becomes `int x = 100;`.
4. **Optimization**: Constant folding allows the compiler to optimize the code by eliminating unnecessary memory allocations and instructions. By replacing references to constants with their actual values, the compiler generates more efficient code.
    

This optimization not only improves the performance of the compiled code but also ensures that the behavior of the program remains consistent with the constant values defined in the source code.
# Bookmarks 
[C# Masterclass - C# Tips and Tricks - октомври 2019 - Николай Костов - YouTube](https://www.youtube.com/watch?v=KrTMzYhpo3E&t=4s)
[Recursion (2013) Bulgarian - Рекурсия - YouTube - Николай Костов](https://www.youtube.com/watch?v=ax1hJOe7dO0)
