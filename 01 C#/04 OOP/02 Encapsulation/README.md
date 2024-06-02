# General
Енкапсулацията в същината си означава скриване на излишните детайли. Скриване на информацията от външния свят, за която не искаме да я променя и да знае за нея.
Много важен принцип в ООП е нашите класове да имат пълен контрол над данните си във всеки един момент. 
Целта е да се защити класа от такива промени и действия, които не са коректни за логиката му. Примерно ако имаме пропърти "заплата" в класа ни, чрез проверката която слагаме в set метода, ще може да подсигурим само валидни стойности. Ако няма проверка, някой може да сложи отрицателно число или заплата под минималната. 
## Property
Пропъртитата са комбинация от специални get (getter) и set (setter) методи, които взимат или дават стойност на дадено поле в класа. Реално са два метода прикрепени към private поле. 
Ако имаме property `FirstName` в нашия клас `Person` и направим променлива на която искаме да присвоим стойност, всъщност викаме set метода на пропъртито:

```
person.FirstName = "Name";
```

Set метода бива извикан скрито от нас, без да има нужда да слагаме скоби както при стандартните методи и слага стойност на private полето което стои зад `FirstName`. Ако не сме разписали някаква логика а сме оставили пропъртито по default както е, тогава private полето е скрито. 

Можем да сложим set да бъде private, което ще означава че само от вътре в класа, може да променяме стойността на пропъртито.
В 90% от случаите се ползват автоматични пропъртита, тоест такива които нямат разписана логика в get или set методите и private полето е скрито. 

Съкратен запис на пропърти, което има само getter:

```
   private List<string> list = new List<string>();
   
   public int Count => list.Count;
```

Така изглежда напълно разписано пропърти:

```
private string firstName;

public string FirstName
{
    get
    {
        return firstName;
    }
    set
    {
        firstName = value;
    }
}

//The methods below are doing the same job as the FirstName property getter and setter
public string GetFirstName()
{
    return firstName;
}

public void SetFirstName(string value)
{
    firstName = value;
}
```

Реално пропъртито е метод, където типа му определя какъв тип данни ще върнем, по същия начин както метода `GetFirstName()` трябва да върне стринг, така и пропъртито `FirstName` трябва да върне string. И при двата случая, ако върнем поле от друг тип данни, ще даде грешка. При setter-a value-то което получава като параметър е от типа на пропъртито. Ако му подадем друг тип, ще има грешка.
## Validation
Трябва да проверим данните преди да са записани в класа, ако има проблем да се коригират или да се хвърли грешка без да се приемат. Трябва да си гарантираме, че всички входни точки за информация - конструктор, поле, пропърти, методи и тн, са защитени чрез проверка на данните.
Добре е валидацията да се случва в setter-a, а не в конструктора, защото така гарантираме, че те ще бъдат валидирани, всеки път когато им се променят стойностите, а не само при създаването на обекта.
Желателно е конструкторите винаги да присвояват стойност на пропъртитата, ако има такива, а не директно на полетата. Целта е да се ползва валидацията на setter-a, за да не се дублира код и същата валидация да се пише и в конструктора. Дори в момента setter-а да не е разписан, след време ако се добави валидираща логика, данните ще бъдат валидирани.
## this
Означава текущия обект, върху който е извикан даден метод или пропърти. Ако имаме метод в нашия клас `Person` който добавя в List от тип `Person`, може да добавим this като параметър. Това е полезно, когато трябва да препращаме текущия обект към други методи или да го добавим в колекция.

```
namespace ConsoleApp
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void AddPerson(List<Person> list)
        {
            list.Add(this);
        }
    }

    public class Program
    {
        static void Main()
        {
            List<Person> list = new List<Person>();

            Person person = new Person()
            {
                Age = 5,
                Name = "Test"
            };

            person.AddPerson(list);
        }
    }
}
```

По време на debug, когато сме вътре в класа се вижда, че this съдържа всички членове на текущия обект.
Лесно се различава дали става въпрос за локална променлива или пропърти / поле когато пишем `this.`Така с един поглед се разбира, че става въпрос за член на класа, а не локална променлива в метод примерно. 
## Access Modifiers
Добрата практика е винаги да се пишат модификаторите за достъп.
Default стойностите, са винаги минималните - даващи най-малко видимост на външния свят.
Друга добра практика е винаги да се държи най-ниското ниво - да се дава минимален достъп на всичко, докато не се наложи да дадем по-голям. Това е и основен принцип в security в IT сферата.

public - най-разрешаващия модификатор, дава на всички право на достъп. 

private - най-ограничаващия модификатор, чрез него основно прилагаме принципа за енкапсулация. Абсолютно никой извън класа не може да достъпва дадения член.

internal - всички в текущия проект имат достъп.

protected - разрешава на всички наследници на класа, включително извън проекта, да достъпват дадения член.

Трябва да се стремим така да изграждаме класовете, че само нещата, които ще потрябват на външния свят да бъдат видими.

Има смисъл да се правят класове, които да са private, само ако са вложени в друг клас, тоест не са необходими на външния свят, а само на класа в който се намира. Иначе ако класа е private и не е вложен в друг клас, то той няма да може да бъда достъпен от никъде и става безсмислен. Важно да се отбележи е че ако вложения клас има член който е private, то той няма да бъда достъпен от съдържащия го клас.

Класовете ги правим public, само когато искаме външни библиотеки да може да ги ползват.
## Mutable vs Immutable Objects
Immutable обектите, са обекти които промяната им изисква създаването на нов обект на ново място в паметта.
Може да постигнем този ефект, като направим setter-a на всички пропъртита на private, така членовете в даден клас, ще може да се инициализират само в конструктора и след това няма да подлежат на промяна.

Мutable обектите, използват същата памет при промяна.
### Real immutable class
Ако имаме class с пропърти от референтен тип данни, примерно List и му направим setter-a private или го изтрием, то пак през getter-а получаваме достъп до паметта и вътре ще може да извикаме примерно метода `Clear()`който ще изчисти листа. Това чупи цялата ни концепция, че списъка е read only. Този проблема се случва при референтните типове. Това, което може да направим е да изберем специален тип колекция, която да е нещо по-базово, примерно интерфейсите `IEnumerable<T>` или `IReadOnlyCollection<T>`, които предоставят само методи за четене. Така от вън, ще може само да се извикват методи за четене и няма да може да се променя колекцията.
С други думи - при работа с референтни типове данни в C#, трябва да внимаваме как ги излагаме чрез пропъртитата на класовете си. Когато използваме getter за колекция като `List<T>`, дори и да е private или без setter, все още предоставяме достъп до оригиналния обект, който може да бъде променен. За всички референтни типове данни трябва да се внимава с предоставянето на достъп чрез getter.
#### Example
Пример за пълна защита и енкапсулация на полето `list` в класа, чрез използването на полиморфизъм. Единствения начин да се вкарат стойности във вътрешния масив е чрез метода `AddElements()`. Когато някой иска да види list-a, трябва да ползва пропъртито `List` или метода `GetList()`, които чрез полиморфизъм връщат `IreadOnlyCollection`. Връщаме такъв тип колекция, защото не може да бъде променяна.

```
namespace ConsoleApp
{
    public class MyClass
    {
        private List<string> list = new List<string>();

        //Property approach
        public IReadOnlyCollection<string> List
        {
            get
            {
                return list;
            }
        }

        //Method approach
        public IReadOnlyCollection<string> GetList()
        {
            return list;
        }

        //The only way to add values in the list
        public void AddElements(params string[] elements)
        {
            list.AddRange(elements);
        }
    }

    public class Program
    {
        public static void Main()
        {
            MyClass myClass = new MyClass();

            myClass.AddElements("test1", "test2");

            //The property and the method produce the same result
            var list1 = myClass.List;
            var list2 = myClass.GetList();
        }
    }
}
```
## .Net code Structure
Имаме главен проект, който го наричаме solution, който включва в себе си проекти. Всеки проект може да бъда конзолно приложение, мобилно, web, desktop, class library и тн. Базовите приложения имат около 10 проекта. Идеята е кода да бъде разпределен на повече места и така ще се управлява по-лесно.

Може да ограничим дадени проекти да виждат само определени други проекти. По default проектите не виждат другите проекти. 
Примерно ако имаме Project1 и Project2 и искаме project1 да може да ползва Project2, трябва да кликнем десен бутон върху Dependencies, под името на Project2 и да изберем "Add Project Reference" и посочим Project1.
### Class library
Проект който съдържа единствено класове, няма Main метод и не може да се стартира. Ползват се с цел да се организират класовете или ако ни трябва някаква функционалност от външни библиотеки
# Misc
Python е езикът който се е наложим в индустрията за изкуствен интелект. 
## Record
**MyClass**: Стандартен клас с конструктор и пропъртита с `get` и `set`.
**MyClass2**: `Record` с основен конструктор и пропъртита, които са `init`-only, т.е. могат да бъдат инициализирани само по време на създаване на обекта.
**MyClass3**: `Record` с пропъртита, които са напълно записваеми (`get` и `set`), и имплицитно дефиниран празен конструктор.

```
    public class MyClass
    {
        public MyClass(string item1, string item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public string Item1 { get; set; }

        public string Item2 { get; set; }
    }

    public record MyClass2(string Item1, string Item2);

    public record MyClass3 { string Item1; string Item2; }
```
# ChatGPT
## Program Cycle
За да се изпълни програмата, която сте написали на C#, тя трябва да мине през две основни компилации:
1. **Компилация на C# код до IL (Intermediate Language)**:
    - Първата компилация се случва когато компилаторът за C# (например Roslyn) превръща вашия C# изходен код в междинен език (IL). Този междинен език е специфичен за .NET платформата и не е машинен код, който може да се изпълни директно от процесора.
2. **JIT компилация (Just-In-Time компилация)**:
    - Втората компилация се случва когато програмата се стартира и се изпълнява от .NET Runtime (CLR - Common Language Runtime).
    - CLR зарежда IL кода от .exe или .dll файла и използва JIT компилатора, за да го преведе в машинен код. Този машинен код е специфичен за архитектурата на процесора, върху който се изпълнява програмата.

Процесът в няколко стъпки:
1. **Написване на C# код**:
    - Програмистът пише програмата си на C#, която включва всички необходими инструкции и логика.
2. **Компилация на C# код**:
    - Когато програмистът компилира своя C# програма, компилаторът превръща изходния код в междинен език (IL), който се съхранява в .exe или .dll файл.
3. **Изпълнение на програмата**:
    - Когато изпълнимият файл се стартира, .NET Runtime (CLR) зарежда IL кода.
    - CLR използва JIT компилатора, за да преведе IL кода в машинен код, който може да се изпълни от процесора на компютъра.

Защо две компилации?
- **Интерпретируемост и абстракция**: Използването на междинен език (IL) позволява абстракция на програмния език от конкретната архитектура на хардуера. Това улеснява преносимостта на програмите, позволявайки им да се изпълняват на различни архитектури и операционни системи.
- **Оптимизация**: JIT компилацията позволява на CLR да оптимизира изпълнението на програмата специфично за конкретния компютър, на който се изпълнява.

Заключение:
И така, да, за да работи програмата, която сте написали на C#, тя трябва да мине през две компилации - първата компилация на C# кода до междинен език (IL) и втората JIT компилация от CLR до машинен код. Този процес позволява на .NET приложенията да бъдат преносими и ефективно изпълняеми на различни платформи.
# Bookmarks 
[Защо C# е перфектният първи език за програмиране? - YouTube](https://www.youtube.com/watch?v=RICc4KQXYBk)

[Numberphile - YouTube](https://www.youtube.com/@numberphile) - Videos about numbers and mathematics.

[ASP.NET Core - Security & Identity - Nikolay Kostov - YouTube](https://www.youtube.com/watch?v=itT73BVRuEQ)  - първата половина от лекцията се разглеждат различни видове атаки, при web приложенията.

Книги препоръчани от Николай Костов:

[Code Complete: A Practical Handbook of Software Construction, Second Edition: McConnell, Steve: 0790145196705: Amazon.com: Books](https://www.amazon.com/Code-Complete-Practical-Handbook-Construction/dp/0735619670) - за качествен програмен код, лесна и приятна за четене, полезна за начинаещи.

[CLR via C# (Developer Reference): Richter, Jeffrey: 9780735667457: Amazon.com: Books](https://www.amazon.com/CLR-via-4th-Developer-Reference/dp/0735667454/ref=sr_1_1?crid=1HTMN2JAX4Y58&dib=eyJ2IjoiMSJ9.TP5_9BV8_i1Sup6AKeabruYIHytcYVbqjq5dvl767_Es0E7DTBpZ2HM5OWhOhZqpUcNKQqUC6e7BMJedoFcYbTGnroFpAnW45ImSX7yhhrz__pg0SZvH2XecFrbUSiHpl_2RZVMpNDJDcxV9qY7iAQ.mPovqwoBnHCdvTpETRGY_MiHSfETcaahdpsPLwsDPD0&dib_tag=se&keywords=clr+via+c%23&qid=1717143888&s=books&sprefix=clr+%2Cstripbooks-intl-ship%2C287&sr=1-1) - показва C# на много ниско ниво и как работи точно, за по-напреднали.

[Програмиране=++Алгоритми; - Преслав Наков, Панайот Добриков](https://knizhen-pazar.net/sold_products/books/1968736-programirane-algoritmi) - Костов е учил по нея за състезания.

[The Algorithm Design Manual : Skiena, Steven S: Amazon.nl: Books](https://www.amazon.nl/-/en/Steven-S-Skiena/dp/1849967202) 

[Introduction to Algorithms, 3rd Edition (Mit Press): Cormen, Thomas H, Leiserson, Charles E, Rivest, Ronald L, Stein, Clifford: 9780262033848: Amazon.com: Books](https://www.amazon.com/Introduction-Algorithms-3rd-MIT-Press/dp/0262033844/ref=sr_1_2?crid=X5H4UCMVBRA7&dib=eyJ2IjoiMSJ9.dDPqDZSqkDgdnEPWAEei-Gq3gCVIjXxt9eyJ9zX_ywHVakZZBB7kD5WYrJk_fGXZovJ_9AVr1-HX4Lria3FFCnKNhMRAYwcyK1aSBxTs41A4jMcA6lQaScOCPjbRLMJSUUwPEe7DR3JFxPDg3JntVd_swBB4DquRKVrs8bwjGT56doQy1pPUQ9vcYETSk4rzPiZaWjIuF3QhZkmig_jugkklbnx69GyLRqJsLBvLg68.VWnF36XZp9RrRVq2WLc3gOCMkvKzFIXrrWxtDxHNV7s&dib_tag=se&keywords=introduction+to+algorithms&qid=1717143845&s=books&sprefix=intr%2Cstripbooks-intl-ship%2C296&sr=1-2) - Курса за алгоритми е базиран на тази книга и е за по-напреднали.

[Amazon.com: Artificial Intelligence: A Modern Approach (Pearson Series in Artifical Intelligence) eBook : Russell, Stuart, Norvig, Peter: Kindle Store](https://www.amazon.com/Artificial-Intelligence-Approach-2-downloads-Artifical-ebook/dp/B092J75GML/ref=sr_1_2?crid=I6O9QYDCK7D&dib=eyJ2IjoiMSJ9.F4BJEvae4dekAwkEnttBiLYt7t0xnijHQa6SX0ML1EykgsPkGo2pbEZa_yzz8uRs2ZfWfyj88CMm3jNg0D8d3AmRQgXjPEmWiZbTF3hH_Iq-bousVk0sGMO4v0sh21MSaoWXVXI95ekOMyhOstGhKmUIBfwTxh4OF95rBefituReTF1d1tL2IiJSCrGK-uHdkeHGdpEVrL_Jo6giXnY97Lr16hxiBXxVTa91vxjxQrc.yy8uZWebsNPNUG7NmQ3Wm3jF6ygXvPnhU5pjVq2HSKQ&dib_tag=se&keywords=artificial+intelligence+a+modern+approach&qid=1717144024&s=books&sprefix=art%2Cstripbooks-intl-ship%2C254&sr=1-2) - много добра книга за изкуствения интелект, трябва математика за 12 клас + матрици, вектори, дискретна математика, статистика, малко анализ. Като цяло е за доста по-напреднали.

Course completion: 02.06.2024