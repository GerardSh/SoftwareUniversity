# General
## Overview
EF Core е стандартния framework за .NET и .NET Core. Преминаването между определени версии на EF е много трудно, затова е добре да се запознаваме със спецификите и проблемите на конкретната версия, ползвайки release notes, breaking changes и тн.

Оползотворява до голяма степен LINQ, за разлика от повечето други frameworks.

Автоматичен change tracking на in-memory обектите. Понякога върши много добра работа, но в други ситуации, може да пречи.

Разработен е да бъде database-agnostic, което означава, че може да сменим базата данни, като:
- Сменим провайдъра – инсталираме съответния NuGet пакет за новата база.
- Актуализираме connection string-а в `DbContext`.
- Проверим съвместимостта на използваните SQL функции и миграции.

Така можем лесно да преминаваме между `SQL Server`, `PostgreSQL`, `MySQL`, `SQLite` и други. Не е строго закачена за релационните бази данни, но се ползва основно за тях.

Open source с independent release cycle, което означава, че EF Core може да бъде обновяван и пускан по различно време от .NET Framework или .NET Core, въпреки че често новите версии на EF Core и .NET са синхронизирани, за да осигурят съвместимост.
## Basic Workflow
- Първото действие е да създадем базата данни, като има два начина - Code First и DB First / Scaffold. При Code First, първо пишем обектно ориентиран модел и EF ще го конвертира в релационен модел, като ще изпълни правилните скриптове върху базата данни. При другия вариант EF изчита таблиците и от тях създава нужните класове, които може да ползваме в обектно ориентираното приложение.
- След като базата данни е създадена, можем да пишем и изпълняваме заявки върху `IQueryable`. Това ни позволява да създадем заявка, която ще бъде превърната в SQL заявка, когато я изпълним. Докато работим с `IQueryable`, не се изпълнява действителната заявка към базата данни – това се случва само когато извикаме метод, който провокира изпълнението, като например `ToList()`, `First()`, `Single()` и други. Това дава възможност да изграждаме сложни и динамични заявки, които се изпълняват оптимално, извличайки само необходимите данни от базата данни.
- EF генерира и изпълнява SQL заявка в базата данни. Трябва да се има предвид, че понякога ако напишем нещо с LINQ, EF не винаги успява да го преведе към SQL. Преди EF 3.1, ако напишем заявка, която EF не знае как да преведе към SQL, без наше знание изтегля цялата таблица в паметта и след това започва да изпълнява LINQ заявката. Реално EF е изпълнявал `SELECT` на всички колони без `WHERE` клауза. Така LINQ заявките ни винаги работят, но на цената на много мрежови, памет и време ресурси. Затова в EF 3.1 MS са решили, ако заявката не се превежда към SQL, да хвърля exception. Докарвайки нашите LINQ заявки до такива, които да може EF да ги преведе към SQL, си гарантираме че приложението ни ще работи много по-бързо. В противен случай, може да имаме сериозни проблеми с производителността.
- След като заявката ни е написана и е преведена към SQL, тя се изпраща към сървъра, изпълнява се и следващата задача на EF е да хване резултата и да го преведе към .NET обект.
- След което, имаме възможност да променим нещо във върнатия обект и да извикаме метода `SaveChanges()`, който ще генерира нов SQL, който да приложи промените в базата данни.

Следвайки тези стъпки, може да извършим всичко с базата данни, без да напишем един ред SQL.
### IQueryable
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
#### Expression
`Expression` е **generic class** в .NET, който представлява дърво на изрази. Той позволява динамично изграждане на изрази, които могат да бъдат превърнати в изпълним код (например SQL заявка). `Expression` се използва основно в LINQ и приема два параметъра: тип на обекта, върху който работи, и тип на резултата от израза.

Пример:

```csharp
Expression<Func<User, bool>> expression = u => u.Age > 18;
```

Тук `Expression<Func<User, bool>>` е generic, където `User` е типът на обекта, а `bool` е типът на резултата.
## Setup
NET първоначално е бил с размер около 200 MB, но с преминаването към .NET Core, MS успяват да намалят този размер до около 20 MB. Това стаwа възможно благодарение на новия модулен подход, при който основната част на платформата (ядрото) е минимална, а допълнителните функционалности се добавят чрез инсталиране на NuGet пакети. Този подход позволява на разработчиците да добавят само необходимите компоненти, което води до по-лек и оптимизиран код. Например, Entity Framework (EF) е отделен като NuGet пакет, вместо да бъде част от основната платформа.

Има два основни начина за използване на NuGet Package Manager:
- Visual Studio – чрез вградената поддръжка за управление на пакети.
- dotnet CLI – трябва да се намираме в директорията, съдържаща project file-а на приложението, и да изпълним следната команда, която ще го модифицира:

```
dotnet add package Microsoft.EntityFrameworkCore
```

Entity Framework (EF) Core е модулен и изисква инсталиране на допълнителни data providers в зависимост от нуждите ни. Трябва да е поне един, но може да инсталираме и няколко, като те няма да си пречат, но за всеки ще трябва да имаме отделен контекст. Например, за работа със SQL Server, трябва да инсталираме следния пакет:

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

За да използваме инструментите на EF, като миграции, Scaffold и други, е необходимо да инсталираме следните пакети и инструменти:

- Инсталиране на **dotnet-ef** като глобален инструмент:

```
dotnet tool install --global dotnet-ef
```

-  Добавяне на пакета **`Microsoft.EntityFrameworkCore.Design`**, който съдържа необходимите зависимости за работа с миграции и други EF инструменти:

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
## Database First Model
При използване на подхода "Database First", съществуваща база данни се преобразува в Entity модел. За целта използваме командата scaffold:

```
dotnet ef dbcontext scaffold "Server=…;Database=…;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

Тази команда създава моделите, които съответстват на таблиците в базата данни, като ги генерира в указаната директория (в този случай Models).

Въпреки че програмистите обикновено не предпочитат този подход, понякога той е необходим и се използва в два основни случая:
- Когато, имаме готова база данни и искаме бързо да се свържем с нея. В този случай, еднократно взимаме базата и генерираме обектно ориентирания модел. След това, преминаваме към подхода "Code First" за бъдещи промени.
- Когато екипът, който поддържа базата данни, прави промените по нея. В този случай, използваме флага **-f** (force), за да обновим модела според последните промени в базата данни.

 Допълнителни опции:
**-f** (force) – обновява модела с последните промени в базата данни.
**-d** указва на **scaffold** да използва data annotation атрибути вместо fluent API. Това е предпочитаният вариант, тъй като атрибутите се поставят директно в класовете, дефиниращи съответните таблици. Fluent API, от друга страна, се използва в **DbContext**, което не е обектно ориентиран подход, тъй като дефинициите за колони трябва да бъдат в класа, към който се отнасят.
**-o** указва директорията, в която ще бъдат генерирани моделите.

```
dotnet ef dbcontext scaffold "…" Microsoft… -o Models -f -d
```

За успешното извършване на scaffold е необходимо да бъдат инсталирани следните NuGet пакети:

- **`Microsoft.EntityFrameworkCore.SqlServer`**
- **`Microsoft.EntityFrameworkCore.Design`**
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
# Bookmarks
Completion: 13.02.2025