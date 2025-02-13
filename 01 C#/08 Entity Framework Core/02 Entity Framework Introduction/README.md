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

```
dotnet add package Microsoft.EntityFrameworkCore
```

Entity Framework (EF) Core е модулен и изисква инсталиране на допълнителни data providers в зависимост от нуждите ни. Трябва да имаме поне един, но може да инсталираме и няколко, като те няма да си пречат, но за всеки ще трябва да имаме отделен DbContext. Например, за работа със SQL Server, трябва да инсталираме **`Microsoft.EntityFrameworkCore.SqlServer`**, като той автоматично включва и **`Microsoft.EntityFrameworkCore`** като зависимост. Това може да стане в VS или ползвайки CLI командата:

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

За да използваме инструментите на EF, като миграции, Scaffold и други, е необходимо да инсталираме следните пакети и инструменти:

- - Инсталиране на **dotnet-ef** като глобален инструмент (необходимо, ако ще използваме `dotnet ef` в терминала или извън Visual Studio):

```
dotnet tool install --global dotnet-ef
```

-  Добавяне на пакета **`Microsoft.EntityFrameworkCore.Design`**, който съдържа необходимите зависимости за работа с миграции и други EF инструменти. CLI командата:

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

- Добавяне на пакета **`Microsoft.EntityFrameworkCore.Tools`**, който е необходим за използване на EF Core команди в **Visual Studio Package Manager Console (PMC)**. Ако се използват само CLI команди, този пакет не е необходим. Командата за добавянето на пакета през CLI:

```
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

В обобщение, тези три пакета са основни за работата с EF Core:

- **`Microsoft.EntityFrameworkCore.SqlServer`** – нужен за работа с база данни SQL Server.
-  **`Microsoft.EntityFrameworkCore.Design`** – съдържа необходимите зависимости за работа с миграции и други EF инструменти.
-  **`Microsoft.EntityFrameworkCore.Tools`** – е необходим само за Visual Studio Package Manager Console (PMC) и не е необходим за използване на командния ред (CLI).
### Database First Model
#### scaffold
При използване на подхода "Database First", съществуваща база данни се преобразува в Entity модел. За целта използваме командата **scaffold**, като е важно да се отбележи, че тя се различава в зависимост дали се изпълнява през CLI или Package Manager Console (PMC) намираща се - VS -> Tools -> NuGet Package Manager -> Package Manager Console:

CLI:
```
dotnet ef dbcontext scaffold "Server=…;Database=…;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

PMC:
```
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

```
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
# Bookmarks
Completion: 14.02.2025