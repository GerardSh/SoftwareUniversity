# General
## Overview and Features
EF Core е стандартния framework за .NET и .NET Core. Преминаването между определени версии на EF е много трудно, затова е добре да се запознаваме със спецификите и проблемите на конкретната версия, ползвайки release notes, breaking changes и тн.

Оползотворява до голяма степен LINQ, за разлика от повечето други frameworks.

Автоматичен change tracking на in-memory обектите. Понякога върши много добра работа, но в други ситуации, може да пречи.

Разработен е да бъде database-agnostic, което означава, че може да сменим базата данни, като:
- Сменим провайдъра – инсталираме съответния NuGet пакет за новата база.
- Актуализираме connection string-а в `DbContext`.
- Проверим съвместимостта на използваните SQL функции и миграции.

Така можем лесно да преминаваме между `SQL Server`, `PostgreSQL`, `MySQL`, `SQLite` и други. Не е строго закачена за релационните бази данни, но се ползва основно за тях.

Open source с independent release cycle, което означава, че EF Core може да бъде обновяван и пускан по различно време от .NET Framework или .NET Core, въпреки че често новите версии на EF Core и .NET са синхронизирани, за да осигурят съвместимост.
### Basic Workflow
- Първото действие е да създадем базата данни, като има два начина - Code First и DB First / Scaffold. При Code First, първо пишем обектно ориентиран модел и EF ще го конвертира в релационен модел, като ще изпълни правилните скриптове върху базата данни. При другия вариант EF изчита таблиците и от тях създава нужните класове, които може да ползваме в обектно ориентираното приложение.
- След като базата данни е създадена, можем да пишем и изпълняваме заявки върху `IQueryable`. Това ни позволява да създадем заявка, която ще бъде превърната в SQL заявка, когато я изпълним. Докато работим с `IQueryable`, не се изпълнява действителната заявка към базата данни – това се случва само когато извикаме метод, който провокира изпълнението, като например `ToList()`, `First()`, `Single()` и други. Това дава възможност да изграждаме сложни и динамични заявки, които се изпълняват оптимално, извличайки само необходимите данни от базата данни.
- EF генерира и изпълнява SQL заявка в базата данни. Трябва да се има предвид, че понякога ако напишем нещо с LINQ, EF не винаги успява да го преведе към SQL. Преди EF 3.1, ако напишем заявка, която EF не знае как да преведе към SQL, без наше знание изтегля цялата таблица в паметта и след това започва да изпълнява LINQ заявката. Реално EF е изпълнявал `SELECT` на всички колони без `WHERE` клауза. Така LINQ заявките ни винаги работят, но на цената на много мрежови, памет и време ресурси. Затова в EF 3.1 MS са решили, ако заявката не се превежда към SQL, да хвърля exception. Докарвайки нашите LINQ заявки до такива, които да може EF да ги преведе към SQL, си гарантираме че приложението ни ще работи много по-бързо. В противен случай, може да имаме сериозни проблеми с производителността.
- След като заявката ни е написана и е преведена към SQL, тя се изпраща към сървъра, изпълнява се и следващата задача на EF е да хване резултата и да го преведе към .NET обект.
- След което, имаме възможност да променим нещо във върнатия обект и да извикаме метода `SaveChanges()`, който ще генерира нов SQL, който да приложи промените в базата данни.

Следвайки тези стъпки, може да извършим всичко с базата данни, без да напишем един ред SQL.
#### IQueryable
LINQ е създаден за работа с колекции и може да бъде използван както за локални колекции, така и за достъп до бази данни. Разликата е, че когато работим с база данни, трябва да използваме интерфейса `IQueryable`. Този интерфейс представлява така нареченото дърво на изразите (expression tree) и съдържа само мета данни за заявката. Той е структура, която описва как ще бъдат достъпени данните, без самите данни да са включени в него.

Докато не извикаме метод за изпълнение на заявката, като например `ToList()` или `First()`, не се изтеглят никакви данни. Това е причината `IQueryable` да бъде много лек – той не съдържа данни, а само информация как те ще бъдат извлечени. С този интерфейс можем да изграждаме и добавяме филтри към заявката, без да изтегляме ненужно данни. Когато решим, че сме готови да получим резултатите, заявката може да бъде изпълнена и тогава ще бъдат извлечени само тези данни, които наистина ни трябват, а не целият набор от данни.

Използването на делегати вътре в `IQueryable`, вместо да се използва `Expression`, може да забави изпълнението, тъй като делегатите не могат да бъдат превърнати в SQL заявки, които да се изпълняват на нивото на базата данни. Когато използваме делегати, операциите се изпълняват на клиентската страна (т.е. върху извлечените данни), вместо да се генерира оптимизирана SQL заявка, която да бъде изпълнена директно в базата данни. Това води до по-голямо натоварване на паметта и процесора, тъй като трябва да се извлекат повече данни, отколкото е необходимо, и операциите се извършват в рамките на самото приложение, а не в базата данни.

В сравнение с `Expression`, който се използва за изграждане на дърво на изразите, което може да бъде превърнато в SQL и изпълнявано директно върху базата данни, използването на делегат води до по-малко ефективно обработване на данните.

**Пример с Делегат**

При използването на делегат, обработката на данните се случва на клиентската страна, след като данните бъдат извлечени от базата данни.

```csharp
var query = context.Users.Where(u => u.Age > 18);
var result = query.ToList(); // Изпълнява заявката и извлича резултатите
```

Тук `Where` използва делегат (анонимна функция), за да изпълни филтрирането върху данните, които са вече извлечени в паметта. Ако има много записи, това може да доведе до натоварване на паметта и излишно изпълнение на логика.

**Пример с Expression**

При използването на `Expression`, изразите се изграждат в дърво на изразите, което може да бъде превърнато в SQL и изпълнено на сървъра (базата данни), като се минимизира количеството извлечени данни и обработката на клиента.

```csharp
Expression<Func<User, bool>> predicate = u => u.Age > 18;
var query = context.Users.Where(predicate); // Използва израз за филтриране на базата данни
var result = query.ToList(); // Изпълнява SQL заявка на базата данни
```

В този случай, `Expression` представлява дърво на изразите, което се превръща в SQL заявка и се изпълнява на сървъра. Това е по-ефективно, тъй като филтрирането се извършва на нивото на базата данни, преди данните да бъдат извлечени в приложението.

**Разлика**

- **Делегат**: Обработката се случва на клиентската страна (след извличане на данните). Това може да доведе до излишно натоварване на паметта и по-бавно изпълнение, особено когато работим с големи набори от данни.
- **Expression**: Обработката се извършва на сървъра (в базата данни). Това е по-ефективно, тъй като минимизира броя на извлечените данни и намалява натоварването на клиента.

Използването на `Expression` е предпочитано за заявки към бази данни, защото позволява оптимизация на изпълнението на заявката, докато делегатите се използват, когато работим с вече извлечени данни.
##### Expression
`Expression` е **generic class** в .NET, който представлява дърво на изрази. Той позволява динамично изграждане на изрази, които могат да бъдат превърнати в изпълним код (например SQL заявка). `Expression` се използва основно в LINQ и приема два параметъра: тип на обекта, върху който работи, и тип на резултата от израза.

Пример:

```csharp
Expression<Func<User, bool>> expression = u => u.Age > 18;
```

Тук `Expression<Func<User, bool>>` е generic, където `User` е типът на обекта, а `bool` е типът на резултата.
### Setup
NET първоначално е бил с размер около 200 MB, но с преминаването към .NET Core, MS успяват да намалят този размер до около 20 MB. Това стаwа възможно благодарение на новия модулен подход, при който основната част на платформата (ядрото) е минимална, а допълнителните функционалности се добавят чрез инсталиране на NuGet пакети. Този подход позволява на разработчиците да добавят само необходимите компоненти, което води до по-лек и оптимизиран код. Например, Entity Framework (EF) е отделен като NuGet пакет, вместо да бъде част от основната платформа. 
При работа с NuGet пакети и EF Core, трябва да се има предвид съвместимостта между версията на пакета и версията на **.NET**, която използваме в проекта. Например **EF Core 6.x** е предназначен за **.NET 6** и **.NET 7**, докато **EF Core 5.x** е за **.NET 5** и по-старите версии.

За добавяне на NuGet пакети към проект има два основни начина:
- Visual Studio – чрез **NuGet Package Manager** интерфейса, за да добавим, обновим или премахнем пакети, както и да конфигурираме различни източници на пакети. Това може да стане чрез **Package Manager Console** или през графичния интерфейс на Visual Studio.
- dotnet CLI – трябва да се намираме в директорията, съдържаща project file-а на приложението, и да изпълним следната команда, която ще го модифицира:

CLI
```sh
dotnet add package Microsoft.EntityFrameworkCore
```

PMC
```powershell
Install-Package Microsoft.EntityFrameworkCore
```

Entity Framework (EF) Core е модулен и изисква инсталиране на допълнителни data providers в зависимост от нуждите ни. Трябва да имаме поне един, но може да инсталираме и няколко, като те няма да си пречат, но за всеки ще трябва да имаме отделен DbContext. Например, за работа със SQL Server, трябва да инсталираме **`Microsoft.EntityFrameworkCore.SqlServer`**, като той автоматично включва и **`Microsoft.EntityFrameworkCore`** като зависимост. Това може да стане в VS или ползвайки CLI командата:

CLI
```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

PMC
```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

За да използваме инструментите на EF, като миграции, Scaffold и други, е необходимо да инсталираме следните пакети и инструменти:

- Инсталиране на **dotnet-ef** като глобален инструмент (необходимо, ако ще използваме `dotnet ef` в терминала или извън Visual Studio)

CLI
```sh
dotnet tool install --global dotnet-ef
```

-  Добавяне на пакета **`Microsoft.EntityFrameworkCore.Design`**, който съдържа необходимите зависимости за работа с миграции и други EF инструменти. 

CLI
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
```

PMC
```powershell
Install-Package Microsoft.EntityFrameworkCore.Design
```

- Добавяне на пакета **`Microsoft.EntityFrameworkCore.Tools`**, който е необходим за използване на EF Core команди в **Visual Studio Package Manager Console (PMC)** и **CLI** (ако не се използва глобален инструмент `dotnet-ef`).

CLI
```sh
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

PMC
```powershell
Install-Package Microsoft.EntityFrameworkCore.Tools
```

В обобщение, тези три пакета са основни за работата с EF Core:

- **`Microsoft.EntityFrameworkCore.SqlServer`** – нужен за работа с база данни SQL Server.
-  **`Microsoft.EntityFrameworkCore.Design`** – съдържа необходимите зависимости за работа с миграции и други EF инструменти.
-  **`Microsoft.EntityFrameworkCore.Tools`** е необходим за използване на EF Core команди както в Visual Studio Package Manager Console (PMC), така и в CLI, ако не се използва глобално инсталиран инструмент `dotnet-ef`.
### Database First Model
#### scaffold
При използване на подхода "Database First", съществуваща база данни се преобразува в Entity модел. За целта използваме командата **scaffold**, като е важно да се отбележи, че тя се различава в зависимост дали се изпълнява през CLI или Package Manager Console (PMC) намираща се - VS -> Tools -> NuGet Package Manager -> Package Manager Console:

CLI
```sh
dotnet ef dbcontext scaffold "Server=…;Database=…;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

PMC
```PowerShell
Scaffold-DbContext "Server=…;Database=…;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

Тази команда създава моделите, които съответстват на таблиците в базата данни, като ги генерира в указаната директория (в този случай Models).

Въпреки че програмистите обикновено не предпочитат този подход, понякога той е необходим и се използва в два основни случая:
- Когато, имаме готова база данни и искаме бързо да се свържем с нея. В този случай, еднократно взимаме базата и генерираме обектно ориентирания модел. След това, преминаваме към подхода "Code First" за бъдещи промени.
- Когато екипът, който поддържа базата данни, прави промените по нея. В този случай, използваме флага **-f** (force), за да обновим модела според последните промени в базата данни.

 Допълнителни опции:
**-f** (force) CLI – обновява модела с последните промени в базата данни. В PMC няма аналогична опция за force, тъй като `Scaffold-DbContext` командата автоматично генерира моделите от текущото състояние на базата данни.
**-d** в CLI /  **`-DataAnnotations`** в PMC - указва на **scaffold** да използва data annotation атрибути вместо fluent API. Това е предпочитаният вариант, тъй като атрибутите се поставят директно в класовете, дефиниращи съответните таблици. Fluent API, от друга страна, се използва в **DbContext**, което не е обектно ориентиран подход, тъй като дефинициите за колони трябва да бъдат в класа, към който се отнасят.
**-o** в CLI / **`-OutputDir`** в PMC - указва директорията, в която ще бъдат генерирани моделите.

За успешното извършване на scaffold е необходимо да бъдат инсталирани следните NuGet пакети:

- **`Microsoft.EntityFrameworkCore.SqlServer`**
- **`Microsoft.EntityFrameworkCore.Design`**
- **`Microsoft.EntityFrameworkCore.Tools`** необходим, ако ще се изпълняват EF Core команди през Visual Studio Package Manager Console (PMC).

Scaffold не прави mapping таблиците (свързващите таблици, когато имаме many-to-many relationship), но когато ползваме code first подход е добре да се направят.

**Разбивка на командата в PMC:**

```PowerShell
Scaffold-DbContext "Server=.;Database=SoftUni;User Id=UserName;Password=Password;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -DataAnnotations -Context SoftUniDbContext -ContextDir Data -OutputDir Data/Models
```

**Connection String** - параметърът за връзка с базата данни: съдържа сървър, база данни и данни за достъп.

**Provider** - `Microsoft.EntityFrameworkCore.SqlServer`: Указва provider-a за SQL Server.

**`-DataAnnotations`** - използва Data Annotations вместо Fluent API при генерирането на класовете.

**`-Context SoftUniDbContext`** - Задава името на генерирания DbContext клас (тук: `SoftUniDbContext`).

**`-ContextDir Data`** - указва директорията за DbContext класа (тук: `Data`).

**`-OutputDir Data/Models`** - указва директорията за моделите (тук: `Data/Models`).

Командата генерира класовете и DbContext за съществуващата база данни, използвайки зададената връзка и Data Annotations.
##### partial class
Всички автоматично генерирани класове, са public partial. Ако искаме да направим каквато и да е промяна, тя се прави в отделен файл, защото ако пре-генерираме, този файл ще бъде презаписан и нашите промени ще изчезнат.
## Components
### Domain Classes (Models)
Entity Framework (EF) работи със стандартни C# класове, наречени **ентитети**. Те могат да съдържат **навигационни пропъртита**, които отразяват релациите между таблиците.

```csharp
public class PostAnswer
{
 public int Id { get; set; } // Primary key
 public string Content { get; set; }
 public int PostId { get; set; } // Foreign key
 public Post Post { get; set; } // Navigation property
}
```

По подразбиране, EF приема, че всяко пропърти, наречено `Id`, е **първичен ключ (Primary Key)**. Ако се използва различно наименование, е необходимо да се маркира с атрибута `[Key]`.
#### Class Library
Добра практика е ентити моделите да се съхраняват в отделен **Class Library** проект, тъй като това предотвратява ненужни зависимости между различните приложения, които работят с базата данни. За да реализираме това:

- Създаваме нов проект в **solution-а** от тип `Class Library`. Добра практика е в името му да включим `Infrastructure`, ако в него ще се съхраняват не само моделите на базата данни, но и други инфраструктурни зависимости като изпращане на имейли, логване и др.
- Отваряме **"Manage NuGet Packages for Solution"** и инсталираме необходимите **NuGet пакети** в Library проекта. **Design пакетът** е необходим само в главния проект и не е нужно да го инсталираме в Library.
- В главния проект добавяме **референция** в `Dependencies` към Library проекта, за да можем да използваме неговите модели и контексти.
- Изпълняваме **Scaffold** командата, като `default project` трябва да бъде **Infrastructure** проектът, а стартиращият проект трябва да остане главният.

По този начин постигаме разделяне на отговорностите – различните приложения вече не зависят едно от друго, а вместо това използват общия Library, което улеснява поддръжката и разширяемостта на проекта.
### DbSet Type
Всеки `DbSet<T>` представлява проекция на таблица в базата данни в обектно-ориентирания модел и съдържа колекция от ентитети, които я съставят. Това е основният начин за работа с EF.

Чрез `DbSet<T>` могат да се извършват различни операции като:

- `Add` – добавяне на нов запис
- `Attach` – привързване на съществуващ обект към контекста
- `Remove` – изтриване на запис
- `Find` – търсене на обект по първичен ключ
### The DbContext Class
`DbContext` представлява проекция на базата данни в обектно-ориентирания модел. 

- Обикновено се наименува според името на базата, като към него се добавя `DbContext`.
- Наследява `DbContext` от Entity Framework.
- Управлява обектния модел чрез колекции `DbSet<T>`  
- Осигурява свързаност и комуникация с базата.
- Чрез `DbSet<T>`, следи промените в нашите обекти, използвайки **Change Tracking**. Обектът трябва да бъде част от `DbSet<T>`, за да може да бъде следен.
- Използва **Identity Tracking**, чрез който EF гарантира, че всяка промяна върху един и същ запис в базата се прилага върху една и съща инстанция на обекта в паметта, вместо да създава нови.
- Предоставя API за **CRUD операции** и **LINQ заявки**, като разширява стандартния **LINQ** с допълнителни **extension методи**, които могат да работят с `IQueryable` и данни от базата.
- Препоръчително е да бъде в отделен **Class Library**, като не трябва да се забравя добавянето на **Entity Framework Core** и съответния **database provider** като зависимости.
- Една база данни може да бъде разделена между няколко `DbContext` класа, но това не се препоръчва, освен ако не е необходимо.

Дефиниране на DbContext Class:

```csharp
using Microsoft.EntityFrameworkCore; // EF Reference
using CodeFirst.Data.Models; // Models Namespace

public class ForumDbContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Post> Posts { get; set; }
  public DbSet<User> Users { get; set; }
}
```
## Reading Data
### The DbContext Class
DbContext-a имплементира `IDisposable`, поради което е препоръчително да го използваме в `using`.

**CRUD Operations**

Извличаме данните от `DbSet`, който е пропърти на `DbContext`, като можем да ползваме extension метода `Select()`. Той връща `IQueryable`, което представлява дърво на изразите (expression tree). За да материализираме тази колекция, е необходимо да използваме завършващ метод, като `ToList()`, който преобразува `IQueryable` в `IEnumerable` и връща `List<T>`. Когато използваме методи като `Where()`, `Select()`, `OrderBy()`, Entity Framework изгражда дървото на изразите, което описва логиката на запитването. Преди да извикаме завършващ метод, на практика изграждаме SQL заявка в дървото на изразите. Това дърво представлява логиката на запитването, без да се изпълнява. В момента, в който извикаме завършващ метод, колекцията се материализира - запитването се превръща в конкретна SQL заявка и се изпълнява към базата данни.
Ако искаме да видим каква SQL заявка ще бъде изпълнена, вместо `ToList()`, можем да използваме метода `ToQueryString()`, който ще върне самата SQL заявка:

```csharp
var SQLCommand = context.Employees
    .Select(e => new
    {
        e.FirstName,
        e.LastName,
        e.JobTitle,
        e.Salary
    })
    .Where(e => e.FirstName.StartsWith("a"))
    .ToQueryString();

Console.WriteLine(SQLCommand);

// Output:
// SELECT [e].[FirstName], [e].[LastName], [e].[JobTitle], [e].[Salary]
// FROM [Employees] AS [e]
// WHERE [e].[FirstName] LIKE 'a%'
```

Препоръчително е при работа с базата данни да използваме `async/await`. За целта трябва да добавим **`Microsoft.EntityFrameworkCore`**, тъй като методът `ToListAsync()` не е част от стандартната библиотека LINQ.

За създаване на нови ентитети, трябва да се ползва метода `Add()`.

Манипулацията на базата данни се извършва чрез модифициране на обектите в материализираната колекция.

Навигацията през релациите на таблиците се осъществява лесно чрез навигационните пропъртита.

Можем да изпълняваме LINQ заявки, които се трансформират в SQL заявки.

Позволява ни да управляваме самата база данни - creation/deletion/migration.
### Using DbContext Class
Създаваме инстанция на класа, като в конструктора може да подадем connection string-a:

```csharp
var context = new SoftUniDbContext();
```

**DbContext Properties**

- `Database` – съдържа методите `EnsureCreated` и `EnsureDeleted`, които трябва да се използват с повишено внимание.
- `ChangeTracker` – автоматично следи промените в обектите.
- Всички ентити класове (таблиците) са изредени като пропъртита, примерно:

```csharp
public DbSet<Employee> Employees { get; set; }
```
### LINQ Query
LINQ-to-SQL query over EF entity:

```csharp
public partial class SoftUniEntities : DbContext
{
 public DbSet<Employee> Employees { get; set; }
 public DbSet<Project> Projects { get; set; }
 public DbSet<Department> Departments { get; set; }
}

using var context = new SoftUniEntities();

 var employees = context.Employees // Employees is a property in the SoftUniEntities DbContext class
 .Where(e => e.JobTitle == "Design Engineer")
 .ToList(); // Materializes the query

// Find element by ID
 var project = context.Projects.Find(2);
 Console.WriteLine(project.Name);
```

Когато търсим елемент по неговия първичен ключ, най-добрият подход е използването на метода `Find()`, защото:
- Първо проверява в `ChangeTracker`, aко обектът вече е зареден в контекста и е променен, ще върне именно тази версия.
- Избягва допълнителна заявка към базата, aко обектът е в паметта, EF няма да прави ново извличане от базата, което повлиява и на бързината на работа.
- Гарантира консистентност, предотвратявайки несъответствия, ако сме променили даден запис в `DbContext`, но сме заредили нова версия от базата. Целта е да няма разминаване, ако примерно вече сме променили обекта, но сме дръпнали нова версия, която не е променена.
### LINQ Simple Operations
EF Core превежда в SQL само тези LINQ методи, които могат да бъдат директно изразени чрез SQL оператори.

Тези методи могат да бъдат преобразувани в SQL заявки и се изпълняват директно в базата (ефективни са).

**Филтриране:**

- `Where()` → `WHERE`
- `First() / FirstOrDefault()` → `TOP(1)`
- `Last() / LastOrDefault()` (⚠ Често зареждат всички резултати в паметта)
- `Skip()` → `OFFSET`
- `Take()` → `LIMIT`

**Сортиране:**

- `OrderBy()` / `OrderByDescending()` → `ORDER BY`
- `ThenBy()` / `ThenByDescending()` → `ORDER BY ...`

**Групиране и агрегация:**

- `GroupBy()` → `GROUP BY`
- `Count()` / `Sum()` / `Average()` / `Min()` / `Max()` → `COUNT(*)`, `SUM(...)`, `AVG(...)`, `MIN(...)`, `MAX(...)`

**Селектиране:**

- `Select()` → `SELECT ... FROM ...`
- `SelectMany()` → (когато е подходящо)
- `Distinct()` → `DISTINCT`

**Съединения:**

- `Join()` → `INNER JOIN`
- `GroupJoin()` → `LEFT JOIN`

**Проверка за наличие:**

- `Any()` → `EXISTS(...)`
- `All()` → `NOT EXISTS(...)`
- `Contains()` → `IN(...)`

Тези методи работят по същия начин, независимо дали колекцията е локална или идва от база данни.
Някои методи не могат да бъдат преведени в SQL и ще се изпълняват в паметта, само след като данните са заредени.

 **Заключение:**  
 
- Голяма част от LINQ методите работят с SQL, но не всички. 
- Методи, които не могат да бъдат преведени в SQL, изискват зареждане в паметта. 
- Винаги е важно да проверяваме генерирания SQL с `.ToQueryString()` (EF Core) или профилиране.
### Logging the Native SQL Queries (SQL Server Profiler)
- Можем да следим заявките, които изпълнява EF през Microsoft SQL Server Management Studio - SQL Server Profiler.
- Друг начин е да ползваме метода `ToQueryString()`
## CRUD Operations
### Creating New Data
Можем да създадем и запазим нов запис в базата данни чрез Entity Framework.

```csharp
var project = new Project() // Create a new Project object
{
 Name = "Judge System",
 StartDate = new DateTime(2023, 1, 26),
};
context.Projects.Add(project); // Add the object to the DbSet
context.SaveChanges(); // Execute SQL statements
```

След извикването на `SaveChanges()`, Entity Framework ще генерира и изпълни `INSERT` заявка, която ще създаде нов запис в базата данни.
### Cascading Inserts
Възможно е да добавяме свързани ентитети каскадно в базата данни чрез Entity Framework. Когато основният (родителски) обект бъде добавен, неговите свързани обекти автоматично се вмъкват в зависимост от конфигурацията на релациите.

```csharp
Employee employee = new Employee();
employee.FirstName = "John";
employee.LastName = "Doe";
employee.Projects.Add(new Project { Name = "SoftUni Conf"} );
softUniEntities.Employees.Add(employee);
softUniEntities.SaveChanges();
```

В този случай, когато `employee` бъде добавен в базата данни, свързаният `Project` също ще бъде автоматично създаден и асоцииран с него.

Този механизъм гарантира целостта на данните и улеснява управлението на релациите между обектите в модела.
### Updating Existing Data
За да модифицираме даден ентитет и да запазим промените му, обектът трябва да бъде проследяван (`tracked`) от Entity Framework. Това означава, че не можем да използваме проекция, а трябва да заредим целия обект, да го променим и след това да извикаме `SaveChanges()`.

За да бъде проследяван (`tracked`) от Entity Framework, обектът трябва:

- Да бъде от клас, който е част от модела на данните (Entity клас, дефиниран в `DbContext`).
- Да е извлечен от базата чрез `DbContext`, за да може EF да следи промените му.

Ако създадем нов обект ръчно (например с `new Employee()`), той няма да бъде проследяван, докато не бъде добавен към `DbContext` чрез `context.Employees.Add(employee)`.

Ако обектът е само проекция (напр. чрез `.Select(e => new { e.FirstName, e.LastName })`), той също няма да бъде проследяван, защото не е цял ентитет.

```csharp
Employees employee =
 softUniEntities.Employees.First(); // SELECT the first order
employees.FirstName = "Alex";
context.SaveChanges(); // Execute an SQL UPDATE
```

След извикването на `SaveChanges()`, Entity Framework ще генерира и изпълни `UPDATE` заявка, която ще актуализира променените полета на съответния запис в базата данни.
### Deleting Existing Data
Можем да изтрием запис от базата данни, като го маркираме за изтриване и извикаме `SaveChanges()`.

```csharp
Employees employee =
 softUniEntities.Employees.First();
softUniEntities.Employees.Remove(employee); // Mark the entity for deleting at the next save
softUniEntities.SaveChanges(); // Execute the SQL DELETE command
```

След извикването на `SaveChanges()`, Entity Framework ще изпълни `DELETE` заявка в базата данни, премахвайки съответния запис.
## EF Core Configuration
### Code First Model
Това означава да напишем .NET класовете и да оставим EF Core да създаде базата данни въз основа на техните конфигурации.

Важно е да се има предвид, че няма проблем да комбинираме DB First и Code First моделите. Можем да добавим Code First промени към база данни, която първоначално сме генерирали чрез DB First. Въпреки това, след като веднъж преминем към Code First, няма възможност да се върнем обратно към DB First.

Ако използваме DB First, всяка промяна в схемата на базата данни трябва да се прави директно чрез SQL скриптове (например `ALTER TABLE`, `ADD COLUMN` и т.н.). След това, за да обновим моделите в Entity Framework, трябва да преизпълним командата за генериране на моделите с флаг за презаписване, ако изпълняваме CLI командата, а в PMC този флаг не се използва, тъй като командата автоматично обновява моделите и презаписва съществуващите файлове:

CLI
```sh
dotnet ef dbcontext scaffold "Your_Connection_String" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f
```

PMC:
```PowerShell
`Scaffold-DbContext "Your_Connection_String" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```
#### Benefits
Пишем код без необходимостта да дефинираме mappings в XML или да създаваме таблици.

Дефинираме обектите си в C# формат, които Entity Framework създава в базата данни като таблици.

Позволява персистентност на данни без необходимост от конфигурация.

Промените в кода могат да бъдат отразени (мигрирани) в схемата. ▪ Използват се Data Annotations или Fluent API за описание на пропъртитата - `[Key]`, `[Required]`, `[MinLength]`.
#### Setup
Трябва да инсталираме EF Core пакета в проекта:

CLI
```sh
dotnet add package Microsoft.EntityFrameworkCore
```

PMC
```powershell
Install-Package Microsoft.EntityFrameworkCore
```

Трябва да се добавят и data providers, примерно **`Microsoft.EntityFrameworkCore.SqlServer`**

**Connect to SQL Server:**

Може да направим Configuration class с нашия connection string, като това не е задължително:

```csharp
public static class Configuration
{
 public const string ConnectionString = "Server=.;Database=…;";
}
```

След това трябва да добавим connection string-a в `OnConfiguring()` метода в DbContext класа:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder builder)
{
 if (!builder.IsConfigured)
 builder.UseSqlServer(Configuration.ConnectionString);
}
```

**Fluent API:**

Методът `OnModelCreating()` в класа `DbContext` ни позволява да използваме Fluent API, за да дефинираме релациите между таблиците в Entity Framework Core:

```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
 builder.Entity<Category>()
	 .HasMany(c => c.Posts)
	 .WithOne(p => p.Category);
 
 builder.Entity<Post>()
	 .HasMany(p => p.Replies)
	 .WithOne(r => r.Post);
 
 builder.Entity<User>()
	 .HasMany(u => u.Posts)
	 .WithOne(p => p.Author);
}
```

**Database Connection Workflow:**

Ако базата данни не съществува, тя се създава автоматично. В противен случай, съществуващата база се използва.
## Database Migrations
Миграциите ни позволяват да променяме структурата на базата данни, без да губим съществуващи данни. Те обработват данните внимателно и ни позволяват да актуализираме схемата на базата, без да нарушаваме нейната цялост.

Entity Framework Core поддържа история на всички промени, което ни позволява да се върнем към определена миграция, ако е необходимо – подобно на source control за базата данни.

При работа с production или тестови среди, всяка база може да бъде поддържана в различно състояние според нуждите на проекта.

Генерират се автоматично.

**Работа с миграции в EF Core**

За да използваме миграции в EF Core, изпълняваме следните команди в EF CLI Tools:

- **Създаване на нова миграция:**

CLI
```sh
dotnet ef migrations add {MigrationName}
```

PMC
```powershell
Add-Migration {MigrationName}
```

- **Отмяна на последната миграция:**

CLI
```sh
dotnet ef migrations remove
```

PMC
```powershell
Remove-Migration
```

- **Прилагане на миграциите към базата:**

CLI
```sh
dotnet ef database update
```

PMC
```powershell
Update-Database
```

- **Прилагане на миграции в кода:**

```csharp
db.Database.Migrate();
```

- **Script Migration**

CLI
```sh
dotnet ef migrations script
```

PMC
```powershell
Script-Migration
```

Представлява генерирането на SQL скрипт от миграциите, който описва промените в базата данни. Чрез командата можем да създадем скрипт, който може да се изпълни ръчно върху базата – това е полезно в production среди или когато искаме да прегледаме SQL кода, преди да го приложим. Можем също така да използваме параметри (като `-From` и `-To`), за да зададем обхвата на миграциите, които искаме да включим в скрипта.

Тези команди ни позволяват да управляваме миграциите ефективно и да гарантираме, че базата ни е в синхрон с модела на данните.
# Misc
# ChatGPT
## ADO.NET, EF Core, and Data Providers
**ADO.NET** is the foundation on which **Entity Framework (EF) Core** operates as an abstraction.

**How ADO.NET, EF Core, and Data Providers Work Together:**

- **EF Core** an abstraction built on top of ADO.NET, providing ORM (Object-Relational Mapping) functionality that allows working with objects instead of raw SQL queries.
- **ADO.NET** the base technology in .NET for working with databases. It works with **data providers**, which handle the low-level communication with the specific database (e.g., `SQL Server`, `PostgreSQL`).
- **Data Provider** responsible for communication with a specific database (e.g., `SQL Server`, `MySQL`, `PostgreSQL`).

**The Relationship Between Them:**

- **EF Core** abstracts the database interaction using **ADO.NET** to execute database operations, such as queries and commands.
- **ADO.NET** is the underlying layer that communicates directly with the database, using **data providers** specific to each database type (e.g., `SqlClient` for SQL Server, `Npgsql` for PostgreSQL).
- **Data Providers** are responsible for translating and sending the SQL queries to the database and receiving the results.

**Example with EF Core and SQL Server Provider:**

When working with **SQL Server**, EF Core uses the `Microsoft.Data.SqlClient` ADO.NET provider for SQL Server:

```csharp
optionsBuilder.UseSqlServer("Server=.;Database=MyDb;Trusted_Connection=True;");
```

Internally, EF Core translates the queries into SQL and sends them to ADO.NET’s `SqlClient`, which executes them on the database.

**Conclusion:**

EF Core **does not replace** ADO.NET; rather, it **builds on top of and abstracts** it. Ultimately, all database interactions are still handled by **ADO.NET Data Providers**. 
**EF Core** relies on **ADO.NET** for database access, and **ADO.NET** uses specific **data providers** to interact with the database.

**You said:**

So using entity framework, we don't care about the exact data providers as its all managed behind the scene?

**ChatGPT said:**

Exactly! When you're using **Entity Framework (EF) Core**, you **don't have to worry about the specific data providers** because EF Core manages everything for you behind the scenes.

**How EF Core Manages Data Providers:**

- EF Core abstracts the underlying database interactions, so you work with **DbContext** and **LINQ queries** instead of dealing directly with SQL or data providers.
- You just specify the database provider (e.g., `SQL Server`, `PostgreSQL`) when configuring EF Core, and it automatically uses the corresponding data provider behind the scenes.
- EF Core handles the connection, command execution, and data retrieval for you using the appropriate **ADO.NET data provider**.

**Example:**

If you’re using `SQL Server`:

```csharp
optionsBuilder.UseSqlServer("YourConnectionStringHere");
```

EF Core internally uses `SqlClient` (the `SQL Server` data provider) to establish a connection, execute queries, and return results.

If you switch to `PostgreSQL`:

```csharp
optionsBuilder.UseNpgsql("YourConnectionStringHere");
```

EF Core now uses the `Npgsql` provider for `PostgreSQL`, but you don’t need to interact with it directly.

**Summary:**

- **EF Core** abstracts the underlying provider and ADO.NET, so you don’t need to handle the connection or command execution logic manually.
- You just configure the database provider and let EF Core handle everything else.

This makes it much easier to work with databases without worrying about the specifics of how each database provider works!
## Fluent API vs Data Annotations
The **Fluent API** is a method of configuring models in Entity Framework (EF) through code rather than using data annotations (attributes). It provides a more flexible and powerful way to define the behavior of your models, relationships, constraints, and other configuration settings.

**Key Characteristics:**

2. **Fluent Interface**: The Fluent API uses a fluent interface, which means it allows for method chaining, making the code more readable and expressive.
3. **Configuration in `OnModelCreating`**: Fluent API configurations are typically done inside the `OnModelCreating` method of the `DbContext` class.
4. **More Control**: It gives you fine-grained control over the configuration of your model, enabling complex configurations that can't always be represented using data annotations.

**Example of Fluent API Configuration**

Suppose you have the following model:

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}
```

To configure this model using Fluent API, you would override the `OnModelCreating` method in your `DbContext` like this:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>()
        .ToTable("Students")                    // Specify the table name
        .HasKey(s => s.Id);                     // Configure the primary key

    modelBuilder.Entity<Student>()
        .Property(s => s.Name)
        .HasMaxLength(100)                      // Set max length for Name property
        .IsRequired();                          // Make Name property required

    modelBuilder.Entity<Student>()
        .Property(s => s.BirthDate)
        .HasColumnType("date");                 // Set the column type for BirthDate
}
```

**Fluent API vs Data Annotations:**

- **Fluent API** is used when you need more complex configurations or need to configure things that aren't supported by data annotations.
- **Data Annotations** are simpler and are used to configure model properties directly using attributes, but they are more limited.

For instance, Fluent API can be used to configure relationships, table splitting, indexes, and more. It's especially useful when you want to keep your model classes clean without cluttering them with attributes.

**When to Use Fluent API:**

- When you need more control over the mapping of your models to the database.
- For complex relationships (e.g., one-to-many, many-to-many) or configurations that data annotations can't express.
- To avoid using attributes in your model classes, especially when you want to separate configuration logic from domain classes.

When you use the `-d` (`DataAnnotations`) flag in the `Scaffold-DbContext` command, **the `OnModelCreating` method is still generated** in your `DbContext` class. However, instead of Fluent API configurations being inside this method, the method will generally remain empty or have minimal configurations. The primary configurations will be **moved to attributes** directly on the model properties and classes.

Other examples:

**With `-d` (`DataAnnotations`):**

- The model classes will have attributes like `[Key]`, `[Column]`, and `[ForeignKey]`, which define the entity relationships, keys, and constraints.
- The `OnModelCreating` method in `DbContext` might remain empty or contain very few Fluent API configurations, but the essential mappings are done using attributes.

Example of the model:

```csharp
public partial class Department
{
    [Key]
    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("ManagerID")]
    public int ManagerId { get; set; }

    [ForeignKey("ManagerId")]
    public virtual Employee Manager { get; set; } = null!;
}
```

The `OnModelCreating` method would likely look like this:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Minimal or no Fluent API here
}
```

**Without `-d` (using Fluent API):**

- The model classes won't have attributes, and **all the configurations will be done using Fluent API** in the `OnModelCreating` method inside the `DbContext`.

Example of the model (without attributes):

```csharp
public partial class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = null!;
    public int ManagerId { get; set; }
    public virtual Employee Manager { get; set; } = null!;
}
```

The `OnModelCreating` method will contain the Fluent API configurations:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Department>(entity =>
    {
        entity.HasKey(e => e.DepartmentId);
        entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
        entity.HasOne(d => d.Manager)
              .WithMany(p => p.Departments)
              .HasForeignKey(d => d.ManagerId)
              .OnDelete(DeleteBehavior.ClientSetNull);
    });
}
```

**Does `OnModelCreating` get used only once?**

- **The `OnModelCreating` method is called each time you interact with your `DbContext`**, such as when you perform database queries or migrations.
- It is **not just used once**; it is invoked by Entity Framework whenever it needs to configure the models.
- **Fluent API** inside `OnModelCreating` is typically used to configure things that are not easily done with `DataAnnotations` or to provide more complex configurations. For example, setting up relationships, indices, or advanced behaviors (like cascade delete) would be done in `OnModelCreating`.

**In summary:**

- With **Data Annotations (`-d`)**, the `OnModelCreating` method will likely remain minimal or empty, as the primary configuration is done through attributes in the model class.
- Without **Data Annotations**, all configuration is done in `OnModelCreating` using Fluent API.
- **`OnModelCreating`** is called whenever EF Core initializes the context, so even if it is empty or contains minimal code, it is still used whenever EF Core interacts with the database.
## How Models, DbContext, and Database Interaction Work
**Entity Classes (Models)**

- These are **C# classes** that represent **tables** in the database.
- They contain **properties** that map to **columns**.
- They may have **navigation properties** that represent **relations** (e.g., `PostAnswer` has a `Post` property).

Example:

```csharp
public class PostAnswer
{
    public int Id { get; set; }  // Primary key
    public string Content { get; set; }
    public int PostId { get; set; }  // Foreign key
    public Post Post { get; set; }  // Navigation property
}
```

**DbContext Class (Database Connection & Operations)**

- This is the **bridge** between your C# application and the database.
- It **configures the connection** to the database.
- It exposes **`DbSet<T>` properties**, which represent **tables** in the database and allow **querying and saving data**.

Example:

```csharp
public class AppDbContext : DbContext
{
    public DbSet<PostAnswer> PostAnswers { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Your_Connection_String_Here");
    }
}
```

- **When you create an instance of `AppDbContext`**, EF **establishes a connection** to the database.
- You can **query, insert, update, and delete** records using this instance.

**Using the Context (Querying & Saving Data)**

Once you have an instance of `AppDbContext`, you can:

✅ **Load data (querying)**

```csharp
using (var context = new AppDbContext())
{
    var answers = context.PostAnswers.ToList(); // Loads all PostAnswer records
}
```

✅ **Insert data**

```csharp
using (var context = new AppDbContext())
{
    var newAnswer = new PostAnswer { Content = "New Answer", PostId = 1 };
    context.PostAnswers.Add(newAnswer);
    context.SaveChanges();  // Saves to the database
}
```

✅ **Update data**

```csharp
using (var context = new AppDbContext())
{
    var answer = context.PostAnswers.FirstOrDefault(a => a.Id == 1);
    if (answer != null)
    {
        answer.Content = "Updated Answer";
        context.SaveChanges();  // Applies changes to the database
    }
}
```

✅ **Delete data**

```csharp
using (var context = new AppDbContext())
{
    var answer = context.PostAnswers.FirstOrDefault(a => a.Id == 1);
    if (answer != null)
    {
        context.PostAnswers.Remove(answer);
        context.SaveChanges();  // Deletes from the database
    }
}
```

**Key Takeaways**

- **Models (Entity Classes)** → Represent **tables**.
- **DbContext Class** → Handles **database connection and operations**.
- **`DbSet<T>` Properties** → Represent **tables** and allow data manipulation.
- **`SaveChanges()`** → Persists changes from memory **to the database**.
- **When you create an instance of `DbContext`**, your app is **connected** to the database and can work with data.
## Entities in ORM
The word **"entity"** can refer to both:

- **The table structure in the database**: When we talk about an entity class in ORM (like Entity Framework), it typically represents a table in the database. For example, an `Employee` entity class corresponds to the `Employees` table.
-  **A record (or row) in the table**: When we instantiate an object of the entity class, each object represents a single record in the corresponding table. For instance, a specific `Employee` object represents a row in the `Employees` table.

So, depending on the context, an **entity** can mean:

- The **table** structure itself (through its class definition).
- A **record** (through the instance of the class).

Outside of Entity Framework context, you would simply refer to the elements in a collection as **elements** or **items** of the collection, not "entities."

**Why Does This Matter?**

- **In EF**, entities are tracked, meaning changes to them can be saved to the database.
- **Outside EF**, objects are not tracked unless explicitly attached to a `DbContext`.
## EF Query Translation
For **Entity Framework** to translate your LINQ query into a valid SQL query, you need to ensure that the methods you use are **translatable into SQL**.

Entity Framework only supports certain methods that it knows how to map to SQL operations. For instance, basic operations like `Where()`, `Select()`, `OrderBy()`, and string methods like `StartsWith()`, `EndsWith()`, and `Contains()` are commonly supported because they have direct SQL equivalents.

**Key Points:**

5. **Supported Methods**: Methods like `StartsWith()`, `Contains()`, and `EndsWith()` are directly translatable into SQL `LIKE` operations.
6. **Unsupported .NET Methods**: Methods like `ToString()`, `ToUpper()`, `FirstOrDefault()`, or operations like `e.FirstName[0]` may not have direct equivalents in SQL and thus won't be translated correctly. These operations typically require **client-side evaluation** (in-memory processing) after fetching the data.

**Example:**

- **Supported**:

```csharp
.Where(e => e.FirstName.StartsWith("a"))
```

This will translate to:

```sql
WHERE FirstName LIKE 'a%'
```

- **Not Supported**:

```csharp
.Where(e => e.FirstName[0] == 'a')
```

This won't translate to SQL, as `e.FirstName[0]` and `ToString()` are not supported by SQL.
## Behavior of Entity Framework with Multiple `ToListAsync()` Calls

When you execute the following code twice:

```csharp
var employees = await context.Employees
    .ToListAsync();

var employees2 = await context.Employees
    .ToListAsync();
```

If you make changes to both collections and call `SaveChanges()`, EF Core will track the same entities in memory because both `employees` and `employees2` refer to the same instances.

- **Identity Resolution**: EF Core performs identity resolution, meaning both collections will contain references to the same objects.
- **Conflicting Changes**: Any changes made in the two collections on the same entity will be saved based on the last modification detected by EF Core. If conflicting changes are made, only the last set of changes will be persisted.
- **Separate Tracking**: To avoid this issue and have independent sets of changes, you can use separate `DbContext` instances or call `AsNoTracking()` to prevent EF Core from tracking the entities.

**Conclusion:**

Multiple `ToListAsync()` calls on the same `DbContext` instance will result in the same entity objects being tracked. Conflicting changes made to the same entities across different collections will overwrite each other when `SaveChanges()` is called.
## Entity Framework and `sp_executesql` Execution
Entity Framework (EF) **does not create stored procedures by default**, but it often executes SQL commands using `sp_executesql`. This is a system stored procedure in SQL Server that allows EF to execute **parameterized queries** dynamically.

**When Does EF Use `sp_executesql`?**

EF translates LINQ queries into SQL and sends them to the database using `sp_executesql` in scenarios such as:

- **SELECT queries** (`ToList()`, `FirstOrDefault()`, etc.)
    
```sql
exec sp_executesql N'SELECT * FROM Employees WHERE JobTitle = @p0', N'@p0 nvarchar(50)', @p0=N'Design Engineer'
```
    
- **INSERT operations** (`Add()` + `SaveChanges()`)
    
```sql
`exec sp_executesql N'INSERT INTO Employees (Name, Age) VALUES (@p0, @p1)', N'@p0 nvarchar(50), @p1 int', @p0=N'John', @p1=30`
```
    
- **UPDATE operations** (`Update()` + `SaveChanges()`)
    
```sql
`exec sp_executesql N'UPDATE Employees SET Age = @p0 WHERE Id = @p1', N'@p0 int, @p1 int', @p0=31, @p1=1`
```
    
- **DELETE operations** (`Remove()` + `SaveChanges()`)
    
```sql
`exec sp_executesql N'DELETE FROM Employees WHERE Id = @p0', N'@p0 int', @p0=1`
```

**Why Does EF Use `sp_executesql`?**

- **Security**: Prevents SQL injection by using parameterized queries.
- **Performance**: Allows SQL Server to reuse execution plans for similar queries.
- **Flexibility**: Enables EF to execute dynamically generated SQL without needing predefined stored procedures.

**Stored Procedures vs. `sp_executesql`**

- **`sp_executesql`** is used for **ad-hoc SQL execution**, meaning EF dynamically generates queries at runtime.
- **Stored procedures** must be explicitly configured if you want EF to use them for CRUD operations.
# Bookmarks
Completion: 14.02.2025