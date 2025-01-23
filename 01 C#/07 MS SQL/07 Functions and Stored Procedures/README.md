# General
## User-Defined Functions
В основната си дефиниция, функцията е блок от код, който приема входни данни (_input_), обработва ги, и връща резултат (_output_).
### Scalar functions
Скаларните функции връщат единична стойност (`INT`, `VARCHAR`, `DECIMAL` и т.н.) като резултат. Те се използват обикновено за изчисления или трансформации върху входните параметри. Могат да се извикват директно в `SELECT`, `WHERE`, `ORDER BY` и други.

**Syntax:**

```sql
CREATE FUNCTION udf_ProjectDurationWeeks (@StartDate DATETIME,
@EndDate DATETIME)
RETURNS INT
AS
BEGIN
 DECLARE @projectWeeks INT;
 IF(@EndDate IS NULL)
 BEGIN
 SET @EndDate = GETDATE()
 END
 SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
 RETURN @projectWeeks;
END
```

Когато правим наши функции, имената им трябва да започват с `udf_` (user defined function), след което самото име е PascalCase.

Първо се изписва името на параметъра, след което неговия тип.

След това следва типа на стойността за връщане, като няма `void`, ако искаме да не връща нищо, трябва да се направи процедура.

Имената на променливите започват с `@`.

Понеже нямаме разграничение кое е параметър и кое е променлива вътре в самата функция, конвенцията е че параметрите се изписват с PascalCase а променливите с camelCase.

Добавянето на променлива става с ключовата дума `DECLARE`. Когато искаме да запишем стойност в променливата, трябва да използваме `SET`.

`BEGIN` и `END` са нещо като отваряща и затваряща скоба за тялото на метода. Желателно е да се ползва и в `IF` конструкция. При `IF` също трябва да се ползва `IS` ако проверяваме за `NULL`. 

Накрая връщаме резултата с `RETURN`, като типа трябва да съвпада с този който сме посочили в началото.

Тези функции се създават в "Programmability -> Functions -> Scalar-valued Functions / Table-valued Functions".

Викат се заедно със схемата в която се намират.
### Table-valued functions
#### Inline table-valued functions (TVF)
Връщат цяла таблица като резултат от един `SELECT`. Подобни са на view-тата но с параметри. Използва се за изпълнение на сравнително проста логика с параметри, които връщат набор от данни.

**Syntax:**

```sql
CREATE FUNCTION udf_AverageSalaryByDepartment()
RETURNS TABLE AS
RETURN
(
SELECT d.[Name] AS Department, AVG(e.Salary) AS AverageSalary
FROM Departments AS d
JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID, d.[Name]
)
```
#### Multi-statement table-valued functions (MSTVF)
Позволяват извършването на няколко SQL заявки (statement-и) в тялото на функцията, преди да се върне резултатът под формата на таблица. Те се използват, когато искаме да изпълним по-сложни операции, като например обединения на таблици, групиране, филтриране или агрегиране, и накрая да върнем набор от резултати (таблица), вместо само една стойност.
Тези функции са мощни за случаи, когато искаме да връщаме структури от данни, които ще се използват по-късно в други SQL заявки, като например в `JOIN`, `SELECT` или други изрази.

**Syntax:**

```sql
CREATE FUNCTION udf_EmployeeListByDepartment(@DepName nvarchar(20))
RETURNS @result TABLE(
 FirstName nvarchar(50) NOT NULL,
 LastName nvarchar(50) NOT NULL,
 DepartmentName nvarchar(20) NOT NULL) AS
BEGIN
 WITH Employees_CTE (FirstName, LastName, DepartmentName)
 AS(
 SELECT e.FirstName, e.LastName, d.[Name]
 FROM Employees AS e
 LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID)
 INSERT INTO @result SELECT FirstName, LastName, DepartmentName
 FROM Employees_CTE WHERE DepartmentName = @DepName
 RETURN
END
```
### Limitations
SQL сървър прави голяма разлика между функции и процедури.

User-defined функциите не могат да се ползват за модифициране на базата данни, но са изцяло за четене.

Не могат да връщат повече от един сет данни.

Не може да се ползва динамичен SQL (генериране на заявки в нашите заявки) и временни таблици, но може да се ползват table variables.

Не може да се влагат повече от 32 функции една в друга.

Error handling-a е ограничен и не може да се ползва `TRY CATCH`, `@ERROR` or `RAISERROR`.
### Execute Functions
Функциите се извикват използвайки `schemaName.functionName`.

**Syntax:**

```sql
SELECT [ProjectID],
 [StartDate],
 [EndDate],
 dbo.udf_ProjectDurationWeeks([StartDate],[EndDate])
 AS ProjectWeeks
 FROM [SoftUni].[dbo].[Projects]
```
## Stored Procedures
Съхранените процедури са мощен инструмент в базите данни, който комбинира повторно използваема логика и оптимизирано изпълнение. Нека добавим повече яснота и примери:

**Характеристики на съхранените процедури**

1. **Програмен код**: Съдържат `T-SQL` инструкции, които могат да включват цикли, проверки и дори динамични заявки.
2. **Параметри**:
    - **Input параметри**: Позволяват подаване на данни към процедурата.
    - **Output параметри**: Позволяват връщане на данни към извикващата програма.
3. **Енкапсулация**: Логиката е отделена в процедурата, което я прави лесна за поддръжка.
4. **Възможност за промяна на състоянието**: Могат да извършват операции като вмъкване, актуализация или изтриване на данни.

**Ползи от съхранените процедури**

1. **Повторно използване на код**: Един път написана, процедурата може да се извиква многократно.
2. **Подобрена производителност**:
    - Предварително компилирани и оптимизирани от SQL Server.
    - Намаляват мрежовия трафик, като се изпращат само параметрите, а не цялата заявка.
3. **Сигурност**: Позволяват ограничаване на достъпа до данни, като се предоставят само чрез контролирани точки (процедури).
### User-defined
Може да се създават във всички бази данни, освен системната Resource.

Може да се създават чрез Transact-SQL или като референция чрез .NET Framework method.

Имаме и временни процедури, които се съхраняват в `tempdb`.
### Creating and Executing
**Syntax:**

```sql
CREATE PROC dbo.usp_SelectEmployeesBySeniority
AS
 SELECT *
 FROM Employees
 WHERE DATEDIFF(Year, HireDate, GETDATE()) > 20
```

Не е задължително да се пише схемата в името, като конвенцията е да се добавя `usp_`.

Ако искаме да променим съществуваща процедура, трябва да се ползва `CREATE OR ALTER PROCEDURE`.

```sql
-- Executing a stored procedure by EXEC
EXEC usp_SelectEmployeesBySeniority

-- Executing a stored procedure within an INSERT statement
INSERT INTO Customers
EXEC usp_SelectEmployeesBySeniority
```
### Altering
**Syntax:**

```sql
ALTER PROC usp_SelectEmployeesBySeniority
-- If we are not sure that the procedures exists, we can use:
-- CREATE OR ALTER PROCEDURE usp_SelectEmployeesBySeniority
AS
 SELECT FirstName, LastName, HireDate,
 DATEDIFF(Year, HireDate, GETDATE()) as Years
 FROM Employees
 WHERE DATEDIFF(Year, HireDate, GETDATE()) > 20
 ORDER BY HireDate
```
### Dropping
**Syntax:**

```sql
DROP PROC usp_SelectEmployeesBySeniority
```

Може да проверим дали някой обект зависи от съхранените процедури:

```sql
EXEC sp_depends 'usp_SelectEmployeesBySeniority'
```
### With Parameters
Скобите не са задължителни, когато дефинираме параметрите.

**Syntax:**

```sql
CREATE PROCEDURE usp_ProcedureName
(@parameter1Name parameterType,
 @parameter2Name parameterType,…) AS
```

Може да слагаме и default стойности:

```sql
CREATE PROC
usp_SelectEmployeesBySeniority(
 @minYearsAtWork int = 5) AS
```

**Example:**

```sql
CREATE PROC usp_SelectEmployeesBySeniority
(@minYearsAtWork int = 5)
AS
 SELECT FirstName, LastName, HireDate,
 DATEDIFF(Year, HireDate, GETDATE()) as Years
 FROM Employees
 WHERE DATEDIFF(Year, HireDate, GETDATE()) > @minYearsAtWork
 ORDER BY HireDate
GO
EXEC usp_SelectEmployeesBySeniority 10
```
#### Passing Parameter Values
Параметрите може да се подават по два начина - позиционно и по име на параметър, като вторият начин е за предпочитане, защото е по-пригледно.

По име на параметър:

```sql
EXEC usp_AddCustomer
 @customerID = 'ALFKI',
 @companyName = 'Alfreds Futterkiste',
 @address = 'Obere Str. 57',
 @city = 'Berlin',
 @phone = '030-0074321' 
```

Позиционно:

```sql
EXEC usp_AddCustomer 'ALFKI2', 'Alfreds
Futterkiste', 'Obere Str. 57', 'Berlin',
'030-0074321'
```
#### Returning Values Using OUTPUT Parameters
Параметрите могат да бъдат input и output. По default са input, но това може да се промени. При извикването, също трябва да се добавя `OUTPUT`.

**Syntax:**

```sql
CREATE PROCEDURE dbo.usp_AddNumbers
 @firstNumber SMALLINT,
 @secondNumber SMALLINT,
 @result INT OUTPUT
AS
 SET @result = @firstNumber + @secondNumber
GO

DECLARE @answer smallint
EXECUTE usp_AddNumbers 5, 6, @answer OUTPUT
SELECT 'The result is: ', @answer
-- The result is: 11
```
#### Returning Multiple Results
една процедура може да върне повече от един набор от резултати (result sets) чрез изпълнение на множество `SELECT` изрази в рамките на една процедура. Това позволява извличането на различни данни, които могат да бъдат обработени отделно от клиента или приложението, което изпълнява процедурата.

**Syntax:**

```sql
CREATE OR ALTER PROC usp_MultipleResults
AS
SELECT FirstName, LastName FROM Employees
SELECT FirstName, LastName, d.[Name] AS Department
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;
GO

EXEC usp_MultipleResults
```

`GO` се слага, когато имаме зависимост от изпълнението на statment-ите и когато искаме да сме сигурни, че първия минава преди втория, трябва да сложим между тях `GO`.
## Error Handling
Error handling-ът е от ключово значение както за **сигурността**, така и за **потребителското изживяване (UX)**:

1. **Сигурност**:  
    Ако приложението хвърля необработени грешки, които достигат до потребители, те могат да съдържат чувствителна информация като структура на базата данни, имена на таблици или вътрешна логика. Това би могло да даде възможност на злонамерени лица да идентифицират слабости в приложението и да го атакуват.
    
2. **Потребителско изживяване (UX)**:  
    Добре обработените грешки гарантират, че потребителите получават ясни, но опростени съобщения, които обясняват проблема без излишни технически детайли. Това подобрява доверието към приложението и помага на потребителите да разберат как да реагират (напр. да опитат отново или да се свържат с поддръжка).
    

Пример за добро управление на грешки е предоставянето на обобщено съобщение за потребителя, докато детайлите на грешката се записват в логове, достъпни само за администратора.

Error Handling-a се ползва, когато има програмна логика в базата, иначе се ползват инструментите които имаме в backend езика, който ползваме.
### THROW
Хвърля грешка и трансферира изпълнението на `CATCH` блок.
Аргументите: 
- `error_number` - INT (между 50000 и 2147483647). Microsoft са запазили за себе си кодовете от 1 до 50000.
- `message` - NVARCHAR(2048)
- `state` - TINYINT (между 0 и 255)

**Syntax:**

```sql
IF(@candidateAge < @minimalCandidateAge)
BEGIN
 THROW 50001, 'The candidate is too young!', 1;
END
```
### TRY...CATCH
Може да слагаме SQL изрази в `TRY` блок. Ако се появи грешка в `TRY` блока, контрола се подава на друга група от изрази намиращи се в `CATCH` блок.

**Syntax:**

```sql
BEGIN TRY
 { sql_statement | statement_block }
END TRY
BEGIN CATCH
 [ { sql_statement | statement_block } ]
END CATCH
[ ; ] 
```

**Example:**

```sql
BEGIN TRY
 -- Generate a divide-by-zero error.
 SELECT 1/0
END TRY
BEGIN CATCH
 SELECT
 ERROR_NUMBER() AS ErrorNumber
 ,ERROR_SEVERITY() AS ErrorSeverity
 ,ERROR_STATE() AS ErrorState
 ,ERROR_PROCEDURE() AS ErrorProcedure
 ,ERROR_LINE() AS ErrorLine
 ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO
```

Информацията от примера идва от стандартни системни функции, които са предназначени за обработка и диагностициране на грешки.
### `@@ERROR`
`@@ERROR` е глобална променлива в SQL Server, която се използва за **проверка на грешки** след изпълнението на SQL заявки. Тя връща стойността на последната възникнала грешка, ако има такава.

**Основни характеристики на `@@ERROR`:**

1. **Връща 0, ако няма грешка**: Ако последният изпълнен SQL израз е завършил успешно, стойността на `@@ERROR` ще бъде 0.
2. **Връща номера на грешката**: Ако е възникнала грешка при изпълнението на SQL заявка, `@@ERROR` ще съдържа номера на тази грешка.
3. **Зачиства се и reset-ва след всяка заявка**: След всяка изпълнена SQL заявка, стойността на `@@ERROR` се reset-ва и трябва да бъде проверена веднага след изпълнението на заявката, ако искаме да уловим грешката.

**Важни бележки:**

- `@@ERROR` е **глобална променлива** и е достъпна по всяко време, но нейното значение е свързано със състоянието на последния изпълнен SQL израз.
- За по-добра обработка на грешки и транзакции е препоръчително да използвате **TRY/CATCH блокове** в SQL Server вместо само `@@ERROR`, тъй като те предоставят по-добро и по-структурирано управление на грешки.
# Misc
# ChatGPT
## Procedures vs Functions
The distinction between **procedures** and **functions** in SQL lies in their purpose and how they are used, offering flexibility based on the intended operation. Here's a breakdown of the **essence** of their differences:

**1. Purpose and Use Case**

- **Procedures**:
    
    - Designed to perform **actions** (e.g., updating tables, inserting rows, managing transactions).
    - Can contain complex logic with multiple steps.
    - Typically used for tasks where returning a value is not the primary goal but executing operations is.
- **Functions**:
    
    - Designed to **calculate and return a value** or a table (e.g., computations, formatting, derived data).
    - Must return a value or table as their result.
    - Commonly used in SELECT statements, `WHERE` clauses, or `JOIN` conditions.

**2. Return Value**

- **Procedures**:
    
    - Can return multiple result sets (using `SELECT` statements) or output parameters.
    - Can return **nothing** if no results or output parameters are defined.
- **Functions**:
    
    - Always return **a single value** (scalar functions) or a **table** (table-valued functions).

**3. Input Parameters**

- **Procedures**:
    
    - Accept input, output, and input-output parameters.
    - More flexible in how they interact with calling code.
- **Functions**:
    
    - Accept only input parameters (no output parameters).

**4. Usage in SQL Queries**

- **Procedures**:
    
    - Cannot be directly used in SQL queries.
    - Executed using the `EXEC` or `CALL` keyword.
- **Functions**:
    
    - Can be used **inline** within SQL queries (e.g., in `SELECT`, `WHERE`, `GROUP BY`).
    - Treat them like built-in SQL functions such as `LEN()` or `SUM()`.

**5. Side Effects**

- **Procedures**:
    
    - Can perform **side effects** like modifying database state (e.g., inserting, updating, or deleting rows).
    - Suitable for transactional workflows.
- **Functions**:
    
    - Are **side-effect-free** (pure functions); they cannot modify database state.
    - This makes them safer for use in queries.

**Analogy**

Think of procedures as **task doers**—like a chef preparing an entire meal in stages, while functions are like **tools**—a specific knife or blender that performs one precise action (e.g., slicing or mixing).
## `GO`
**`GO`** is used in SQL Server to separate batches of SQL statements. It is not part of the SQL standard but is a command specific to SQL Server, indicating that the preceding batch of SQL statements should be executed as a separate unit.

**Main purposes of `GO`:**

1. **Batch separation**: When you need to execute different blocks of SQL code as separate batches.
2. **Re-execution of commands**: If you want to ensure that each statement or group of statements is executed separately.
3. **Context changes**: For example, if you're creating or altering objects like tables and want to make sure the commands are executed individually.

**Example:**

```sql
SELECT 'Hello World';  -- First batch
GO
SELECT 'Goodbye World';  -- Second batch
GO
```

In this example, the two queries will be executed separately because of the **`GO`** command.
# Bookmarks
Completion: 23.01.2025