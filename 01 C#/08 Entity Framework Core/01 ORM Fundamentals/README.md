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
    
    - **Connected Model** – Работи директно с базата данни чрез `SqlCo# General
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
![](Pasted%20image%2020250206130846.png)

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
![](Pasted%20image%2020250206131541.png)
## ORM (Object-Relational Mapping)
![](Pasted%20image%2020250206133252.png)

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
# Bookmarks
Completion: 07.02.2025nnection`, `SqlCommand` и `SqlDataReader`, като поддържа активна връзка.
    - **Disconnected Model** – Използва `DataSet`, `DataTable` и `DataAdapter`, което позволява работа с данни офлайн и кеширане на резултати.
3. **Поддръжка на LINQ** – Позволява използване на LINQ за заявки към данните чрез `LINQ to DataSet`, `LINQ to SQL` и Entity Framework. LINQ е много мощен инструмент, за работа с всякакви колекции. Базата данни е колекция от таблици, които са колекция от редове, които са колекция от колони, където се намират данните.
    
4. **Изпълнение на SQL заявки** – Позволява директно изпълнение на SQL команди за четене, писане и модифициране на данни в RDBMS системи.
    
5. **Възможност за ORM функционалност** – Въпреки че ADO.NET сам по себе си не е ORM, той е основата за Entity Framework, който автоматизира работата с обекти и релационни структури.

ADO.NET продължава да бъде важен инструмент в .NET екосистемата, особено за приложения, които изискват висока производителност и контрол върху изпълнението на SQL команди.
### Data Providers
Това са колекция от класове, които дават достъп до различни бази данни. За различните RDBMS системи, трябват различни providers. Служат като мост между ADO.NET и съответната база данни.

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
# Misc
# ChatGPT
# Bookmarks
Completion: 06.02.2025