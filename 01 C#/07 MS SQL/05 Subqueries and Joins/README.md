# General
## Data from Multiple Tables
Процесът на обединяване на данните, които са разделени в няколко таблици по време на нормализацията, се нарича `JOIN`. Това е механизъм за събиране на данните от няколко таблици на едно място. При изпълнение на `JOIN` получаваме обединената информация от таблиците.
За да може да се прави `JOIN` трябва да имаме релационна база данни и да имаме две таблици, които да може да бъдат свързани помежду си, по някакъв признак.

Основната идея е да се вземат данни от таблица 1 и таблица 2 и чрез определен механизъм да се обединят в таблица 3. Тези таблици условно могат да бъдат наречени Left, Right и Result. Правилото е, че таблицата, която е посочена отляво в заявката (първата, която е дефинирана в кода), се нарича Left,  а другата – Right.

`JOIN` може да работи и без наличието на **Foreign Key**, като той винаги се осъществява между две таблици. Дори когато използваме няколко поредни `JOIN`-а, всеки следващ `JOIN` свързва таблица с резултата от предишните `JOIN`-и, които вече са комбинирани в една обща таблица.
## Types of Joins
### Inner Join
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250114122409.png)

Това е най-често използвания join, защото връща най-малко данни. Връща само тези редове, които отговарят на join условието. Inner join-a  прави сечение между множествата, взима множеството от ляво и множеството от дясно, които са двете таблици и намира сечението между тях. В inner join-a се включват само записите, които фигурират и в лявата и в дясната таблица.

**Syntax:**

```sql
SELECT * FROM Employees AS e
 INNER JOIN Departments AS d
 ON e.DepartmentID = d.DepartmentID
```

`JOIN` по default e `INNER JOIN`, няма значение кое от двете ще напишем.
Третия ред след `ON` е условието - какво трябва да се случи, за да match-нат редовете.
### Outer Join
#### Left
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250114125544.png)

Връщат се същите редове както и при `INNER JOIN`, но се връщат и редове които съществуват само в лявата или дясна таблица, според това дали сме използвали left или right join. Ползва се в случаите, в които ни трябват повече данни - не само сечението на двете множества но и всички данни на една от таблиците. 
Примерно имаме служители и трябва да видим, кой по какви проекти работи, ако направим `INNER JOIN`, няма да разберем ако има някой, който не работи по проект. В този случай, трябва да ползваме `OUTER JOIN`.

**Syntax:**

```sql
SELECT * FROM Employees AS e
 LEFT OUTER JOIN Departments AS d
 ON e.DepartmentID = d.DepartmentID
```

Може да напишем и само `LEFT JOIN`, няма нужда от `OUTER`.
#### Right
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250114133602.png)

Работи по същия начин като `LEFT OUTER JOIN`, но взима всички записи от дясната таблица. Всъщност, ако винаги поставяме таблицата, от която ни трябват всички резултати, вляво, няма да има нужда да използваме `RIGHT JOIN`. Когато заявката вече е написана, е по-лесно просто да сменим например `LEFT` с `RIGHT`. `LEFT` и `RIGHT` `JOIN` са взаимнозаменяеми, ако сменим местата на таблиците.

**Syntax:**

```sql
SELECT * FROM Employees AS e
 RIGHT OUTER JOIN Departments AS d
 ON e.DepartmentID = d.DepartmentID
```
#### Full
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250114135937.png)

Връща редовете от `INNER JOIN`, както и всички останали редове, които не са успели да отговорят на условията.

**Syntax:**

```sql
SELECT * FROM Employees AS e
 FULL JOIN Departments AS d
 ON e.DepartmentID = d.DepartmentID
```
### Cross Join
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020250114142214.png)

`CROSS JOIN` създава картезиански продукт, като комбинира всеки ред от едната таблица с всеки ред от другата. Това води до всички възможни комбинации между двете таблици, независимо от условия за свързване. Получаваме най-много данни и се ползва рядко.

**Syntax:**

```sql
SELECT * FROM Employees AS e
 CROSS JOIN Departments AS d
```
#### Cartesian Product
Това е операция в релационните бази данни, която комбинира всеки ред от една таблица с всеки ред от друга таблица. Той се използва, когато няма зададено условие за свързване (`ON`) между таблиците. Това е имплицитен `CROSS JOIN`.

**Пример**

Ако имаме две таблици:

**Таблица A:**

|ID|Име|
|---|---|
|1|Иван|
|2|Петър|

**Таблица B:**

|Номер|Град|
|---|---|
|10|София|
|20|Пловдив|

**Картезианският продукт на тези таблици ще бъде:**

| ID  | Име   | Номер | Град    |
| --- | ----- | ----- | ------- |
| 1   | Иван  | 10    | София   |
| 1   | Иван  | 20    | Пловдив |
| 2   | Петър | 10    | София   |
| 2   | Петър | 20    | Пловдив |
**Брой резултати:**

Картезианският продукт създава редове, равни на произведението на броя редове в двете таблици. 
Например: Ако таблица A има 2 реда, а таблица B има 3 реда, резултатът ще съдържа 2×3=6 реда.

**Практическо използване:**

Обикновено картезианският продукт не се използва директно, тъй като генерира голям обем ненужни данни.
Най-често се получава случайно, когато при `JOIN` липсва условие за свързване.

**Кога е полезен?**

В редки случаи, когато целта е да се изследват всички възможни комбинации между данни от две таблици (например при статистически анализи).

**Syntax:**

```sql
SELECT *
FROM TableA, TableB;
```
## Subqueries
SQL позволява да влагаме заявки в заявки, по същия начин, както функциите в програмирането могат да връщат стойности за друга функция, така и подзаявките могат да връщат резултати, използвани в главната заявка. Това е полезно за сложни зависимости между таблици или за извличане на данни с динамични условия.

**Syntax:**

```sql
SELECT * FROM Employees AS e
WHERE e.DepartmentID IN
 (
   SELECT d.DepartmentID
   FROM Departments AS d
   WHERE d.Name = 'Finance'
 )
```
## Common Table Expressions (CTE)
CTE е наименувана подзаявка, използвана за подобряване на четимостта и преизползването на код в рамките на дадена SQL заявка или транзакция.

Обикновено се позиционира в началото на заявката, преди основната SELECT инструкция.

**Syntax:**

```sql
WITH Employees_CTE
  (FirstName, LastName, DepartmentName)
AS
(
  SELECT e.FirstName, e.LastName, d.Name
  FROM Employees AS e
  LEFT JOIN Departments AS d ON
  d.DepartmentID = e.DepartmentID
)

SELECT FirstName, LastName, DepartmentName
  FROM Employees_CTE
```
## Temporary Tables
Временните таблици се използват за временно съхранение на данни, които могат да бъдат обработени допълнително. Те се пазят в **`tempdb`**, специална база данни във всеки SQL Server.

**Характеристики:**

 Не се кешират.
 
 Изчезват автоматично, когато вече не са необходими (в зависимост от типа таблица).
 
 Полезни за сложни изчисления, многократна употреба на данни в рамките на заявка или транзакция.
### Types
#### Variable
```sql
DECLARE @t TABLE
```

Променливите в SQL се декларират с `DECLARE` и  се ползва символа `@` след който следва името на променливата и нейния тип.

В примера декларираме променливата `t`, която е от тип таблица. 

Достъпност: Само в текущия скоуп на заявката/процедурата.

Живот: Изчезва, когато променливата излезе от скоуп (например при приключване на процедурата).
#### Local
```sql
CREATE TABLE #t
```

Достъпност: Само за текущата сесия (connection).

Живот: Изчезват автоматично, когато сесията приключи.
#### Global
```sql
CREATE TABLE ##t
```

Достъпност: Видими за всички активни сесии.

Живот: Изчезват, когато всички сесии, които ги използват, бъдат затворени.
#### Tempdb permanent
```sql
USER tempdb
CREATE TABLE t
```

Достъпност: Видими за всички сесии.

Живот: Изчезват при рестартиране на SQL Server.
# Misc
## Caching
Най-бавното нещо в компютъра е хард диска, заради което информацията прочетена от базата данни, се кешира в RAM паметта. Повторното четене минава много бързо. Кешира се най-често ползваната информация. SQL Server използва цялата налична RAM памет, точно поради кеширането на информацията. Този процес ускорява четенето на информацията и приложенията работят много по-бързо.
# ChatGPT
## Subqueries and Derived Tables in SQL
1. **Derived Tables as Temporary Tables:**

- Subqueries in the `FROM` clause act as temporary, unnamed tables used only during query execution.
- Example:

```sql
SELECT *
FROM (
    SELECT DepartmentID, [Name]
    FROM Departments
) AS TempDepartments;
```

2. **Part of the Subquery Mechanism:**

- Subqueries are versatile and can appear in:
- `SELECT` clause (returning values):

```sql
SELECT EmployeeID, 
       (SELECT [Name] FROM Departments WHERE DepartmentID = Employees.DepartmentID) AS DepartmentName
FROM Employees;
```

This query behaves like a `JOIN` because it retrieves data from two related tables (`Employees` and `Departments`) based on a common key (`DepartmentID`). However, there are important differences in how this works compared to an explicit `JOIN`. Use `JOIN` when combining tables whenever possible, as it is generally more efficient and easier to optimize. Use subqueries in specific cases, such as when you need to calculate a scalar value or work with aggregate results for each row.

- `WHERE` clause (filtering results):

```sql
SELECT * FROM Employees
WHERE DepartmentID IN (
    SELECT DepartmentID FROM Departments WHERE ManagerID IS NOT NULL
);
```

3. **Nesting Limits:**

- Databases allow deep nesting (e.g., MySQL up to 64 levels), but excessive nesting can harm performance.
4. **Best Practices:**

- Reduce unnecessary nesting for better performance and readability.
- Use **Common Table Expressions (CTEs)** for clarity:

```sql
WITH TempDepartments AS (
    SELECT DepartmentID, [Name]
    FROM Departments
)
SELECT *
FROM TempDepartments;
```
# Bookmarks
Completion: 15.01.2025