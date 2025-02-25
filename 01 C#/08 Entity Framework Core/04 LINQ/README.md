# General
Microsoft се опитват да привлекат програмистите, които традиционно работят директно с бази данни, като ги насочат към работа с колекции в .NET. Самата база данни може да се разглежда като колекция от таблици, всяка таблица – като колекция от редове, а всеки ред – като колекция от колони.

В периода, когато Microsoft популяризират своя език за програмиране, голяма част от бизнес логиката започва да се изнася към приложенията. Това се счита за предимство, тъй като извличането на данни от базата е бавен процес, а разработчиците са съсредоточени предимно върху SQL. Възползвайки се от този факт, Microsoft създават в .NET концепция, която наподобява SQL – езика за заявки LINQ (Language Integrated Query).

Когато по-късно разработват ORM, естествено възниква идеята работата с Entity Framework да бъде интегрирана с LINQ. Това води до широко използване на LINQ при работа с Entity Framework Core, тъй като той осигурява интуитивен начин за обработка на данни в стил, близък до SQL, но с възможност за по-добра интеграция в .NET приложенията.
## Asynchronous Methods
Трябва да използваме асинхронните версии на методите, когато е възможно, защото в противен случай блокираме нишката, която изпълнява заявката. Операциите в базите данни и други бавни операции, като достъп до файловата система или мрежови заявки, обикновено отнемат време за изпълнение. Това е важно, защото ако не използваме асинхронност, нишката ще бъде блокирана, докато чака резултата, което води до неефективно използване на ресурсите.

Независимо от причината за забавянето, ако дадена операция е I/O-bound и изисква време за изпълнение, тя трябва да бъде маркирана като асинхронна. Когато извършваме такива операции асинхронно, позволяваме на сървъра, докато чака резултата, да обработва други заявки. Това води до по-ефективно използване на ресурсите, като позволява на нишките в пула да обслужват повече потребители.

Докато приложението чака резултат от външен източник, какъвто е базата данни, сървърът може да продължи да обработва други заявки. Дори ако на сървъра работи само нашето приложение, асинхронността носи ползи при увеличен брой потребители, тъй като позволява по-добро управление на наличните нишки.

Ако например сървърната машина разполага с осем ядра, това означава, че физически могат да работят само осем нишки едновременно. Ако дадена нишка е блокирана, докато чака отговор от базата данни, тя не може да изпълнява друга задача, което ограничава капацитета на сървъра. Използвайки асинхронни методи, позволяваме на системата да освободи нишката, докато чака резултат, така че тя да бъде използвана за обработка на друга заявка.

Важно е да се отбележи, че шаблонът `async/await` не гарантира, че операцията ще бъде изпълнена асинхронно на ниво хардуер. Това зависи от .NET Runtime, който решава дали операцията ще бъде обработена асинхронно въз основа на натоварването на системата и естеството на самата задача. Въпреки това, използването на асинхронни методи дава възможност на системата динамично да управлява ресурсите и да подобри производителността при работа с бавни операции.

Ако не материализираме заявката, тя няма да бъде изпълнена, докато не се опитаме да я използваме. Например, ако използваме `foreach` върху резултата от заявка, това автоматично ще я материализира и ще я изпълни веднага. Това обаче означава, че губим възможността да изпълним заявката асинхронно, тъй като `foreach` блокира изпълнението, докато не се получат всички резултати. За да запазим асинхронността, трябва да използваме подходящи методи като `ToListAsync()` или `ToArrayAsync()`, които материализират заявката по асинхронен начин. Желателно е да я материализираме асинхронно възможно най-късно, точно преди да ни потрябват данните.
## Filtering
`Where()` - Selects values that are based on a predicate function

```csharp
string[] words = { "the", "quick", "brown", "fox", "jumps" };

// Using the LINQ method Where to filter the words with length 3
IEnumerable<string> query =
       words.Where(word => word.Length == 3); 

// Classical LINQ achiving the same
IEnumerable<string> query = from word in words
							where word.Length == 3
							select word; 
```

Класическият LINQ (query syntax) предлага по-декларативен начин за изразяване на заявки, подобен на SQL. Той използва ключови думи като `from`, `where` и `select`, което прави кода по-четим в определени случаи. Въпреки това, синтаксисът с разширяващи методи (`Where()`, `Select()`, `OrderBy()`) е по-гъвкав и предпочитан в повечето сценарии, особено когато комбинираме множество операции.
## Select
Методът `Select` ни позволява да направим проекция върху данните, което води до намаляване на мрежовия трафик и бързината за тяхното доставяне, благодарение на по-малкия обем върната информация. Друг голям плюс е че нашите ентити модели, не трябва да ходят навън.
Чрез избора на само необходимите колони и поставянето им в анонимен обект, можем ефективно да получим само данните, от които се нуждаем. 

```csharp
var employeesWithTown = context
 .Employees
 .Select(employee => new
 {
 EmployeeName = employee.FirstName,
 TownName = employee.Address.Town.Name
 });
```

**SQL Server Profiler:**

```sql
SELECT [employee].[FirstName] AS [EmployeeName], [employee.Address.Town].[Name] AS [TownName]
 FROM [Employees] AS [employee]
LEFT JOIN [Addresses] AS [employee.Address] ON [employee].[AddressID] = [employee.Address].[AddressID]
LEFT JOIN [Towns] AS [employee.Address.Town] ON [employee.Address].[TownID] =
 [employee.Address.Town].[TownID]
```

Един от недостатъците на анонимните обекти е, че когато ги подадем към метод, те се третират като `object`, което води до загуба на типизация и ограничаване на достъпа до техните пропъртита. Това означава, че извън контекста на създаването на анонимния обект няма лесен директен достъп до пропъртитата му.

Ако използваме анонимен обект или DTO, губим възможността да се възползваме от `change tracker`-а на Entity Framework, тъй като обектът, с който работим, не е ентити и не може да се използва за ъпдейтване на базата данни, той вече не е част от контекста. DTO обектите са задължителни за комуникацията между клиента и приложението, тъй като позволяват да се изпрати само нужната информация, която клиентът иска да промени. Когато потребителят прави промяна, не е препоръчително да изпращаме директно ентити, а да изпратим DTO обект, който съдържа само необходимите данни. След като получим DTO обекта, можем да валидираме данните и след това да актуализираме съответното ентити, което вече сме заредили от базата. Ентититата не трябва да напускат границите на нашето приложение, за да предотвратим нежелани странични ефекти и да гарантираме сигурността на данните.
### DTO / Result Models
За да избегнем проблема с анонимните обекти, можем да създадем DTO (Data Transfer Object) клас, в който дефинираме необходимите пропъртита за проекцията. Голямото предимство е, че можем да валидираме информацията, която идва от клиента, и да осигурим по-добра сигурност при манипулиране на данните. 
Много е важно, всеки бит информация да бъде проверен и валидиран дали отговаря на поне формални правила, ако примерно получаваме ЕГН, трябва да проверим че съдържа 10 цифри, без нищо друго .

От .NET 8 и C# 11 имаме новата функционалност `required`, която ни позволява да зададем изисквания към дадено пропърти. Когато използваме `required`, определяме, че пропъртито трябва да бъде зададено при създаването на обекта. Това предотвратява създаването на обекти с незадължителни или липсващи критични данни.

Пример с `required`:

```csharp
public class MyDto
{
    public required string Name { get; set; }
}
```

Това означава, че при създаване на обект от класа `MyDto`, пропъртито `Name` трябва да бъде зададено, в противен случай ще получим компилационна грешка. Така се гарантира, че данните, които получаваме от клиента, са валидни и пълни.

DTO обектите имат атрибути, които са предназначени за валидация на клиентските данни, докато базовите модели, използвани за работа с базата данни, имат атрибути, които влияят на самата база. Например, можем да използваме атрибути като `[Required]` и за клиентска валидация, за да гарантираме, че определени полета не са празни при подадени данни.

`Select` и `GroupBy` могат да работят с custom класове, което ни позволява да ги подаваме на методи и да ги ползваме като return type:

```csharp
public class UserResultModel
{
 public string FullName { get; set; }
 public int Age { get; set; }
}

var currentUser = context.Users
 .Where(u => u.Id == 8)
 .Select(u => new UserResultModel
 {
	 FullName = u.FirstName + " " + u.LastName,
	 Age = u.Age
 })
 .SingleOrDefault();

// The new type can be used in a method signature
public UserResultModel GetUserInfo(int Id) { … }
```
## Aggregation
Тези функции работят по същия начин, както и в базата данни, с разликата, че някои от тях могат да приемат предикат, което позволява допълнителна филтрация директно в метода.

Например, SQL заявката:

```sql
SELECT COUNT(*) FROM Employees AS e
WHERE e.DepartmentID = 1
```

Може да бъде изразена в LINQ с предикат по следния начин:

```csharp
context.Employees
.Where(e => e.DepartmentId == 1)
.Count();

// Alternatively
context.Employees
.Count(e => e.DepartmentId == 1);
```

И двете ще генерират еднаква заявка, като разликата е че ползвайки предикат, се намалява дължината на кода.

Освен `Count`, LINQ предоставя и други агрегиращи функции като `Average`, `Max`, `Min` и `Sum`, като всички те имат асинхронни версии: `CountAsync`, `AverageAsync`, `MaxAsync`, `MinAsync` и `SumAsync`.
## Joining Tables
### Implicit Join
Най-оптимално е `JOIN` операциите да се извършват по външни ключове, тъй като релационните бази данни поддържат индекси върху тях, което значително подобрява производителността на заявките. Когато използваме `JOIN` по foreign key, няма необходимост от използване на extension метода `Join`, тъй като Entity Framework автоматично генерира съответното присъединяване при достъп до навигационните свойства.

Методът `Join` в LINQ е предназначен за случаи, в които няма дефинирана релация между таблиците, но такива случаи са изключително редки и често индикират проблеми с дизайна на базата данни. Използването му трябва да бъде добре обмислено, тъй като може да доведе до неочаквани резултати и неоптимални заявки.

Например, ако изпълним следната LINQ заявка:

```csharp
var query = context.Employees
    .Where(e => e.DepartmentId == 1)
    .Select(e => new
    {
        e.FirstName,
        e.LastName,
        e.JobTitle,
        Department = e.Department.Name
    })
    .ToList();
```

Генерираната SQL заявка ще бъде:

```sql
SELECT [e].[FirstName], [e].[LastName], [e].[JobTitle], [d].[Name] AS [Department]
FROM [Employees] AS [e]
INNER JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[DepartmentID] = 1
```

EF прави `JOIN` без да сме го посочвали експлицитно, защото използвахме нещо от Department класа. Реално в момента в който EF види, че имаме нужда от информация намираща се в таблицата към която има релация, автоматично генерира `JOIN`.

В този случай EF автоматично създава `JOIN`, въпреки че не сме го дефинирали изрично. Това се случва, защото използваме пропъртито (`Name`) от навигационното пропърти `Department`. В момента, в който EF установи необходимост от достъп до данни от релационна таблица, той генерира съответното присъединяване, за да осигури коректното извличане на информацията.
### Join
Методът `Join` в LINQ позволява ръчно свързване на две колекции, когато между тях няма дефинирана навигационна релация. Той изисква като първи аргумент втората колекция, с която ще извършим `JOIN`, след което посочваме двете пропъртита, които ще бъдат използвани за свързване. В последния аргумент изграждаме резултатния обект, комбинирайки данните от двете таблици.

Пример за използване на `Join`:

```csharp
var employees = context.Employees
    .Join(
        context.Departments,
        e => e.DepartmentId,
        d => d.DepartmentId,
        (e, d) => new
        {
            e.FirstName,
            e.LastName,
            Department = d.Name
        })
    .ToList();
```

В този случай `Employees` и `Departments` се обединяват по `DepartmentId`. Тъй като няма навигационно пропърти, използваме `Join`, за да изпълним `INNER JOIN` ръчно. В повечето случаи, когато в базата данни има дефинирани релации, използването на навигационни пропъртита е по-естественият и препоръчителен подход, тъй като EF автоматично генерира `JOIN` без нужда от явното му деклариране.

В LINQ, методът `Join` обикновено се използва за проекция, т.е. за комбиниране на данни от две или повече колекции в нов обект или анонимен тип. Основната цел на `Join` е да обедини конкретни пропъртита  от свързаните таблици, а не да върне целите ентитети.
### Include
Ако искаме да получим целите ентитети, можем да използваме `Include`, което е специален метод в Entity Framework, предназначен за зареждане на свързани ентитети чрез навигационни пропъртита. Това дава възможност за зареждане на свързаните обекти, без да е нужно да използваме метода `Join` или да достъпваме навигационно пропърти.

Пример:

```csharp
var employeesWithDepartments = context.Employees
    .Include(e => e.Department)
    .ToList();
```

В този пример, чрез `Include`, зареждаме целия `Department` ентитет за всеки служител, който се намира в резултата. EF изпълнява left outer join, което означава, че дори ако даден служител няма свързан департамент, той ще бъде включен в резултата, като стойността за департамент ще бъде `null`. 

Това поведение е аналогично на изпълнение на SQL заявка с `LEFT OUTER JOIN`, при която всички редове от таблицата на служителите ще се върнат, независимо дали съществува съвпадение в таблицата на департаментите. Ако няма съвпадение, полето за департамент ще съдържа `NULL`.

EF може да оптимизира заявката, като използва inner join, но това е само когато свързаните ентитита са гарантирано налични за всички записи в основния ентитет например, всички служители имат департамент. EF автоматично прави тази оптимизация в зависимост от структурата на данните и може да преминава между вътрешен и външен join

Ключовата разлика е, че когато използваме `Include`, се оставяме на Entity Framework да управлява генерирането на SQL заявката и да се справи със свързаните таблици, без ние да пишем явен `JOIN` в заявката.
Include се използва, когато искаме да заредим целия свързан ентитет, запазвайки навигационните пропъртита и цялата структура на обектите. Освен това, получаваме и автоматично управление на промените чрез change tracking, което означава, че Entity Framework ще следи за модификациите на тези обекти и ще може да ги синхронизира с базата данни.
## Grouping Tables in EF
За да групираме данните, в LINQ имаме метода`GroupBy`, но трябва много да се внимава, защото има разлика между това дали изпълняваме метода спрямо базата или колекция в паметта. Примерно ако направим следното групиране:

```csharp
var employees = context.Employees
    .GroupBy(e => e.JobTitle)
    .ToList();
```

Ще хвърли exception, защото няма да може да преведе заявката. Причината е че не сме спазили правилата, които са валидни от страна на SQL, а именно че не сме направили проекция, селектирайки само колоната / колоните, които участват в групирането или колони, които са част от агрегираща функция.

Ако прехвърлим колекцията първо в паметта и изпълним `GroupBy` отново, тогава ще работи без проблеми, защото нямаме ограниченията наложени от SQL, но това означава, че всички записи първо ще бъдат заредени в паметта, което може да бъде проблем при големи обеми данни.

```csharp
var employees = context.Employees
    .ToList();

var groupedEmployees = employees
    .GroupBy(e => e.JobTitle)
    .ToList();


foreach (var grp in groupedEmployees)
{
    Console.WriteLine($"{grp.Key} - {grp.Sum(e=> e.Salary)}");
}
```

Правилният начин да направим групиране директно на ниво база е да използваме `Select` след `GroupBy`, за да формираме коректна SQL заявка, която спазва ограниченията на `GROUP BY`:

```csharp
var groupedEmployees = context.Employees
    .GroupBy(e => e.JobTitle)
    .Select(grp => new
    {
        Department = grp.Key,
        Salary = grp.Sum(e => e.Salary)
    })
    .ToList();

foreach (var grp in groupedEmployees)
{
    Console.WriteLine($"{grp.Department} - {grp.Salary}");
}
```

Може да направим групиране и по повече колони, като тогава трябва да ги подадем като анонимен обект, поради което пропъртито `Key` вече няма да бъде стринг но анонимен обект съдържащ имената на подадените колони:

```csharp
var groupedEmployees = context.Employees
    .GroupBy(e => new
    {
        e.JobTitle,
        Department = e.Department.Name
    })
    .Select(grp => new
    {
        grp.Key.Department,
        grp.Key.JobTitle,
        Sum = grp.Sum(e => e.Salary)
    })
    .ToList();

foreach (var grp in groupedEmployees)
{
    Console.WriteLine($"{grp.JobTitle} - {grp.Department} - {grp.Sum}");
}
```

Като обобщение, `GroupBy` в LINQ работи по същия начин като `GROUP BY` в базата данни. Единствената разлика е, че когато го използваме директно в LINQ към база данни, трябва да спазваме SQL ограниченията—всички колони, които не са част от `GROUP BY`, трябва да бъдат агрегирани.

В паметта (`ToList()` преди `GroupBy`) тези ограничения не важат, защото LINQ използва обектно-ориентирана логика, а не SQL. В този случай `GroupBy` работи като стандартен `.NET` метод, който групира елементи в `IEnumerable<IGrouping<TKey, TElement>>`, без да изисква допълнителна проекция.

Ако изключим ограниченията, поведението е идентично.

Опростен пример как работи `GroupBy`:

```csharp
var numberGroups = new int[] { 1, 2, 3, 4 }
.GroupBy(x => x % 2);


foreach (var grp in numberGroups)
{
    Console.WriteLine($"Group: {grp.Key} Sum: {grp.Sum()}");
}

// Output:
// Group: 1 Sum: 4
// Group: 0 Sum: 6
```

Първо, групираме числата според това дали са четни или нечетни. Това означава, че всички числа, които дават един и същ остатък при деление на 2, попадат в една и съща група. По същия начин можем да групираме и обекти, като ги разделим в групи въз основа на обща стойност за дадено пропърти.

След това обхождаме всяка група. Всяка група има:

- **Key** – стойността, по която сме групирали (0 за четни, 1 за нечетни числа).
- **Елементи** – всички числа, които принадлежат към съответната група.

Накрая използваме агрегиращата функция `Sum()`, за да изчислим сумата на числата във всяка група. 
## `SelectMany`
Целта на `SelectMany` е да изтегли и обедини елементи от вложени колекции (или колекции в колекции) в една плоска колекция, като премахва вложеността и прави данните по-достъпни за обработка.

Пример:

```csharp
var employees = new[]
{
    new { Name = "Alice", Skills = new[] { "C#", "SQL" } },
    new { Name = "Bob", Skills = new[] { "JavaScript", "HTML" } },
    new { Name = "Charlie", Skills = new[] { "C#", "JavaScript" } }
};

var allSkills = employees
    .SelectMany(e => e.Skills);

foreach (var skill in allSkills)
{
    Console.WriteLine(skill);
}

// Output:
// C#
// SQL
// JavaScript
// HTML
// C#
// JavaScript
```

- Имаме масив от служители, като всеки от тях има списък с умения (`Skills`).
- Използваме `SelectMany`, за да "разгънем" всички умения в една обща колекция, без вложени масиви.
- В резултат получаваме единен списък от всички умения на всички служители.

Ако бяхме използвали `Select`, щяхме да получим колекция от масиви, вместо единен списък. `SelectMany` комбинира всички елементи в една плоска структура.

Семпла репрезентация на това как работи `SelecMany`:

```csharp
var employees = new[]
{
    new { Name = "Alice", Skills = new[] { "C#", "SQL" } },
    new { Name = "Bob", Skills = new[] { "JavaScript", "HTML" } },
    new { Name = "Charlie", Skills = new[] { "C#", "JavaScript" } }
};

var allSkills = employees
    .Select(e => e.Skills);

var allSkillsFlattened = new List<string>();

foreach (var skillList in allSkills)
{
    foreach (var skill in skillList)
    {
        allSkillsFlattened.Add(skill);
    }
}

foreach (var skill in allSkillsFlattened)
{
    Console.WriteLine(skill);
}
```

Вторият параметър на `SelectMany` се използва, за да комбинираме елементите от външната и вътрешната колекция и да създадем нов обект, който съдържа данни и от двете.

Пример:

```csharp
var flattenedSkillsWithEmployee = employees
    .SelectMany(
        e => e.Skills,               // Unpacks Skills for each employee
        (e, skill) => new            // Creates a new object combining employee and skill
        {
            EmployeeName = e.Name,
            Skill = skill
        })
    .ToList();
```

Този код ще върне списък с анонимни обекти, съдържащи името на служителя и съответното му умение. Вторият параметър позволява да комбинираме данни от двете колекции.
## `IEnumerable` vs `IQueryable`
### `IEnumerable<T>`
Това е интерфейс, който се намира в `System.Collection.Generic`. Той представлява имплементацията на iterator design pattern-а в C#, като позволява преминаване през елементите на колекцията само в една посока, без възможност за връщане.

Използва се само за обекти в паметта (in-memory data objects). Ако нещо е `IEnumerable`, това означава, че се намира в RAM паметта. Ако по някаква причина преобразуваме нашето `IQueryable` в `IEnumerable`, заявката ще бъде изпълнена веднага. 

Трябва да бъдем внимателни, тъй като преобразуването от `IQueryable` към `IEnumerable` понякога е имплицитно. Когато .NET разпознае, че трябва да използваме дърво на изразите, заявката се изпълнява. 

Много е важно да се запомни, че в `IEnumerable<T>` се използват делегати `Func<>`, докато в `IQueryable<T>` се използват `Expression<Func<>>`. Ако подадем `Func<>`, заявката ще се материализира веднага и това често води до изпълнение на заявки без `WHERE` клауза, което ще върне всички записи от таблицата. Ако таблицата съдържа много данни, това може да създаде сериозни проблеми. Пример:

```csharp
Func<Employee, bool> filter = e => e.DepartmentId == 1;

var groupedEmployees = context.Employees
    .Where(e => e.AddressId == 1)
    .ToList();

var groupedEmployees2 = context.Employees
   .Where(filter)
   .ToList();
```

В първия пример използваме `Where` метод с директно подаден ламбда израз, който генерира `Expression<Func>`. Това позволява на Entity Framework Core да преобразува израза в SQL заявка, добавяйки правилно `WHERE` клаузата в SQL заявката и изпълнявайки я ефективно, като извлича само необходимите записи от базата данни.

Във втория пример използваме предварително дефиниран `Func<Employee, bool>`, който се подава в `Where` метода. Това не води до изграждане на `Expression<Func>`, тъй като `Func<Employee, bool>` е обикновен делегат, който не може да бъде преведен в SQL от Entity Framework Core. В този случай EF Core не добавя `WHERE` клаузата в генерираната заявка и изтегля всички записи от базата данни. Вместо това, филтрирането се извършва на ниво памет, като се зареждат всички записи в паметта и след това се прилага филтърът. Това води до ненужно увеличаване на натоварването и евентуално до производствени проблеми.

Метода `Compile()` преобразува `Expression<Func<T, TResult>>` в `Func<T, TResult>`, което позволява изпълнението му в паметта като стандартен C# делегат. Това е полезно, ако искаме да използваме израза извън LINQ to SQL, но губи възможността за транслация в SQL заявка.

Важно е да се отбележи, че в този случай няма да възникне грешка, защото Entity Framework Core не проверява дали подаваният делегат може да бъде преобразуван в SQL. Той само извършва транслация на изрази и не може да засече, че `Func<Employee, bool>` не е валиден за транслация в SQL. Затова запитването се изпълнява без грешка, но резултатите се филтрират на ниво памет, което не е ефективно.

Основната разлика между двата примера е, че в първия се използва израз, който може да бъде преведен в SQL, докато във втория се използва делегат, който не може да бъде интерпретиран от EF Core като SQL операция.
### `IQueryable<T>`
Това е интерфейс, който идва от `System.Linq` и е специално предназначен за работа с LINQ, като предоставя възможност за изграждане на динамични заявки чрез дървета на изразите (expression trees). Това позволява да описваме операциите, които искаме да изпълним върху дадена колекция, без да извършваме физическо изпълнение на тези операции веднага. `IQueryable` не е самата колекция от данни, а по-скоро описание на това как да се получат данните, което да се обработи от съответния провайдър (например SQL Server, ако използваме Entity Framework).

Целта на `IQueryable` е да генерира заявки, които ще бъдат изпълнени от база данни или друг източник на данни, като изпълнението се извършва чрез съответния провайдър (например SQL провайдър за база данни). Важно е да се подчертае, че параметрите на `IQueryable` са от тип `Expression<Func<>>`, което означава, че заявката не се материализира веднага при създаването ѝ. Вместо това, тя се компилира в дърво на изразите, което може да бъде превърнато в SQL или друга форма на заявка, която да се изпълни по-късно.

Ако използваме `Func<>` вместо `Expression<Func<>>`, ще получим материализация на заявката, тоест ще се извърши директно в паметта (с всички данни, а не само филтрираните). В резултат на това, когато се използва `Func<>` с `IQueryable`, се извършва имплицитно преобразуване на `IQueryable` в `IEnumerable`, което може да доведе до изтегляне на всички данни от базата, без да се приложат оптимизации като филтриране с `WHERE` клаузата на SQL. Тази имплицитна промяна често води до сериозни проблеми, ако данните в базата са много.
### Differences
**`IEnumerable<T>`**

- Намира се в `System.Collections.Generic`.
- Базов тип за всички колекции в .NET.
- LINQ методите работят с `Func<>`.
- Подходящ за работа с данни в паметта (in-memory collections).

**`IQueryable<T>`**

- Намира се в `System.Linq`.
- Наследява `IEnumerable<T>`, което позволява имплицитно конвертиране.
- LINQ методите работят с `Expression<Func<>>`.
- Използва се за заявки към външни източници на данни (например бази данни), като заявките могат да бъдат оптимизирани и изпълнени от съответния провайдър.

Основната разлика е, че `IQueryable<T>` позволява отложено изпълнение и оптимизация на заявките, докато `IEnumerable<T>` работи с вече заредени в паметта данни.
### Expression Tree
Expression Tree в .NET осигурява механизъм за представяне на кода като обектен модел, който позволява анализ и модификация на заявките преди тяхното изпълнение. Това е особено полезно при работа с LINQ, като позволява динамично трансформиране на заявките преди те да бъдат превърнати в SQL или друга форма за изпълнение.

Entity Framework Core използва Expression Trees, за да обработва и оптимизира заявките, като позволява добавяне на допълнителни условия, промяна на селектираните колони или дори комбиниране на различни изрази. Това осигурява гъвкавост и възможност за динамично изграждане на заявки според нуждите на приложението.

До версия 3.1 на Entity Framework, ако не успее да преведе нещо към SQL заявка, тогава я изпълнява без `WHERE` клауза, което дърпа цялата таблица, прави групирането и връща очаквания резултат. След тази версия, ако има проблем с превода се хвърля exception.
# Misc
## EF Core Explicit Column Selection
При генерирането на заявки, EF никога не използва `SELECT *`, а винаги изрежда конкретните колони. Това се прави именно за да се избегнат грешки при промени в схемата на базата данни. Ако в таблицата бъдат добавени нови колони, но моделът в приложението не е актуализиран, използването на `SELECT *` би довело до получаване на неочаквани данни, които EF Core не знае как да обработи. Изричното изброяване на колоните гарантира, че заявките ще върнат само тези данни, които съответстват на дефинирания модел.
# ChatGPT
## Handling Query Translation in EF Core: Expression`<Func<T, bool>>` vs `Func<T, bool>`
```sql
Func<Employee, bool> filter = e => e.DepartmentId == 1;

var groupedEmployees = context.Employees
    .Where(e => e.AddressId == 1)
    .ToList();

var groupedEmployees2 = context.Employees
   .Where(filter)
   .ToList();
```

I don't understand why the second version results in the SQL query being generated without the `WHERE` clause, leading to the download of all records from the database, which could be problematic. Both versions are accepting a `Func` function, correct?

**ChatGPT said:**

The issue you're encountering happens because of how LINQ expressions are interpreted when passing a `Func<T, bool>` as a parameter.

In the second version:

```csharp
Func<Employee, bool> filter = e => e.DepartmentId == 1;

var groupedEmployees2 = context.Employees
    .Where(filter)
    .ToList();
```

When you use a `Func<Employee, bool>`, Entity Framework cannot directly translate that `Func` into SQL. EF Core (or LINQ to Entities in general) cannot translate a `Func<T, bool>` to a SQL `WHERE` clause because it doesn't know how to evaluate the function on the SQL server side. Instead, it simply retrieves all the records into memory, and then the `Where` method is applied in memory, which leads to downloading all records before filtering, causing performance issues.

On the other hand, the first version:

```csharp
var groupedEmployees = context.Employees
    .Where(e => e.AddressId == 1)
    .ToList();
```

works correctly because `e => e.AddressId == 1` is a directly translatable expression, meaning Entity Framework can translate it to a SQL query and execute it on the database, which is much more efficient because only the relevant rows are retrieved.

**Why does this happen?**

- **Expression Trees**: When you pass a lambda expression directly (like in `Where(e => e.AddressId == 1)`), it is automatically compiled into an expression tree, which EF Core can use to translate it into SQL.
    
- **Delegate (Func)**: However, when you use a `Func<T, bool>` directly (like `Where(filter)`), it is a regular .NET delegate, and EF Core can't translate it into SQL. As a result, it ends up fetching all records and applying the filter in memory instead of at the database level.

**Solution:**

If you want to use a `Func<T, bool>` in a way that can still be translated to SQL, you should either:

1. **Define the filter directly in the `Where` clause**, like in your first version:
    
```csharp
var groupedEmployees = context.Employees
    .Where(e => e.AddressId == 1)
    .ToList();
```
    
2. **Use an expression tree** to ensure it's translatable:
    
```csharp
Expression<Func<Employee, bool>> filter = e => e.DepartmentId == 1;

var groupedEmployees2 = context.Employees
    .Where(filter)
    .ToList();
```


By using an `Expression<Func<T, bool>>` instead of a `Func<T, bool>`, you're telling EF Core that it should treat the `filter` as an expression tree, which can be translated to SQL properly.

**You said:**

Ah, I see now. The `Where` clause automatically uses an `Expression<Func>`, which is why it works.

**ChatGPT said:**

Exactly! The `Where` clause in LINQ automatically uses an `Expression<Func<T, bool>>`, which is why it works as expected when you write something like:

```csharp
`.Where(e => e.AddressId == 1)`
```

This is a _lambda expression_ that is automatically compiled into an _expression tree_, which Entity Framework can translate into SQL and execute on the database.

When you use a `Func<T, bool>` instead, like in your second version:

```csharp
Func<Employee, bool> filter = e => e.DepartmentId == 1;
```

You are creating a regular _delegate_, which can't be translated to SQL. That's why EF Core can't directly use it for filtering on the database side and instead fetches all the records, then applies the filter in memory.

So to sum up, for database queries, LINQ to Entities expects an expression tree (which it can convert to SQL), and a regular delegate (`Func<T, bool>`) won't be processed the same way. If you want to use a delegate-like approach, using `Expression<Func<T, bool>>` will make sure it can still be translated into a SQL query.

**You said:**

One last thing to ask is why EF does not throw exception in this case, like it does with when facing translation issues?

**ChatGPT said:**

That's a great question! The reason why EF Core doesn't throw an exception when it encounters a `Func<T, bool>` instead of an `Expression<Func<T, bool>>` is due to how LINQ queries are handled in EF Core.

**Here’s the key idea:**

- **`Expression<Func<T, bool>>`** represents a _tree of expressions_ that EF Core can translate into SQL queries. EF Core needs this form because SQL is a declarative language that can be dynamically generated from the expression tree.
    
- **`Func<T, bool>`** is a **delegate**, not an expression tree. A delegate is executed in-memory (on the client side) and cannot be converted into SQL. EF Core doesn't need to "translate" a `Func<T, bool>` to SQL because it doesn't need to send it to the database.

Now, here's why EF Core doesn't throw an exception for this:

1. **EF Core doesn't try to translate `Func<T, bool>` to SQL**: When EF Core encounters a `Func<T, bool>`, it recognizes that it's something that will be executed locally, not on the database. Since no translation is attempted, EF Core doesn't raise an error. It just passes the data to LINQ and applies the filter in-memory after loading the data.
    
2. **EF Core only throws exceptions for unsupported operations**: EF Core throws exceptions when it tries to translate something that is not supported by the underlying database provider. For example, if you try to use methods that aren't supported by SQL (like `string.Contains()` in some cases), EF Core will throw an exception. However, with `Func<T, bool>`, EF Core doesn't attempt to make an unsupported translation—it just handles it as an in-memory operation.
    
3. **Automatic fallback to in-memory execution**: In cases where EF Core can't translate a part of a query (e.g., a `Func<T, bool>`), it will execute that part in-memory after it fetches the data. This "fallback" behavior allows the code to still work, but it's suboptimal, as it could result in fetching more data than necessary, leading to performance issues (especially with large datasets).

**Example:**

```csharp
var filter = new Func<Employee, bool>(e => e.DepartmentId == 1);

// EF Core won't throw an exception here because it just executes the filter in-memory
var filteredEmployees = context.Employees.Where(filter).ToList(); 
```

In this case:

- EF Core will first execute `context.Employees` as a query to the database.
- Then, it will fetch all employees and apply the `Func<T, bool>` filter **in-memory** after retrieving the data.

**Why not throw an exception?**

EF Core doesn't throw an exception because:

1. It **doesn't attempt to translate** the `Func<T, bool>` into SQL.
2. Instead, it falls back to an **in-memory filter**, which is still valid, though it can lead to inefficiencies.
3. This allows you to still write code without runtime errors, even though the query might not be as optimized as you'd like.

**Conclusion:**

EF Core doesn't throw an exception for `Func<T, bool>` because it recognizes the need to execute it in-memory, rather than attempting a translation to SQL. However, this can lead to performance issues if you're working with large datasets, which is why it's important to use `Expression<Func<T, bool>>` for database queries when you want to leverage SQL-based filtering.
# Bookmarks
Completion: 25.02.2025