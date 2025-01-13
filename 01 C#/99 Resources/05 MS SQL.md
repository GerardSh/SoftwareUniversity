# Database Structure and Modifications
`CREATE DATABASE DatabaseName` - за създаване на база данни.

---
Създава таблицa. С `PRIMARY KEY` се прави дадена колона да е primary key-a, `NOT NULL` означава че искаме полето да е задължително. `IDENTITY` автоматично генерира стойности за тази колона, които започват от 1 и се увеличават с 1 (по подразбиране). Може да сложим и други стойности с `IDENTITY(Seed, Increment)`:

```sql
CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
Email VARCHAR(50) NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
[Date] DATE
)
```

---
`SELECT * FROM MyTable` - взимане на всички записи в посочената таблица. Ако искаме определени колони, трябва да ги изредим.

---
Взима първите 10 рекорда подредени по подразбиране (ако няма `ORDER BY`), като ги показва с изброените колони, от тях филтрираме чрез `WHERE` само записите, в които стойността на колоната `FirstName` е `'Gerard'`. Чрез `AS` може да сменим името на колоната и ако новото име съдържа интервали, трябва да е в квадратни скоби или двойни кавички:

```sql
SELECT TOP(10) 
	LastName, 
	FirstName,
	Id AS [Employee Identifier]
FROM Employees 
WHERE FirstName = 'Gerard'
ORDER BY LastName ASC;
```
---
`ALTER TABLE` позволява промени в структурата на съществуваща таблица:

- **Добавяне на колона**

```sql
ALTER TABLE TableName
ADD ColumnName DataType;
```

- **Модифициране на колона**

```sql
ALTER TABLE TableName
ALTER COLUMN ColumnName NewDataType;
```

- **Изтриване на колона**

```sql
ALTER TABLE TableName
DROP COLUMN ColumnName;
```

- **Добавяне на ограничение**

```sql
ALTER TABLE TableName
ADD CONSTRAINT ConstraintName ConstraintType (ColumnName);
```

- **Изтриване на ограничение**

```sql
ALTER TABLE TableName
DROP CONSTRAINT ConstraintName;
```

- **Add a Foreign Key Constraint**

```sql
ALTER TABLE TableName
ADD FOREIGN KEY (ColumnName) REFERENCES ReferencedTableName(ReferencedColumnName);
```

- **Add a Named Foreign Key Constraint**

```sql
ALTER TABLE TableName
ADD CONSTRAINT FK_ConstraintName
FOREIGN KEY (ColumnName) REFERENCES ReferencedTableName(ReferencedColumnName);
```
---
Добавя нови редове в таблица в база данни. Може да се пропусне изреждането на колоните, ако ще се подадат стойности на всички колони в реда им в таблицата:

```sql
INSERT INTO Towns ([Id], [Name]) 
VALUES 
    (1, 'Sofia'),
    (2, 'Plovdiv'),
    (3, 'Varna');
```
---
`TRUNCATE TABLE MyTable` - изтрива записите, но не изтрива самата таблица.

---
`DROP TABLE MyTable` - изтрива таблицата.

---
**Constraints**

| **Feature**   | **Description**                                                | **Example**                                           |
| ------------- | -------------------------------------------------------------- | ----------------------------------------------------- |
| `NOT NULL`    | Ensures the column cannot have empty (NULL) values.            | `Name NVARCHAR(50) NOT NULL`                          |
| `UNIQUE`      | Ensures all values in the column are distinct (no duplicates). | `Email NVARCHAR(100) UNIQUE`                          |
| `PRIMARY KEY` | Combines `NOT NULL` and `UNIQUE` for a unique identifier.      | `EmployeeId INT PRIMARY KEY`                          |
| `FOREIGN KEY` | Links one table to another by enforcing a relationship.        | `FOREIGN KEY (DeptId) REFERENCES Departments(DeptId)` |
| `CHECK`       | Ensures the column's value satisfies a condition.              | `Age INT CHECK (Age >= 18)`                           |
| `DEFAULT`     | Provides a default value when no value is provided.            | `Status NVARCHAR(20) DEFAULT 'Active'`                |
| `INDEX`       | Creates an index to improve query performance.                 | `CREATE INDEX idx_name ON Employees (Name)`           |

**Properties**

|**Feature**|**Description**|**Example**|
|---|---|---|
|`IDENTITY`|Automatically generates sequential values for a column.|`EmployeeId INT IDENTITY(1,1)`|
|`DEFAULT`|Assigns a predefined value if none is provided.|`CreatedDate DATE DEFAULT GETDATE()`|
|`AUTO_INCREMENT`|Automatically increments numeric values (MySQL equivalent of `IDENTITY`).|`UserId INT AUTO_INCREMENT`|
|`COLLATION`|Defines the sorting and comparison rules for string data.|`Name NVARCHAR(50) COLLATE Latin1_General_CI_AS`|
|`CHARACTER SET`|Specifies the encoding of text data.|`Description TEXT CHARACTER SET utf8mb4`|
|`SPARSE`|Optimizes storage for NULL values (SQL Server-specific).|`PhoneNumber NVARCHAR(15) SPARSE`|
|`PERSISTED`|Stores computed column values physically in the table.|`FullName AS (FirstName + ' ' + LastName) PERSISTED`|
# Functions
## String
`CONCAT` - заменя `NULL` стойности с празен стринг `''` така че да не повлияе на крайния резултат.

Пример:

```sql
SELECT CONCAT('Hello', ' ', NULL, 'World') AS Result;
-- Result: Hello World
```

---
`CONCAT_WS` - обединява стринговете със зададен сепаратор Ако има `NULL` стойност, не я включва, докато ако ползваме само `CONCAT` ще добави празен стринг.

Пример:

```sql
SELECT CONCAT_WS(' ', 'Hello', NULL, 'World') AS Result;
-- Result: Hello World
```

При някои ситуации, използвайки `CONCAT` ще получим повече празни пространства, примерно:

```sql
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name] FROM Employee
```

Проблема в примера е, че ако `MiddleName` е `NULL`, тогава ще бъде заменен с празен стринг, но сепараторите `' '` ще останат и ще получим две празни пространства вместо едно, между `FirstName` и `LastName`.

---
`SUBSTRING(String, StartIndex, Length)` - извлича част от стринг, като започва от началния индекс спрямо зададената дължина, като индексирането започва от 1 а не от 0.

Подхода в долния пример е полезен за показване на кратка част от текста в списъци или прегледи на статии, без да се показва цялото съдържание:

```sql
SELECT ArticleId, Author, Content,
SUBSTRING(Content, 1, 200) + '...' AS Summary
FROM Articles
```

---
`REPLACE(String, Pattern, Replacement)` - заменя даден стринг с друг.

В примера цензурираме думата 'blood':

```sql
SELECT REPLACE(Title, 'blood', '*****’) AS Title FROM Album
```

---
`LTRIM(string, trim_characters)` / `RTRIM(string, trim_characters)` - тези функции премахват водещи и завършващи символи от даден стринг. По подразбиране премахват празни пространства, но могат да се зададат конкретни символи за премахване. Аргумента `trim_characters` не е задължителен.

В примера се премахват всички `+` и `-` символи в края на стринга. Ако между тези символи имаше друг знак, премахването щеше да спре при първия срещнат символ, който не е част от зададения списък.

```sql
SELECT RTRIM('test-++--+--+', '+-');
```

---
`TRIM([LEADING | TRAILING | BOTH] trim_characters FROM string)` - премахва водещи и/или завършващи символи от даден низ. Ако използваме `TRIM` без аргументи, ще премахне **само водещите и завършващите празни пространства** от стринга. Няма да премахне други символи.

- **`LEADING`**: Премахва само водещи символи.
- **`TRAILING`**: Премахва само завършващи символи.
- **`BOTH`** (по подразбиране): Премахва символите и от двете страни.
- **`trim_characters`**: Символите, които да бъдат премахнати (по подразбиране е празно пространство).

Пример:

```sql
SELECT TRIM(BOTH '+-' FROM '-+-test-+-');
```

---
`LEN(String)` - връща броя на символите в даден стринг.

---
`DATALENGTH(String)` - връща броя на байтовете, които даден стринг заема в паметта.

В примера конвертираме стринга в тип `NVARCHAR`, където всеки символ използва 2 байта (в зависимост от кодировката). Този метод е полезен за проверка на реалната големина на данните в паметта, особено когато се работи с различни типове данни като `VARCHAR` и `NVARCHAR`.

```sql
SELECT DATALENGTH(CAST('Test' AS NVARCHAR)) AS Result;
-- Result: 8
```

---
`LEFT(String, Count)` /  `RIGHT(String, Count)` - взима посочените брой символи от началото или края на даден стринг.

---
`LOWER(String)` /  `UPPER(String)` - прави целия стринг lower или upper case.

---
`REVERSE(String)` - обръща стринга на обратно.

Пример:

```sql
SELECT REVERSE('12 34') AS Result
-- Result: 43 21
```

---
`REPLICATE(String, Count)` - повтаря стринг count на брой пъти.

Пример:

```sql
SELECT REPLICATE('12', 3) AS Result
-- Result: 121212
```

---
`FORMAT(SomeDate, 'yyyy-MMMM-dd', 'bg-BG')` - форматира дата в указан формат с регионални настройки.

Пример:

```sql
SELECT FORMAT(GETDATE(), 'yyyy-MMMM-dd', 'bg-BG') AS FormattedDate
-- FormattedDate: 2025-януари-11
```

---
`CHARINDEX(Pattern, String, [StartIndex])` - намира индекса от който започва първия намерен pattern в даден стринг. Може да посочим начален индекс от който да започне търсенето чрез`StartIndex`, по default е 1.

Пример:

```sql
SELECT CHARINDEX('test', '--test', 1) AS Result
-- Result: 3
```

---
`STUFF(String, StartIndex, Length, Substring)` - вмъква даден `Substring` в `String` на посочения `StartIndex`, като изтрива `Length` на брой символа от `String`. Ако `StartIndex` е извън границите на `String`, функцията връща `NULL`.

Пример:

```sql
SELECT STUFF('1234', 4, 1,'5678') AS Result
-- Result: 1235678
```
## Math
`PI()` - връща числото π.

---
`ABS(Value)` - връща абсолютната стойност на дадено число.

---
`SQRT(Value)` - връща корен квадратен на дадено число.

---
`SQUARE(Value)` - връща квадрата на дадено число.

---
`POWER(Value, Exponent)` - връща стойността на дадено число, вдигнато на посочена степен (експонента).

---
`Round(Value, Precision)` - връща стойността закръглена до подадения `Precision`. Ако се подаде негативна стойност на `Precision`, закръгля стойността преди десетичната запетая.

Пример:

```SQL
SELECT ROUND(123.4567, 2) AS Result
-- Result: 123.4600

SELECT ROUND(123.4567, -2) AS Result
-- Result: 100.0000
```

---
`FLOOR(Value)` / `CEILING(Value)` - закръгляват до най-близкото цяло число, съответно надолу и нагоре.

---
`SIGN(Value)` - връща 1, -1 или 0, в зависимост от това дали стойността на подаденото число е положителна, отрицателна или нула.

---
`RAND(Seed)` - връща произволно реално число в интервала 0-1. Ако се подаде стойност за `Seed`, функцията ще генерира същото число за същия seed при всяко изпълнение. Ако искаме да получим число в интервала между 0 и 10 (без горната граница да е включена), можем да умножим резултата от `RAND()` по 10.

Пример:

```sql
SELECT 
    RAND() AS RandomNumber,        -- Генерира произволно число.
    RAND(10) AS SeededNumber1,    -- Генерира число, базирано на seed 10.
    RAND(10) AS SeededNumber2;    -- Същият seed генерира същото число.
    RAND() * 10 AS RandomNumberBetween0And10;
-- RandomNumber: (различно при всяко изпълнение)
-- SeededNumber1: 0.713757
-- SeededNumber2: 0.713757
-- RandomNumberBetween0And10: число в интервала [0, 10) 
```

---
## Date
`DATEPART(DatePart, Date)` -  връща конкретна част от дата (напр. година, месец, ден, час) като цяло число, позволявайки лесно извличане на компоненти за анализ или изчисления. Резултатът е цяло число. `DatePart` може да бъде една от следните стойности: `year`, `quarter`, `month`, `day`, `hour`, `minute`, `second` и други.

```sql
SELECT 
    DATEPART(quarter, '2025-01-11') AS Quarter,
    DATEPART(year, '2025-01-11') AS Year,
    DATEPART(month, '2025-01-11') AS Month,
    DATEPART(day, '2025-01-11') AS Day;
-- Year: 2025, Month: 1, Day: 11
```

[DATEPART (Transact-SQL) - SQL Server | Microsoft Learn](https://learn.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql?view=sql-server-ver16)

---
`YEAR(Date)` / `MONTH(Date)` / `DAY(Date)` - връщат съответно годината, месеца или деня от дадена дата като цяло число, осигурявайки бърз достъп до отделни компоненти на датата.

Пример:

```sql
SELECT 
    YEAR('2025-01-11') AS Year,
    MONTH('2025-01-11') AS Month,
    DAY('2025-01-11') AS Day;
-- Year: 2025, Month: 1, Day: 11
```

---
`DATEDIFF(DatePart, StartDate, EndDate)` - връща разликата между две дати, измерена в посочената част от датата (например дни, месеци, години). Разликата се изчислява като `EndDate - StartDate` за указаната част.

Пример:

```sql
SELECT 
    DATEDIFF(day, '2025-01-01', '2025-01-11') AS DaysDifference,
    DATEDIFF(month, '2024-12-01', '2025-01-01') AS MonthsDifference,
    DATEDIFF(year, '2020-01-01', '2025-01-01') AS YearsDifference;
-- DaysDifference: 10, MonthsDifference: 1, YearsDifference: 5
```

---
`DATENAME(DatePart, Date)` - връща името на указаната част от дадена дата като текстов стринг (напр. "January" за месец или "Monday" за ден от седмицата). Резултатът зависи от езиковите настройки на SQL Server (например, за `bg-BG` месеците и дните ще бъдат на български).

Пример:

```sql
SELECT 
    DATENAME(year, '2025-01-11') AS YearName,
    DATENAME(month, '2025-01-11') AS MonthName,
    DATENAME(weekday, '2025-01-11') AS WeekdayName;
-- YearName: 2025, MonthName: January, WeekdayName: Saturday
```

---
`DATEADD(DatePart, Number, Date)` - добавя или изважда даден брой единици към/от конкретна част на дата (например дни, месеци, години), връщайки новата дата.

Пример:
Добавяне на 10 дни към дата:

```sql
SELECT DATEADD(day, 10, '2025-01-11') AS NewDate;
-- NewDate: 2025-01-21
```

---
`GETDATE()` - връща текущата дата и час на сървъра в системата, като се използва формат `yyyy-mm-dd hh:mm:ss.fff`.

Пример:

```sql
SELECT GETDATE() AS CurrentDateTime;
-- CurrentDateTime: 2025-01-11 14:35:29.123
```

---
`EOMONTH(StartDate, MonthToAdd)` - връща последния ден на месеца за дадена дата, като може да добавите или извадите месеци. Вторият параметър `MonthToAdd` е опционален и задава колко месеца да се добавят или изваждат от `StartDate`.

Пример:

```sql
SELECT EOMONTH('2025-01-11') AS EndOfMonth;
-- EndOfMonth: 2025-01-31

SELECT EOMONTH('2025-01-11', 1) AS EndOfNextMonth;
-- EndOfNextMonth: 2025-02-28
```

---
## Other Functions
`CAST(Expression AS DataType)` / `CONVERT(DataType, Expression)` - използват се за преобразуване на данни от един тип в друг. Те позволяват преобразуване на стойности от например текстови формати в числа, дати или други типове данни. `CONVERT` позволява допълнителни опции като форматиране на дати, може да прилага допълнителни формати към дати и други типове данни (например, форматиране на дата в специфичен стил), докато `CAST` няма такава възможност. И двете са бавни операции, затова трябва да се внимава при таблици с много записи.

Пример:

```sql
SELECT CAST('2025-01-11' AS DATE) AS CastDate;
-- CastDate: 2025-01-11

SELECT CONVERT(DATE, '2025-01-11') AS ConvertDate;
-- ConvertDate: 2025-01-11
```

---
`ISNULL(Expression, ReplacementValue)` - проверява дали даден израз или стойност е `NULL` и ако е така, го заменяме с `ReplacementValue`. Това е полезно, когато искаме да заменим `NULL` стойности с подходяща стойност, за да избегнем потенциални проблеми с обработката на данни или изчисления. Tрябва да са от един и същи тип или поне `ReplacementValue` трябва да може да бъде неявно преобразуван към типа на `Expression`. 

Пример:

```sql
SELECT ISNULL(NULL, 'Replacement Value') AS Result;
-- Result: Replacement Value

SELECT ISNULL('Hello', 'Replacement Value') AS Result;
-- Result: Hello
```

---
`COALESCE(Expression1, Expression2, ..., ExpressionN)` - връща първата стойност от списъка, която не е `NULL`. Ако всички изрази са `NULL`, функцията връща `NULL`. Тази функция е удобна, когато искаме да проверим множество алтернативи и да върнем първата налична стойност. Стойностите трябва да са от един и същи тип или трябва да могат да бъдат неявно преобразувани към един общ тип.

Пример:

```sql
SELECT COALESCE(Address, AlternativeAddress, 'No Address') AS FinalAddress
FROM Customers;
-- Резултатът ще бъде първата ненулева стойност между Address, AlternativeAddress и 'No Address'.
```

---
`OFFSET(NumberOfRows) FETCH NEXT NumberOfRows ROWS ONLY` - се използват за странициране на резултатите от заявката.

- `OFFSET` пропуска посочен брой редове.
- `FETCH` извлича следващите определен брой редове след пропуснатите.

Тези оператори изискват наличието на `ORDER BY`, тъй като редът на данните е от съществено значение за правилното странициране.

Пример:

```sql
SELECT CustomerName, City
FROM Customers
ORDER BY CustomerName
OFFSET 5 ROWS FETCH NEXT 10 ROWS ONLY;
-- Пропуска първите 5 реда и връща следващите 10.
```

---
## Ranking
`RANK()` - присвоява ранг на всеки ред в резултата, базиран на реда, определен от `ORDER BY`. Ако има дублирани стойности, те получават един и същ ранг, но следващият ранг прескача номерата, за да отрази броя на дубликатите.

**Синтаксис:**

```sql
RANK() OVER (PARTITION BY ColumnName ORDER BY ColumnName) AS Rank
```

- **`OVER`**: Задава обхвата за класирането.
- **`PARTITION BY`**: Определя групите за класиране (по избор).
- **`ORDER BY`**: Задава реда, по който се определя рангът.

```sql
SELECT 
    EmployeeName, 
    Salary, 
    RANK() OVER (ORDER BY Salary DESC) AS Rank
FROM Employees;
-- Сортира служителите по заплата в низходящ ред и присвоява рангове.
```

| EmployeeName | Salary | Rank |
| ------------ | ------ | ---- |
| John         | 5000   | 1    |
| Jane         | 4500   | 2    |
| Alice        | 4500   | 2    |
| Bob          | 4000   | 4    |

**Пример 2: Рангове в рамките на групи**

```sql
SELECT 
    Department, 
    EmployeeName, 
    Salary, 
    RANK() OVER (PARTITION BY Department ORDER BY Salary DESC) AS Rank
FROM Employees;
-- Присвоява рангове в рамките на всяко отделение.
```

|Department|EmployeeName|Salary|Rank|
|---|---|---|---|
|IT|John|5000|1|
|IT|Alice|4500|2|
|IT|Bob|4500|2|
|HR|Jane|4500|1|
|HR|Bob|4000|2|
|HR|Alice|4500|1|
- **Отдел IT**:
    - **John** има най-високата заплата (5000), така че получава ранг 1.
    - **Alice** и **Bob** имат еднаква заплата (4500), затова получават ранг 2. Тъй като `RANK()` дава същия ранг за служителите с еднакви заплати, следващият ранг, който би трябвало да бъде 3, се пропуска.
- **Отдел HR**:
    - **Jane** има най-високата заплата (4500), така че получава ранг 1.
    - **Bob** има заплата 4000, така че получава ранг 2.
    - **Alice** има също заплата 4500, което я прави равна на **Jane**, така че тя също получава ранг 1.

---
`DENSE_RANK()` - работи по подобен начин на `RANK()`, но с една основна разлика: когато има еднакви стойности в групата, няма пропуск в ранговете. Докато при `RANK()` пропускат числови стойности за ранговете след еднакви стойности, при `DENSE_RANK()` ранговете се присвояват без да се изпускат.

Пример:

|Department|EmployeeName|Salary|Rank|
|---|---|---|---|
|IT|John|5000|1|
|IT|Alice|4500|2|
|IT|Bob|4500|2|
|HR|Jane|4500|1|
|HR|Bob|4000|2|
|HR|Alice|4500|1|

**Обяснение:**

1. **Отдел IT**:
    - **John** има най-високата заплата (5000), така че получава ранг 1.
    - **Alice** и **Bob** имат същата заплата (4500), така че получават ранг 2. Тъй като използваме `DENSE_RANK()`, не пропускаме ранг 3, както би се случило при `RANK()`.
2. **Отдел HR**:
    - **Jane** има най-високата заплата (4500), така че получава ранг 1.
    - **Bob** има заплата 4000, така че получава ранг 2.
    - **Alice** има също заплата 4500 и също получава ранг 1, без пропуск в ранговете.

При `DENSE_RANK()` няма пропуски между стойностите на ранг. Това означава, че след група с еднакви стойности не се прескачат номера на ранга, както е при `RANK()`.

---
`ROW_NUMBER()` - присвоява уникален номер на всеки ред в резултата от заявката, базиран на реда, определен от `ORDER BY`. Тази функция е особено полезна, когато е необходимо да се номерират редовете или да се извлекат подмножества от данни. Често се използва в комбинация с `CTE` (Common Table Expressions) за извличане на определени редове, например за премахване на дубликати.

**Синтаксис:**

```sql
ROW_NUMBER() OVER (PARTITION BY ColumnName ORDER BY ColumnName) AS RowNum
```

- **`OVER`**: Задава обхвата на номериране.
- **`PARTITION BY`**: Определя групите за номериране (по избор).
- **`ORDER BY`**: Задава реда, в който се присвояват номерата.

**Пример 1: Номериране на всички редове**

```sql
SELECT 
    CustomerName, 
    City, 
    ROW_NUMBER() OVER (ORDER BY CustomerName) AS RowNum
FROM Customers;
-- Присвоява уникален номер на всеки ред, сортиран по CustomerName.
```

**Пример 2: Номериране в рамките на групи**

```sql
SELECT 
    CustomerName, 
    City, 
    ROW_NUMBER() OVER (PARTITION BY City ORDER BY CustomerName) AS RowNum
FROM Customers;
-- Номерира редовете за всеки град (City), сортирани по име на клиента (CustomerName).
```

---
`NTILE()` - разпределя редовете на групи (или "порции") от определен брой и връща номер на групата за всеки ред. Тази функция се използва за разделяне на данните на равни части, като например за създаване на квартали или други равномерни разделения.

**Синтаксис:**

```sql
`NTILE(NumberOfBuckets) OVER (PARTITION BY Column ORDER BY Column)`
```

- **NumberOfBuckets**: Броят на групите или порциите, на които искаме да разделим данните.
- **PARTITION BY**: (по желание) Разделя редовете в отделни групи, ако е необходимо.
- **ORDER BY**: Определя как да се подредят редовете преди да бъдат разделени.

**Пример:**

Да кажем, че имаме таблица със служители, като искаме да разпределим заплатите на 4 групи.

|EmployeeName|Salary|
|---|---|
|John|5000|
|Alice|4500|
|Bob|4000|
|Carol|3500|
|David|3000|

```sql
SELECT 
    EmployeeName, 
    Salary, 
    NTILE(4) OVER (ORDER BY Salary) AS SalaryGroup
FROM Employees;
```

Резултат:

|EmployeeName|Salary|SalaryGroup|
|---|---|---|
|David|3000|1|
|Carol|3500|2|
|Bob|4000|3|
|Alice|4500|4|
|John|5000|4|

Обяснение:

1. Данните са сортирани по заплата в нарастващ ред.
2. Данните са разделени на 4 равни групи:
    - **Група 1**: Давид (3000)
    - **Група 2**: Карол (3500)
    - **Група 3**: Боб (4000)
    - **Група 4**: Алиса и Джон (4500 и 5000)

Важни моменти:

- Ако броят на редовете не е точно кратен на броя на групите, редовете ще бъдат разпределени колкото се може по-равномерно, като по възможност първите групи ще съдържат по един допълнителен ред.
- Тази функция е полезна, когато искаме да разпределим данните в определен брой категории (като например квантилите в статистиката).
# Wildcards
**Пример за комбинация с `NOT` и `AND`:**

```sql
SELECT 
    FirstName, 
    LastName 
FROM Employees
WHERE FirstName LIKE 'A%' 
  AND LastName NOT LIKE '%son';
```

**Поддържани символи:**

`%` - всяка последователност от символи, включително нулева дължина.
`_` - всеки един символ.
`[...]` - всеки символ в посочен диапазон.
`[^...]` - всеки символ, който не е в посочения диапазон.

**ESCAPE** - позволява да използваме специални символи, като дефинираме префикс за тях. Пример:

```sql
SELECT ID, Name
FROM Tracks
WHERE Name LIKE '%max!%' ESCAPE '!'
```

В този случай, символът `!` се използва като escape символ, за да търсим буквално `%` или `_` в имената.