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
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250206133252.png)

Чрез този модел, реално не работим с базата данни, навсякъде виждаме само обекти. ORM-а се грижи, всичко което правим в обектно ориентирания модел, да го изпълнява върху релационния. Всичко се превежда към SQL и се изпълнява в базата данни. Идеята е да се map-не обектния и релационния модел, за да работим с обектния в приложението, а базата да се оправя с релационния модел. Така всяка таблица в базата данни, става клас в нашия обектно ориентиран модел и обект, когато се инстанцира.
Трябва да се има предвид и casing-a на имената на колоните, в случая няма конфликт, защото .NET и SQL Server, ползват PascalCase. Други бази данни (като PostgreSQL, MySQL) използват snake_case по подразбиране, което може да доведе до несъответствия.
### Benefits and Problems
Предимства:
- По-малко код.
- Използваме обекти вместо таблици и SQL.
- Интегриран механизъм за писане на заявки. ORM-а прави SQL заявки над средното ниво, на голяма част от програмистите.

Проблеми:
- Не толкова гъвкави, макар че имаме възможност да пишем и Raw SQL, което ни дава същата гъвкавост, която имаме и без ORM.
- Понякога има проблеми с производителността, заради автоматично генерирания SQL, но отново в такъв случай, може да напишем Raw SQL, което ще реши проблема. Често, проблемите идват от забравени индекси и тн, затова е добре да се проверяват как работят заявките периодично и ако има бавни заявки, базата данни предлага инструменти, които логват бавните заявки. Така може да ги прегледаме и ако не може да ги оправим по друг начин, може да пренапишем цялата заявка. 
### Entity Framework Core
Това е универсален ORM, като той може да създава mapping между ООП и базата данни, да отваря връзки, да достъпва данните, да ги модифицира и тн.
Връзките се менажират автоматично, докато при ADO.NET, трябва да ги управляваме ние, но има вариант да се автоматизират и там.

Използва `Connection Pooling`, което означава, че повторно използва вече отворени връзки, вместо да създава нови всеки път, тъй като връзката е скъпа операция. Това намалява времето за изпълнение на заявки, пести ресурси на базата данни и намалява натоварването на мрежата.
Това е едно от предимствата на EF Core, защото се възползва от connection pooling на ADO.NET, без да се налага да го управляваме ръчно.
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
# Bookmarks
Completion: 07.02.2025