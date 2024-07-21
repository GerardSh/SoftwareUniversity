# General
Спазването на dependency inversion - петия принцип от SOLID, освен че ни дава възможност да разширяваме много кода, получаваме възможност да го тестваме много лесно и да му контролираме поведението, докато го тестваме. Като вторична полза от този принцип е че тестовете могат да бъдат много по всестранни и могат да бъдат много по лесно контролирани неговите dependency-та. Dependency e и ключовата думичка `new` - това е все едно да оженим един клас за друг и нямат разкачане. 

Ако имаме следния код:

![](Pasted%20image%2020240721134431.png)

`Bank` и `AccountManager` класовете, са много тясно свързани и банката не може без акаунт мениджъра. От тази връзка, следват различни следствия - ако се появи бъг в акаунт мениджъра, той се пренася и в банката. Друго следствие е, че ако искаме да тестваме банката, трябва да тестваме и акаунт мениджъра заедно с нея. Ако акаунт мениджъра е завързан за външен ресурс, банката се завързва и с него. Примерно ако акаунт мениджъра използва база данни, за да тестваме банката, трябва да имаме базата данни налична. Тази тясна връзка си проличава много силно, когато тръгнем да тестваме, защото unit test-a е длъжен да подсигури всяко външно депендънси, което акаунт мениджъра има - не може изолирано да тестваме поведението само на банката, абстрахирайки се от какво прави акаунт мениджъра конкретно. Това е силно депендънси и се стараем да го избягваме, когато е възможно.

Когато искаме да разкачим дадени класове, най-лесната връзка, която може да направим между тях е чрез интерфейс. Примерно да направим мост между банката и акаунт мениджъра `IAccountManager` или нещо, което да е абстрактно. Когато банката зависи от интерфейса, в unit test-a може да подадем какъвто си искаме акаунт мениджър, който може да е създаден само за целите на unit test-a и така напълно да контролираме неговото поведение. Така тестваме само поведението на банката, без акаунт мениджъра да влияе и евентуални негови бъгове, няма да се пренесът на банката. Акаунт мениджъра трябва да се провери с други unit тестове, които ще проверяват само неговото поведение. Unit тестовете, които тестват банката, ще се занимават само с нейната функционалност, без евентуалните проблеми на акаунт мениджъра да се пренасят върху нея.

![](Pasted%20image%2020240721145552.png)

Банката си получава това депендънси отвън, затова казваме dependency inversion - зависимостта на банката вече не идва от самата банка, но отвън, тоест обръщаме наопаки нещата. Така може да си позволим лукса - отвън да получим всякаква имплементация на акаунт мениджъра и тя да бъде каквато решим. В unit test-а ще е една, в реалността ще е друга, в друга ситуация ще е съвсем друга за целите на съответната програма, важното е че получаваме гъвкавост.

Когато правим тестове с наш акаунт мениджър, който сме написали, ние може да видим примерно как реагира банката, ако акаунта не съществува - като на акаунт мениджъра му се поиска акаунт, той да връща null. Така ще разберем дали банката се държи адекватно в тази ситуация. Друг вариант ако акаунт мениджъра върне два акаунта с един и същи номер и тн. Тази гъвкавост в тестването я постигаме спазвайки dependency inversion принципа.

Примерно, ако имаме следните класове:

```
namespace MockingAndTestDrivenDevelopment
{
    public class GreetingWriter
    {
        public void WriteGreeting()
        {
            if (DateTime.Now.Hour < 12)
            {
                Console.WriteLine("Good morning!");
            }
            else if (DateTime.Now.Hour < 17)
            {
                Console.WriteLine("Good afternoon!");
            }
            else
            {
                Console.WriteLine("Good evening!");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var writer = new GreetingWriter();
            writer.WriteGreeting();
        }
    }
}

//TestProject

namespace MockingAndTestDrivenDevelopment.Tests
{
    public class Tests
    {
        [Test]
        public void WritGreetingShouldWorkCorrectlyInTheMorning()
        {
            var writer = new GreetingWriter();
            writer.WriteGreeting();
            // Assert? contains 'morning'?
        }
    }
}
```

При така написаните неща, няма как да направим Assert-a, защото метода не връща нищо, а не може да прочетем какво пише на конзолата. 
Другия основен проблем е че за да вземем поведението му сутрин, трябва да го стартираме сутринта. Тези проблеми, когато нещо не може да бъде проверено или условията му не зависят от нас, означава че  dependency inversion принципа не е спазен. 
В случая горе имаме две основни депендънсита - едното е върху `DateTime` , която е статична информация, която се сменя и ние  не може да я контролираме. Второто депендънси е конзолата. Двете неща едновременно ни пречат да напишем тест. Примерно искаме да разберем дали текста съдържа `morning`, но няма как да го направим. Трябва да изнесем депендънситата отвън. 
Проблема с времето може да разрешим по два начина - да направим `ITimeProvider` интерфейс, който да има метода `GetTime()` или когато е само една единствена информация, може директно да я изнесем навън - да подадем на метода `WriteGreeting(DateTime dateTime)`. Който ще ползва метода, трябва да подаде времето спрямо което трябва да се изчисли поздрава. 
Минуса при dependency inversion-a e че трябва тази информация да се даде отвън. За улеснение на хората, които ползват кода, може да направим метод overloading - тоест същия метод, без параметри, който да извика другия метод с default стойността. Тази стойност не може да се подаде при параметрите като default защото е динамично променяща се.

```
public void WriteGreeting(DateTime dateTime) {..}

//TestProject

namespace MockingAndTestDrivenDevelopment.Tests
{
    public class Tests
    {
        [Test]
        public void WritGreetingShouldWorkCorrectlyInTheMorning()
        {
            var writer = new GreetingWriter(new ConsoleWriter());
            writer.WriteGreeting(new DateTime(2021, 1, 1, 8, 0, 0));
            // Assert? contains 'morning'?
        }
    }
}
```

Тази корекция в проекта решава първия проблем, но втория къде точно информация се изписва не е решен. Примерно ако утре има изискване поздрава да се изписва във файл или да се праща по мейл, така както е, не може да стане. Трябва да копираме `GreetingWriter` и да направим `GreetingFileWriter`, `GreetingEmailWriter`, `GreetingConsoleWriter` и тн.
Този подход е крайно нежелателен, трябва да се изкара и второто депендънси отвън чрез интерфейс, който да има метода Write.

```
namespace MockingAndTestDrivenDevelopment
{
    public interface IWriter
    {
        void Write(string text);
    }
}
```

Благодарение на този интерфейс, може да си направим различни класове, които да го имплементират и те да изписват информацията там където трябва.
Трябва да направим конструктор, който да приема `IWriter` и да го записва в поле вътре в класа. След това трябва да заместим този writer вместо конзолата. Правейки си `ConsoleWriter` клас, който да имплементира `IWriter`, запазваме оригиналната функционалност да пише на конзолата.  
Може да си направим и `PrettyConsoleWriter` клас, който да имплементира `IWriter`, като в този клас, пак ще изписваме текста на конзолата, но с добавени тирета. 
Направихме си различни writers, които може да бъдат използвани в комбинация с нашия `GreetingWriter`, при създаването му. Това ще определя къде той ще пише, тоест даваме му това депендънси - за писане. Може да си направим и празен конструктор, който да подава `ConsoleWriter` към другия конструктор. Старото поведение си остава, но даваме възможност, от вън да ни вкарат друг writer.

Кода ни след промените изглежда така:

```
namespace MockingAndTestDrivenDevelopment
{
    public interface IWriter
    {
        void Write(string text);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class PrettyConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine('-' + text + new string(' ', 60 - 2 - text.Length) + '-');
            Console.WriteLine(new string('-', 60));
        }
    }

    public class GreetingWriter
    {
        readonly IWriter writer;

        public GreetingWriter()
            : this(new ConsoleWriter())
        {
        }

        public GreetingWriter(IWriter writer)
        {
            this.writer = writer;
        }

        public void WriteGreeting()
        {
            WriteGreeting(DateTime.Now);
        }

        public void WriteGreeting(DateTime dateTime)
        {
            if (dateTime.Hour < 12)
            {
                writer.Write("Good morning!");
            }
            else if (dateTime.Hour < 17)
            {
                writer.Write("Good afternoon!");
            }
            else
            {
                writer.Write("Good evening!");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var consoleWriter = new GreetingWriter(new ConsoleWriter());
            consoleWriter.WriteGreeting(DateTime.MaxValue);

            var prettyConsoleWriter = new GreetingWriter(new PrettyConsoleWriter());
            prettyConsoleWriter.WriteGreeting(DateTime.MinValue);
        }
    }
}
```

Сега вече, може да си направим наш специален unit test writer



# Misc

# ChatGPT

# Bookmarks 

Course completion: 01.01.2024