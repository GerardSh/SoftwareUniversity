# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#)

Итераторите и компараторите са допълнителни неща, които може да добавим в нашия клас, с цел да разширим неговите функционалности.
## Iterators
Итераторите и енумераторите са едно и също нещо. Итераторите са функционалност в C# и езиците около .NET платформата. Позволяват ни да обхождаме една колекция с foreach. Ако искаме наш клас да може да бъде foreach-нат, трябва да използваме вградения интерфейс в .NET `IEnumerable<T>` който има само един метод `GetEnumerator()`, показващ на C# с какви стъпки да обхожда елементите от даден клас. Кой е точния алгоритъм, точната последователност от стъпки, чрез които може да се обходи съответния клас.
Когато имплементираме `IEnumerable<T>` за нашия клас, `<T>` трябва да отговаря на това какъв тип, ще са елементите които ще обикаляме в нашия клас.

Когато добавим интерфейса към нашия клас - `internal class Student : IEnumerable<double>` трябва да го имплементираме с `Ctrl + .` или ако ръчно въведем неговите два метода в класа. Реално втория метод `IEnumerator IEnumerable.GetEnumerator()` е ненужен и единствено стои поради legacy причини. Достъпен е експлицитно чрез името на стария клас `IEnumerable.GetEnumerator()`, защото иначе става конфликт с имената на методите. Това което се прави е да му дадем `return this.GetEnumerator();` тоест върни това, което ще върне другия метод и го забравяме. 
След като сме добавили интерфейса към класа и сме му посочили типа данни на мястото на `<T>` когато правим foreach на обект от нашия клас, то foreach знае какъв ще е типа данни, които ще обикаля. Трябва да измислим по какъв начин ще се обработва нашия клас и най-простото нещо, което може да направим е да пренасочим обработването на нашия клас, към обработването на нещо друго. Когато някой иска да обработи / да взима елементите от нашия клас `Student` в примера долу, може да му кажем да обработи оценките му. С други думи, вместо ние да измисляме някакви сложни логики в метода `GetEnumerator()` може да кажем обработването на `Student` е същото, като обработването на неговите оценки. Метода `GetEnumerator()` на `Student` казва намери какво прави Grades в нашия случай `List<double>` и от него се връщат елементи от тип double. При foreach на нашия `Student` ще получим неговите оценки. Това което се случва е, че foreach ще пита студента, как да те обходя и студента ще каже, ползвай enumerator алгоритъма който е имплементиран в списъка с оценките:

```
namespace ConsoleApp
{
    public class Student : IEnumerable<double>
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public IEnumerator<double> GetEnumerator()
        {
            return Grades.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Program
    {
        static void Main()
        {
            var student = new Student();
            student.Grades = new List<double> { 5.5, 5.6, 5.7, 5.8, 5.9, 6 };

            student.Grades.GetEnumerator();

            foreach (var grade in student)
            {
                Console.WriteLine($"{grade:f2}");
            }
        }
    }
}
```

Понякога се налага ние сами да си пишем логиката по която да се обхождат елементите в класа ни. Този код, който определя как ще се обработва дадено нещо, се нарича `Enumerator`. Това е отделен клас, в който се намира единствено логиката на обработване на елементите. 

Цикъла foreach e построен върху `GetEnumerator()` :

```
            var enumerator = student.GetEnumerator();
           
            while (enumerator.MoveNext())
            {
                var grade = enumerator.Current;
                Console.WriteLine($"{grade:f2}");
            }
            
            enumerator.Reset();

            // Тhe above while is the same as:

            foreach (var grade in student)
            {
                Console.WriteLine($"{grade:f2}");
            }
```

В while цикъла се вика метода `MoveNext()`, който се мести на дясно и връща bool стойност дали е успял. В този метод се намира цялата логика в това какво означава да отива надясно. 
За някои неща, отиването на дясно е много лесно, примерно при масивите `Reset()` означава започни от нулевия елемент, а отиването на дясно е да се отиде към следващия елемент. 
Ако колекцията е по-сложна, примерно дърво, тогава `MoveNext()` трябва да взима по-сложни решения, в зависимост от алгоритъма с който работи, може да мине на следващ елемент от ляво или на следващия елемент от дясно първо или първо parent елемент-а и тн. `MoveNext()` - преценява как да отиде до следващия елемент и дали сме стигнали края. 
За да реализираме - `Reset()`, `MoveNext()` и `Current`, те също са обединени в общ интерфейс, който се нарича `IEnumerator<T>`.

`IEnumerator<T>`, трябва да го използваме за класа, в който ще изпишем логиката на нашия enumerator, по която да се обхождат елементите в класа ни. Този интерфейс ще ни създаде методите и пропъртито Current, където отново имаме с legacy цели оставено старото пропърти `object IEnumerator.Current => Current;`, отново трябва да го направим да връща новия Current. И тук имаме конфликт с имената на пропъртитата и поради тази причина, старото пропърти е достъпено експлицитно чрез името на стария интерфейс `IEnumerator.Current`.

След като създадем enumerator класа ни, трябва да му направим конструктор в който да подаваме листа от нашия клас, който ще се обхожда:

```
 public class Student : IEnumerable<double>
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public IEnumerator<double> GetEnumerator()
        {
            return new ReverseIterationEnumerationLogic(Grades);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
```

В примера горе, сме създали `ReverseIterationEnumerationLogic` class, където сме изградили логика как да се обхожда подадената колекция в обратен ред. Към този клас сме имплементирали и `IEnumerator<T>` интерфейс с необходимия тип данни. След това, foreach вика `GetEnumerator` метода на нашия student, който създава нов обект от тип `IEnumerator`, съдържащ цялата нужна информация за да може foreach да работи - има колекция, взета от студент класа в случая `Grades` и има логиката по която да се движи към следващия елемент чрез метода `MoveNext()`. Единственото което прави foreach е да вика тези методи в определен ред и да връща текущия елемент. Това което гарантира на foreach че може да работи с нашия `IEnumerator` е имплементацията на `IEnumerator` интерфейса която класа ни има. Без тази имплементация, няма да работи. Примерно в Student класа ни, може и да нямаме `IEnumerable` интерфейс, достатъчно е да имаме само метода `GetEnumerator()` и пак ще работи.

```
using System.Collections;

namespace ConsoleApp
{
    public class Student : IEnumerable<double>
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public IEnumerator<double> GetEnumerator()
        {
          return new ReverseIterationEnumerationLogic(Grades);       
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class ReverseIterationEnumerationLogic : IEnumerator<double>
    {
        private List<double> items;

        private int index;

        public ReverseIterationEnumerationLogic(List<double> items)
        {
            this.items = items;
            index = items.Count;
        }

        public double Current => items[index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (index > 0)
            {
                index--;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            index = items.Count;
        }
        public void Dispose()
        {

        }
    }

    public class Program
    {
        static void Main()
        {
            var student = new Student();
            student.Grades = new List<double> { 5.5, 5.6, 5.7, 5.8, 5.9, 6 };

            foreach (var grade in student)
            {
                Console.WriteLine($"{grade:f2}");
            }

            //Working the same as the C# implemented foreach loop.
            var enumerator = student.GetEnumerator();

            enumerator.Reset();

            while (enumerator.MoveNext())
            {
                var grade = enumerator.Current;
                Console.WriteLine($"{grade:f2}");
            }        
        }
    }
}
```

В същината си видно от кода долу, дори няма нужда от интерфейси, за да си направим наш foreach цикъл, достатъчно е само да имаме enumerator обект, на който да подадем дадена колекция:

```
namespace ConsoleApp
{
    public class Student 
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }
    }

    class ReverseIterationEnumerationLogic 
    {
        private List<double> items;

        private int index;

        public ReverseIterationEnumerationLogic(List<double> items)
        {
            this.items = items;
            index = items.Count;
        }

        public double Current => items[index];

        public bool MoveNext()
        {       
            if (index > 0)
            {
                index--;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            index = items.Count;
        }
    }

    public class Program
    {
        static void Main()
        {
            var student = new Student();

            student.Grades = new List<double> { 5.5, 5.6, 5.7, 5.8, 5.9, 6 };

            var enumerator = new ReverseIterationEnumerationLogic(student.Grades);

            while (enumerator.MoveNext())
            {
                var grade = enumerator.Current;
                Console.WriteLine($"{grade:f2}");
            }
        }
    }
}
```

Всичко се свежда до това че трябва да имаме enumerator обект, и да го напълним с данни и този обект се подава към foreach, който използва напълнените данни вътре заедно с методите от enumerator interface-a, за да ги обходи.
### Yield Return
Понякога може да си спестим писането на отделен клас enumerator и вътре в метода `GetEnumenator()` да си напишем обхождането с наш цикъл и за да решим кога даден елемент отива в foreach ползваме оператора yield return. Това е направено за наше улеснение и може да оставим C# да генерира enumerator клас вместо нас, използвайки нашия направен цикъл или кои елементи да обходи. Това е доста сложно и създателите на C# много са се постарали, да може да работим само с една думичка `yield`. Реално ако си направим променлива и запишем резултата от `GetEnumerator()`, отново ще получим обект от тип enumerator.
В практиката се ползва по често от отделен enumerator клас, защото повечето неща може да се направят по този начин. Възможна причина все пак да предпочетем отделен enumerator е по-голямото му бързодействие.

```
 public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < books.Count; i++)
            {
                yield return books[i];
            }
        }
```

Конструкцията yield return е направена по много хитър начин, със стеков автомат и се следи в генерирания от C# enumerator за правилното придвижване по елементите.

```
using System.Collections;

namespace IteratorsAndComparators
{
    class Student : IEnumerable<string>
    {
        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public IEnumerator<string>  GetEnumerator()
        {
            yield return FirstName;
            yield return FamilyName;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Program
    {
        public static void Main()
        {
            Student student = new Student()
            {
                FirstName = "Gerard",
                 FamilyName = "Shahin"
            };

            foreach (var name in student)
            {
                Console.WriteLine(name);
            }
        }
    }
}
```

Това е друг начин по който може да ползваме yield return - изреждаме елементи вътре от класа, които задължително трябва да са от един тип. Всеки елемент ще бъде подаван към foreach и след това ще се връща за следващия елемент докато свършат:
## Comparators
Позволяват да декларираме кога два обекта създадени от наш клас са по-големи или равни един с друг. Примерно ако имаме две книги, трябва да изберем критерии, чрез който да определим коя книга е по-голяма. Примерно тази с повече страници или тази която е по-нова, или тази която е с по-голяма популярност или по-дълго име и тн.
С други думи, компараторите ни дават начин да определим кога дадена инстанция от наш клас е по-голяма от друга инстанция от същия клас. 
Когато искаме да може да се сравняват инстанциите, трябва да имплементираме интерфейса `IComparable<T>`, който съдържа един метод `CompareTo()`, определящ сортировката. 
Задължително трябва да го имплементираме и когато искаме обекти от нашия клас, да бъдат съхранявани в `SortedSet` или `SortedDictionary` колекции. Трябва да се внимава с `SortedSet`, защото ако има няколко елемента, които са определени като равни, ще остане само един.
Метода `CompareTo()` трябва да определи на база данните, които имаме в класа, как се отнасят спрямо друга инстанция на класа. 
Трите стойности които метода връща, при сравнение на две инстанции са:

```
this > other
this == other
this < other
```

Когато другата инстанция е по голяма, метода трябва да връща отрицателно число, ако двете са равни трябва да върне 0 и ако текущата инстанция е по-голяма трябва да връща положително число. Добрата практика е отрицателно число да е винаги -1, а положителното 1. 

Изразено с код:

```

public class Book : IComparable<Book>
{
    public Book(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public string Title { get; set; }

    public int Year { get; set; }

    public int CompareTo(Book? other)
    {
        if (Year > other.Year)
        {
            return 1;
        }
        else if (Year < other.Year)
        {
            return -1;
        }
        else
        {
            return Title.CompareTo(other.Title);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Book bookOne = new Book("Animal Farm", 2003);
        Book bookTwo = new Book("The Documents in the Case", 2002);
        Book bookThree = new Book("A Short History of Nearly Everything", 2003);

        Console.WriteLine(bookOne.CompareTo(bookTwo));
        Console.WriteLine(bookOne.CompareTo(bookThree));
        Console.WriteLine(bookTwo.CompareTo(bookOne));
    }
}
```

В примера може да забележим, че при равенство в годините, правим допълнителна лексикографска проверка и вече ако и там имаме равенство, върнатия резултат ще е 0. 

Принципно може да ползваме и `OrderBy().ThenBy()` за да сортираме по дадена логика и критерии, но всеки път като искаме да сортираме колекция от нашия клас, трябва да я изписваме. 
Когато ползваме `OrderBy()` или `ThenBy()` за да подреди колекцията по дадена string стойност, то те използват `CompareTo()` метода на string класа, за да проверят кой стринг е по-голям.
По удачно е да имплементираме логиката директно вътре в класа, чрез `IComperable` интерфейса и така ще може да се преизползва отново и отново на различни места. Допълнително ще имаме на разположение `Sort()` метода, както и `SortedSet` и `SortedDictionary` колекции.
### Comparer
В нашия клас, може да имаме само една единствена сортировка, която дефинираме в метода `CompareTo()`. Когато искаме класа ни да може да бъде сортиран по повече от един начин, тоест искаме да имаме различни алгоритми, различни логики по които да се извършва сортирането, трябва да ги отделим в отделен клас, който се занимава само и единствено с това. Може да си направим много такива класове. Този клас трябва да имплементира интерфейса `IComparer<T>` , а не `IComparable<T>` и взима вече две книги, които да сравни и отново връща положително или отрицателно число или 0. Този интерфейс съдържа метода `Compare(T x, T y)`. Когато искаме да ползваме логика от Comparer клас, трябва да подадем инстанция на тоя клас в `Sort()` метода - `classCollection.Sort(new BookComparator());` Освен на `Sort()` метода, новата сортировка може да я подаваме и когато правим sorted Set или Dictionary в техния конструктор.

Example comparer class:

```
  public class BookComparator : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            int result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }

            return result;
        }
    }    
```

Ако нямаме желание да правим цял клас за сортиране, може директно в `Sort()` с анонимен метод да напишем логиката за сортиране: `books.Sort((x, y) => x.Year > y.Year ? 1 : x.Year < y.Year ? -1 : 0);`
## Inheritance
Основно правило в програмирането е, че ако ще променяме кода за нещо, кода трябва да е така написан, че промяната да е само на едно място. Copy - Paste трябва да се избягва дублирането на код. Поради тази причина е измислено наследяването - даден клас да използва всичките членове на друг клас и да добави допълнително каквото му е нужно:

```
namespace ConsoleApp
{
    class Student
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }
    }

    class UniversityStudent : Student
    {
        public string University { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            UniversityStudent student = new UniversityStudent();        
        }
    }
}
```

В този пример, `UniversityStudent` класа има всички пропъртита на `Student` класа + допълнителното негово пропърти.
## Interface
Интерфейса е нещо като клас, който единствено описва списък от методи или свойства (по рядко), но без тяхната функционалност. Тоест е нещо като описание на методи, които трябва да присъстват / наследят задължително във всички класове, които ще имплементират този интерфейс. Тези методи са празни и класа трябва да определи какво ще има в тези методи. 
Интерфейсите се кръщават с `I` отпред и се създават в нов файл. Примерно, може да декларираме следния интерфейс:

```
namespace ConsoleApp
{

    interface IHaveInstitutionName
    {
        string GetName();

        void PrintName();
    }

    public class Student : IHaveInstitutionName
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void PrintName()
        {
            throw new NotImplementedException();
        }
    }
```

Всеки клас, който имплементира този интерфейс е задължен да име тези методи, със същото име и signature.
Интерфейсите служат да може да групираме няколко класа под обща категория, които да имат обща функционалност.

Два основни съществуващи интерфейси са `IEnumerable<T>` и `IComparable<T>`
`IEnumerable<T>` дава възможност да обикаляме елементите с foreach.
`IComparable<T>` дава възможност за участие в сортиране, `SortedSet` и `SortedDictionary`. 

C# знае че ако класа имплементира този `IComparable<T>`, то той може и знае как да се сортира, или ако имплементира `IEnumerable<T>` той може да участва във foreach цикли и C# знае какво да направи с този клас, така че да може да му обходи елементите един след друг.
## Methods params keyword

```
    public class Program
    {
        static void Main()
        {

            MyMethod(new int[] {1,2,3 });

            MyMethod(1,2,3);

            MyMethod();
        }

        static void MyMethod(params int[] ints)
        {
            
        }
    }
```

Води се optional parameter, ползва се когато не е ясно колко данни от един и същи тип ще получим. Трябва да се слага накрая след другите параметри и може да имаме само един `params` в метода. Работи само с едномерни масиви. Това което прави е че подадените стойностите изредени със запетайка и ги слага в масив, а може да му подадем и директно масив. Ако нищо не му подадем, инициализира празен масив.
# Misc
## The Four Stages of Competence
1 - Несъзнателна некомпетентност е когато дадено нещо не го знаем, то си е там някъде в света, но ние никога не сме го чували.
2 - Съзнателна некомпетентност е когато сме чували за дадено нещо, но не го разбираме или с други думи, знаем че не знаем.
3 - Съзнателна компетентност е когато правим нещо и разбираме когато го правим. Когато учим нещо ново и знаем как се прави, но трябва да се замисляме докато го правим, да си припомняме кое  как беше и тн.
4 - Несъзнателна компетентност е когато правим нещо автоматично, без изобщо да се замисляме в следствие на много опит.
## GitHub Pull Request
Когато намерим проблем в чужд код, трябва да направим pull request - тоест предложение за промяна.
## Design pattern
Composite - когато един клас има елементи от себе си, тоест дървовидна структура от данни, под формата на класове.
## Tuples
Не е добра практика да се ползват, защото имената на пропъртита им са неясни `Item1, Item2 ..` и тн.
Има начин при дефинирането на променливата да им се сменят имената - ` (int ТestNumber, string ТestString, int TestNumber2) test =  (1, "test", 2);`
По-добрата практика е да се направи отделен клас.
Tuples са нещо като анонимните функции при методите.
## Homework after Web
- Learn how to search in Google
- Watch again ASP.NET Core + First 3 Web Basics lectures
- Internet Explained lecture: [Internet Explained - YouTube](https://www.youtube.com/watch?v=1pSsIlU3T-s)
- JS Applications Course / DOM / Events...
- Prepare for the interview: [Как успешно да преминем интервю за работа в IT сектора (2012) - YouTube](https://www.youtube.com/watch?v=NLoQJamzL8M)
- High-quality code [High-Quality Code - YouTube](https://www.youtube.com/playlist?list=PLf5IBVXYNTwJO9dE-XR9-iKbp_kw3_ZQy)
- Algorithms: [Intro to Data Structures, Algorithms and Complexity (2015) (Bulgarian) - Структури данни и алгоритми - YouTube](https://www.youtube.com/watch?v=PsABC66m4_I&list=PLf5IBVXYNTwLwDCbpFtQLj1_587a3asv5)
- Math course: [Курс "Математика за програмисти - част 1" - eee.bg](https://eee.bg/Courses/math-for-developers-1)
- Learn Angular, Vue.js or React
- New technology new project
- Learn a new language (C#,JS) - Python
- Book: Code Complete
- Book: C# via CLR (deep C#)
- Book: Artificial Intelligence: A Modern Approach
- Experiment with MongoDB
- ML.NET lecture: [ML.NET - YouTube](https://www.youtube.com/watch?v=dluB5VE1m1k)
- machine learning (distant future) (math) + ML.NET lecture
# ChatGPT
## Using Interface as variable
You

I don't understand why we need to use 

`IComparer<Book> comparer = new Comparer();`

and not

`Comparer comparer = new Comparer();`

What's the purpose of this?

ChatGPT

In C#, when you declare a variable using an interface type, such as `IComparer<Book>`, you're allowing that variable to hold any object that implements that interface. This is the essence of polymorphism.

When you use `IComparer<Book> comparer = new Comparer();`, you're saying, "I want a variable comparer that can hold any object that implements the `IComparer<Book>` interface, and I'm initializing it with an instance of the Comparer class, which does implement that interface."

On the other hand, if you use `Comparer comparer = new Comparer();`, you're saying, "I want a variable comparer that specifically holds instances of the Comparer class."

While both would work in your specific scenario because Comparer implements `IComparer<Book>`, the former (`IComparer<Book> comparer = new Comparer();`) is preferred because it allows for greater flexibility and adheres to programming against interfaces rather than concrete implementations. This means that if you decide to switch the implementation of Comparer or provide another class that implements `IComparer<Book>`, you can easily assign it to comparer without changing the variable's type.

So, using `IComparer<Book>` instead of Comparer makes your code more adaptable to change and adheres to good object-oriented programming practices.

In C#, interfaces cannot have instances. Interfaces define a contract or a set of methods and properties that implementing classes must provide, but they do not contain any implementation details themselves. Therefore, you cannot instantiate an interface directly. Instead, you create instances of classes that implement the interface.

However, you can have variables of an interface type. These variables can hold references to instances of any class that implements the interface. Here’s a simple example to illustrate this concept:

```
public interface IAnimal
{
    void MakeSound();
}

public class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

public class Program
{
    public static void Main()
    {
        IAnimal myDog = new Dog();  // Variable of type IAnimal holding an instance of Dog
        IAnimal myCat = new Cat();  // Variable of type IAnimal holding an instance of Cat

        myDog.MakeSound();  // Outputs: Woof!
        myCat.MakeSound();  // Outputs: Meow!
    }
}
```

In this example:

1. `IAnimal` is an interface that declares a method `MakeSound`.
2. `Dog` and `Cat` are classes that implement the `IAnimal` interface.
3. `myDog` and `myCat` are variables of type `IAnimal` that hold instances of `Dog` and `Cat`, respectively.
4. You can call the `MakeSound` method on these variables, and the appropriate method for the actual object (either `Dog` or `Cat`) will be executed.

In summary:

- Interfaces define methods and properties but cannot be instantiated directly.
- You can declare variables of an interface type, which can reference instances of any class that implements the interface.
- This allows for polymorphism, enabling you to write code that works with any implementation of the interface.
## Comparison of Equality Handling in HashSet / Dictionary and SortedSet / SortedDictionary
`GetHashCode()` is used for fast lookup in hash-based collections (`HashSet<T>`, `Dictionary<K, V>`, etc.). It provides an efficient way to locate buckets where objects may be stored based on their hash codes. Hash codes are used as an initial check to narrow down potential matches.

`Equals()` is used to verify actual object equality based on their properties or fields. It provides a more accurate comparison beyond just hash codes. `Equals()` is essential in ensuring that objects with the same hash code are truly equal based on their content, especially in cases where hash collisions may occur.

Both methods are necessary in implementing object equality:

- `GetHashCode()` ensures efficiency by quickly narrowing down the potential matches to objects with the same hash code.
- `Equals()` provides accuracy by verifying if two objects are truly equal based on their properties or fields.

For hash-based collections like `HashSet<T>` and `Dictionary<K, V>`, `GetHashCode()` and `Equals()` are crucial in managing object uniqueness and retrieval efficiency.

On the other hand, `SortedSet<T>` uses the `CompareTo()` method (via `IComparable<T>` or `IComparer<T>`) to maintain a sorted order of elements. It doesn't rely on hash codes for storage or retrieval. Instead, it directly compares elements using `CompareTo()` to maintain sorting order.
# Bookmarks 
[Sorting and Searching Algorithms (2013) Bulgarian - Алгоритми за сортиране и търсене - YouTube](https://www.youtube.com/watch?v=EHXcrswy6lo) - Николай Костов
[softuni.bg/downloads/svn/csharp-web/trunk/May-2021/ASP-NET-Core-June-2021/HomeworkAfterWeb.txt](https://softuni.bg/downloads/svn/csharp-web/trunk/May-2021/ASP-NET-Core-June-2021/HomeworkAfterWeb.txt) - Николай Костов

Course completion: 17.05.2024
