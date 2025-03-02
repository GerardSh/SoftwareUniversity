# General
## Native SQL Queries
### Executing Queries
Използването на ORM като EF Core не защитава напълно приложението от SQL инжекции, ако не се ползва правилно. Задачата на EF Core е да абстрахира базата данни и да осигури безопасност при работа с данни чрез параметризирани заявки, но native raw SQL queries могат да бъдат уязвими на SQL инжекции, ако не се използват параметри.

Това означава, че защитата от SQL инжекции не е автоматична при използването на ръчни SQL заявки в EF Core. Когато използваме native SQL query (например с `FromSqlRaw` или `ExecuteSqlRaw`), е важно да внимаваме да подадем параметри, а не да конкатенираме директно входни данни в SQL заявката.

 Пример за изпълнението на SQL заявки директно в EF:

```csharp
var query = "SELECT * FROM Employees";
var employees = db.Employees
 .FromSqlRaw(query)
 .ToArray();
```

В този пример правим SQL заявка в стринг и я подаваме на метода `FromSqlRaw()` за изпълнение.
#### Restrictions
- `JOIN` изрази не работят - когато използваме `FromSqlRaw()`, не можем да използваме `JOIN` изрази или други сложни SQL конструкции, които биха създали резултати, които не могат да бъдат мапнати към съществуващия ентити клас. Това ограничава възможността да правим сложни заявки и проекции.
- Required колоните трябва да са посочени - когато работим с `FromSqlRaw()`, трябва да сме сигурни, че всички required колони, които не могат да бъдат `NULL`, са включени в заявката. Това е така, защото `FromSqlRaw()` винаги връща entity type и резултатът трябва да съответства на съществуващия `DbSet<>` entity клас. Заявката трябва да съдържа всички задължителни колони в класа, за да може да се създаде обекта.
- Таргет таблицата трябва да съвпада с избрания `DbSet` - когато използваме `FromSqlRaw()`, трябва да се уверим, че заявката е насочена към същата таблица, която съответства на `DbSet` класа, с който работим. Например, ако имаме `DbSet<Employee>`, то заявката трябва да е насочена към таблицата за служители в базата данни.

Тези ограничения са важни за правилното функциониране на заявките в EF Core, тъй като EF Core се опитва да мапва резултатите от заявката към съществуващите ентити класове.
##### EF Core 8
В EF Core 8  нямаме ограничения за изпълнение на SQL код, но това води до риск от по-сериозни SQL инжекция, ако не се внимава. Проблемът е, че при ползването на `SqlQueryRaw` можем да изпълняваме произволни SQL заявки, което предоставя възможност за атаки, ако входните данни не се обработват внимателно.

Затова е препоръчително да ползваме `context.Database.SqlQuery<DTO>`, който не ни разрешава да ползваме нищо различно от `FormattableString` за безопасно и ефективно изпълнение на заявките, тъй като `FormattableString` осигурява безопасност спрямо SQL инжекция чрез автоматично ескейпване на параметрите, които се подлагат на подмяна.

Пример за правилен подход:

```csharp
var result = context.Database
    .SqlQuery<EmployeeDepartmentDTO>("SELECT e.Id AS EmployeeId, e.Name AS EmployeeName, d.Name AS DepartmentName " +
                                     "FROM Employees e JOIN Departments d ON e.DepartmentId = d.Id")
    .ToList();
```

Този подход е безопасен, когато заявката се изгражда с ескейпнати параметри и няма ръчно вмъкване на потребителски данни, което би могло да доведе до SQL инжекция.

Ако ползваме `context.Database.SqlQuery<DTO>` няма как да се получи SQL инжекция, защото той не ни разрешава да ползваме нищо различно от `FormattableString`.
### Using Parameters To Counter SQL Injections
При работа с SQL заявки в Entity Framework Core, трябва да използваме параметри за защита от SQL injection атаки, когато параметрите идва от вънка. Тогава, ако директно конкатенираме потребителски вход в заявката, има риск от изпълнение на зловреден код. Ако стойността не идва от външен източник (например е hard coded в кода или идва от безопасен източник), тогава няма риск от SQL инжекция.

Безопасен подход (използване на параметри)

```csharp
var context = new SoftUniDbContext();
string nativeSQLQuery =
 "SELECT FirstName, LastName, JobTitle" +
 "FROM dbo.Employees WHERE JobTitle = {0}"; // Parameter placeholder
 
var employees = context.Employees.FromSqlRaw(
 nativeSQLQuery, "Marketing Specialist"); //Parameter value

foreach (var employee in employees)
{
  Console.WriteLine(employee.FirstName);
}
```

- Стойността `"Marketing Specialist"` не се конкатенира директно в заявката, а се подава като параметър.
- Базата данни я интерпретира като текст, а не като част от SQL командата.

Ако подадем входа: `' OR 1=1; --`

финалната SQL заявка ще изглежда така:

```sql
SELECT FirstName, LastName, JobTitle FROM dbo.Employees WHERE JobTitle = @p0
```

Където `@p0` е стойността на входа `' OR 1=1; --`.

Базата данни не интерпретира това като изпълним SQL код, а го третира като литерален низ. Въпреки че входът изглежда като опит за SQL инжекция, той няма да бъде изпълнен като част от SQL командата. Базата данни ще върне нулеви резултати (ако няма записи с такъв `JobTitle`), вместо да изпълни зловреден SQL код като част от заявката. Това предотвратява успешната атака с SQL инжекция. Атакуващият няма да има ясен индикатор дали заявката е блокирана или просто не е намерила съвпадащи записи. Това допълнително обърква потенциалния нападател и затруднява разбирането дали атаката му е успешна. Колкото по-малко информация получава атакуващият, толкова по-сигурно е приложението ни.

Небезопасен подход (SQL Injection уязвимост)

```csharp
string userInput = Console.ReadLine(); // User value input
string sqlQuery = "SELECT FirstName, LastName FROM Employees WHERE JobTitle = '" + userInput + "'";

var employees = context.Employees.FromSqlRaw(sqlQuery); // Vurnable to SQL Injection!
```

Атака с SQL Injection

Ако злонамерен потребител въведе `' OR 1=1; --`

Тогава финалната заявка ще изглежда така:

```sql
SELECT FirstName, LastName FROM Employees WHERE JobTitle = '' OR 1=1; --'
```

- `1=1` винаги е true, така че всички записи в таблицата се връщат.
- Ако заявката беше `DELETE FROM Employees WHERE JobTitle = '...'`, всички записи щяха да бъдат изтрити!
### Interpolation in SQL Queries
В EF 6 и по-ранни версии има специален метод `FromSqlInterpolated`, който позволява интерполация на стойности в SQL заявките, като същевременно защитава приложението от SQL инжекции.

```csharp
var context = new SoftUniDbContext();
string jobTitle = "Marketing Specialist";
FormattableString nativeSQLQuery =
 $"SELECT * FROM dbo.Employees WHERE JobTitle = {jobTitle}"; // Interpolated parameter
 
var employees = context.Employees.FromSqlInterpolated(
 nativeSQLQuery);

foreach (var employee in employees)
{
  Console.WriteLine(employee.FirstName);
}
```

Докато в примера изглежда, че директно вмъкваме стойността в заявката чрез интерполация, EF Core се грижи за безопасността, като създава параметризирана заявка в базата данни. Това означава, че дори ако подадем злонамерен вход като `' OR 1=1; --`, той ще бъде третиран като обикновен стринг, а не като част от SQL командата.

Когато използваме `FromSqlInterpolated`, стойността трябва да бъде представена като `FormattableString`, за да може EF Core да обработи интерполацията и да създаде правилната параметризирана SQL заявка, осигуряваща защита от SQL инжекции.

SQL инжекциите не са възможни, когато използваме `FromSqlInterpolated`.
### Executing a Stored Procedure
За да изпълним store-ната процедура безопасно, трябва да използваме параметри, които съответстват на имената, зададени в самата процедура.
В параметъра на SQL заявката можем да зададем различни настройки, като например дали той е входен (`INPUT`), изходен (`OUTPUT`) или input-output (`INOUT`). Това позволява по-гъвкаво взаимодействие със сторнати процедури и функции в базата данни.

SQL процедура:

```sql
CREATE PROCEDURE UpdateSalary @param int
AS
UPDATE Employees SET Salary = Salary + @param;
```

C# изпълнение: 

```csharp
var salaryParameter = new SqlParameter("@salary", 5);
var query = "EXEC UpdateSalary @salary";
context.Database.ExecuteSqlRaw(query, salaryParameter);
```

- Съответствие на имената - името на параметъра в SQL (`@param`) трябва да съвпада с това, което подаваме в C# (`@salary`).
- Защита от SQL инжекции - когато използваме `SqlParameter`, EF Core се грижи входните стойности да не бъдат изпълнявани като част от SQL кода, а да бъдат третирани като обикновени стойности.
- По-добра производителност - параметризираните заявки могат да бъдат кеширани от SQL сървъра, което намалява натоварването върху него.

Изпълнява се върху обекта `Database`, а не върху конкретен `DbSet`.
## Object Tracking
Когато селектираме данни чрез контекста, EF автоматично започва да следи промените по тях. Това е важно, тъй като обектите, докато съществуват в паметта, нямат пряка връзка с базата данни. За да може тези промени да бъдат отразени, EF проследява всяка модификация и знае точно каква е тя. При извикване на метода `SaveChanges`, EF генерира съответния SQL код, който отразява извършените промени и го изпълнява в рамките на транзакция върху базата данни.
### Attached and Detached Objects
При attached обектите контекстът следи промените по тях, което означава, че винаги е информиран за това какво се случва.

Detached обектите, от своя страна, не се проследяват от контекста и ако извършваме действия с тях, тези промени няма да се отразят в базата данни, освен ако не бъдат предприети допълнителни операции.

Проблемът с attached обектите е, че tracker-ът може бързо да се „разтегли“, тъй като всичко, което извличаме от базата, влиза в него. Това увеличава натоварването на системата и операциите стават по-бавни. Принципно контекстът трябва да живее за кратък период и след като бъде унищожен, всички обекти се отделят от него. При Web приложенията, правилния lifespan на контекста е в рамките на request-a. Дори обектите да продължат да съществуват, те остават detached и не могат да бъдат променяни чрез този контекст. Контекстът ни позволява да вземем данните в състояние detached, без да се добавят в tracker-а. 
Това е най-подходящо, когато искаме просто да прочетем и покажем информация, без да правим промени.

Ако обаче имаме намерение да променяме обектите, по-добре е те да бъдат attached, защото ако ги прикрепим след като сме ги променили, направените промени могат да се загубят. За да предотвратим това, е необходимо да се извърши сканиране на разликите, при което Entity Framework сравнява всяко свойство на двата обекта.
Този процес изисква повторно извличане на данните от базата и извършване на детайлно сравнение – операция, която е ресурсно и време интензивна. Затова, когато имаме намерение да променяме обект, по-добре е той от самото начало да бъде attached.

Ако логиката изисква понякога да правим промени, а понякога не, оптималното решение е първо обектът да бъде в състояние detached и след това да се закачи към контекста преди извършване на промените.

Всички attached обекти се менажират от `DbContext`, а всички промени се проследяват от Entity Tracker. Когато извикаме `SaveChanges()`, тези промени се персистират в базата данни.

Detached обектите, от друга страна, не се проследяват и са напълно нормални обекти, които нямат никаква връзка с Entity Framework.

Ако искаме да извлечем информация от базата данни, без да бъде attached към Entity Tracker, можем да използваме `AsNoTracking()`. Този метод извлича данните, без да ги добавя в тракера. Така заявките са по-бързи и заемат по-малко ресурси, което ги прави подходящи за сценарии, при които данните само се четат, без да се налага тяхното последващо модифициране.

**Tracking queries**

```csharp
var employee = context.Employees
			   .FirstOrDefault(e => e.EmployeeId == 1);

employee.JobTitle = "Marketing Specialist";
context.SaveChanges();
```

**No-tracking queries**

```csharp
var employees = context.Employees
				.AsNoTracking()
				.ToList();
```
### Detaching Objects
Обектът се detach-ва, когато:

- Вземем обект от `DbContext` и след това го dispose-нем:

```csharp
Employee GetEmployeeById(int id)
{
	 using (var SoftUniDbContext = new SoftUniDbContext())
	 {
		 return SoftUniDbContext.Employees
			.First(e => e.EmployeeID == id); // Returned employee is detached
	 }
}
```

- Ръчно зададем `EntityState.Detached`:

```csharp
var employee = context.Employees.First(e => e.EmployeeID == id);
context.Entry(employee).State = EntityState.Detached;
```

Обяснение:
- `context.Entry(employee)` връща `EntityEntry<Employee>`, който съдържа метаданни за `employee` в `DbContext`.
- `EntityEntry.State` указва текущото състояние на обекта (Attached, Detached, Modified и т.н.).
- Когато зададем `EntityState.Detached`, разкачаме обекта от `DbContext`, което означава, че той вече не се проследява от Entity Tracker.
### Reattaching Objects
Когато искаме да обновим разкачен (`Detached`) обект, първо трябва да го закачим към контекста, след което да извършим промяната и да я запазим в базата.

```csharp
void UpdateName(Employee employee, string newName)
{
	 using (var softUniDbContext = new SoftUniDbContext())
	 {
        var entry = softUniDbContext.Entry(employee); // Create an entry for the object
        entry.State = EntityState.Modified; // Attach it and mark it as modified (this tracks the object and considers it changed)
        // entry.State = EntityState.Unchanged; // Alternatively, if we only want to attach the object without considering any previous changes made while untracked:
        employee.FirstName = newName; // Apply the change
        softUniDbContext.SaveChanges(); // Persist the change to the database
	 }
}
```

Обяснение:
- Методът приема разкачен обект, който не се следи от `DbContext`.
- Чрез `Entry()` получаваме достъп до състоянието на обекта и го маркираме като `Modified`.
- Маркирането на обекта като `Modified` означава, че EF ще третира всички пропъртита като променени, дори ако е модифицирано само едно. Това може да доведе до изпращане на излишни колони в SQL заявката за актуализация, но по този начин всички промени ще бъдат отразени, дори ако са направени преди обекта да е закачен.
- Извикваме `SaveChanges()`, което генерира и изпълнява съответната SQL заявка за актуализация.
- Този подход е полезен, когато разполагаме с обект, който вече не е следен от `DbContext`, но искаме да го актуализираме в базата.
- Ако искаме да обновим само конкретно променените пропъртита, можем да използваме `Attach(employee)` и да зададем `Modified` само на нужните пропъртита - `softUniDbContext.Entry(employee).Property(e => e.FirstName).IsModified = true;`

Този подход е полезен, когато разполагаме с обект, който вече не е следен от `DbContext`, но искаме да го актуализираме в базата.

Вместо да използваме подхода, при който взимаме мета данните на даден обект чрез метода `Entry()`, можем директно да използваме методите `Attach()` или `Update()` за по-опростена и по-ясна работа с обектите.

```csharp
void UpdateName(Employee employee, string newName)
{
    using (var softUniDbContext = new SoftUniDbContext())
    {     
        employee.FirstName = newName; // Change the first name before attaching the object

        // Using Attach()
        softUniDbContext.Employees.Attach(employee); // Attach the object without marking it as modofied, we can mark it separately
        softUniDbContext.Entry(employee).Property(e => e.FirstName).IsModified = true; // Mark only the changed property as modified
    
        // Using Update()
        softUniDbContext.Employees.Update(employee); // Attach and mark all properties of the object as modified

        softUniDbContext.SaveChanges(); // Persist the changes to the database
    }
}
```

Обяснение:

- `Attach()` - закача обекта към контекста без да маркира нито едно свойство като променено. Можете по-късно да посочим целия обект или дадени свойства да бъдат маркирани като променени.
- `Update()` -  закача обекта и маркира всички свойства като променени, което означава, че всяко свойство ще бъде актуализирано в базата данни, когато се извика `SaveChanges()`.

Този подход предлага гъвкавост, ако искаме да актуализираме само конкретни свойства или целия обект.
## Bulk Operations
Заявките се изпълняват една по една – когато трябва да направим промяна на 100 обекта, в класическия случай преминаваме през обектите в `foreach`, променяме стойностите и при извикване на `SaveChanges()` се генерират `n` `UPDATE` заявки, където `n` е броят на обектите. Това е проблем, защото в действителност би могло да се извърши всичко с една SQL заявка. Причината за това е, че Entity Framework Tracker не следи обектите като цяло в контекста, а ги следи поотделно. Когато трябва да персистираме промените, той генерира отделни заявки за всеки обект.

EF Core 6 не поддържа bulk операции, но от EF 7 нататък тези операции са добавени. За версия 6 можем да използваме **`Z.EntityFramework.Plus`**, който не използва Entity Tracker и работи по различен начин, позволявайки ни да правим bulk операции (като `UPDATE`, `DELETE`, и `INSERT`) на ентитита. Това е third-party пакет, като проблемът е, че не е безплатен. Ако нямаме лиценз, пакетът спира да работи след 30 дни. Въпреки това, този пакет значително ускорява операции за вмъкване на множество редове (bulk insert), което е много по-бързо от стандартния EF.

[Entity Framework Plus](https://entityframework-plus.net/) библиотека за подобряване на работата с EF6.
### Entity Framework Plus
Тази библиотека ни дава extension методи, чрез които да правим bulk операциите:

`Delete()`:

```csharp
context.Employees
 .Where(e => e.FirstName == "Pesho")
 .Delete();
```

Този метод генерира следната заявка:

```sql
DELETE [dbo].[Employees]
FROM [dbo].[Employees] AS j0 INNER JOIN (
SELECT
	 [Extent1].[Id] AS [Id]
	 FROM [dbo].[Employees] AS [Extent1].[Name]
	 WHERE N’Pesho' = [Extent1].[Name]
) AS j1 ON (j0.[Id] = j1.[Id])
```

`Update()`:

```csharp
// Update all Employees with name "Niki" to "Stoyan"
context.Employees
 .Where(t => t.Name == "Niki")
 .Update(u => new Employee { Name = "Stoyan" });

// Update all Employees' age to 99 who have the name "Plamen"
context.Employees
 .Where(employee => employee.Name == "Plamen");
 .Update(employee => new Employee { Age = 99 });
```
### EF8
В EF8 са добавени методите `ExecuteDeleteAsync()` и `ExecuteUpdateAsync()`, които извършват bulk операции и се изпълняват на момента, не чакат `SaveChanges` метода. Можем да създадем custom метод, който да извършва soft или hard bulk delete, в зависимост от това дали даденият клас имплементира custom интерфейса `ISoftDeletable`, който сме дефинирали:

```csharp
public interface ISoftDeletable
{
  public bool IsDeleted { get; set; }
  public DateTime? DeletedOn { get; set; }
}

async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> search) where T : class
{
    int result = 0;
    var context = new SoftUniContext();
    IQueryable<T> collection = context.Set<T>().Where(search);

    if (typeof(T).IsAssignableTo(typeof(ISoftDeletable)))
    {
        DateTime now = DateTime.Now;
        bool isDeleted = true;

        result = await collection
            .Select(c => c as ISoftDeletable)
            .ExecuteUpdateAsync(c => c
                .SetProperty(p => p.IsDeleted, isDeleted)
                .SetProperty(p => p.DeletedOn, now));
    }
    else
    {
        result = await collection.ExecuteDeleteAsync();
    }

    return result;
}
```

1.  `ISoftDeletable` интерфейс – Това е интерфейсът, който се добавя към класовете, които ще поддържат меко изтриване. Класовете, които го имплементират, ще съдържат свойствата `IsDeleted` и `DeletedOn`.
2. `DeleteAsync<T>` метод – Този метод проверява дали типът `T` имплементира интерфейса `ISoftDeletable`. Ако да, използва `ExecuteUpdateAsync()` за да актуализира полетата `IsDeleted` и `DeletedOn` на записите, които отговарят на условието. Ако не, използва `ExecuteDeleteAsync()` за да премахне записите физически от базата данни.
## Types of Loading
EF подържа три типа loading, които се отнасят за свързаните таблици. Примерно всеки `Department` има колекция с `Employee`-та, задачата на loading-a е да реши кога тази колекция ще се напълни.
### Explicit Loading
Ние решаваме кога да заредим дадената колекция. Ако не ни трябват, не ги зареждаме, като така спестяваме излишни `JOIN` операции и пестим ресурси. Ако все пак искаме да заредим данните, трябва да използваме методите `Reference().Load()` за единичен обект и `Collection().Load()` за зареждане на колекция. Реално тези методи не правят `JOIN`, а просто зареждат данните на даден обект (например на даден `Department`). Това е добър начин за оптимизиране на заявките и подобряване на производителността в случаи, когато не е необходимо да зареждаме всички свързани данни наведнъж.

```csharp
var employee = context.Employees.First();

context.Entry(employee)
 .Reference(e => e.Department)
 .Load();

context.Entry(employee)
 .Collection(e => e.EmployeeProjects)
 .Load();
```
### Eager Loading
Това е най-често използваният вариант за работа с EF. Данните се зареждат в момента на изпълнение на заявката. При писане на заявката в LINQ обикновено знаем дали дадените данни ще ни трябват и ако е необходимо, указваме на eager loading да ги зареди. Той работи само в момента на зареждане на всички данни. За тази цел се използват методите `Include()` и `ThenInclude()`, като `ThenInclude()` се използва, когато има допълнителни връзки. Тези методи генерират `JOIN` операции в SQL заявката.

```csharp
context.Towns.Include("Employees");

context.Towns.Include(town => town.Employees);

context.Employees
 .Include(employee => employee.Address)
 .ThenInclude(address => address.Town)
```
### Lazy Loading
Възможно е да възникнат множество проблеми с този вид loading. Той работи почти като explicit loading, но разликата е, че lazy loading решава кога да изпълни заявката, а не ние. Обикновено той зарежда само основните данни и когато се опитаме да достъпим навигационно пропърти, извършва допълнителна заявка, за да ги зареди. 
Проблемът идва, когато използваме `foreach` върху колекция от обекти и се опитаме да достъпим пропърти, което е релация — в този случай lazy loading ще изпълни n+1 заявки, тоест ще генерира 1 + N заявки към базата данни (1 за служителите и N за техните отдели). Това може да доведе до сериозни проблеми с производителността, особено при големи данни.

В дадени случаи предоставя по-добър performance. 

Работи за всяко навигационно пропърти, което е `virtual`, за да може да ги override-не. Другото условие да работи е да инсталираме пакета **`Install-Package Microsoft.EntityFrameworkCore.Proxies`** и да модифицираме `OnConfiguring` метода:

```csharp
void OnConfiguring (DbContextOptionsBuilder options)
{
	options
		.UseLazyLoadingProxies()
		.UseSqlServer(myConnectionString);
}
```

Ако направим тези неща, lazy loading ще работи по подразбиране, докато не ползваме някой от другите loading-и.
### N+1 Problem
- Когато презаредим страницата със списъка на статиите, се изпращат 11 заявки към базата данни.  
- Първата заявка извлича първите 10 статии.  
- Следващите 10 заявки извличат коментарите за всяка отделна статия.  
- Общо 11 заявки (N + 1).

Можем да използваме една заявка, ако заредим данните чрез eager loading. Недостатъкът е, че в някои случаи множество по-малки заявки могат да бъдат по-бързи от една голяма. Преценката кой вариант е по-подходящ зависи от конкретния случай и трябва да се прави внимателно.
## Concurrency Checks
### Optimistic Concurrency - Last One Wins
EF Core работи в `optimistic concurrency` mode (no locking). Това означава, че няма блокиране на записите в базата данни (no locking). Всеки потребител може да зареди данни, да ги промени локално и да ги запише. Ако двама потребители заредят един и същи обект, направят промени и се опитат да го запишат, последният, който запише промените си, ще презапише предходните без предупреждение (т.е. "последният печели"). В повечето случаи потребителите работят със собствени данни, което минимизира риска от конфликти.

За контрол върху конкурентните промени в `optimistic concurrency` използваме конкурентна проверка (Concurrency Check), като добавяме специална колона, върху която поставяме атрибута `[ConcurrencyCheck]`. Тази колона трябва да съдържа стойност, която се променя при всяка актуализация на записа.

Когато двама потребители заредят един и същ обект, колоната за проверка ще има една и съща стойност. При запис EF ще провери дали стойността в базата е останала непроменена. Ако тя е различна (т.е. друг потребител вече е записал промени), EF ще генерира грешка, сигнализираща, че обектът е бил модифициран и трябва да бъде актуализиран.

```csharp
// First user
var contextFirstUser = new SoftUniDbContext();
var lastProjectFirstUser = contextFirstUser.Projects.Last();
lastProjectFirstUser.Name = "Changed by the First User";

// Second user changes the same record
var contextSecondUser = new SoftUniDbContext();
var lastProjectSecondUser = contextSecondUser.Projects.Last();
lastProjectSecondUser.Name = "Changed by the Second User";

// Conflicting changes: last wins
contextFirstUser.SaveChanges();
contextSecondUser.SaveChanges(); // Second user wins
```
### Pessimistic Concurrency - First One Wins
Понякога искаме точно обратното – ако двама потребители направят запис, първият да бъде успешен, а вторият да получи грешка, която го уведомява, че обектът вече е променен и трябва да презареди и актуализира своите данни. Този подход се нарича `pessimistic concurrency`.
При `pessimistic concurrency` вместо проверки върху стойностите в колоните, се използват блокировки (locks) на ниво база данни, които предотвратяват едновременното изменение на даден запис от повече от един потребител. Това означава, че когато един потребител започне да променя даден обект, той заключва този запис, така че никой друг да не може да го модифицира, докато не приключи операцията.

При `pessimistic concurrency` вторият потребител няма нужда да презарежда обекта ръчно – той просто чака заключването да се освободи (или получава грешка, ако заявката надхвърли времето за изчакване).

При pessimistic concurrency EF Core не предоставя вградена поддръжка за автоматично управление на заключванията, а обикновено се разчита на transaction-level locks чрез `SELECT ... FOR UPDATE` в SQL Server или подобни механизми в други бази.

```csharp
var contextFirstUser = new SoftUniDbContext();
var lastTownFirstUser = contextFirstUser.Towns.Last();
lastTownFirstUser.Name = "First User";

var contextSecondUser = new SoftUniDbContext();
var lastTownSecondUser = contextSecondUser.Towns.Last();
lastTownSecondUser.Name = "Second User";

// Saving changes for the first user
contextFirstUser.SaveChanges(); // Changes for the first user get saved

// Saving changes for the second user
contextSecondUser.SaveChanges(); // This will throw a DbUpdateConcurrencyException
```
## Cascade Operations
Когато работим с EF Core и използваме Code First подхода за изграждане на база данни, каскадните операции се определят според това как сме дефинирали моделите си. За да контролираме поведението на каскадните операции, можем да зададем стратегията за всяко външно ключово поле (FK) в метода `OnModelCreating`.
### Cascade Delete Scenarios
- **Required FK с cascade delete true**: Изтрива всички свързани записи в таблиците при изтриване на основния запис. Ако имаме адреси, които съдържат FK към градове, и се опитаме да изтрием град, например "София", всички адреси, свързани с този град, ще бъдат изтрити автоматично. Това е полезно, ако искаме да премахнем всички записи, свързани с града.

- **Required FK с cascade delete false**: Генерира изключение при опит за изтриване, ако има свързани обекти. Ако имаме адреси, които съдържат FK към градове, ще получим грешка, ако се опитаме да изтрием град, който все още има адреси, свързани с него.

- **Optional FK (nullable) с cascade delete true**: Изтрива всички свързани записи при изтриване на основния запис, работи по същия начин като **Required FK с cascade delete true**, но при този случай е възможно съществуването на записи с `NULL` стойност за FK. Ако имаме адреси, които съдържат FK към градове, и се опитаме да изтрием град, например "Пловдив", всички адреси, свързани с този град, ще бъдат изтрити.

- **Optional FK (nullable) с cascade delete false**: Поставя стойността на FK на `NULL`. Например, ако имаме адреси, които съдържат FK към градове, и изтрием един град, всички адреси, свързани с този град, ще имат стойност `NULL` за съответния FK.

Тези правила могат да бъдат дефинирани в метода `OnModelCreating` с помощта на Fluent API.
### Cascade Delete with Fluent API
- **`DeleteBehavior.Cascade`**: Изтрива свързаните записи (по подразбиране за задължителни външни ключове). Това е стандартното поведение при използване на задължителни FK, при което всички свързани записи ще бъдат изтрити при изтриване на основния запис.

- **`DeleteBehavior.Restrict`**: Хвърля изключение при опит за изтриване, ако има свързани обекти. Това е полезно, когато не искаме да позволим изтриване на записи, които имат свързани записи (например, ако има адреси свързани с конкретен град).

- **`DeleteBehavior.ClientSetNull`**: Това е стандартното поведение за опционални външни ключове (не засяга базата данни). Когато се изтрие основният запис, свързаните записи няма да бъдат изтрити, но стойността на FK ще бъде зададена на `NULL` на ниво клиент, а не в базата данни.

- **`DeleteBehavior.SetNull`**: Задава стойността на FK на `NULL` в базата данни при изтриване на свързания запис. Това е полезно за опционални външни ключове, когато искаме да премахнем връзката, но да запазим записите в базата.

**Syntax:**

```csharp
modelBuilder.Entity<User>()
 .HasMany(u => u.Replies)
 .WithOne(a => a.Author)
 .HasForeignKey(a => a.UserId)
 .OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<User>()
 .HasMany(u => u.Replies)
 .WithOne(a => a.Author)
 .HasForeignKey(a => a.UserId)
 .OnDelete(DeleteBehavior.Cascade);
```
# Misc
# ChatGPT
## Nested Select
```csharp
.Select(a => new
{
    AlbumName = a.Name,
    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
    ProducerName = a.Producer!.Name, 
    Songs = a.Songs
             .Select(s => new
             {
                 SongName = s.Name,
                 SongPrice = s.Price.ToString("f2"),
                 SongWriter = s.Writer.Name
             })
            .OrderByDescending(s => s.SongName)
            .ThenBy(s => s.SongWriter)
            .ToList(),
    AlbumPrice = a.Price
})
```

How this works exactly, why the `IQueryable<T>` does not turn to `IEnumerable<T>` right after the nested `ToList()`?

**ChatGPT said:**

Great question! The key reason why `IQueryable<T>` does not turn into `IEnumerable<T>` immediately after the nested `.ToList()` is **due to how LINQ queries are executed and how projections work**.

**Breaking Down the Query Execution**

You are working with **Entity Framework (EF) Core**, and this is a **LINQ-to-Entities** query. Let's analyze step by step:

**1. Outer `Select(a => new { ... })` Execution**

The query starts with:

```csharp
.Select(a => new
{
    AlbumName = a.Name,
    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
    ProducerName = a.Producer!.Name, 
    Songs = a.Songs
             .Select(s => new
             {
                 SongName = s.Name,
                 SongPrice = s.Price.ToString("f2"),
                 SongWriter = s.Writer.Name
             })
            .OrderByDescending(s => s.SongName)
            .ThenBy(s => s.SongWriter)
            .ToList(),
    AlbumPrice = a.Price
})
```

- This is **still an IQueryable**, meaning EF Core is constructing a SQL query.
- The **entire projection** is analyzed **before execution**.

**2. Nested `.ToList()` Execution (`Songs.ToList()`)**

Inside the projection, you have:

```csharp
.Songs
    .Select(s => new { ... })
    .OrderByDescending(s => s.SongName)
    .ThenBy(s => s.SongWriter)
    .ToList()
```

- Since `Songs` is a **navigation property** (collection), EF **knows how to translate it into SQL**.
- `ToList()` **is applied inside the projection**, **but it doesn’t execute the whole query immediately**.
- Instead, EF **translates everything into a SQL query that retrieves all the required data in one go**.

This is possible because **EF Core supports translating nested collections into subqueries**. So instead of breaking the query into separate parts, EF Core keeps **everything inside the SQL execution plan**.

**3. Why `IQueryable<T>` Doesn't Turn Into `IEnumerable<T>` Immediately**

A common misunderstanding is that calling `.ToList()` inside a `.Select()` forces immediate execution. However, **this is not true in Entity Framework Core**. Instead:

1. **EF Core doesn’t execute the query immediately** when it sees `.ToList()` inside the projection.
2. It **analyzes the entire expression tree** and attempts to translate it into **a single SQL query**.
3. The **final execution** happens when the outer `.ToList()` (on the whole query) is called.

In other words, **everything stays as `IQueryable<T>` until the entire query is materialized** at the very end.

**How Does EF Core Handle This in SQL?**

Instead of breaking execution into multiple database queries, EF Core **generates a SQL query with a nested SELECT for the songs**. It would be something like:

```sql
SELECT a.Name AS AlbumName,
       FORMAT(a.ReleaseDate, 'MM/dd/yyyy') AS ReleaseDate,
       p.Name AS ProducerName,
       a.Price AS AlbumPrice,
       s.Name AS SongName,
       FORMAT(s.Price, 'f2') AS SongPrice,
       w.Name AS SongWriter
FROM Albums a
LEFT JOIN Producers p ON a.ProducerId = p.Id
LEFT JOIN Songs s ON s.AlbumId = a.Id
LEFT JOIN Writers w ON s.WriterId = w.Id
ORDER BY a.Id, s.Name DESC, w.Name
```

- The **nested `ToList()` does not trigger an immediate execution** but rather **shapes how EF Core constructs the SQL query**.
- EF Core **retrieves everything in one query and materializes the data in C#**.

**What If It Was LINQ-to-Objects?**

If you were working with **in-memory data** (i.e., `List<T>` instead of `DbSet<T>`), the behavior would be different:

- `.ToList()` **would force an immediate enumeration** of `Songs` at that moment.
- The outer `.Select()` would then work with already materialized lists.

But with **Entity Framework Core (LINQ-to-Entities)**, **the whole query is composed first**, and then **executed as a single SQL query**.

**Why Does It Fail Without `.ToList()` on `Songs`?**

- **Only the outermost `ToList()` executes the query** (i.e., `ToList()` on `Albums` materializes everything).
- However, **EF Core requires inner collections (`Songs`) to be `List<T>` or `Array<T>`**, because **it does not support `IOrderedQueryable<T>` inside projections**.

If we write:

```csharp
Songs = a.Songs
         .Select(s => new
         {
             SongName = s.Name,
             SongPrice = s.Price.ToString("f2"),
             SongWriter = s.Writer.Name
         })
        .OrderByDescending(s => s.SongName)
        .ThenBy(s => s.SongWriter), // ❌ This remains IOrderedQueryable<T>
```

- **The outer query is still `IQueryable<T>`** (good ✅).
- **But `Songs` remains an `IOrderedQueryable<T>` inside the projection** (bad ❌).
- **EF Core does not support returning an `IQueryable<T>` inside an anonymous object projection** → it throws an exception.

**Key Takeaways**

1. **LINQ-to-Entities defers execution**—everything remains `IQueryable<T>` until the final `.ToList()` on the main query.
2. **EF Core translates nested `.ToList()` into SQL subqueries**, avoiding multiple database calls.
3. **If this were LINQ-to-Objects, `ToList()` would force execution immediately**.
4. **The query materializes when `ToList()` is called on the outermost query (`Albums`).**
5. **Inner collections must be convertible to concrete types** (`List<T>` or `Array<T>`) inside projections.
6. **EF Core does not support `IQueryable<T>` inside projections**—hence, `Songs` needs `.ToList()`.

That’s why **your query remains `IQueryable<T>` even after the nested `.ToList()`**, and execution only happens when the outer `.ToList()` is called.

**Conclusion**

As long as the `ToList()` is used **inside a projection (like inside `Select`)**, it will not break the **IQueryable** chain at the top level.

✔ **Using `ToList()` inside `.Select()` (for collections like `a.Songs`) is safe** because it only materializes that **nested collection**, while the outer query remains **deferred** (`IQueryable`).

✔ **Only the final `.ToList()` at the end** should be called on the **top-level `IQueryable`**, ensuring **query execution is optimized**.

🚀 This pattern is commonly used in **Entity Framework Core projections** to **control when and where the query is executed** while keeping SQL efficient.
## Calculated Properties in EF Core
1. **What Are Calculated Properties?**

    - These are **C# properties** that **do not exist in the database** but are computed dynamically based on other properties.
    - Example:

```csharp
public decimal Price => Songs.Sum(s => s.Price);
```

2. **How EF Core Handles Them?**

    - EF **does not translate** them into SQL.
    - Instead, EF **loads all related data into memory** and then calculates the value.

3. **Why Can This Be a Problem?**

    - If the property depends on **navigation properties** (e.g., `Songs`), EF must **load all related records**, which can hurt performance.
    - This can lead to **N+1 query issues** or unnecessary data retrieval.
4. **Optimizing Calculated Properties in Queries**

    - Instead of using the property, **calculate the value in SQL using LINQ**:
    - The below approach avoids loading the entire `Songs` collection and makes the query **more efficient**.

   ```csharp
var albums = context.Albums
    .Select(a => new 
    { 
        AlbumName = a.Name, 
        AlbumPrice = a.Songs.Sum(s => s.Price) // Translates to SQL SUM()
    })
    .ToList();
    ```

5. **Best Practices for Performance**  

    ✅ **Use database-backed computed columns** (if the calculation is simple).  
    ✅ **Calculate values in LINQ-to-SQL expressions** instead of in-memory properties.  
    ✅ **Be cautious when accessing navigation properties inside a projection**, as it can trigger unwanted data loading.
## EF Core Limitation: String Interpolation vs. Concatenation in Queries
EF Core struggles with string interpolation (`$"{sp.Performer.FirstName} {sp.Performer.LastName}"`) because it involves runtime formatting, which may not translate well into SQL. However, simple string concatenation (`sp.Performer.FirstName + " " + sp.Performer.LastName`) works because it is easier for EF Core to convert into SQL. To avoid issues, prefer concatenation over interpolation when constructing strings inside `Select()`.
# Bookmarks
[Entity Framework Plus](https://entityframework-plus.net/)
Completion: 02.03.2025