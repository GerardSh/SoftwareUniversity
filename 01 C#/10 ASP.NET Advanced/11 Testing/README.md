# General
## Testing
Тестването е важна част от жизнения цикъл на дадено приложение.

Новите функционалности трябва да бъдат проверени, преди да бъдат предоставени на клиентите.

Чрез тестване се проверява дали софтуерът отговаря на изискванията, като целта е да се открият дефекти. Не е толкова сериозен проблем, ако разработчикът не е разбрал напълно дадените изисквания. В подобен случай има възможност QA екипът да открие несъответствието по време на тестването и да се избегне достигането на грешката до клиента.
По-неблагоприятен е сценарият, при който бизнес анализаторът (BA) не е разбрал правилно изискванията. Ако те бъдат описани некоректно още в началото, разработчикът ще ги изпълни спрямо грешното описание, а QA екипът ще потвърди, че всичко работи според тях. В този случай съществува риск проблемът да остане незабелязан и да достигне до крайния клиент.
Затова е по-добре потенциално неразбиране да възникне на по-късен етап – например при разработчика – тъй като тогава има възможност за корекция преди завършване на цялостния процес.

Тестването обхваща широка част от разработката на приложения.

Съществуват няколко нива на тестване, различни концепции в разработката и разнообразни видове тестване.

Уеб приложенията също изискват тестване за "непредвидени функционалности".

Controllers, Services, Custom Components и други.

Всеки компонент на приложението трябва да бъде тестван.
## Main Test Levels
Различните компоненти на приложението се тестват на различни нива.
### Unit Tests
Тестват се отделни компоненти. Това е най-ниското ниво на тестване и е задължително да се създава от разработчиците.

Целта е да се покрие логиката, която е вложена в съответната функционалност. При разработването на даден feature се следва определена последователност и се прилага конкретна логика, която може да бъде обхваната чрез unit тестове.

Дали самата логика е коректна или не, обикновено се разбира на по-късен етап. Важно е обаче тя да бъде покрита, защото ако при промяна на дадена част от кода се наруши друга, това би довело до промяна в поведението на приложението, както и до нарушаване на логиката му и съответните unit тестове би трябвало да дадат грешка.

При unit тестовете целта е да се тества само една единица код (например метод или функция) в изолация. За да се постигне това, външни зависимости не се включват – вместо тях обикновено се използват mock обекти (или stubs), за да се изолира логиката от външни влияния като бази данни, мрежови заявки и т.н.

Това е първото ниво на защита. Нито една система за continuous integration няма да придвижи приложението напред, ако има неуспешни тестове.

Unit тестът покрива много малка част от приложението – конкретен метод или логически блок. Когато всички тези малки части са тествани, се очаква, че работят правилно поотделно. Дали обаче функционират коректно в съвкупност, на този етап не е ясно.
### Integration Tests
Проверява се взаимодействието между компонентите, като например APIs.

Ако unit тестовете са преминали успешно, има отделни части, за които се знае, че работят правилно поотделно. Следващата стъпка е да се провери дали ще продължат да функционират коректно, когато се комбинират, което се прави чрез integration тестове.

Тези тестове обхващат по-широки функционалности. Целта е да се установи дали даден процес в приложението работи цялостно. Това обикновено е задача на QA екипа, но е препоръчително и разработчиците предварително да се уверят, че функционалността е стабилна.

Докато при unit тестовете не се включват външни компоненти, при интеграционните тестове това е допустимо. Базата данни, външни API и други зависимости могат да участват, тъй като са част от цялостната интеграция.

Интеграционният тест проверява дали даден процес функционира правилно – например процесът по създаване на запис, процесът по изпращане на заявка и т.н.

Създават се от разработчици или QA automation инженери.
### System / end-to-end Tests
Тества се цялата система. Необходимо е да се провери, че всеки процес в приложението функционира коректно и че всички процеси работят съвместно като едно цяло.

Създават се от QA automation инженери, тъй като разработчиците обикновено се фокусират върху конкретна функционалност. Например, когато няколко разработчици работят върху различни части на приложението, всеки от тях има поглед само върху своята част и често няма пълна представа за останалата система.

Макар комуникацията между екипа да е важна, на практика познаването на цялостната система е ограничено. Поради това е трудно разработчиците да изготвят пълни тестове за цялата система. Именно тук се включват QA инженерите, които имат по-широк поглед върху приложението и могат да изградят системни тестове, които покриват всички основни процеси от край до край.
## Regression Tests
Тези тестове гарантират, че ако се коригира даден бъг, няма да се повреди друга част от системата. Обикновено се прилагат, след като всички предходни нива на тестване са преминати успешно. Разработката се организира на етапи, а ако се използва методология като `Scrum`, процесът се разделя на спринтове.

В края на първия спринт има разработени функционалности, върху които вече са изпълнени unit тестове и компонентни тестове. След тях QA специалистите провеждат integration тестове, които също трябва да преминат успешно. Накрая се извършват системни тестове на цялото приложение. В този ранен етап системата все още включва малко функционалности, но всички те се проверяват и ако всичко работи, се счита, че спринтът е успешно завършен и може да се премине към следващия.

Възможно е обаче да възникне проблем в рамките на същия спринт. При връщане за корекция, QA екипът трябва отново да изпълни всички тестове – не само на проблемната част. Ако всички тестове са автоматизирани, извършването на regression testing е значително по-лесно – след всяка промяна и отстраняване на проблем, всички тестове се стартират отново.

По този начин се проверява дали преди това работещите функционалности все още функционират правилно. В момента, в който нещо спре да работи, въпреки че по-рано е било изправно, това се счита за регресия и изисква връщане и корекция.
## Acceptance Tests
Когато функционалностите са преминали през всички други нива на тестване, идва моментът, в който клиентът трябва да потвърди дали това е резултатът, който си е представял. На всеки етап от разработката е препоръчително да се провежда acceptance testing, за да може клиентът да потвърди, че конкретна функционалност отговаря на неговите очаквания.

След потвърждение се подписва протокол и процесът продължава към следващата стъпка. Това осигурява яснота и съгласуваност между екипа по разработка и клиента на всяка фаза от проекта.
## Stress Tests
Понякога е трудно да извършим stress testing в предварителна среда (pre-production), особено когато става въпрос за приложения с милиони потребители. Симулирането на такъв огромен трафик чрез софтуерни инструменти невинаги е реалистично или ефективно.

Затова компании като Netflix често провеждат стрес тестове директно в продукционна среда. Това се случва поетапно:

- Новата версия на приложението се пуска частично, само на малка част от потребителите или сървърите (нодовете).
    
- Ключови метрики като време за отговор, процент на грешки, натоварване на CPU/памет и пропускателна способност се наблюдават внимателно.
    
- Ако всичко е в норма, новата версия се разгръща към все повече сървъри.
    
- Ако се открият проблеми, се прави връщане назад (rollback) и се анализират логовете и телеметричните данни.

Приложението трябва да работи известно време в продукционна среда, за да се генерира достатъчно информация в логовете и да се направят реални изводи за натоварването.

Този подход е известен като canary deployment и представлява безопасен и контролиран начин за провеждане на стрес тестове в продукционна среда, без да се рискува стабилността на цялата система.
## More Test Levels
| Test Level             | Description                                                                                                             |
| ---------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| Unit Testing           | Tests individual parts of the code, independent from the infrastructure                                                 |
| Component Testing      | Testing of multiple functionalities (a single component)                                                                |
| Integration Testing    | Testing of all integrated modules to verify the combined functionality                                                  |
| System Testing         | Tests the system as a whole, once all the components are integrated                                                     |
| Regression Testing     | Ensures that a fixed bug won't happen again                                                                             |
| Acceptance Testing     | Tests if the product meets the client's requirements. Purely done by QAs                                                |
| Load / Stress Testing  | Test the application's limits by attempting large data processing and introducing abnormal circumstances and conditions |
| Security Testing       | Test if the application has any security flaws and vulnerabilities                                                      |
| Other Types of Testing | Manual, automation, UI, performance, black box, end-to-end testing, A/B, etc                                            |
## Test Concepts
Има различни концепции и практики за разработка на тестове.

**Code-first** - използва се подход, при който първо се създава кодът (обичайният начин на разработка).

**Test-first** - Възможен е и подход, при който първо се създават тестовете (разработка, водена от тестове).

Всеки от тези подходи има своите предимства и недостатъци.

Подходът с първо създаване на кода осигурява гъвкавост и бърза разработка. При този подход тестовете обикновено се създават въз основа на вече написания код.

Подходът с първо създаване на тестове гарантира по-високо качество и обхващане на граничните случаи. Този подход е по-сложен и води до първоначално забавяне.
## The "AAA" Testing Pattern
Автоматизираните тестове обикновено следват модела "AAA".

Arrange: подготвя входните данни и началните условия.

Act: извиква действието, което трябва да бъде тествано.

Assert: проверява изхода и крайните условия.

```csharp
// The "AAA" Testing Pattern
[Test]
public void Test_SumNumbers()
{
    // Arrange
    var nums = new int[] { 3, 5 };

    // Act
    var sum = Sum(nums);

    // Assert
    Assert.That(sum, Is.EqualTo(8));
}
```
## Unit Testing
Юнит тестването на уеб приложения по същество не се различава много от обикновеното юнит тестване.

Създават се тестови методи за проверка на класове и методи (функционалности).

Тестват се отделни компоненти от кода (юнити), а не инфраструктурата.

Използват се същите тестови рамки, както при обикновеното юнит тестване.

Това е ръчен тест, написан на обикновен C# без никаква тестова рамка (framework).

```csharp
public class Summator
{
    public int Sum(int[] arr)
    {
        int sum = arr[0];
        for (int i = 1; i < arr.Length; i++)
            sum += arr[i];
        return sum;
    }
}

void Test_SumTwoNumbers() {
    var summator = new Summator();
    if (summator.Sum(new int[]{1, 2}) != 3)
        throw new Exception("1+2 != 3");
}
```

Същия тест, написан правилно с помощта на NUnit:

```csharp
using NUnit.Framework;

[TestFixture]
public class SummatorTests
{
    [Test]
    public void Sum_WithTwoNumbers_ReturnsCorrectSum()
    {
        var summator = new Summator();
        var result = summator.Sum(new int[] { 1, 2 });

        Assert.That(result, Is.EqualTo(3));
    }
}
```
## Unit Testing in ASP.NET Core
При ползване на framework като ASP.NET Core, вградената логика не изисква тестване. Тя вече е тествана по време на разработката на ASP.NET.

[aspnetcore/src/Mvc/test at main · dotnet/aspnetcore](https://github.com/dotnet/aspnetcore/tree/main/src/Mvc/test) - пример за MVC тестове.

Все пак е необходимо да се тества собствената функционалност.
## NUnit
**Unit-Testing Framework for All .NET Languages**

NUnit е популярен тестови фреймуърк за C#.

Поддържа тестови комплекти, тестови случаи, код преди и след теста, стартиращ и почистващ код, таймаути, очаквани грешки и други.

Подобен е на JUnit (за Java).

Свободен е за ползване и с отворен код.

Предлага висока функционалност и е зряла технология.

Има широка общност от потребители.

Има вградена поддръжка във Visual Studio.

[NUnit.org](https://nunit.org/) - официален сайт.
### Assertions
Проверява се дали дадено условие е изпълнено:

```csharp
Assert.That(condition, Is.True);
```

Извършват се сравнения (равенство, по-голямо, по-малко или равно и други):

```csharp
Assert.That(actual, Is.EqualTo(expected));
Assert.That(actual, Is.GreaterThan(expected));
Assert.That(actual, Is.LessThan(expected));
```

Поддържат се проверки в определен диапазон:

```csharp
Assert.That(number, Is.InRange(80, 100));
```

String assertions позволяват проверка на конкретни стойности в текстове:

```csharp
Assert.That(string actual, Does.Contain(string expected));
```

Може да се провери дали низ или колекция е празна:

```csharp
Assert.That(message, Is.Empty);

Assert.That(collection, Is.Empty);
```

Предоставени са и много други възможности.
### Messages
Assertions могат да показват съобщения, които помагат при диагностика.

Съобщенията при грешка в NUnit тестването спомагат за откриване на проблема.

```csharp
// Asserts that axe durability is 12, with a custom message on failure
Assert.That(axe.DurabilityPoints, Is.EqualTo(12),
    "Axe Durability doesn't change after attack");
```

Ако тестът не премине (напр. действителната стойност е 10), изходът ще изглежда така:

```
Axe Durability doesn't change after attack
  Expected: 12
  But was:  9
```
### Test Classes and Test Methods
Тестовите класове съдържат тестови методи.

Необходимо е да се импортира `NUnit.Framework`.


```csharp
using NUnit.Framework; // Import NUnit

// Test class
[TestFixture] // Optional notation
public class SummatorTests 
{
    // Test method
    [Test]
    public void Test_SumTwoNumbers() 
    {
        var summator = new Summator();

        var sum = summator.Sum(new int[] { 1, 2 });

        // Assertion
        Assert.That(sum, Is.EqualTo(3));
    }
}
```

Анотацията `[TestFixture]` е опционална, но се използва често за яснота.
### Initialization and Cleanup Methods
Изпълнява се преди всеки тест:

```csharp
private Summator summator;

[SetUp] // or [OneTimeSetUp]
public void TestInitialize()
{
    this.summator = new Summator();
}
```

Изпълнява се след всеки тест:

```csharp
[TearDown] // or [OneTimeTearDown]
public void TestCleanup()
{
    // …
}
```

Коментари:

- `[SetUp]` отбелязва метод, който се изпълнява **преди всеки тестов метод**.

- `[OneTimeSetUp]` се използва, когато инициализацията трябва да се извърши **само веднъж**, преди всички тестове.

- `[TearDown]` се изпълнява **след всеки тест**.

- `[OneTimeTearDown]` — **веднъж**, след всички тестове.
## Mocking
**Simulating External Dependencies in Unit Tests**

Mocking е изключително важен, тъй като модулният тест не бива да зависи от външни компоненти по никакъв начин. Целта е да се тества единствено конкретната логика, която е написана.
Не е подходящо да се включват в теста външни API-та, бази данни, части от самия framework и други подобни зависимости.
За да бъде това възможно, е необходимо останалите елементи в методите да могат да бъдат симулирани.
Това се постига чрез mocking – техника, която симулира външните фактори, влияещи върху изпълнението на даден метод.

Mocking означава създаване на нещо, което имитира оригинала.

Mocking е практика в софтуерната разработка, която се използва основно при модулно тестване, но може да се приложи и в самото приложение с цел имитация на функционалност, която все още не е готова.
Позволява да се създаде поведение, което връща предварително зададени стойности, без да е необходимо реалната логика да е завършена.

Обектът, който се тества, може да зависи от други обекти.

За да се изолира поведението на тествания обект, зависимите обекти се заменят.

При Arrange се подготвят данните, с които ще се работи, за да бъдат контролирани. Това важи и за зависимостите — те също трябва да бъдат контролирани и заменени с мокнати обекти
Не е подходящо тестът да се насочва към реално API, тъй като разработчикът му може да направи промени и резултатът да се различава.
В такъв случай тестовете биха fail-нали и няма да е ясно дали грешката е в нашия код или в API-то.
Поради това е важно всички външни зависимости да бъдат мокнати.

Mock-обектите симулират поведението на реалните обекти. Резултатът е предварително контролиран и зададен от нас.

Ако зависимостите са част от логиката, която искаме да тестваме, мокинг не е необходим. Ако обаче зависимостите са външни и не са част от тествания код, се използва мокинг framework.

Това е полезно, когато реалните обекти са трудни за използване или неподходящи за модулен тест.

Накратко, Mocking означава създаване на обекти, които симулират определено поведение.

В .NET може да се ползва библиотеката Moq за създаване на такива mock-обекти.

**Why Mocking?**

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250608205851.png)

Unit тестът трябва да тества един отделен компонент.

Той трябва да бъде изолиран от всички останали.

Външните зависимости трябва да бъдат мокнати (фалшифицирани, симулирани).
### Testing a Service With Mocking
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250608212734.png)

Mocking симулира поведението на реалните обекти.

Mocking обикновено се извършва чрез интерфейси, което го прави особено удобно при нужда от замяна на реален сървис. Вместо истинската имплементация, подаваме контролирана, фалшива версия на интерфейса, което ни позволява лесно да изолираме и тестваме конкретната логика.

Реалната имплементация (например с база данни).

Фалшива имплементация (използва се за модулните тестове).

```csharp
public interface ICreditDecisionService
{
    string GetDecision(int creditScore);
}

public class CreditDecisionService : ICreditDecisionService
{
    public string GetDecision(int creditScore)
    {
        if (creditScore < 550)
            return "Declined";
        else if (creditScore < 675)
            return "Maybe";
        else
            return "Absolutely";
    }
}

public class CreditDecision
{
    private readonly ICreditDecisionService service;

    public CreditDecision(ICreditDecisionService service)
    {
        this.service = service;
    }

    public string MakeCreditDecision(int creditScore)
    {
        return service.GetDecision(creditScore);
    }
}
```

Ако искаме да тестваме `CreditDecision` класа без да разчитаме на реалната имплементация на `CreditDecisionService`, използваме **Moq**. С помощта на Moq създаваме "мокнат" (имитиран) обект на интерфейса `ICreditDecisionService`. Този мокнат обект няма собствена логика — ние му задаваме поведение чрез метода `.Setup()`. Например казваме: "Когато получиш вход 100, върни 'Declined'". По този начин изолираме тествания клас и контролираме резултатите, за да проверим дали `CreditDecision` реагира правилно на дадената стойност. Ако подадем стойност, за която няма дефиниран `Setup` в мокнатия обект, тогава, Moq **ще върне стойност по подразбиране** за типа на метода. В примера `GetDecision` връща `string`, затова стойността по подразбиране ще бъде **null**.

Мокването позволява да създадем фалшиви версии на зависимости, които да връщат контролирани и очаквани резултати, за да тестваме само логиката на нашия клас, без да се влияе от реалната външна имплементация.

```csharp
using Moq;
using NUnit.Framework;

[TestFixture]
public class CreditDecisionTests
{
    [Test]
    public void MakeCreditDecision_ShouldReturnCorrectResult()
    {
        // Arrange: create a mock of the service
        var mockCreditDecisionService = new Mock<ICreditDecisionService>();
        mockCreditDecisionService
            .Setup(service => service.GetDecision(100))
            .Returns("Declined");

        // Inject the mock into the class under test
        var creditDecision = new CreditDecision(mockCreditDecisionService.Object);

        // Act: call the method
        var result = creditDecision.MakeCreditDecision(100);

        // Assert: verify the result and interactions
        Assert.That(result, Is.EqualTo("Declined"));
        mockCreditDecisionService.VerifyAll();
    }
}
```
## In-Memory Database
**Data Storage in Memory**
Услугите, които достъпват база данни, подлежат на тестване и това е препоръчителна практика.

При тестване на такива услуги не се създава нова база данни.

В противен случай това би натоварило сървъра на базата данни.

При тестване на такава услуга се използва In-Memory база данни.

```
Test class             TestDb class
Test Case 1    <=>     Test events      <=>      QA DB (in memory) // Contains only synthetic data from the TestDb class
Test Case 2            Test users                                  // Created and dropped every time when tests are executed
```

[Eventures/Eventures.Tests.Common/TestDb.cs at main · nakov/Eventures](https://github.com/nakov/Eventures/blob/main/Eventures.Tests.Common/TestDb.cs)

Файлът съдържа само синтетични данни от класа `TestDb`.

Базата се създава и изтрива при всяко изпълнение на тестовете.
### EF Core In-Memory Database
EF Core предоставя In-Memory база данни.

Предлага се чрез пакета `Microsoft.EntityFrameworkCore.InMemory`.

Основното ѝ предназначение е да служи като тестова база данни.

```csharp
// Create a db context as usual
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<CreditDecision> CreditDecisions { get; set; }
}

public class CreditDecision
{
    public int Id { get; set; }
    public int Score { get; set; }
    public string Decision { get; set; }
}
```
### Testing a Service with In-memory Database
```csharp
public interface ICreditDecisionService
{
    CreditDecision GetById(int id);
}

public class CreditDecisionService : ICreditDecisionService
{
    private readonly AppDbContext data;

    public CreditDecisionService(AppDbContext data) // Inject the db context to the service
        => this.data = data;

    public CreditDecision GetById(int id)
        => this.data.CreditDecisions.Find(id);
}
```

Интерфейсът `ICreditDecisionService` дефинира абстракция за услуга, която предоставя достъп до кредитни решения.

Класът `CreditDecisionService` имплементира този интерфейс и използва `AppDbContext`, за да извлича данни от базата.

Методът `GetById(int id)` връща конкретно кредитно решение чрез неговото ID, като използва `Find(id)` върху `DbSet`.

```csharp
[TestFixture]
public class CreditDecisionDbTests
{
    private IEnumerable<CreditDecision> decisions;
    private AppDbContext dbContext;

    [SetUp] // Method is executed before tests
    public void TestInitialize()
    {
        this.decisions = new List<CreditDecision>
        {
            new CreditDecision { Id = 1, Score = 100, Decision = "Declined" },
            new CreditDecision { Id = 2, Score = 600, Decision = "Maybe" },
            new CreditDecision { Id = 3, Score = 800, Decision = "Absolutely" }
        };

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "CreditsInMemoryDb") // Use an in-memory DB
            .Options;

        this.dbContext = new AppDbContext(options);
        this.dbContext.AddRange(this.decisions); // Add data to the DB
        this.dbContext.SaveChanges();
    }

    [Test]
    public void Test_GetAllCreditDescisions()
    {
        var decisionId = 1;

        // Pass the in-memory db to the service
        ICreditDecisionService service = new CreditDecisionService(this.dbContext);

        // Use service methods
        var decision = service.GetById(decisionId);

        var dbDecision = this.decisions
            .ToList()
            .Find(d => d.Id == decisionId);

        // Compare and assert returned CreditDecision from DB and from the service method
        Assert.That(decision, Is.Not.Null);
		Assert.That(decision.Score, Is.EqualTo(dbDecision.Score));
		Assert.That(decision.Decision, Is.EqualTo(dbDecision.Decision));
    }
}
```

Класът `CreditDecisionDbTests` дефинира тестов набор за работа с кредитни решения.

Методът `TestInitialize` се изпълнява преди всеки тест и подготвя средата за тестване.

Създава се списък с тестови обекти `CreditDecision`, който се добавя в база данни „в паметта“ с помощта на EF Core `UseInMemoryDatabase`.

Контекстът `AppDbContext` се инициализира с тази временна база, а данните се записват чрез `AddRange` и `SaveChanges`.

Използва се реалният `AppDbContext`, конфигуриран с in-memory база.

Създава се инстанция на `CreditDecisionService`, в която се подава този контекст.

Взема се решение чрез `service.GetById(...)`.

Сравнява се резултатът от услугата с оригиналните данни, добавени в паметта (`this.decisions`).

Използват се `Assert.That` твърдения, за да се валидират стойностите.
## Integration Testing
Интеграционното тестване проверява няколко единици (компонента) заедно.

Целта е да се открият грешки в начина, по който интегрираните единици взаимодействат помежду си.

Пример: тества се регистрация на потребител + услуги за достъп до данни + съхранение в база данни  
(дали новият потребител се запазва в базата данни).
Самата регистрация на потребител не проверява дължината на имейла и това няма да доведе до грешка, защото проверка за дължина не се прави.
При интеграционния тест обаче се опитваме да запишем потребителя в реалната база и тестът се проваля, защото имейлът надвишава разрешения брой символи.
Поотделно, базата може да запише имейла, сървисът може да го подаде към базата, регистрацията минава успешно, защото мока на базата няма ограничение на полето.
Тези неща работят като отделни unit тестове, но не и като интеграционен тест.

Сравнение между unit testing и integration testing.

Интеграционното тестване проверява взаимодействието между няколко единици.

Unit тестването проверява една-единствена единица (компонент).

ASP.NET Core поддържа интеграционно тестване чрез framework за единични тестове.

Framework-ът разполага с вграден уеб хост и тестов сървър в паметта.

Интеграционните тестове следват последователност от стъпки.

Нужно е да се конфигурира уеб хостът на приложението.

Създава се клиент на тестовия сървър, който изпраща заявки към приложението.

`[Arrange]` - Тестовото приложение подготвя заявка.

`[Act]` - Клиентът изпраща заявката и получава отговор.

`[Assert]` - Реалният отговор се валидира спрямо очаквания резултат.

След приключване на всички тестове се генерира отчет с резултатите.

**Integration Test for the `TaskBoard` App**

```csharp
[Test]
public async Task TestAllBoards()
{
    // Arrange
    var httpClient = new HttpClient();

    // Act: send a GET request
    var response = await httpClient.GetAsync("https://google.com");

    // Assert
    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
}
```
## Selenium
Selenium е преносим framework за тестване на уеб приложения.

Предоставя инструмент за запис и изпълнение на тестове (Selenium IDE).

Предоставя специфичен език за писане на тестове (Selenese).

Поддържа директно управление на браузъри (Selenium WebDriver).

„Selenium автоматизира браузъри. Това е всичко!“ — документация на Selenium.

Автоматизира уеб приложения с цел тестване.

Полезен е за интеграционно тестване на SPA приложения.
### Install and Set-up Selenium
Инсталира се последната стабилна версия на Node.js:
[Node.js — Run JavaScript Everywhere](https://nodejs.org/en/)

Инсталира се npm пакетът:
`npm install -g selenium-standalone`

Инсталира се последната версия на Java:
[Download Java](https://www.java.com/en/download/)

Изтегля се JAR файлът на Selenium Standalone Server:
[Downloads | Selenium](https://www.selenium.dev/downloads/)

Изтегля се `ChromeDriver`, съответстващ на версията на Chrome браузъра:
[Downloads  |  ChromeDriver  |  Chrome for Developers](https://developer.chrome.com/docs/chromedriver/downloads)
Файлът се разархивира в същата папка, където се намира Selenium Standalone Server.

Стартира се Selenium сървърът:
`java -jar .\selenium-server-standalone-3.141.59.jar`

**Selenium and .NET**

Подготвя се Selenium за тестване на ASP.NET Core приложение.

Инсталират се необходимите NuGet пакети:

`Selenium.Support`

`Selenium.WebDriver`
## `MyTested.AspNetCore.Mvc`
`MyTested.AspNetCore.Mvc` е мощна библиотека за тестване на ASP.NET Core приложения.

Осигурява автоматично разрешаване на зависимостите за тестовете.

Предлага Fluent API със силно типизирани разширения.

Позволява писане на unit тестове, интеграционни тестове, тестове на маршрути – всичко е покрито.

Включва вградени mock обекти за всякакви ASP.NET Core сценарии.

Поддържа автентикация, DbContext, HTTP, сесии, кеширане и много други.

[ivaylokenov/MyTested.AspNetCore.Mvc: Fluent testing library for ASP.NET Core MVC.](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc)

```csharp
// Instantiates controller with the registered global services,
// and mocks authenticated user,
// and tests for valid model state,
// and tests for added by the action view bag entry,
// and tests for view result and model with specific assertions
MyController<MyMvcController>
    .Instance(instance => instance
        .WithUser(user => user.WithUsername("MyUserName")))
    .Calling(c => c.MyAction(myRequestModel))
    .ShouldHave()
    .ValidModelState()
    .AndAlso().ShouldHave()
    .ViewBag(viewBag => viewBag.ContainingEntry("MyViewBagProperty", "MyViewBagValue"))
    .AndAlso().ShouldReturn()
    .View(result => result
        .WithModelOfType<MyResponseModel>()
        .Passing(model =>
        {
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("My property value", model.MyProperty);
        }));
```
# Misc
# ChatGPT
## Scrum
**Scrum** is an **agile framework** used for managing and completing complex projects, especially in software development. The key idea in Scrum is to **divide work into short, repeatable cycles** called **sprints**, usually lasting between 1 to 4 weeks. The team focuses on completing a specific set of tasks during each sprint.

**Key Elements of Scrum:**

- **Epic** – An **epic** is a **large user story or initiative** that cannot be completed within a single sprint. It represents a **group of related features or user stories** that together deliver a complete business capability.  
    _Example:_ An epic might be _“User Profile Management”_, which could include features like _“Sign Up”_, _“Login”_, _“Edit Profile”_, etc.
    
- **Feature / User Story** – A **feature** or **user story** is a **smaller, specific functionality** that can usually be delivered within a single sprint. It’s typically written from the user’s perspective.  
    _Example:_ “As a user, I want to reset my password so I can access my account if I forget it.”
    
- **Sprint** – A **sprint** is a fixed timebox (usually 1–4 weeks) in which a specific set of tasks or user stories are completed.  
    Each sprint includes:
    
    - **Sprint Planning** – planning what will be done in the sprint
        
    - **Daily Scrum** – short daily stand-up meetings
        
    - **Sprint Review** – demonstrating what was completed
        
    - **Sprint Retrospective** – reflecting on how to improve in the next sprint

**Example:**

- **Epic:** Order Management
    
    - **Feature 1:** Create new order
        
    - **Feature 2:** View order status
        
    - **Feature 3:** Cancel order

These features can be distributed across multiple sprints. Once all are complete, the full "Order Management" functionality is delivered.

**Summary:**

- **Epic = the big picture**
    
- **Feature = specific, deliverable user value**
    
- **Sprint = short time period to implement features and make progress**

Scrum helps teams stay focused, collaborate better, and deliver working software **incrementally and iteratively**.
## `Assert.That()` - Simple Representation
Here’s a simplified example of how the `Assert.That` method might look in C#, including its parameters and a basic implementation idea.

**Method signature (simple version):**

```csharp
public static void That<T>(T actual, IConstraint constraint)
{
    if (!constraint.Matches(actual))
    {
        throw new AssertionException("Assertion failed.");
    }
}

```

**Explanation:**

- The first parameter `actual` is the value being tested.
    
- The second parameter `constraint` is an object that defines the condition (for example, `Is.EqualTo(5)`).
    
- The method calls `constraint.Matches(actual)`, which returns `true` or `false`.
    
- If the result is `false`, an exception is thrown, signaling the test failure.

**What the `IConstraint` interface might look like (simplified):**

```csharp
public interface IConstraint
{
    bool Matches<T>(T actual);
}
```

**Example of a simple `EqualToConstraint` implementation:**

```csharp
public class EqualToConstraint : IConstraint
{
    private readonly object expected;

    public EqualToConstraint(object expected)
    {
        this.expected = expected;
    }

    public bool Matches<T>(T actual)
    {
        return object.Equals(actual, expected);
    }
}
```

**Usage example:**

```csharp
Assert.That(5, new EqualToConstraint(5)); // passes

Assert.That(3, new EqualToConstraint(5)); // throws AssertionException
```

The real NUnit implementation is much more complex and feature-rich (supporting error messages, chaining, type handling, etc.), but this simple version illustrates the core idea behind `Assert.That`.
# Bookmarks
[aspnetcore/src/Mvc/test at main · dotnet/aspnetcore](https://github.com/dotnet/aspnetcore/tree/main/src/Mvc/test) - пример за MVC тестове.

[NUnit.org](https://nunit.org/)

Set-up Selenium:

[Node.js — Run JavaScript Everywhere](https://nodejs.org/en/)

[Download Java](https://www.java.com/en/download/)

[Downloads | Selenium](https://www.selenium.dev/downloads/)

[Downloads  |  ChromeDriver  |  Chrome for Developers](https://developer.chrome.com/docs/chromedriver/downloads)

`MyTested.AspNetCore.Mvc`

[ivaylokenov/MyTested.AspNetCore.Mvc: Fluent testing library for ASP.NET Core MVC.](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc)

Completion: 09.06.2025