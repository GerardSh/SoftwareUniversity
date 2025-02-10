# General
## ADO.NET
ADO.NET е основната технология на Microsoft за достъп до данни в .NET, която осигурява взаимодействие с различни източници на данни, включително релационни бази данни, XML файлове и други. Тя служи като основа за Entity Framework (EF), който добавя допълнително ниво на абстракция, улеснявайки работата с данни чрез ORM (Object-Relational Mapping).

Основни характеристики на ADO.NET:

1. **Различни Data Providers** – Включва различни доставчици (providers), като например:
    
    - `Microsoft.Data.SqlClient` – За работа с Microsoft SQL Server.
    - `System.Data.OleDb` – За достъп до бази чрез OLE DB.
    - `System.Data.Odbc` – За използване на ODBC драйвери.
    - `Npgsql` – За PostgreSQL.
    - `MySql.Data` – За MySQL.
2. **Два основни модела на работа**:
    
    - **Connected Model** – Работи директно с базата данни чрез `SqlConnection`, `SqlCommand` и `SqlDataReader`, като поддържа активна връзка.
    - **Disconnected Model** – Използва `DataSet`, `DataTable` и `DataAdapter`, което позволява работа с данни офлайн и кеширане на резултати.
3. **Поддръжка на LINQ** – Позволява използване на LINQ за заявки към данните чрез `LINQ to DataSet`, `LINQ to SQL` и Entity Framework. LINQ е много мощен инструмент, за работа с всякакви колекции. Базата данни е колекция от таблици, които са колекция от редове, които са колекция от колони, където се намират данните.
    
4. **Изпълнение на SQL заявки** – Позволява директно изпълнение на SQL команди за четене, писане и модифициране на данни в RDBMS системи.
    
5. **Възможност за ORM функционалност** – Въпреки че ADO.NET сам по себе си не е ORM, той е основата за Entity Framework, който автоматизира работата с обекти и релационни структури.

ADO.NET продължава да бъде важен инструмент в .NET екосистемата, особено за приложения, които изискват висока производителност и контрол върху изпълнението на SQL команди.
### Data Providers
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250206130846.png)

Това са колекция от класове, които дават достъп до различни бази данни. За различните RDBMS системи, трябват различни providers. Служат като мост между ADO.NET и съответната база данни. Чрез различни Data Providers може да се работи с разнообразни източници на данни като **Excel**, **XML**, **SharePoint** и други.

Всеки Data Provider, трябва да имплементира определен интерфейс, като има неща, които са общи за всички:
- **Connection** - за връзка към базата данни. Това е една от най-скъпите операции, като се отразява и на бързодействието на приложението ни. Параметрите и правилното менажиране на връзката, са изключително важни.
- **Command** - това е SQL команда, която може да се изпълни върху базата към която сме се свързали, чрез дадения `Connection`.
- **DataReader**  - служи за извличане на данни от базата.

Няколко стандартни Data Providers се разпространяват като част от .NET Framework:
- **SqlClient**  - клиента, който работи с SQL Server.
- **OleDB**  - стандарт за OLE DB data sources.
- **Odbc** - стандарт за ODBC data sources.
- **Oracle** - достъпва Oracle databases.

Имаме third party Data Providers за `MySQL`, `PostgreSQL`, `Interbase`, `DB2`, `SQLite`. Има и други като `SQL Azure`, `Salesforce` `CRM`, `Amazon SimpleDB` и други.
## SqlClient and ADO.NET Connected Model
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250206131541.png)
## ORM (Object-Relational Mapping)
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250207112219.png)
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250206133252.png)

Чрез този модел, реално не работим с базата данни, навсякъде виждаме само обекти. ORM-а се грижи, всичко което правим в обектно ориентирания модел, да го изпълнява върху релационния. Всичко се превежда към SQL и се изпълнява в базата данни. Идеята е да се map-не обектния и релационния модел, за да работим с обектния в приложението, а базата да се оправя с релационния модел. Така всяка таблица в базата данни, става клас в нашия обектно ориентиран модел и обект, когато се инстанцира.
Трябва да се има предвид и casing-a на имената на колоните, в случая няма конфликт, защото .NET и SQL Server, ползват PascalCase. Други бази данни (като PostgreSQL, MySQL) използват snake_case по подразбиране, което може да доведе до несъответствия.
### Benefits and Problems
Предимства:
- По-малко код, повече продуктивност.
- Използваме обекти вместо таблици и SQL, чрез абстракция. Тази абстракция позволява лесната подмяна на базата данни.
- Интегриран механизъм за писане на заявки. ORM-а прави SQL заявки над средното ниво, на голяма част от програмистите.
- По-лесно управление, когато става въпрос за сложни връзки - примерно вкарва записи в правилния ред, като се съобразява с Foreign Key constraints.
- По-лесна поддръжка.

Проблеми:
- Не толкова гъвкави, макар че имаме възможност да пишем и Raw SQL, което ни дава същата гъвкавост, която имаме и без ORM.
- Понякога има проблеми с производителността, заради автоматично генерирания SQL, но отново в такъв случай, може да напишем Raw SQL, което ще реши проблема. Често, проблемите идват от забравени индекси и тн, затова е добре да се проверяват как работят заявките периодично и ако има бавни заявки, базата данни предлага инструменти, които логват бавните заявки. Така може да ги прегледаме и ако не може да ги оправим по друг начин, може да пренапишем цялата заявка. 
### Entity Framework Core
Това е универсален ORM, като той може да създава mapping между ООП и базата данни, да отваря връзки, да достъпва данните, да ги модифицира и тн.
Връзките се менажират автоматично, докато при ADO.NET, трябва да ги управляваме ние, но има вариант да се автоматизират и там.

Използва `Connection Pooling`, което означава, че повторно използва вече отворени връзки, вместо да създава нови всеки път, тъй като връзката е скъпа операция. Това намалява времето за изпълнение на заявки, пести ресурси на базата данни и намалява натоварването на мрежата.
Това е едно от предимствата на EF Core, защото се възползва от connection pooling на ADO.NET, без да се налага да го управляваме ръчно.

Поддържа и двата варианта на работа:
- **Database First** – започваме с вече съществуващи таблици, а ORM-a генерира съответните класове.
- **Code First** – първо дефинираме класовете, след което ORM-a създава таблици въз основа на тях.
### ORM Features
ORM-ите предлагат определени функции, една от които е автоматичното генериране на SQL:

```csharp
database.Employees.Add(new Employee
{
	 FirstName = "George",
	 LastName = "Peterson",
	 IsEmployed = true });
```

ORM-а ще генерира:

```sql
INSERT INTO Employees
(FirstName, LastName, IsEmployed)
VALUES
('George '
,
'Peterson', 1)
```

- ORM-a може да генерира обектния модел, като анализира схемата на базата данни - (**DB First model**)
- Може да направи и обратното, ако имаме създаден обектен модел, ORM-a може да създаде базата по него - (**Code First model**)
- Можем да правим заявки върху обектно ориентирания модел, ORM-а я обръща в SQL и я изпраща към базата. Получавайки отговора от базата, ORM-а го map-ва към обектите в обектно ориентирания модел и получаваме обект - (**e.g., LINQ queries**)
### Entity Classes - Data Holders
Това са нормални C# класове.

Когато извличаме данни от базата данни, нашето приложение ги съхранява в паметта. Колкото повече информация дърпаме от базата, толкова повече нараства консумацията на паметта. Поради това се опитваме да дърпаме по-малко информация - когато е възможно правим проекции, слагаме `WHERE` клаузи, ограничаваме информацията, само до тази, която ни е необходима. Това се отразява не само на паметта, но и на мрежовото натоварване, като така печелим по-голяма производителност и скорост. 
Реално може да дръпнем цялата информация от базата и да вземем само това, което ни трябва, игнорирайки останалото, но това е много лоша практика, заради изброените причини.
#### Navigation Properties
По конвенция, EF ще направи `PRIMARY KEY`, всяка една колона, която кръстим `Id`. Все пак е желателно нещата да са експлицитни и затова е добре `PRIMARY KEY` да се отбележи с атрибут `[KEY]`.

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }  // Foreign Key (FK)
    public Department Department { get; set; }  // Навигационно пропърти (Many-to-One)
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // Навигационно пропърти (One-to-Many)
}
```

При `FOREIGN KEY`, се ползват navigation properties. Примерно ако имаме SQL таблица `Employees` с колона `DepartmentId`, която е `FK`, трябва да направим освен нормалното `int` property `public int DepartmentId { get; set; }` то и navigation property-то `public Department Department { get; set; }`. В случая `Department` е инстанция на класа `Department`, който отразява таблицата `Departments` в базата.
Води се навигационно пропърти, защото ни позволява през него, да отидем в следващата таблица и да прочетем данните от таблица `Department`. Чрез това пропърти, EF ще направи `JOIN` на двете таблици и ще попълни и `Employee` и `Department` обекта с информацията от `Department`.  В обекта `Department` ще имаме само информацията за департамента с посочения номер в `DepartmentId`.
Реално `FK` е `DepartmentId`, а navigation property-то е `Department`.

Навигационните пропъртита може да са колекции. Например, в класа `Department` можем да имаме колекция `Employees`, защото един департамент може да има много служители. Това съответства на релацията **One-to-Many** между таблиците.

Въпреки че в класа `Department` нямаме изрично дефинирано `FK` пропърти, Entity Framework ще разпознае връзката, като открие `DepartmentId` в класа `Employee`. По този начин EF ще знае кои служители да включи в колекцията `Employees` за съответния департамент. Това ще работи коректно, ако пропъртитата са наименувани правилно.

Обикновено типа на пропъртито е `ICollection<T>`

Всяка релация в базата данни е navigation property в нашия обектно ориентиран модел.
### `DbSet<T>`
Специален тип колекция, която е направена само за работа с базата данни. Това е обектно ориентирания вариант на таблицата в базата данни, където `<T>` е типа на entity-to.
Entity класовете са единичен запис - един entity клас е един ред от таблицата, докато `DbSet<T>` е обект, който е самата таблица.

`DbSet<T>` е generic collection с допълнителни свойства.

Всеки `DbSet<T>` отговаря точно на една таблица в базата данни.

Наследява от `ICollection<T>` както и `IEnumerable` - може да бъде foreach-нат.

Подържа LINQ операции.

Обикновено няколко `DbSet` са част от `DbContext`.
- Най-ниското ниво в базата данни е колоната, която съдържа единична стойност. В нашия обектно-ориентиран модел, това е съответстващо на пропърти в ентити класовете.
- Следващото ниво е редът, който съдържа колекция от колони, и това отговаря на нашите ентити класове. Всеки ред в таблицата е представен като един обект от клас.
- След това е `DbSet`, който е колекция от редове и отговаря на една таблица в базата данни. `DbSet` представлява таблица и позволява CRUD операции върху нея.
- Колекцията от няколко `DbSet` са част от `DbContext`, който е репрезентацията на базата данни в обектно-ориентирания модел. В `DbContext` се управляват всички таблици (чрез `DbSet`), както и логиката за тяхното взаимодействие с базата данни.

В обобщение, `DbSet<T>` е основният механизъм, чрез който Entity Framework работи с таблиците в базата данни, предоставяйки обектно-ориентиран интерфейс за манипулиране на данните, които се съхраняват в релационните таблици.
#### Features
##### Change Tracker
Всяка таблица си следи редовете, ако възникне промяна, таблицата ще разбере, използвайки Change Tracker. 
Change Tracker следи обектите, които сме заредили в паметта чрез `DbContext`, и ако направим промени в тях, той ги запомня и при `SaveChanges()` ги пренася в базата данни. Ако са добавени редове, когато запазим промените, ще бъдат генерирани `INSERT` заявки за да ги запишат в базата, ако променяме данни, ще бъдат генерирани `UPDATE` заявки. При изтриване, ще бъде генерирана `DELETE` заявка.
Чрез този механизъм, можем да проверим кои стойности са променени преди `SaveChanges()`, което ни позволява да валидираме промяната. Вместо да проверява всички данни, EF анализира само промените и генерира съответните SQL заявки.
##### `ICollection<T>`
Има всички свойства на `ICollection<T>`:
- Достъп до отделните елементи, ползвайки LINQ.
- Добавяне / промяна на елементи.
- Изтриване на ентитита.
- Проверка дали даден елемент съществува.
- Проверка на броя елементи.
# Misc
# ChatGPT
## SQL Tables as Both Objects and Collections From OOP Perspective
In SQL, a table serves a dual role that can be conceptually compared to how objects and collections work in OOP:

1. **Table as a Collection:**  
    A SQL table contains multiple rows. In an OOP language like C#, you can think of the table as a collection (like a list, array, or any enumerable collection) where each element in the collection is an individual record.
    
2. **Row as an Object:**  
    Each row in the table represents a record and is analogous to an object in C#. The columns in the table correspond to the properties or fields of that object. For example, if you have a `Users` table with columns `UserID`, `UserName`, and `Email`, you might map that to a C# class:
    
```csharp
public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
```
    
    In this analogy, each row in the `Users` table is like an instance of the `User` class.
    
3. **Schema as a Blueprint:**  
    The structure (schema) of the table—its column definitions, data types, constraints, etc.—acts like a blueprint for the objects. When you design a table, you're defining what properties each object (row) will have and how the data is structured.
    
4. **Collections in OOP:**  
    When you fetch data from a table, you typically load the rows into a collection, such as a `List<User>` in C#. This collection holds all the objects that represent the records from your SQL table:
    
```csharp
List<User> users = GetUsersFromDatabase(); // Imagine this method fills a list with User objects
```
    
5. **ORM Mapping:**  
    Tools like Entity Framework further blur the line by automatically mapping SQL tables to classes and rows to object instances. This means that you can work with your data as if they were regular C# objects without manually writing the code to convert between rows and objects.

**Summary**

- **SQL Table:**
    
    - **Collection of Records:** Each table is a container holding multiple rows.
    - **Schema Definition:** It defines the structure (columns, data types) that each record must follow.
- **C# Objects and Collections:**
    
    - **Row as an Object:** Each row can be mapped to a class instance.
    - **Table as a Collection:** The set of rows can be represented as a collection of these objects (e.g., a `List<T>`).

In SQL, a table serves as both the blueprint for a single record (analogous to an object in C#) and as a collection that holds multiple such records. Each row represents an instance of that blueprint, similar to an object with properties defined by the table's columns. When you retrieve data, you can map these rows to objects and even store them in a collection like a `List<T>` in C#. This analogy helps bridge the gap between relational database design and object-oriented programming, making it easier to conceptualize how data is structured and manipulated across both paradigms.
## Entity Framework and SQL Server: Mapping Tables to Classes and DbContext
In SQL Server, you can think of it this way:

- **A column** represents a **property** of a class (like a field in an object).
- **A row** represents an **instance of a class** (an object with values for each property).
- **A collection of rows (the entire table)** represents a **DbSet** in Entity Framework, which is a collection of instances of a class.
- **The database** represents the **DbContext**, which manages multiple `DbSets` and provides a session for querying and saving changes.

So, in object-oriented terms:

- A **table** is like a **class definition** (but also acts as a collection of objects).
- A **row** is an **instance of that class** (an object).
- A **column** is a **property** of that object.
- A **`DbSet<T>`** represents a **table**, allowing you to query and manipulate rows as objects.
- The **DbContext** acts as the **unit of work**, managing the connection to the database, tracking changes, and persisting them when `SaveChanges()` is called.

This is why ORM tools like Entity Framework map database tables to C# classes—because the structure is quite similar!
## ORM
The **primary idea of an ORM** is to **abstract away SQL** so that developers can focus on **object-oriented programming (OOP)** instead of writing raw SQL queries.

**Key Benefits of Using an ORM**

✅ **Less SQL, More OOP**

- Instead of writing SQL queries, we interact with **objects and collections** in our programming language.
- Example in **Entity Framework (C#):**

```csharp
var users = dbContext.Users.Where(u => u.IsActive).ToList();
```

🔹 No need to write `SELECT * FROM Users WHERE IsActive = 1;` manually.

✅ **Less SQL Knowledge Required**

- Developers **don’t need deep SQL expertise** because the ORM generates the necessary SQL behind the scenes.

✅ **Automatic Query Generation**

- ORMs optimize and generate **parameterized queries**, reducing security risks like SQL injection.

✅ **Database Independence**

- ORMs allow switching between databases **without rewriting queries** (e.g., from SQL Server to PostgreSQL).

✅ **Relationships as Object Associations**

- Instead of handling **JOINs manually**, ORMs handle **navigation properties** between tables.

**When SQL Knowledge Is Still Useful**

Even though ORM reduces the need for SQL, some **SQL knowledge is still useful**:  
🔹 **Performance Optimization** – Understanding indexes, execution plans, and query optimization.  
🔹 **Complex Queries** – ORM struggles with very complex queries involving multiple `JOIN`s and aggregations.  
🔹 **Debugging** – Knowing SQL helps when ORM-generated queries perform poorly.

**Conclusion**

Yes, ORMs **reduce the need for SQL** knowledge because they handle database operations internally. However, understanding **basic SQL** is still valuable for debugging, performance tuning, and handling edge cases. 🚀
## ORM and ADO.NET Relation
ORM (Object-Relational Mapping) and ADO.NET are closely related in that ORM frameworks are typically built on top of ADO.NET to simplify data access in .NET applications. Here’s how they relate:

1. **Underlying Data Access**
    
    - **ADO.NET** provides the low-level classes and infrastructure (such as connections, commands, data readers, and data adapters) for interacting with relational databases.
    - **ORM frameworks** (like Entity Framework) leverage ADO.NET under the hood to execute SQL commands, manage connections, and retrieve data. They abstract these low-level operations, allowing developers to work with higher-level objects instead of raw SQL.
2. **Abstraction Layer**
    
    - **ADO.NET** requires developers to manually handle SQL queries, parameterization, and mapping data rows to objects.
    - **ORM** automates much of this work by mapping database tables to classes and rows to object instances. This abstraction means you can focus on object-oriented programming rather than database-specific details.
3. **Productivity and Maintainability**
    
    - With **ADO.NET**, you write and maintain SQL code along with the data access code.
    - With an **ORM**, you work with LINQ queries and other high-level constructs, which can improve productivity and make the code more maintainable. The ORM translates these queries into the necessary SQL behind the scenes.
4. **Performance Considerations**
    
    - **ADO.NET** offers fine-grained control over SQL execution and is ideal for performance-critical sections where custom optimizations are required.
    - **ORMs** generally cover most CRUD operations and common queries. However, if advanced or highly optimized queries are needed, you can often fall back to raw SQL even when using an ORM.

**Summary**

- **ADO.NET** is the foundational technology for data access in .NET, handling the direct interaction with the database.
- **ORMs** use ADO.NET internally to map database data to objects, allowing you to work with a higher-level, object-oriented approach rather than writing raw SQL.

In essence, ORM is an abstraction built upon ADO.NET, streamlining database operations and enabling developers to focus on their application’s business logic.

**You said:**

Why not use ADO.NET directly?

**ChatGPT said:**

Using ADO.NET directly gives you fine-grained control over every aspect of database interaction, but it comes with several drawbacks compared to using an ORM:

- **Verbosity and Manual Mapping:**  
    With ADO.NET, you must write extensive boilerplate code to open connections, construct SQL queries, execute commands, and manually map the resulting data rows to your object models. This manual process is more error-prone and time-consuming than the automated mapping that ORMs provide.  

- **Maintainability:**  
    Since raw ADO.NET requires you to maintain both the SQL code and the object mapping logic, any changes in the database schema demand corresponding updates in your code. ORMs like Entity Framework handle these changes more seamlessly by automatically updating mappings based on your domain models.  

- **Productivity and Abstraction:**  
    ORMs abstract much of the low-level details of data access. This allows developers to work at a higher level—focusing on the domain objects and business logic rather than SQL. Features such as LINQ integration, change tracking, and lazy loading help speed up development and reduce the likelihood of bugs.  

- **Security Considerations:**  
    Although ADO.NET can be used securely with parameterized queries, ORMs automatically incorporate many security best practices (like preventing SQL injection) into their generated SQL. This reduces the risk of mistakes that might occur with manual query construction.

**Key Difference in Abstraction**

✔ **ADO.NET**

- **ADO.NET does not abstract SQL away**—it simply provides a structured way to integrate SQL into a .NET application using **connections, commands, readers, and adapters**, but the SQL logic is **your responsibility**.

✔ **ORM (e.g., Entity Framework)**

- It **does** abstract SQL away in most cases, by generating queries automatically, mapping results to objects, and letting you work with objects and LINQ instead of raw SQL.
- It **generates SQL for you** behind the scenes, meaning you don't need deep SQL knowledge for basic operations.

In other words - both ADO.NET and ORMs aim to enable object-oriented programming (OOP). However, using raw ADO.NET requires significantly more effort because you must manually:

1. **Write SQL queries**
2. **Open and manage connections**
3. **Execute commands**
4. **Handle transactions**
5. **Map results to objects**

ORMs like Entity Framework automate most of this, allowing developers to work with objects directly without worrying about SQL syntax and database operations. This makes ORMs more efficient and developer-friendly, though they introduce some performance overhead compared to raw ADO.NET.

In summary, while ADO.NET provides maximum control and might be slightly more performant in very specific, optimized scenarios, the advantages in developer productivity, maintainability, and abstraction make ORMs the preferred choice for most applications.
## Understanding the Backend Data Processing Workflow
The main idea of the **backend** part of a web application revolves around:

1. **Retrieving data** from the database.
2. **Processing** that data in memory.
3. **Saving the results** back to the database.

This process relies on **various collections** and **data structures** that are optimized to perform the task efficiently.

**What does this process involve?**

1. **Retrieving data from the database:**
    
    - **SQL queries** are used to access data from tables and relationships between them.
    - **ORM (Object-Relational Mapping)** technologies like **Entity Framework** are used to map data from the relational format into objects (or classes) that can be processed in memory.
2. **Processing data in memory:**
    
    - Once the data is retrieved, it can be **manipulated**, **filtered**, **sorted**, **grouped**, and **modified** using various data structures (like Lists (`List<T>`), Sets (`HashSet<T>`), Dictionaries (`Dictionary<T1, T2>`), Collections (`ICollection<T>`)).
    - For example, if we want to get a list of all employees in a specific department, we might use `ICollection<Employee>` or` List<Employee>` in memory to work with the data.
3. **Saving data back to the database:**
    
    - After processing the data, the modified results can be saved back to the database using **insert, update, or delete** SQL commands.
    - ORM typically handles generating the corresponding SQL queries based on changes to the objects.

**What is the main focus of backend programming?**

**Optimizing these processes** is the main focus of backend development because:

- **Quick data retrieval** from the database and **fast processing** in memory is crucial for application performance.
- **Using the right data structures** and **optimizing queries** is essential for **system efficiency**.
- **Scalability** is also a key factor – backend applications need to handle large volumes of data and perform efficiently under increased load.

This explains why **collections** and **data structures** are so important in the data processing pipeline and why backend programming involves so much interaction with them. 🎯
# Bookmarks
Completion: 11.02.2025