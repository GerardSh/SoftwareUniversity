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

```sql
SELECT CONCAT('Hello', ' ', NULL, 'World') AS Result;
-- Result: Hello World
```

---
`CONCAT_WS` - обединява стринговете със зададен сепаратор.. Ако има `NULL` стойност, не я включва, докато ако ползваме само `CONCAT` ще добави празен стринг.

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
`LTRIM(string, trim_characters)` & `RTRIM(string, trim_characters)` - тези функции премахват водещи и завършващи символи от даден стринг. По подразбиране премахват празни пространства, но могат да се зададат конкретни символи за премахване. Аргумента `trim_characters` не е задължителен.

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
`LEFT(String, Count) RIGHT(String, Count)` - взима посочените брой символи от началото или края на даден стринг.

---
`LOWER(String) UPPER(String)` - прави целия стринг lower или upper case.

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
`FLOOR(Value)` & `CEILING(Value)` - закръгляват до най-близкото цяло число, съответно надолу и нагоре.

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
    RAND() * 10 AS RandomNumberBetween0And10; -- Резултат: 
-- Резултат:
-- RandomNumber: (различно при всяко изпълнение)
-- SeededNumber1: 0.713757
-- SeededNumber2: 0.713757
-- RandomNumberBetween0And10: число в интервала [0, 10) 
```

---