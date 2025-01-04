# General
## Query Basics
### What Are SQL and T-SQL
SQL е декларативен език и е близък до английския език.

Подържа дефинирането, манипулацията и контрола на достъпа до записите.
Почти всичко което е необходимо да направим с базата данни, може да се направи с SQL. 

Transact-SQL (Т-SQL) е версията на Майкрософт за техния SQL Server. 
Всички relational database management systems (RDBMS) имат собствен диалект на SQL, който е създаден с цел решаване на специфични проблеми или да предоставя допълнителна функционалност, която е уникална за съответната система. Голямата част е еднаква и стандартизирана за всички RDBMS.

T-SQL подържа богат набор от ключови думи и оператори, чрез които може да ползваме неща като цикли, условия и тн. Създаден е за да може да пишем логика вътре в базата данни. В края на 90-те е имало разбиране, че най-добрия вариант за създаване на компютърна архитектура е когато бизнес логиката е максимално близко до данните. В резултат на това са се получили трислойни приложения в които програмната част не прави нищо, а е просто интерфейс и цялата бизнес логика е вътре в базата данни. Проблема е че SQL не е най-добрия език за бизнес логика, силата му е в data specific логика, data storage и тн, но не е бизнес език. Поради това, Майкрософт се стараят да направят T-SQL език за бизнес логика. Поддръжката на тези приложения е трудна и трябва да се избягват.
LINQ в C# е опит да се копира SQL, тъй като е много добър в работата с колекции. Чрез LINQ, Microsoft цели да привлече хората работещи с SQL като им предложи нещо познато.
### SQL Examples
```sql
SELECT FirstName, LastName, JobTitle FROM Employees
```

Когато взимаме само част от информацията, без излишните колони се нарича проекция. В примера, взимаме трите посочени колони на всички записи.

```sql
SELECT * FROM Projects WHERE StartDate = '1/1/2006'
```

 Символа * означава че искаме цялата информация. Чрез `WHERE` правим филтрация на записите. В примера, взимаме всички колони на филтрираните записи.

```sql
INSERT INTO Projects(Name, StartDate)
     VALUES ('Introduction to SQL Course', '1/1/2006')
```

Вмъкване данни в базата. Ако ще вмъкваме данни във всички колони, може да пропуснем изреждането им в скобите. Ако сме изредили колоните, трябва в същия ред да подадем данните.

```sql
UPDATE Projects
   SET EndDate = '8/31/2006'
 WHERE StartDate = '1/1/2006'
```

Чрез `UPDATE`, може да променим нещо, което вече е вмъкнато. В примера променяме стойността на `EndDate` колоната в записите, които отговарят на посочения филтър.

```sql
DELETE FROM Projects
      WHERE StartDate = '1/1/2006'
```

Никога не трябва да се трие без `WHERE`, освен ако искаме да изтрием всички записи, но тогава трябва да се ползва `TRUNCATE` защото е много по-бързо, но не може да се използва върху таблици с външни ключове, докато `DELETE` може (стига да се спазят ограниченията). Ако искаме да изтрием цялата таблица, трябва да ползваме `DROP`.
## Retrieving Data Using SELECT
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250102164653.png)

При проекцията, искаме само част от данните на записите - взимаме само колоните / пропъртитата на ентитито, които ни интересуват.

При селекцията взимаме точно определени редове / ентитита.

Може да обединим двете неща и да направим проекция и селекция.
### Relational Databases
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250102170716.png)

Релациите са връзки между таблиците, които ни позволяват да обединим информацията от две таблици с цел да получим пълното описание за обекта, който ни интересува.
Това се прави с цел дедупликация на данните, намаляване на обема от данни в базата. В MSSMS може да създадем диаграми на връзките / релациите между таблиците, като се създават с десен бутон върху `Database Diagrams` папката, вътре в базата данни.
Примерно ако искаме информация за даден служител и в кой отдел работи, в таблицата със служители, го няма името на отдела защото в един и същи отдел работят много хора и няма смисъл името да се дублира за всеки един от тях. Името се заменя с число, което в таблицата с отдели, кореспондира на определено име. Това е част от нормализацията на базите данни.
### Combining Table Data
Чрез `JOIN` комбинираме информацията от две или повече таблици. Когато в две таблици имаме нещо, което е еднакво, може да го използваме за даги свържем.

```sql
SELECT 
FirstName,
LastName,
Salary,
d.[Name]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.ManagerID
```

В примера използваме съкращения (alias) за имената на таблиците, което прави кода по-компактен и лесен за четене. Това е често използвана техника в SQL, особено когато се работи с по-дълги или сложни имена на таблици. `JOIN` комбинира редовете от двете таблици (`Employees` и `Departments`) въз основа на условие, зададено в `ON` частта.
В този случай се съпоставят стойностите на `DepartmentID` от таблицата `Employees` с `DepartmentID` от таблицата `Departments`.
Това означава, че всеки служител, на който `DepartmentID` съвпада в двете таблици, ще получи информация за отдела си.

Ако искаме да комбинираме повече от две таблици, трябва да ги изредим една след друга:

```sql
SELECT 
FirstName,
LastName,
Salary,
d.[Name],
a.[AddressText],
t.[Name]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.ManagerID
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
```
### Column Aliases
Можем да променяме името на колона в резултата от заявката, като използваме псевдоними. Това е полезно, когато искаме да направим имената на колоните по-ясни или да ги форматираме според изискванията на приложението.
### Concatenation Operator
```sql
SELECT 
CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Full Name],
CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name],
FirstName + ' ' + LastName AS [Full Name],
EmployeeID
FROM Employees
```

Може да конкатенираме данните, ползвайки оператора `+`, когато говорим за стрингове или функциите `CONCAT(columnName1, ' ', columnName2)` и `CONCAT_WS(separator, columnName1, columnName2)`. `+` оператора е подходящ за основни операции, но не е най-добрият избор, защото не е гъвкав и често води до грешки, ако една от стойностите е `NULL`. Функцията `CONCAT_WS` е най-подходяща, защото ако има запис без `MiddleName` в примера, няма да вкара вторo празно пространство. 

Всички стрингове в SQL и T-SQL са в единични кавички. В стандарта на SQL имената таблиците и обектите са в двойни кавички, но не е задължително. 
Когато искаме да подадем текст, трябва да е в единични кавички.

Имената, съдържащи специални символи като интервал, служебни думи и т.н., трябва да се слагат в квадратни скоби `[ ]` в SQL Server. В допълнение, могат да се използват и двойни кавички `" "`, ако базата данни ги поддържа и настройката `QUOTED_IDENTIFIER` е активирана (в SQL Server обикновено е включена по подразбиране).
### Filtering the Selected Rows
```sql
SELECT DISTINCT DepartmentID
FROM Employees
```

Чрез ключовата дума `DISTINCT` можем да премахнем дублиращите се стойности в резултата на заявка. Това обаче работи само върху колоните, които са включени в `SELECT`. Ако има уникални стойности в някоя от колоните (например `Id`), `DISTINCT` няма да премахне редове, защото целият запис ще бъде уникален.

Може да филтрираме чрез `WHERE`, като израза след `WHERE` трябва да e предикат. Може да се ползват и логическите оператори `NOT`, `OR`, `AND` и скоби за по-голям контрол:

```sql
SELECT LastName, DepartmentID, Salary
FROM Employees
WHERE NOT (DepartmentID = 1) AND (Salary > 40000 OR Salary = 38500)
```

`BETWEEN` оператора се ползва за да се посочи range, като в този range влизат и посочените стойности:

```sql
SELECT LastName, DepartmentID, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 40000
```

`IN` / `NOT IN` операторите се ползват за филтриране по група от стойности, като това най-често са Id-та:

```sql
SELECT LastName, DepartmentID, Salary
FROM Employees
WHERE ManagerID IN (109, 3, 16)
```
### Comparing with NULL
```sql
-- Incorrect
SELECT LastName, DepartmentID
FROM Employees
WHERE ManagerID = NULL

-- Correct
SELECT LastName, DepartmentID
FROM Employees
WHERE ManagerID IS NULL
```

`NULL` е специална стойност, която означава, че липсва стойност. Различна е от 0 или празно пространство. Не може да се ползва `=` за да проверим дали дадена колона е равна на `NULL` правилния начин е да се ползва `IS`. Ако искаме да вземем само записите които не са `NULL` не може да ползваме знака за различие `<>` защото нямаме сравнение между `NULL`и `NULL`. Правилния начин е `IS NOT NULL`. За останалите сравнения, не може да заменим `=` с `IS`, примерно `WHERE ManagerID IS 1`.
### Sorting Result Sets
```sql
SELECT LastName, DepartmentID, Salary
FROM Employees
WHERE DepartmentID = 1
ORDER BY Salary DESC, LastName DESC
```

Сортирането на редовете става чрез `ORDER BY`, по default е `ASC` ascending order - сортиране във възходящ ред и може да бъде пропуснато. Ако искаме в обратен ред, трябва да се ползва `DESC` descending order. В примера, ако има няколко служителя с еднакви заплати, ще ги подреди по фамилията им. Реално всяка допълнителна колона, която сложим е като `ThenBy` в C# LINQ. `ASC` и `DESC` modifiers се прилагат за всяка колона отделно.
## Views
```sql
CREATE VIEW v_EmployeesByDepartment AS
SELECT FirstName + ' ' + LastName AS [Full Name],
       Salary
  FROM Employees

SELECT * FROM v_EmployeesByDepartment
```

View-тата улесняват, когато имаме сложни заявки. View-то е именувана заявка, която представлява обект в базата данни и позволява да се използва механизма за достъп.

Ако искаме да го изтрием, това става чрез командата `DROP VIEW viewName`
Имаме материализирани view-та, които запазват резултатите от заявката на диска, подобно на таблици. Използват се за ускоряване на сложни заявки, като предварително изчисляват и съхраняват данните, но нямат директна поддръжка в T-SQL.
## Inserting Data
Използваме командата `INSERT`.  Ако ще вкарваме всички данни в дадената таблица, може да не изреждаме колоните:

```sql
INSERT INTO Towns 
     VALUES (33, 'Paris')
```

Ако ще вкарваме данни, само в част от колоните, трябва да ги посочим и след това в същия ред да подадем стойностите:

```sql
INSERT INTO Projects ([Name], StartDate)
     VALUES ('Reflective Jacket', GETDATE())
```

За да вкараме много данни с една заявка, трябва да ги изредим:

```sql
INSERT INTO EmployeesProjects
     VALUES (229, 1),
            (229, 2),
	        (229, 3)
```

Когато имаме съществуваща таблица в която искаме да прехвърлим данни в друга таблица, примерно искаме да прехвърлим само няколко колони в нова таблица, тогава вместо `VALUES`, трябва да направим `SELECT`, който да върне нужните стойности. По този начин, може да прелеем от една таблица в друга:

```sql
INSERT INTO Projects ([Name], StartDate)
	 SELECT [Name] + ' Restructuring', GETDATE()
	   FROM Departments
```

Ако искаме да прехвърлим данните в нова таблица, която искаме да създадем сега, трябва да ползваме конструкцията в примера долу. В този случай, SQL ще създаде нова таблица, гледайки типовете и размерите на изброените колони:

```sql
SELECT CustomerID, FirstName, Email, Phone
  INTO CustomerContacts -- New table name
  FROM Customers -- Existing source
```
## Sequences
```sql
CREATE SEQUENCE seq_Customers_CustomerID
			 AS INT
     START WITH 1
   INCREMENT BY 1

SELECT NEXT VALUE FOR seq_Customers_CustomerID
```

Това са специален обект в SQL Server, който е подобен на `IDENTITY` полетата, с тази разлика, че `IDENTITY` полето е част от самата таблица - специален тип колона с определени свойства, може да генерира поредно число. 

Sequence-a прави същото, но е отделен обект, а не е част от таблицата, може да бъде към някоя таблица, но не е част от нея. При sequence-a има възможност да превърти - като стигне последната стойност, да започне от начало.

В PostgreSQL и Oracle няма `IDENTITY` и там sequence се ползва за идентификаторите. 
Друго приложение на sequence e, че може да се ползва като брояч.
## Modifying Existing Records
### Deleting Data
Ако искаме да изтрием определени редове, се ползва `DELETE` с `WHERE` като обикновено се посочва id-то.

```sql
DELETE FROM Employees WHERE EmployeeID = 1
```

Ако искаме да изтрием всички редове:

```sql
TRUNCATE TABLE Users
```
### Updating Data
```sql
UPDATE Employees
   SET Salary *= 1.10,
       JobTitle = 'Senior ' + JobTitle
 WHERE DepartmentID = 3
```

Казваме коя таблица искаме да update-нем и след това чрез `SET` променяме стойностите в посочените колони.
Много важно е да имаме `WHERE`, защото ще мине и ще промени всички записи, като обикновено се посочва id-то.
# Misc
## IntelliSense
Когато пишем `SELECT` заявки е добре да пишем първо `FROM` и името на таблицата, защото така ще ни подсказва чрез IntelliSense.
# ChatGPT
## Tables as Collection of Objects
When we say that tables are like a collection of objects each record is like an object with different properties (columns) right? when we use `CONCAT_WS()` its like `string.Join()` in C# but `string.Join()` is for all elements in the collection, however `CONCAT_WS()` is used not for all elements, but to concatenate the property values IN EACH element.

**ChatGPT said:**

Yes, that's an excellent analogy! Let's break it down:

**Tables as Arrays of Objects**

- In a **relational table**, you can think of:
    - **Rows** as **objects**.
    - **Columns** as **properties** of those objects.

For example, consider this table:

|FirstName|LastName|Age|
|---|---|---|
|John|Doe|30|
|Jane|Smith|25|

This is conceptually similar to an array of objects in C#:

```csharp
var people = new[]
{
    new { FirstName = "John", LastName = "Doe", Age = 30 },
    new { FirstName = "Jane", LastName = "Smith", Age = 25 }
};
```

`STRING.JOIN` in C#

- **Purpose**: Combines all elements of a collection into a single string, separated by a specified delimiter.
- **Scope**: Operates on the entire collection.

Example:

```csharp
var names = new[] { "John", "Jane", "Smith" };
var result = string.Join(", ", names); // "John, Jane, Smith"
```

`CONCAT_WS` in SQL

- **Purpose**: Concatenates multiple columns (or expressions) within a **single row** into one string, separated by a specified delimiter.
- **Scope**: Operates on the properties (columns) of each individual row.

Example:

```sql
SELECT CONCAT_WS(', ', FirstName, LastName) AS FullName
FROM Employees;
```

With this table:

|FirstName|LastName|
|---|---|
|John|Doe|
|Jane|Smith|

The result would be:

|FullName|
|---|
|John, Doe|
|Jane, Smith|

**Key Difference**

1. **`STRING.JOIN` (C#)**:
    
    - Joins the elements of a collection (all rows or values from multiple rows).
    - Operates at the **collection level**.
2. **`CONCAT_WS` (SQL)**:
    
    - Joins the values of specific columns (or expressions) within a **single row**.
    - Operates at the **row level**.

**Combined Analogy**

If a table is like an array of objects, then:

- **`STRING.JOIN`**: Joins multiple objects' properties across all rows.
- **`CONCAT_WS`**: Joins the properties **within each individual object** (row).
# Bookmarks
Completion: 03.01.2025