# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#)

Итераторите и компараторите са допълнителни неща, които може да добавим в нашия клас, за да ни разрешат да го обработваме елемент по елемент, тоест да го foreach-ваме. 
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
За да реализираме - `Reset()`, `MoveNext()` и `Current`, те също са обединени в общ интерфейс, който се нарича `IEnumerator<>`.

`IEnumerator<>`, трябва да го използваме за класа, в който ще изпишем логиката на нашия enumerator, по която да се обхождат елементите в класа ни. Този интерфейс ще ни създаде методите и пропъртито Current, където отново имаме с legacy цели оставено старото пропърти `object IEnumerator.Current => Current;`, отново трябва да го направим да връща новия Current. И тук имаме конфликт с имената на пропъртитата и поради тази причина, старото пропърти е достъпено експлицитно чрез името на стария интерфейс `IEnumerator.Current`.

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

В примера горе, сме създали `ReverseIterationEnumerationLogic` class, където сме изградили логика как да се обхожда подадената колекция в обратен ред. Към този клас сме имплементирали и `IEnumerator<>` интерфейс с необходимия тип данни. След това, foreach вика `GetEnumerator` метода на нашия student, който създава нов обект от тип `IEnumerator`, съдържащ цялата нужна информация за да може foreach да работи - има колекция, взета от студент класа в случая `Grades` и има логиката по която да се движи към следващия елемент чрез метода `MoveNext()`. Единственото което прави foreach е да вика тези методи в определен ред и да връща текущия елемент. Това което гарантира на foreach че може да работи с нашия `IEnumerator` е имплементацията на `IEnumerator` интерфейса която класа ни има. Без тази имплементация, няма да работи. Примерно в Student класа ни, може и да нямаме `IEnumerable` интерфейс, достатъчно е да имаме само метода `GetEnumerator()` и пак ще работи.

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

В същината си видно от кода долу, дори няма нужда от интерфейси, за да си направим наш си foreach цикъл, достатъчно е само да имаме enumerator обект, на който да подадем дадена колекция:

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
## Comparators
Позволяват да декларираме кога два обекта създадени от наш клас са по-големи или равни един с друг. Примерно ако имаме две книги, трябва да изберем критерии, чрез който да определим коя книга е по-голяма. Примерно тази с повече страници или тази която е по-нова, или тази която е с по-голяма популярност или по-дълго име и тн.
## Inheritance
Основно правило в програмирането е, че ако ще променяме кода за нещо, кода трябва да е така написан, че промяната да е само на едно място. Copy - Paste трябва да се избягва, тоест дублирането на код. Поради тази причина е измислено наследяването, тоест даден клас да използва всичките членове на друг клас и да добави допълнително каквото му е нужно:

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

Два основни съществуващи интерфейси са `IEnumerable<>` и `IComparable<>`
`IEnumerable<>` дава възможност да обикаляме елементите с foreach.
`IComparable<>` дава възможност за участие в сортиране, `SortedSet` и `SortedDictionary`. 

C# знае че ако класа имплементира този `IComparable<>`, то той може и знае как да се сортира, или ако имплементира `IEnumerable<>` той може да участва във foreach цикли и C# знае какво да направи с този клас, така че да може да му обходи елементите един след друг.
# Misc
Основно правило в програмирането е, че ако ще променяме кода за нещо, кода трябва да е така написан, че промяната да е само на едно място. Copy - Paste трябва да се избягва, тоест дублирането на код. Поради тази причина е измислено наследяването, тоест даден клас да използва всичките членове на друг клас и да добави допълнително каквото му е нужно.

# ChatGPT

# Bookmarks 
